﻿using AuthenticationService.Models;
using System.Security.Cryptography;

namespace AuthenticationService
{
    public class GenTokens
    {
        public String Build(String SecretKey)
        {
            if (SecretKey == "")
            {
                var hmac = new HMACSHA256();

                IAuthContainerModel model = GetJWTContainerModel(SecretKey);
                model.SecretKey = Convert.ToBase64String(hmac.Key);
                return model.SecretKey;
            }
            return SecretKey;
        }

        #region Private Methods
        private static GIMBContainerModel GetJWTContainerModel(String SecretJey)
        {
            return new GIMBContainerModel()
            {
                SecretKey = new GIMBContainerModel().SecretKey
            };
        }
        #endregion
    }
}