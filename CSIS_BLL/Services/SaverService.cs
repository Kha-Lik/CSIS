using CSIS_BLL.Interfaces;
using CSIS_DataAccess;

namespace CSIS_BLL
{
    public class SaverService : ISaverService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save()
        {
            _unitOfWork.SaveChanges();
        }
    }
}