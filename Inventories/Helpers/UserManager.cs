using Inventories.Entities;
using Inventories.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace Inventories.Helpers
{
    public class UserManager
    {
        private DatabaseContext db = new();

        public bool AddUser(RegisterModel model)
        {

            User user = new User()
            {
                DepartmanId =Int32.Parse(model.SelectedDepartman),
                Username = model.Username,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                IsBreak = model.IsBreak,
                StartDateJob = model.StartDateJob,
                EmploymentDate = model.EmploymentDate,
            };
            User? IsHave = db.Users.FirstOrDefault(x => x.Username == model.Username);
            if (IsHave == null)
            {
                db.Users.Add(user);
                int result = db.SaveChanges();
                return true;
            }
            return false;
        }

        public User Authenticate(string username, string password)
        {
            User user = db.Users.Include("Departman").FirstOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        public User GetUserById(int userId)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
        public bool UpdateProfile(int userId, string name, string surname)
        {
            User user = GetUserById(userId);
            if (user != null)
            {
                user.Name = name;
                user.Surname = surname;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        

        internal List<User>? GetAllUsers()
        {
            List<User>? users = db.Users.Include("Departman").Where(x => x.Id != 0).ToList();
            return users;
        }
    }
}
