using GmJournal.Data.Entities;

namespace GmJournal.Logic.Services.Users
{
    public interface IUserAccessService
    {
        Task<bool> UserExists(string login);
        Task<bool> UserExistsById(long id);

        Task LoginAsync (string login, string password);

        Task RegisterAsync(string login, string password);

        bool IsUserLogged();
        void Logout();

        public User LoggedUser { get; }
    }
}
