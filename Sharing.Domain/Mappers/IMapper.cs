using System;
using System.Collections.Generic;
using System.Text;
using Sharing.DataAccessCore.Core;

namespace Sharing.Domain.Mappers
{
    public interface IMapper<T, DTO>
        where T : Entity
        where DTO : Entity
    {
        DTO AutoMap(T item);
        T ReAutoMap(DTO item, T initialItem);
    }
}
