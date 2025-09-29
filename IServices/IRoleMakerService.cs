
using Raqmiyat.Entities.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace OpenFinanceWebApi.IServices
{
    public interface IRoleMakerService
    {
       string CreateRole(Role role);
        IEnumerable<Role> GetRoleDetails();
        IEnumerable<Role> GetSearchRoleDetails(Role role);
        public string UpdateRole(Role role);
        public IEnumerable<ProductType> GetProductTypes();
    }
}
