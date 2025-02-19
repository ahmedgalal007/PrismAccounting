using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAccounting.Core;
using PrismAccounting.Core.Interfaces;
using PrismAccounting.Modules.Layout.Views;
using System.Windows;

namespace PrismAccounting.Modules.Layout;
public class LayoutModule : IModule
{
  private readonly IRegionManager _regionManager;
  private readonly ILayoutManager _layoutManager;

  public LayoutModule(IRegionManager regionManager, ILayoutManager layoutManager)
  {
    _regionManager = regionManager;
    _layoutManager = layoutManager;
  }

  public void OnInitialized(IContainerProvider containerProvider)
  {
    _layoutManager.AddLayoutRegion(new SidebarView(), new LayoutRegion(RegionNames.SidebarRegion, new GridLength(100), new GridLength(100, GridUnitType.Star), true, 1, 1, 2, 2));
    _regionManager.RequestNavigate(RegionNames.ContentRegion, "LayoutView");
    _regionManager.RequestNavigate(RegionNames.SidebarRegion, "SidebarView");
    SidebarView view = containerProvider.Resolve<SidebarView>();
     _layoutManager.RegisterViewWithRegion(RegionNames.SidebarRegion, view.GetType());
    // _layoutManager.RegisterViewWithRegion(RegionNames.SidebarRegion, view.GetType());
    // _regionManager.RequestNavigate(RegionNames.SidebarRegion, "SidebarView");
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterForNavigation<LayoutView>();
    containerRegistry.RegisterForNavigation<SidebarView>();
  }
}