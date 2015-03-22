using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;

    public class LendingViewModelTransalator : IViewModelTransalator<LendingViewModel, LendingModel>
    {

        public LendingModel TransalateToModel(LendingViewModel lendingviewModel)
        {
            var lendingModel = new LendingModel
            {
                ID = lendingviewModel.ID,
                Issuer = lendingviewModel.Issuer,
                ItemIssued = lendingviewModel.ItemIssued,
                Issuedate = lendingviewModel.Issuedate
            };
            return lendingModel;
        }
        public LendingViewModel TransalateToViewModel(LendingModel lendingModel)
        {
            var lendingViewModel = new LendingViewModel
            {

                ID = lendingModel.ID,
                Issuer = lendingModel.Issuer,
                ItemIssued = lendingModel.ItemIssued,
                Issuedate = lendingModel.Issuedate
            };
            return lendingViewModel;
        }
    }
}