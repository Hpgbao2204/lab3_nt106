using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace Bai5
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient database;

        public FirebaseHelper()
        {
            database = new FirebaseClient("https://lab3-bai5-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            // Kiểm tra xem username đã tồn tại chưa
            var existingUser = await database.Child("Users").Child(username).OnceSingleAsync<object>();
            if (existingUser != null)
            {
                return false; // Username đã tồn tại
            }

            // Nếu chưa tồn tại, thêm người dùng mới vào Database
            await database.Child("Users").Child(username).PutAsync(new { Password = password });
            return true;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = await database.Child("Users").Child(username).OnceSingleAsync<dynamic>();

            if (user != null && user.Password == password)
            {
                return true; // Đăng nhập thành công
            }

            return false; // Đăng nhập thất bại
        }

        public FirebaseClient GetDatabaseClient() => database;
    }
}
