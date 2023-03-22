using GmJournal.Data.Entities;
using GmJournal.Data.Repositories;
using System.Linq;


namespace GmJournal.Logic.Services.Users
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IRepositoryBase<User> _repository;
        public User? LoggedUser { get; set; }

        public UserAccessService(IRepositoryBase<User> repository)
        {
            _repository = repository;
        }   

        public bool IsUserLogged()
            => LoggedUser != null;

        public bool IsUserAdmin()
            => LoggedUser != null ?
                LoggedUser.isAdmin :
                throw new Exception("User not logged");

        public void Logout()
            => LoggedUser = null;

        public Task<bool> UserExistsById(long id)
            => _repository.ExistsByIdAsync(id);

        public async Task<bool> UserExists(string login)
        {
            var userFound = await _repository.FindAsync(u => u.login == login);
            return userFound.Any();
        }

        public async Task<bool> LoginAsync(User user)
        {
            var usersFound = await _repository.FindAsync(u => u.login == user.login && u.password == user.password);
            bool userExists = usersFound.Any();

            if (!userExists)
                throw new Exception("Incorrect interaction data!");

            LoggedUser = usersFound.First();
            return userExists;
        }

        public async Task<bool> LoginAsync(string login, string password)
        {
            var usersFound = await _repository.FindAsync(u => u.login == login && u.password == password);
            bool userExists = usersFound.Any();

            if (!userExists)
                throw new Exception("Błędne dane logowania!");

            LoggedUser = usersFound.First();
            return userExists;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            if (user.login != null && await UserExists(user.login))
            {
                throw new Exception($"User {user.login} already exist.");
            }
            else
            {
                await _repository.AddAsync(user);
                await _repository.SaveChangesAsync();
                LoggedUser = user;
                return true;
            }
        }
    }
}
