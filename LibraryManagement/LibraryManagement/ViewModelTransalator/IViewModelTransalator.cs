

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;
    using LibraryManagement.Models;

    public interface IViewModelTransalator<TViewModel, TModel>
        where TViewModel : BaseViewModel
        where TModel : BaseModel
    {
        TModel TransalateToModel(TViewModel ViewModel);
        TViewModel TransalateToViewModel(TModel Model);
    }
}
