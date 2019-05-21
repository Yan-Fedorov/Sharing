using Sharing.DataAccessCore.Core;
using System;
using System.Linq;

namespace Sharing.DataAccess
{
    public class SeedData
    {
        public static void Initialize(SharingContext _modelContext)
        {
            _modelContext.Database.EnsureCreated();
            

            var mediumAction1 = new MediumAction()
            {  
                Medium = "Ground",
            };
            var mediumAction2 = new MediumAction()
            {
                
                Medium = "Air",
            };
            var mediumAction3 = new MediumAction()
            {
                
                Medium = "Air-Ground",
            };


            //if (!_modelContext.MediumActions.Any())
            //{
            //    _modelContext.MediumActions.Add(mediumAction1);
            //    _modelContext.MediumActions.Add(mediumAction2);
            //    _modelContext.MediumActions.Add(mediumAction3);
            //}

            var applicationMode1 = new ApplicationMode()
            {
                
                Mode = "Entertainment"
            };

            if (!_modelContext.ApplicationModes.Any())
            {
                _modelContext.ApplicationModes.Add(applicationMode1);

            }

            var machineType1 = new MachineType()
            {
                
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction1
            };
            var machineType2 = new MachineType()
            {
                
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction2
            };
            var machineType3 = new MachineType()
            {
                
                ApplicationMode = applicationMode1,
                MediumAction = mediumAction3
            };

            if (!_modelContext.MachineTypes.Any())
            {
                _modelContext.MachineTypes.Add(machineType1);
                _modelContext.MachineTypes.Add(machineType2);
                _modelContext.MachineTypes.Add(machineType3);
            }

            var location1 = new Location()
            {
                
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
                
                Accelaration = 3,
                ActionRadius = 50,
                Speed = 34,
                Weight = 3,
                WorkTime = new DateTime().AddHours(2)
            };

            if (!_modelContext.Characteristics.Any())
            {
                _modelContext.Characteristics.Add(characteristic1);
            }

            var machine2 = new CloudResource()
            {
                
                Discount = 9.5m,
                IsAvailable = true,
                MachineType = machineType2,
                Name = "Machine can fly",
                Price = 12.5m,
                Characteristic = characteristic1
            };

            var machine1 = new CloudResource()
            {
                
                Discount = 9.5m,
                IsAvailable = true,
                MachineType = machineType1,
                Name = "Machine with wheels",
                Price = 15.5m,
                Characteristic = characteristic1
            };
            var machine3 = new CloudResource()
            {
                
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

            var renter1 = new Customer()
            {
                
                FirstName = "1",
                LastName = "1",
                Money = 300,
                UserName = "Ivan"
            };

            if (!_modelContext.Renters.Any())
            {
                _modelContext.Renters.Add(renter1);
            }

            var renteredMachine1 = new RenteredResource()
            {
                
                ActivationCode = "1",
                FinishDate = DateTime.Now.AddDays(30),
                StartDate = DateTime.Now,
                CloudResource = machine1,
                Price = machine1.Price - machine1.Discount,
                Customer = renter1
            };

            var renteredMachine2 = new RenteredResource()
            {
                
                ActivationCode = "2",
                FinishDate = DateTime.Now.AddDays(30),
                StartDate = DateTime.Now,
                CloudResource = machine2,
                Price = machine2.Price - machine2.Discount,
                Customer = renter1
            };

            if (!_modelContext.RenteredMachines.Any())
            {
                _modelContext.RenteredMachines.Add(renteredMachine1);
                _modelContext.RenteredMachines.Add(renteredMachine2);
            }
            
            _modelContext.SaveChanges();
        }
    }
}
