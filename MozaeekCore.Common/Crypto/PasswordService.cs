using System;
using System.Collections.Generic;
using System.Text;

namespace MozaeekCore.Common.Crypto
{
    public class PasswordService : IPasswordService
    {
        public (string hash,string salt) GenerateHashPassword(string password)
        {
            var salt = CryptoService.GenerateSalt();
            var hashPassword = CryptoService.ComputeHash(password, salt);
            return (Convert.ToBase64String(hashPassword), Convert.ToBase64String(salt));
        }

        public bool Verify(string plainPassword, string hashPassword, string salt)
        {
            var computedSalt = Convert.FromBase64String(salt);
            var computedHashPasswordByte = CryptoService.ComputeHash(plainPassword, computedSalt);
            var computedHashPassword = Convert.ToBase64String(computedHashPasswordByte);
            return computedHashPassword.Equals(hashPassword);
        }
    }
}
