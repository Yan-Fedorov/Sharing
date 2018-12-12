using Microsoft.EntityFrameworkCore;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharing.DataAccessCore.Realization
{
    public class CharacteristicRepository : IRepository<Characteristic>
    {
        private readonly SharingContext _dataBase;

        public CharacteristicRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(Characteristic item)
        {
            if (item != null)
            {
                _dataBase.Characteristics.Add(item);
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in CharacteristicRepository");
        }

        public int Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id < 0 in CharacteristicRepository");
            }

            Characteristic characteristic = _dataBase.Characteristics.Find(id);

            if (characteristic == null)
            {
                throw new ArgumentException("item is null in CharacteristicRepository");
            }

            _dataBase.Characteristics.Remove(characteristic);
            _dataBase.SaveChanges();
            return id;
        }

        public Characteristic GetItem(int id)
        {
            return _dataBase.Characteristics.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Characteristic> GetItemList()
        {
            return _dataBase.Characteristics;
        }

        public int Update(Characteristic item)
        {
            if (item != null)
            {
                _dataBase.Entry(item).State = EntityState.Modified;
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in CharacteristicRepository");
        }
    }
}
