using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Models
{
    public class ProductType
    {
        private int typeID;
        private string typeName;

        public int TypeID { get => typeID; set => typeID = value; }
        public string TypeName { get => typeName; set => typeName = value; }
    }
}
