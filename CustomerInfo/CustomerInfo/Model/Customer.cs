using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Model
{
    public class Customer
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Contact { set; get; }
        public string Address { set; get; }
        public int DistrictId { set; get; }
    }
}
