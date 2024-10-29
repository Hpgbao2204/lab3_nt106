using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;

namespace Bai5
{
    public partial class ChatRoomForm : Form
    {
        private string username;
        private FirebaseClient database;

        public ChatRoomForm(string user)
        {
            InitializeComponent();
            username = user;
            database = new FirebaseHelper().GetDatabaseClient();

            ListenForMessages();
        }

        private void txtMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            if (!string.IsNullOrEmpty(message))
            {
                await database.Child("ChatRoom").PostAsync(new { User = username, message = message });
                txtMessage.Clear();
            }
        }

        private void ListenForMessages()
        {
            // Lắng nghe các thay đổi từ phòng chat
            database.Child("ChatRoom")
                .AsObservable<Message>()
                .Subscribe(message =>
                {
                    if (message.Object != null)
                    {
                        DisplayMessage(message.Object.user, message.Object.message); 
                    }
                });
        }

        private void DisplayMessage(string user, string message)
        {
            if (txtMessages.InvokeRequired)
            {
                // Nếu có, sử dụng Invoke để gọi phương thức DisplayMessage trên UI thread
                txtMessages.Invoke(new Action(() => DisplayMessage(user, message)));
            }
            else
            {
                // Nếu không, thực hiện cập nhật giao diện
                txtMessages.AppendText($"{user}: {message}{Environment.NewLine}");
            }
        }

        public class Message
        {
            public string user { get; set; }
            public string message { get; set; }
        }

        public class Room
        {
            public string RoomName { get; set; }
            public Dictionary<string, bool> Users { get; set; } = new Dictionary<string, bool>();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            string roomCode = txtRoomCode.Text; // Lấy mã phòng từ textbox
            if (!string.IsNullOrEmpty(roomCode))
            {
                await JoinRoom(roomCode);
            }
        }

        private async Task JoinRoom(string roomCode)
        {
            // Xóa tất cả tin nhắn hiện tại
            txtMessages.Clear();

            // Lấy thông tin phòng chat từ Firebase
            var room = await database.Child("Rooms").Child(roomCode).OnceSingleAsync<Room>();

            if (room != null)
            {
                // Thêm người dùng vào phòng
                if (!room.Users.ContainsKey(username))
                {
                    room.Users[username] = true;
                    await database.Child("Rooms").Child(roomCode).Child("users").Child(username).PutAsync(true);
                    // Thông báo cho các người dùng khác trong phòng
                    await database.Child("Rooms").Child(roomCode).Child("messages").PostAsync(new Message
                    {
                        user = "System",
                        message = $"{username} has joined the room."
                    });
                }

                // Lắng nghe tin nhắn trong phòng chat
                ListenForMessages(roomCode);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var roomCode = Guid.NewGuid().ToString();
            await database.Child("Rooms").Child(roomCode).PutAsync(new { roomName = txtRoomName.Text });
            MessageBox.Show("Phòng đã được tạo với mã: " + roomCode);
        }

        private void ListenToMessages(string roomCode)
        {
            database.Child("Rooms").Child(roomCode).Child("messages").AsObservable<Message>()
                .Subscribe(d =>
                {
                    if (d.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                    {
                        var message = d.Object;
                        txtMessages.AppendText($"{message.user}: {message.message}{Environment.NewLine}");
                    }
                });
        }

        private void ListenForMessages(string roomCode)
        {
            // Lắng nghe các thay đổi từ phòng chat
            database.Child("Rooms").Child(roomCode).Child("messages")
                .AsObservable<Message>()
                .Subscribe(message =>
                {
                    if (message.Object != null)
                    {
                        DisplayMessage(message.Object.user, message.Object.message);
                    }
                });
        }
    }
}
