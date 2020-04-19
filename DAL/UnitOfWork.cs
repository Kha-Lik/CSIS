namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CsisDbContext _dbContext;

        public UnitOfWork(CsisDbContext dbContext, ICosmeticRepository cosmeticRepository /*,
            ICosmeticUsedSlowlyRepository cosmeticUsedSlowlyRepository*/)
        {
            _dbContext = dbContext;
            CosmeticRepository = cosmeticRepository;
        }

        public ICosmeticRepository CosmeticRepository { get; }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}