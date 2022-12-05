using AudioEditor.Core.Models;
using AudioEditor.Infrastructure.Data;

namespace AudioEditor.Application.Services
{
    public class UsersService
    {
        private readonly AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void AddUser(User user)
        {
            var _user = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public User UpdateUserById(int id, User user)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (_user != null)
            {
                _user.FirstName = user.FirstName;
                _user.LastName = user.LastName;
                _user.Email = user.Email;
                _user.ModifiedDate = DateTime.Now;

                _context.SaveChanges();
            }

            return _user;
        }

        public void DeleteUserById(int id)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
        }
    }
}
