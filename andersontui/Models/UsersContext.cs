using Planilhas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planilhas.Models
{
    public class UsersContext : OurDbContext
    {
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public void AddUser(UserAccount user)
        {
            Users.Add(user);
            SaveChanges();
        }

        public UserAccount GetUser(string userName)
        {
            var user = Users.SingleOrDefault(u => u.Nome == userName);
            return user;
        }

        public UserAccount GetUser(string userName, string password)
        {
            var user = Users.SingleOrDefault(u => u.Nome ==
                           userName && u.Senha == password);
            return user;
        }

        public void AddUserRole(UserRole userRole)
        {
            var roleEntry = UserRoles.SingleOrDefault(r => r.UserId == userRole.UserId);
            if (roleEntry != null)
            {
                UserRoles.Remove(roleEntry);
                SaveChanges();
            }
            UserRoles.Add(userRole);
            SaveChanges();
        }
    }
}