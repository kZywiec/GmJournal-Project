using GmJournal.Data.Entities;

namespace GmJournal.Logic.Services.Users
{
    public interface IUserAccessService
    {
        Task<bool> UserExists(string login);
        Task<bool> UserExistsById(long id);

        Task<bool> LoginAsync(User user);
        Task<bool> LoginAsync (string login, string password);

        Task<bool> RegisterAsync(User user);

        bool IsUserLogged();
        void Logout();

        public User? LoggedUser { get; }
    }
}
