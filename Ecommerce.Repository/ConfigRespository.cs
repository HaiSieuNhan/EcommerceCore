using Ecommerce.Domain.Models;
using System;
using Ecommerce.Domain;
using System.Linq;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Common.Infrastructure.Helper;

namespace Ecommerce.Repository
{
    public class ConfigRespository : BaseRepository<Config>, IConfigResponsitory
    {
        public ConfigRespository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public Config Authenticate(string key, string code)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(code))
                return null;

            var Key = DbContext.Configs.SingleOrDefault(x => x.Key == key);

            // check if username exists
            if (Key == null)
                return null;

            // check if password is correct
            //if (!AuthenUserHelper.VerifyPasswordHash(password, user.PassWordHash, user.PassWordSalt))
            //{
            //    return null;
            //}

            // authentication successful
            return Key;
        }

        public Config Create(Config config, string code,string value)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new Exception("Code is required");

            if (DbContext.Configs.Any(x => x.Key == config.Key))
                throw new Exception("Key \"" + config.Key + "\" is already taken");

            //byte[] passwordHash;
            //byte[] passwordSalt;

            config.Value = value;
            config.Code = code;

            DbContext.Configs.Add(config);
            DbContext.SaveChanges();

            return config;
        }

        public void Update(Config configParam,string code=null)
        {
            var config = DbContext.Configs.Find(configParam.Key);

            if (config == null)
                throw new Exception("config not found");

            if (configParam.Key != config.Key)
            {
                // username has changed so check if the new username is already taken
                if (DbContext.Configs.Any(x => x.Key == configParam.Key))
                    throw new Exception("Key " + configParam.Key + " is already taken");
            }

            // update user properties
            //user.FirstName = userParam.FirstName;
            //user.LastName = userParam.LastName;
            //user.UserName = userParam.UserName;
            config.Value = configParam.Value;
            config.Code = configParam.Code;

            // update password if it was entered
            //if (!string.IsNullOrWhiteSpace(password))
            //{
            //    byte[] passwordHash, passwordSalt;
            //    AuthenUserHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //    user.PassWordHash = passwordHash;
            //    user.PassWordSalt = passwordSalt;
            //}

            DbContext.Configs.Update(config);
            DbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var config = DbContext.Configs.Find(id);
            if (config != null)
            {
                DbContext.Configs.Remove(config);
                DbContext.SaveChanges();
            }
        }
    }
}
