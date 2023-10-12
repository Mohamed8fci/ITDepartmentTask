using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDepartmentTask.Dal.Models
{
    public class PropertyValue
    {
        public int ID { get; set; }
        public int PropertyItemId { get; set; }
        public PropertyItem PropertyItem { get; set; }
        public string Value { get; set; }
    }

}
