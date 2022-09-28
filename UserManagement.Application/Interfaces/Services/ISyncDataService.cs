using UserManagement.Common.Responses;
using UserManagement.Common.Wrapper;

namespace UserManagement.Application.Interfaces.Services
{
    public interface ISyncDataService
    {
        Task<IResult<CheckingNameResponse>> CheckingADName(string name);
    }
}
