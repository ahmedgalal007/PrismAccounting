using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAccounting.Core;
using PrismAccounting.Modules.Layout.Views;

namespace PrismAccounting.Modules.Layout;
public class LayoutModule : IModule
{
  public IRegionManager _regionManager { get; }

  public LayoutModule(IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }


  public void OnInitialized(IContainerProvider containerProvider)
  {
    _regionManager.RequestNavigate(RegionNames.ContentRegion, "LayoutView");
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterForNavigation<LayoutView>();
  }
}