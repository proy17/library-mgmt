using LibraryManagement.Entities;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;

    interface IViewModelTransalator<TViewModel, TModel>
        where TViewModel : BaseViewModel
        where TModel : BaseModel
    {
        TModel TransalateToModel(TViewModel ViewModel);
        TViewModel TransalateToViewModel(TModel Model);
    }
}
