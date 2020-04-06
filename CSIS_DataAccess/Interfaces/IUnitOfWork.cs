namespace CSIS_DataAccess
{
    public interface IUnitOfWork
    {
        ICosmeticRepository CosmeticRepository { get; }

        //ICosmeticUsedSlowlyRepository CosmeticUsedSlowlyRepository { get; }

        void SaveChanges();
    }
}