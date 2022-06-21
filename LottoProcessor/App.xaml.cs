using Lotto.Data.Implementation;
using Lotto.Data.Interface;
using Lotto.Services.Implementation;
using Lotto.Services.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LottoProcessor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Singleton Injection Container
        public static Container Container { get; private set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrap();
        }

        private static void Bootstrap()
        {
            // Register your injections here

            // Repos
            Container.Register<ILottoRepository, LottoJSONRepository>(Lifestyle.Singleton);

            // Services
            Container.Register<ILottoDrawingsService, LottoDrawingsService>(Lifestyle.Singleton);
            Container.Register<ISkipService, SkipService>(Lifestyle.Singleton);
            Container.Register<IRelationshipService, RelationshipService>(Lifestyle.Singleton);

            Container.Verify();
        }
    }
}
