using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharing.DataAccess.Core;

namespace Sharing.DataAccess
{
    public class SeedData
    {
        public static void Initialize(SharingContext _modelContext)
        {
            _modelContext.Database.EnsureCreated();

            var mediumAction1 = new MediumAction()
            {
                Id = 0,
                Medium = "Ground",

            };
            var mediumAction2 = new MediumAction()
            {
                Id = 1,
                Medium = "Air",
            };
            var mediumAction3 = new MediumAction()
            {
                Id = 1,
                Medium = "Air-Ground",
            };


            if (!_modelContext.MediumActions.Any())
            {
                _modelContext.MediumActions.Add(mediumAction1);
                _modelContext.MediumActions.Add(mediumAction2);
                _modelContext.MediumActions.Add(mediumAction3);
            }

            var applicationMode1 = new ApplicationMode()
            {
                Id = 0,
                Mode = "Entertainment"
            };

            if (!_modelContext.MediumActions.Any())
            {
                _modelContext.ApplicationModes.Add(applicationMode1);

            }

            var machineType1 = new MachineType()
            {
                Id = 0,
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction1
            };
            var machineType2 = new MachineType()
            {
                Id = 1,
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction2
            };
            var machineType3 = new MachineType()
            {
                Id = 2,
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction3
            };

            if (!_modelContext.MediumActions.Any())
            {
                _modelContext.MachineTypes.Add(machineType1);
                _modelContext.MachineTypes.Add(machineType1);
                _modelContext.MachineTypes.Add(machineType1);
            }

            var location1 = new Location()
            {
                Id = 0,
                Continent = "Europe",
                Country = "Germany",
                City = "Berlin",
                House = "11n",
                Street = "Street"
            };
            if (!_modelContext.Locations.Any())
            {
                _modelContext.Locations.Add(location1);
            }

            var characteristic1 = new Characteristic()
            {
                Id = 0,
                Accelaration = 3,
                ActionRadius = 50,
                Speed = 34,
                Weight = 3,
                WorkTime = new DateTime(0, 0, 0, 3, 30, 0)
            };

            if (!_modelContext.Characteristics.Any())
            {
                _modelContext.Characteristics.Add(characteristic1);
            }

            var machine2 = new Machine()
            {
                Id = 0,
                Discount = 9.5m,
                IsAvailable = true,
                MachineType = machineType2,
                Name = "Machine can fly",
                Price = 12.5m,
                Characteristic = characteristic1
            };

            var machine1 = new Machine()
            {
                Id = 1,
                Discount = 9.5m,
                IsAvailable = true,
                MachineType = machineType1,
                Name = "Machine with wheels",
                Price = 15.5m,
                Characteristic = characteristic1
            };
            var machine3 = new Machine()
            {
                Id = 2,
                Discount = 9.5m,
                IsAvailable = true,
                MachineType = machineType3,
                Name = "Machine with wheels can fly",
                Price = 15.5m,
                Characteristic = characteristic1
            };
            if (!_modelContext.Machines.Any())
            {
                _modelContext.Machines.Add(machine3);
                _modelContext.Machines.Add(machine1);
                _modelContext.Machines.Add(machine2);
            }

            _modelContext.SaveChanges();
        }
    }
}
