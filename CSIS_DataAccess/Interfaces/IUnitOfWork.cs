namespace CSIS_DataAccess
{
    public interface IUnitOfWork
    {
        ICosmeticRepository CosmeticRepository { get; }
        
        void SaveChanges();
    }
}