using Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenFinanceWebApi.IServices
{
    public interface IPasswordPolicyService
    {
        string AddPasswordPolicy(PasswordPolicyModelView passwordPolicyModelView);
       /// <summary>
       /// string EditPasswordPolicy(PasswordPolicyModelView passwordPolicyModelView);
       /// </summary>
       /// <returns></returns>
        public PasswordPolicyModelView GetPassworPolicy();
        public PasswordPolicyModelView GetPasswordDetailsPolicy();
        public IEnumerable<PasswordPolicyModelView> GetPasswordCheckerPolicy();
        string Approve(PasswordPolicyModelView passwordPolicyModelView);
    }
}
