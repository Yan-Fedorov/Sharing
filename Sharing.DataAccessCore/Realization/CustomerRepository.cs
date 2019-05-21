using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.DataAccessCore.Realization
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly SharingContext _dataBase;

        public CustomerRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(Customer item)
        {
            if (item != null)
            {
                _dataBase.Renters.Add(item);
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in RenterRepository");
        }

        public int Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id < 0 in RenterRepository");
            }

            Customer renter = _dataBase.Renters.Find(id);

            if (renter == null)
            {
                throw new ArgumentException("item is null in RenterRepository");
            }

            _dataBase.Renters.Remove(renter);
            _dataBase.SaveChanges();
            return id;
        }

        public Customer GetItem(int id)
        {
            return  _dataBase.Renters.Include(x => x.RenteredMachine).ThenInclude(x => x.CloudResource).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetItemList()
        {
            return _dataBase.Renters;
        }

        public int Update(Customer item)
        {
            if (item != null)
            {
                _dataBase.Entry(item).State = EntityState.Modified;
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in RenterRepository");
        }
    }
}
