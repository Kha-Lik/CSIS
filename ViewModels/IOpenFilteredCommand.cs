using System.Windows.Input;
using BLL.Abstract;

namespace ViewModels
{
    public interface IOpenFilteredCommand : ICommand
    {
        public IFacade Facade { get; set; }
    }
}