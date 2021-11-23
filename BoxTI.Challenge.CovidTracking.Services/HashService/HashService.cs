using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BoxTI.Challenge.CovidTracking.Services.HashService
{
    public class HashService : IHashService
    {
        public string CalculateHash(string Senha)
        {
            try
            {
                MD5 md5 = MD5.Create();
                byte[] passBytes = Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(passBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
