using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Mvc.Model;

namespace Autofac.Mvc.ITest
{
    public interface IUserRepositories
    {
        List<UserModel> GetList();
    }
}
