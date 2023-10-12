using ITDepartmentTask.Bll.IRepository;
using ITDepartmentTask.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDepartmentTask.Bll.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private protected readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) {
            _context = context;
        }
        public int Add(T item)
        {
            _context.Set<T>().Add(item);
            return _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Device))
            {
                return (IEnumerable<T>)_context.Devices.Include(d => d.DeviceCategory).ToList();
            }else if (typeof(T) == typeof(DeviceCategory))
            {
                return (IEnumerable<T>)_context.DeviceCategories.Include(d => d.PropertyItems).ToList();

            }
            
            else
            {
                return _context.Set<T>().ToList();
            }
        }
    }
}
