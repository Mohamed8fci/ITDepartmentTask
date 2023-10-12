using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDepartmentTask.Dal.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
           
        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceCategory> DeviceCategories { get; set; }
        public DbSet<PropertyItem> PropertyItems { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
    }
}
