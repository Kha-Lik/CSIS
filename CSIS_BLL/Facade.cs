using CSIS_BLL.Interfaces;

namespace CSIS_BLL
{
    public class Facade : IFacade
    {
        public Facade(ICosmeticService cosmeticService, /*ICosmeticUsedSlowlyService cosmeticUsedSlowlyService,*/
            IFilterService filterService, ISaverService saverService)
        {
            CosmeticService = cosmeticService;
            FilterService = filterService;
            SaverService = saverService;
        }

        public ICosmeticService CosmeticService { get; }

        public IFilterService FilterService { get; }
        public ISaverService SaverService { get; }


    }
}