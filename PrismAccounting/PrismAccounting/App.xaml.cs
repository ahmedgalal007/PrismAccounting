using Prism.Ioc;
using Prism.Modularity;
using PrismAccounting.Modules.ModuleName;
using PrismAccounting.Modules.Layout;
using PrismAccounting.Services;
using PrismAccounting.Services.Interfaces;
using PrismAccounting.Views;
using System.Windows;

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
  }

  protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
  {
    // moduleCatalog.AddModule<ModuleNameModule>();
    moduleCatalog.AddModule<LayoutModule>();
  }
}
