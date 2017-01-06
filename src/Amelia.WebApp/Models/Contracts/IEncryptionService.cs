namespace Amelia.WebApp.Models.Contracts
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Create a random Salt 
        /// </summary>
        /// <returns></returns>
        string CreateSalt();

        string EncryptPassword(string password, string salt);
    }
}