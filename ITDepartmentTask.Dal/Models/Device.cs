using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDepartmentTask.Dal.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string? DeviceName { get; set; }
        public int DeviceCategoryId { get; set; }
        public DeviceCategory? DeviceCategory { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Memo { get; set; }
        public List<PropertyValue>? PropertyValues { get; set; }
    }
}
