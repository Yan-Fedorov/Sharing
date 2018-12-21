using Sharing.DataAccessCore.Core;

namespace Sharing.Business.Interfaces
{
    public interface IUserAccountService
    {
        bool DeleteLessorAccount(int id);
        bool DeleteRenterAccount(int id);
        bool ChangeRenterAccount(Renter user);
        Renter GetRenterAccount(int id);
        Lessor GetLessorAccount(int id);
        bool ChangeLessorAccount(Lessor user);
        RenteredMachine GetRenteredMachineAccount(int id);
        bool ActivateDron(int id);
    }
}
