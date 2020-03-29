using System.Collections.Generic;

namespace CSIS_BLL.Interfaces
{
    public interface IFacade
    {
        public ICosmeticService CosmeticService { get; }
        public ICosmeticUsedSlowlyService CosmeticUsedSlowlyService { get; }
        public IFilterService FilterService { get; }
        public ISaverService SaverService { get; }

        public IEnumerable<CosmeticModel> GetAll();
    }
}