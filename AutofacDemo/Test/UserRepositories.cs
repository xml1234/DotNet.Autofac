using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Mvc.ITest;
using Autofac.Mvc.Model;

namespace Autofac.Mvc.Test
{
    public class UserRepositories : IUserRepositories
    {
        public List<UserModel> GetList()
        {
            List<UserModel> list = new List<UserModel>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(new UserModel { ID = i, UserName = "张" + i });
            }

            return list;
        }
    }
}
