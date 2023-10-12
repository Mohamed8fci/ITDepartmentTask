using ITDepartmentTask.Bll.IRepository;
using ITDepartmentTask.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDepartmentTask.Bll.Repository
{
    public class DeviceRepositrory : GenericRepository<Device> ,IDeviceRepositrory
    {
        private readonly ApplicationDbContext _context;
        public DeviceRepositrory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
