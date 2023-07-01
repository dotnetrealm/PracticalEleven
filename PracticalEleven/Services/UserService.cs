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

        /// <summary>
        /// Get all user list
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            return _users;
        }

        /// <summary>
        /// Get specific user by id
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        public static User? GetUserById(int id)
        {
            return _users.SingleOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>status</returns>
        public static int AddUser(User user)
        {
            var maxId = _users.Max(e => e.Id);
            user.Id = maxId + 1;
            _users.Add(user);
            return user.Id;
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id">UserId</param>
        public static void RemoveUserById(int id)
        {
            User? user = _users.SingleOrDefault(x => x.Id == id);
            if (user != null) _users.Remove(user);
        }

        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="id">UserId</param>
        /// <param name="user">Updated user object</param>
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
