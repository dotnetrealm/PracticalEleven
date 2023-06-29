using PracticalEleven.Models;

namespace PracticalEleven.Services
{
    public static class UserService
    {
        public static List<User> Users;
        static UserService()
        {
            Users = new() {
                new User() { Id = 1, Name="Bhavin", DOB = new DateOnly(2002, 02, 09), Address = "Rajkot"},
                new User() { Id = 2, Name="Vipul", DOB = new DateOnly(1999, 07, 07), Address = "Ahmedabad"},
                new User() { Id = 3, Name="Jil", DOB = new DateOnly(2001, 04, 17), Address = "Anand"},
                new User() { Id = 4, Name="Abhi", DOB =new DateOnly(2002, 04, 15), Address = "Morbi"},
                new User() { Id = 5, Name="Jay", DOB = new DateOnly(2004, 01, 01), Address = "Rajkot"}
            };
        }

        public static List<User> GetAllUsers()
        {
            return Users;
        }

        public static User GetUserById(int id)
        {
            return Users.Single(e => e.Id == id);
        }

        public static void AddUser(User user)
        {
            var maxId = Users.Max(e => e.Id);
            user.Id = maxId + 1;
            Users.Add(user);
        }

        public static void RemoveUserById(int id)
        {
            User? user = Users.SingleOrDefault(x => x.Id == id);
            if (user != null) Users.Remove(user);
        }

        public static void UpdateUser(int id, User user)
        {
            Users.Where(e => e.Id == id).Select(s =>
            {
                s.Name = user.Name;
                s.DOB = user.DOB;
                s.Address = user.Address;
                return s;
            }).ToList();
        }

    }
}
