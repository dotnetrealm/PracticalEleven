using Microsoft.AspNetCore.Mvc;
using PracticalEleven.Models;

namespace PracticalEleven.Services
{
    public static class UserService
    {
        private static List<User> _users;
        static UserService()
        {
            _users = new() {
                new User() { Id = 1, Name="Bhavin", DOB = new DateOnly(2002, 02, 09), Address = "Rajkot"},
                new User() { Id = 2, Name="Vipul", DOB = new DateOnly(1999, 07, 07), Address = "Ahmedabad"},
                new User() { Id = 3, Name="Jil", DOB = new DateOnly(2001, 04, 17), Address = "Anand"},
                new User() { Id = 4, Name="Abhi", DOB =new DateOnly(2002, 04, 15), Address = "Morbi"},
                new User() { Id = 5, Name="Jay", DOB = new DateOnly(2004, 01, 01), Address = "Rajkot"}
            };
        }

        public static List<User> GetAllUsers()
        {
            return _users;
        }


        public static User? GetUserById(int id)
        {
            return _users.SingleOrDefault(e => e.Id == id);
        }

        public static void AddUser(User user)
        {
            var maxId = _users.Max(e => e.Id);
            user.Id = maxId + 1;
            _users.Add(user);
        }

        public static void RemoveUserById(int id)
        {
            User? user = _users.SingleOrDefault(x => x.Id == id);
            if (user != null) _users.Remove(user);
        }

        public static void UpdateUser(int id, User user)
        {
            _users.Where(e => e.Id == id).Select(s =>
            {
                s.Name = user.Name;
                s.DOB = user.DOB;
                s.Address = user.Address;
                return s;
            }).ToList();

        }

    }
}
