using BLL.Abstract;

namespace BLL
{
    public class Facade : IFacade
    {
        public Facade(ICosmeticService cosmeticService, /*ICosmeticUsedSlowlyService cosmeticUsedSlowlyService,*/
            IFilterService filterService)
        {
            CosmeticService = cosmeticService;
            FilterService = filterService;
        }

        public ICosmeticService CosmeticService { get; }

        public IFilterService FilterService { get; }
    }
}