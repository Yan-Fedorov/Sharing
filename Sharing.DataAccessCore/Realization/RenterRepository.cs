using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.DataAccessCore.Realization
{
    public class RenterRepository : IRepository<Renter>
    {
        private readonly SharingContext _dataBase;

        public RenterRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(Renter item)
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

            Renter renter = _dataBase.Renters.Find(id);

            if (renter == null)
            {
                throw new ArgumentException("item is null in RenterRepository");
            }

            _dataBase.Renters.Remove(renter);
            _dataBase.SaveChanges();
            return id;
        }

        public Renter GetItem(int id)
        {
            return _dataBase.Renters.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Renter> GetItemList()
        {
            return _dataBase.Renters;
        }

        public int Update(Renter item)
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
