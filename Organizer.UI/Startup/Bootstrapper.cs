using Autofac;
using Organizer.DataAccess;
using Organizer.UI.Data;
using Organizer.UI.ViewModel;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.UI.Startup
{
   public class Bootstrapper
    {
        public IContainer Bootstrap()
        { 
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<OrganizerDbContext>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();

            return builder.Build();
        }

    }
}
