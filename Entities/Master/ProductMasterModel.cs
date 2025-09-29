using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Master
{
    public class ProductMasterModel
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Controller_Name { get; set; }
        public string Action_Name { get; set; }
        public string App_Url { get; set; }

    }
}
