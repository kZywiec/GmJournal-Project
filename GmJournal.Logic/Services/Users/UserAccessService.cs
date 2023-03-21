using GmJournal.Data.Entities;
using GmJournal.Data.Repositories;
using System.Linq;


namespace GmJournal.Logic.Services.Users
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IRepositoryBase<User> _repository;
        public User? LoggedUser { get; set; }

        public bool IsUserLogged()
            => LoggedUser != null;

        public bool IsUserAdmin()
            => IsUserLogged() ?
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

        public Task LoginAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(string login, string password)
        {
            User newUser = new User(login, password);

            if (await UserExists(newUser.login))
            {
                throw new Exception($"User {newUser.login} already exist.");
            }
            else
            {
                await _repository.AddAsync(newUser);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
