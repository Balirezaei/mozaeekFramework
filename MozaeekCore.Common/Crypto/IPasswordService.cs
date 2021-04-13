namespace MozaeekCore.Common.Crypto
{
    public interface IPasswordService
    {
        (string hash, string salt) GenerateHashPassword(string password);
        bool Verify(string plainPassword, string hashPassword,string salt);
    }
}
