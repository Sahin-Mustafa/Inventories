using Inventories.Entities;
using Inventories.Models.Employee;
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
                DepartmanId =model.SelectedDepartman,
                Username = model.Username,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                StartDateJob = model.StartDateJob,
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
            User user = db.Users.Include("Departman").FirstOrDefault(x => x.Id == userId);
            return user;
        }
        public bool EditById(int id, EditModel model )
        {
            User user = GetUserById(id);
            if (user != null)
            {
                user.Username = model.Username;
                user.Password = model.Password;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.StartDateJob = model.StartDateJob;
                user.IsBreak=model.IsBreak;
                user.EmploymentDate= model.EmploymentDate;
                user.DepartmanId = model.SelectedDepartman;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        

        internal List<User>? GetAllUsers()
        {
            List<User>? users = db.Users.Include("Departman").Where(x => x.Id != 0).ToList();
            return users;
        }

        internal void RemoveById(int id)
        {
            User user =GetUserById(id);
            db.Users.Remove(user);
            db.SaveChanges();

        }
    }
}
