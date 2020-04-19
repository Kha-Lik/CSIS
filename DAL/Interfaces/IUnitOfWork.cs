namespace DAL
{
    public interface IUnitOfWork
    {
        ICosmeticRepository CosmeticRepository { get; }
        
        void SaveChanges();
    }
}