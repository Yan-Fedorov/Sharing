using Sharing.DataAccessCore.Core;

namespace Sharing.Business.Interfaces
{
    public interface IUserAccountService
    {
        bool DeleteLessorAccount(int id);
        bool DeleteRenterAccount(int id);
        bool ChangeRenterAccount(Customer user);
        Customer GetRenterAccount(int id);
        Lessor GetLessorAccount(int id);
        bool ChangeLessorAccount(Lessor user);
        RenteredResource GetRenteredMachineAccount(int id);
        bool ActivateDron(int id);
    }
}
