using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryManagement.DAL.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;

    public class UserViewModelTransalator : IViewModelTransalator<UserViewModel, UserModel>
    {
        public UserModel TransalateToModel(UserViewModel userViewModel)
        {           
             var   userModel = new UserModel
                {
                    ID = userViewModel.ID,
                                      
                };
             return userModel;
               
        }
        public UserViewModel TransalateToViewModel(UserModel userModel)
        {
            var userViewModel = new UserViewModel
                {
                    ID = userModel.ID,
                    Roleid = userModel.Roleid,                
                };

            return userViewModel;
        }
    }
}