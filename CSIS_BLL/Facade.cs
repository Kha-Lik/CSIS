using System.Collections.Generic;
using System.Linq;
using CSIS_BLL.Interfaces;

namespace CSIS_BLL
{
    public class Facade : IFacade
    {
        public Facade(ICosmeticService cosmeticService, ICosmeticUsedSlowlyService cosmeticUsedSlowlyService,
            IFilterService filterService, ISaverService saverService)
        {
            CosmeticService = cosmeticService;
            CosmeticUsedSlowlyService = cosmeticUsedSlowlyService;
            FilterService = filterService;
            SaverService = saverService;
        }

        public ICosmeticService CosmeticService { get; }
        public ICosmeticUsedSlowlyService CosmeticUsedSlowlyService { get; }
        public IFilterService FilterService { get; }
        public ISaverService SaverService { get; }

        public IEnumerable<CosmeticModel> GetAll()
        {
            var cosmetics = CosmeticService.GetAll().ToList();
            cosmetics.AddRange(CosmeticUsedSlowlyService.GetAll());
            return cosmetics;
        }
    }
}