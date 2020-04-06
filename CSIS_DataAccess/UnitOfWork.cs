namespace CSIS_DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CsisDbContext _dbContext;

        public UnitOfWork(CsisDbContext dbContext, ICosmeticRepository cosmeticRepository/*,
            ICosmeticUsedSlowlyRepository cosmeticUsedSlowlyRepository*/)
        {
            _dbContext = dbContext;
            CosmeticRepository = cosmeticRepository;
            //CosmeticUsedSlowlyRepository = cosmeticUsedSlowlyRepository;
        }

        public ICosmeticRepository CosmeticRepository { get; }
        //public ICosmeticUsedSlowlyRepository CosmeticUsedSlowlyRepository { get; }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}