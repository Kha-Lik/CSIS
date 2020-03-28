namespace CSIS_DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<CosmeticEntity> CosmeticRepository { get; }

        IRepository<CosmeticUsedSlowlyEnity> CosmeticUsedSlowlyRepository { get; }

        void SaveChanges();
    }
}