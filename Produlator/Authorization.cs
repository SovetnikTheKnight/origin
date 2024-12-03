using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produlator
{
    internal class Authorization
    {
        public static int? authorizationRole;

        public static int? GetRole(string login, string password)
        {
            var entities = Produlator_dbEntities1.GetInstance().account.FirstOrDefault(a => a.login == login && a.password == password);
            if (entities != null) return authorizationRole = entities.access_level_id;
            return null;
        }
    }
}
