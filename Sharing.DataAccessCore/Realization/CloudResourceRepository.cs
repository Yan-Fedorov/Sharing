using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.DataAccessCore.Realization
{
    public class CloudResourceRepository : IRepository<CloudResource>
    {
        private readonly SharingContext _dataBase;

        public CloudResourceRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(CloudResource item)
        {
            if (item != null)
            {
                _dataBase.Machines.Add(item);
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in MachineRepository");
        }

        public int Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id < 0 in MachineRepository");
            }

            CloudResource machine = _dataBase.Machines.Find(id);

            if (machine == null)
            {
                throw new ArgumentException("item is null in MachineRepository");
            }

            _dataBase.Machines.Remove(machine);
            _dataBase.SaveChanges();
            return id;
        }

        public CloudResource GetItem(int id)
        {
            return _dataBase.Machines.Include(x => x.Lessor).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CloudResource> GetItemList()
        {
            return _dataBase.Machines;
        }

        public int Update(CloudResource item)
        {
            if (item != null)
            {
                _dataBase.Entry(item).State = EntityState.Modified;
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in MachineRepository");
        }
    }
}
