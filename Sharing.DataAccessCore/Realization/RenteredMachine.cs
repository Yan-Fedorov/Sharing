using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharing.DataAccessCore.Realization
{
    public class RenteredMachineRepository : IRepository<RenteredMachine>
    {
        private readonly SharingContext _dataBase;

        public RenteredMachineRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(RenteredMachine item)
        {
            if (item != null)
            {
                _dataBase.RenteredMachines.Add(item);
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in RenteredMachineRepository");
        }

        public int Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id < 0 in RenteredMachineRepository");
            }

            RenteredMachine renteredMachine = _dataBase.RenteredMachines.Find(id);

            if (renteredMachine == null)
            {
                throw new ArgumentException("item is null in RenteredMachineRepository");
            }

            _dataBase.RenteredMachines.Remove(renteredMachine);
            _dataBase.SaveChanges();
            return id;
        }

        public RenteredMachine GetItem(int id)
        {
            return _dataBase.RenteredMachines.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<RenteredMachine> GetItemList()
        {
            return _dataBase.RenteredMachines;
        }

        public int Update(RenteredMachine item)
        {
            if (item != null)
            {
                _dataBase.Entry(item).State = EntityState.Modified;
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in RenteredMachineRepository");
        }
    }
}
