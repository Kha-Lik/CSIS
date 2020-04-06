namespace CSIS_BLL.Interfaces
{
    public interface IFacade
    {
        public ICosmeticService CosmeticService { get; }

        public IFilterService FilterService { get; }

    }
}