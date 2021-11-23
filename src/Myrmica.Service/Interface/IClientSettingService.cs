using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IClientSettingService
    {
        public Task<string> AddClientSettingAsync(ClientSettingDto menu);
        public Task<ClientSettingDto> GetClientSettingByIdAsync(string menuId);
        public Task<PagedList<ClientSettingDto>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditClientSettingAsync(ClientSettingDto dto);
        public Task<bool> DeleteClientSettingAsync(string menuId);
    }
}
