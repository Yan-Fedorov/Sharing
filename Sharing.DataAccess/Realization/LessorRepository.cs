using Sharing.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Sharing.DataAccess.Core;
using Microsoft.EntityFrameworkCore;

namespace Sharing.DataAccess.Realization
{

    public class LessorRepository : IRepository<Lessor>
    {
        private readonly SharingContext _dataBase;

        public LessorRepository(SharingContext dataBase)
        {
            _dataBase = dataBase;
        }

        public int Create(Lessor item)
        {
            if (item != null)
            {
                _dataBase.Lessors.Add(item);
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in LessorRepository");
        }

        public int Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id < 0 in LessorRepository");
            }

            Lessor lessor = _dataBase.Lessors.Find(id);

            if (lessor == null)
            {
                throw new ArgumentException("item is null in LessorRepository");
            }

            _dataBase.Lessors.Remove(lessor);
            _dataBase.SaveChanges();
            return id;
        }

        public Lessor GetItem(int id)
        {
            return _dataBase.Lessors.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Lessor> GetItemList()
        {
            return _dataBase.Lessors;
        }

        public int Update(Lessor item)
        {
            if (item != null)
            {
                _dataBase.Entry(item).State = EntityState.Modified;
                _dataBase.SaveChanges();
                return item.Id;
            }

            throw new ArgumentException("item is null in LessorRepository");
        }
    }
}
