using System;
using System.Collections.Generic;
using System.Text;
using Sharing.DataAccessCore.Core;

namespace Sharing.DataAccessCore.Interfaces
{
    interface IGenericRepository<T> where T : Entity
    {
        IEnumerable<T> GetItemList();
        T GetItem(int id);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
    }
}
