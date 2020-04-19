namespace DAL.Abstract
{
    public interface IUnitOfWork
    {
        ICosmeticRepository CosmeticRepository { get; }

        void SaveChanges();
    }
}