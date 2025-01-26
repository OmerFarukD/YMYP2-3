using System.Security.Cryptography;
using System.Text;

namespace UserManagmentSystem.Service.Helpers;

public static class HashingHelper
{

    public static void CreatePasswordHash(string password , out byte[] passwordHash, out byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }



    public static bool VerifyPasswordHash(string password, byte[] passwordHash,  byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new(passwordSalt);
        byte[] computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


        //for (int i=0; i<computeHash.Length; i++)
        //{
        //    if (passwordHash[i] != computeHash[i])
        //    {
        //        return false;
        //    }
        //}

        //return true;
        return computeHash.SequenceEqual(passwordHash);
    }

}