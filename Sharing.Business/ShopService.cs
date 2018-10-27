using System;
using Sharing.Business.Interfaces;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;

namespace Sharing.Business
{
    public class ShopService: IShopService
    {
        private readonly IRepository<Renter> _renterRepository;
        private readonly IRepository<Machine> _machineRepository;
        private readonly IRepository<RenteredMachine> _renteredMachineRepository;
        private readonly IRepository<Lessor> _lessorRepository;
        public ShopService(IRepository<Renter> renterRepository, IRepository<Machine> machineRepository, IRepository<RenteredMachine> renteredMachineRepository, IRepository<Lessor> lessorRepository)
        {
            _renterRepository = renterRepository;
            _machineRepository = machineRepository;
            _renteredMachineRepository = renteredMachineRepository;
            _lessorRepository = lessorRepository;
        }

        public int RenterMachine(int renterId, int machineId, DateTime starTime, DateTime endTime)
        {
            if (renterId <= 0 || machineId <= 0)
            {
                throw new ArgumentException("renterId is less then 1 or machineId is less then 1 in musicStoreService in BuySong", "renterId or machineId");
            }

            Renter renter = _renterRepository.GetItem(renterId);

            if (renter == null)
            {
                throw new Exception("Renter is null");
            }

            Machine machine = _machineRepository.GetItem(machineId);

            if (machine == null)
            {
                throw new Exception("Machine is null");
            }

            if (machine.Lessor == null)
            {
                throw new Exception("Lessor of machine is null");
            }
            
            Lessor lessor = machine.Lessor;

            if (renter.Money < machine.Price)
            {
                throw new Exception($"Renter has not enough money for rent {machine.Name} machine");
            }

            string activationCode = " ";
            var renteredMachine = new RenteredMachine(renter, machine, starTime, endTime, machine.Price, activationCode);
            var renteredMachineId = _renteredMachineRepository.Create(renteredMachine);

            renter.Money -= machine.Price;
            lessor.Money += machine.Price;

            _renterRepository.Update(renter);
            _lessorRepository.Update(lessor);

            return renteredMachineId;
        }
    }
}
