using System;

namespace Sharing.Business.Interfaces
{
    public interface IShopService
    {
        int RenterMachine(int renterId, int machineId, DateTime starTime, DateTime endTime);
    }
}
