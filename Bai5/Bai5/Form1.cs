using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Form1 : Form
    {

        private FirebaseHelper firebaseHelper = new FirebaseHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e) //
        {
            // Lấy thông tin từ các TextBox
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Gọi phương thức LoginUser từ FirebaseHelper để đăng nhập
            bool isLoggedIn = await firebaseHelper.LoginUser(username, password);

            if (isLoggedIn)
            {
                MessageBox.Show("Đăng nhập thành công!");
                // Chuyển sang form chat room sau khi đăng nhập thành công
                ChatRoomForm chatRoomForm = new ChatRoomForm(username);
                chatRoomForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Gọi phương thức RegisterUser từ FirebaseHelper để đăng ký
            bool isRegistered = await firebaseHelper.RegisterUser(username, password);

            if (isRegistered)
            {
                MessageBox.Show("Đăng ký thành công!");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.");
            }
        }
    }
}
