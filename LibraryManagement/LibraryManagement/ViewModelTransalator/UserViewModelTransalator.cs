namespace LibraryManagement.DAL.ViewModelTransalator
{
    using LibraryManagement.ViewModels;
    using LibraryManagement.Models;

    public class UserViewModelTransalator : IViewModelTransalator<UserViewModel, UserModel>
    {
        public UserModel TransalateToModel(UserViewModel userViewModel)
        {
            var userModel = new UserModel
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
                    RoleId = userModel.RoleId.ToString(),
                    Firstname = userModel.Firstname,
                    LastName = userModel.LastName,
                    Password = userModel.Password,
                    UserName = userModel.UserEmail
                };

            return userViewModel;
        }
    }
}