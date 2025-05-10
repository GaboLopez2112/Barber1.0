//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BarberApp.Models;
//using System.IO;

//namespace BarberApp.Services
//{
//    public class DatabaseService
//    {
//        private static SQLiteAsyncConnection _db;

//        private static async Task Init()
//        {
//            if (_db != null)
//                return;

//            var dbPath = Path.Combine(
//                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
//                "barberapp.db");

//            _db = new SQLiteAsyncConnection(dbPath);
//            await _db.CreateTableAsync<UserModel>();
//        }

//        public static async Task<bool> RegisterUser(string username, string password, string role)
//        {
//            await Init();

//            var existingUser = await _db.Table<UserModel>().Where(u => u.nombreUsuario == username).FirstOrDefaultAsync();
//            if (existingUser != null)
//                return false;

//            var user = new UserModel
//            {
//                nombreUsuario = username,
//                //Password = password,
//                rol = role
//            };

//            await _db.InsertAsync(user);
//            return true;
//        }

//        public static async Task<UserModel> LoginUser(string username, string password)
//        {
//            await Init();
//            return await _db.Table<UserModel>()
//                .Where(u => u.nombreUsuario == username && u.Password == password)
//                .FirstOrDefaultAsync();
//        }
//    }
//}
