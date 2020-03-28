namespace CSIS_DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CSIS_DBContext _dbContext;

        public UnitOfWork(CSIS_DBContext dbContext, IRepository<CosmeticEntity> cosmeticRepository,
            IRepository<CosmeticUsedSlowlyEnity> cosmeticUsedSlowlyRepository)
        {
            _dbContext = dbContext;
            CosmeticRepository = cosmeticRepository;
            CosmeticUsedSlowlyRepository = cosmeticUsedSlowlyRepository;
        }

        public IRepository<CosmeticEntity> CosmeticRepository { get; }
        public IRepository<CosmeticUsedSlowlyEnity> CosmeticUsedSlowlyRepository { get; }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}