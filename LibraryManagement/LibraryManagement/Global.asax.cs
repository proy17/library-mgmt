using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;




namespace LibraryManagement
{
    using System;
    using System.Web.Helpers;

    using Autofac;
    using Autofac.Configuration;



    using LibraryManagement.Controllers;
    using LibraryManagement.DAL;
    using LibraryManagement.DAL.Entities;
    using LibraryManagement.DAL.EntityModelTranslator;
    using LibraryManagement.DAL.Repositories;
    using LibraryManagement.DAL.ViewModelTransalator;
    using LibraryManagement.Entities;
    using LibraryManagement.Models;

    using Autofac.Integration.Mvc;

    using LibraryManagement.Services;
    using LibraryManagement.ViewModels;

    using Unity.Mvc4;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            this.RegistorComponents();
            //var container = new UnityContainer();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }


        private void RegistorComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));

            // Controller manager
            builder.RegisterFilterProvider();

            //******************* Account Controller
            //1. UserService 
            //IRepository<UserEntity> userRepository,IRepository<RoleEntity> roleRepository,ITransalator<UserEntity, UserModel> userTransalator
            builder.RegisterType<AccountController>().InstancePerHttpRequest();

            builder.RegisterType<UserRepository>().As<IRepository<UserEntity>>();
            builder.RegisterType<RoleRepository>().As<IRepository<RoleEntity>>();
            builder.RegisterType<UserTransalator>().As<ITransalator<UserEntity, UserModel>>();
            builder.Register(c => new UserService(c.Resolve<IRepository<UserEntity>>(), c.Resolve<IRepository<RoleEntity>>(),
                       c.Resolve<ITransalator<UserEntity, UserModel>>())).As<IUserService>();

            //2. UserViewModelTranslator
            builder.RegisterType<UserViewModelTransalator>().As<IViewModelTransalator<UserViewModel, UserModel>>();

            //3. AccountController
            builder.Register(c => new AccountController(c.Resolve<IUserService>(), c.Resolve<UserViewModelTransalator>())).As<Controller>();

            //******************* Search Controller
            builder.RegisterType<SearchController>().InstancePerHttpRequest();

            builder.RegisterType<BookMetadataViewModelTransalator>().As<IViewModelTransalator<BookMetadataViewModel, BookMetadataModel>>();

            builder.RegisterType<BookMetadataRepository>().As<MetadataRepository<BookMetadataEntity>>();
            builder.RegisterType<BookMetadataTransalator>().As<ITransalator<BookMetadataEntity, BookMetadataModel>>();
            builder.Register(c => new BookMetadataService(c.Resolve<MetadataRepository<BookMetadataEntity>>(),
                c.Resolve<ITransalator<BookMetadataEntity, BookMetadataModel>>())).As<IBookMetadataService>();

            //private IBookService bookService;

            builder.RegisterType<BookRepository>().As<ItemRepository<BookEntity>>();
            builder.RegisterType<BookTransalator>().As<ITransalator<BookEntity, BookModel>>();
            builder.RegisterType<BookMetadataRepository>().As<MetadataRepository<BookMetadataEntity>>();
            builder.Register(c => new BookService(c.Resolve<ItemRepository<BookEntity>>(),
                c.Resolve<MetadataRepository<BookMetadataEntity>>(),
                c.Resolve<ITransalator<BookEntity, BookModel>>(),
                c.Resolve<ITransalator<BookMetadataEntity, BookMetadataModel>>())).As<IBookService>();


            //private ILendingService lendingService;
            builder.RegisterType<LendingRepository>().As<IRepository<LendingEntity>>();
            builder.RegisterType<LendingTransalator>().As<ITransalator<LendingEntity, LendingModel>>();
            builder.Register(c => new LendingService(c.Resolve<ItemRepository<BookEntity>>(),
                c.Resolve<ITransalator<BookEntity, BookModel>>(),
                c.Resolve<IRepository<LendingEntity>>(),
                c.Resolve<ITransalator<LendingEntity, LendingModel>>())).As<ILendingService>();

            //private IUserService userService;                        
            builder.Register(c => new SearchController(c.Resolve<IUserService>(),
                c.Resolve<IViewModelTransalator<BookMetadataViewModel, BookMetadataModel>>(),
                c.Resolve<IBookMetadataService>(),
                c.Resolve<ILendingService>(),
                c.Resolve<IBookService>()
            )).As<Controller>();

            //******************* LendingController           
            builder.Register(c => new LendingController(c.Resolve<IBookService>(),
                c.Resolve<ILendingService>(),
                c.Resolve<IBookMetadataService>()
            )).As<Controller>();
            builder.RegisterType<LendingController>().InstancePerHttpRequest();

            //******************* BookController           
            builder.Register(c => new BookController(c.Resolve<IViewModelTransalator<BookMetadataViewModel, BookMetadataModel>>(),
                c.Resolve<IBookMetadataService>(),
                c.Resolve<IBookService>()
            )).As<Controller>();
            builder.RegisterType<BookController>().InstancePerHttpRequest();

            //******************* TemplateController
            builder.RegisterType<TemplateController>().InstancePerHttpRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
