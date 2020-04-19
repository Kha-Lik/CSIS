namespace BLL.Abstract
{
    public interface IFacade
    {
        public ICosmeticService CosmeticService { get; }

        public IFilterService FilterService { get; }
    }
}