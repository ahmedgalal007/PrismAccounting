using Prism.Ioc;
using Prism.Modularity;
using PrismAccounting.Modules.Layout;
using PrismAccounting.Services;
using PrismAccounting.Services.Interfaces;
using PrismAccounting.Views;
using System.Windows;
using PrismAccounting.Core;
using PrismAccounting.Core.Interfaces;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;
using Prism.Regions;
using System.Runtime;
using PrismAccounting.Core.Regions;

namespace PrismAccounting;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
  protected override Window CreateShell()
  {
    return Container.Resolve<MainWindow>();
  }

  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterSingleton<IMessageService, MessageService>();

    containerRegistry.RegisterSingleton<ILayoutManager, LayoutManager>();
    //containerRegistry.RegisterSingleton<ILayoutManager>(c => new LayoutManager(
    //        regionManager: c.Resolve<IRegionManager>(), 
    //        window: App.Current.MainWindow));
  }
    
  protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // moduleCatalog.AddModule<ModuleNameModule>();
    moduleCatalog.AddModule<LayoutModule>();
  }

  protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings mappings)
  {
    base.ConfigureRegionAdapterMappings(mappings);

    mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
  }
}
