
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raqmiyat.Entities.Login
{
    public class Role
    {

        public int ROLE_ID { get; set; }
        public string? ROLE_CODE { get; set; }
        public string? ROLE_NAME { get; set; }
        public string? ACTION_BY { get; set; }
        public DateTime ACTION_ON { get; set; }
        public string? ACTION { get; set; }
        public string? APPROVED_BY { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public string? ROLE_DESCRIPTION { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public string? Pre_Role_Name { get; set; }
        public string? REJECT_REASON { get; set; }

        public bool Selected { get; set; }

        public string? Message { get; set; }

        public bool Delete_Role { get; set; }

        public bool Delete { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
        public int Product_ID { get; set; }
        public string? Product_Name { get; set; }
        public int IsAssigned { get; set; }
        public List<ProductType>? ProductTypesList { get; set; }

    }
    public class ProductType

    {
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
    }


}
