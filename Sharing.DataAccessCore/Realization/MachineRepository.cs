using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.DataAccessCore.Realization
{
    public class MachineRepository : IRepository<Machine>
    {
        private readonly SharingContext _dataBase;

        public MachineRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(Machine item)
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

            Machine machine = _dataBase.Machines.Find(id);

            if (machine == null)
            {
                throw new ArgumentException("item is null in MachineRepository");
            }

            _dataBase.Machines.Remove(machine);
            _dataBase.SaveChanges();
            return id;
        }

        public Machine GetItem(int id)
        {
            return _dataBase.Machines.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Machine> GetItemList()
        {
            return _dataBase.Machines;
        }

        public int Update(Machine item)
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
