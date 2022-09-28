using Microsoft.Extensions.Configuration;
using UserManagement.Application.Interfaces.Services;
using UserManagement.Common.Endpoints;
using UserManagement.Common.Extensions;
using UserManagement.Common.Responses;
using UserManagement.Common.Wrapper;

namespace UserManagement.Infrastructure.Services
{
    public class SyncDataService : ISyncDataService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpclient;

        public SyncDataService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpclient = httpClient;
        }
        public async Task<IResult<CheckingNameResponse>> CheckingADName(string name)
        {
            var requestUrl = $"{_configuration["ADServiceHost"]}/{SyncDataEndPoints.CheckName(name)}";
            var result = await _httpclient.GetAsync(requestUrl);
            return await result.ToResult<CheckingNameResponse>();
        }
    }
}
