using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAccounting.Core.Regions;
using PrismAccounting.Core.Interfaces;
using PrismAccounting.Modules.Layout.Views;
using System.Windows;
using PrismAccounting.Core.UI;

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
    LayoutGridUtility.AddGridColumnDefinition(ref _layoutManager.GetGrid, "*".ToGridLength(), 0);
    LayoutGridUtility.AddGridColumnDefinition(ref _layoutManager.GetGrid, "6*".ToGridLength(), 1);
    LayoutGridUtility.AddGridColumnDefinition(ref _layoutManager.GetGrid, "4*".ToGridLength(), 2);
    LayoutGridUtility.AddGridColumnDefinition(ref _layoutManager.GetGrid, "10".ToGridLength(), 3);
    LayoutGridUtility.AddGridRowDefinition(ref _layoutManager.GetGrid, "100".ToGridLength(), 0);
    LayoutGridUtility.AddGridRowDefinition(ref _layoutManager.GetGrid, "*".ToGridLength(), 1);
    LayoutGridUtility.AddGridRowDefinition(ref _layoutManager.GetGrid, "60".ToGridLength(), 2);

    _layoutManager.AddLayoutRegion<SidebarView>(new LayoutRegion(RegionNames.SidebarRegion, "100".ToGridLength(), "100*".ToGridLength(), true, 1, 1, 2, 2));
    _layoutManager.AddLayoutRegion<FooterView>(new LayoutRegion(RegionNames.BottomDrawerRegion, "100".ToGridLength(), "100*".ToGridLength(), true, 0, 2, 4));
    _regionManager.RequestNavigate(RegionNames.ContentRegion, "LayoutView");
    var sidRegion = _layoutManager.GetRegionByName(RegionNames.SidebarRegion);
    sidRegion.GridColumn = 1;
    sidRegion.GridColSpansProperty = 1;
    // _regionManager.RequestNavigate(RegionNames.SidebarRegion, "SidebarView");
    //SidebarView view = containerProvider.Resolve<SidebarView>();
    // _layoutManager.RegisterViewWithRegion(RegionNames.SidebarRegion, view.GetType());
    // _layoutManager.RegisterViewWithRegion(RegionNames.SidebarRegion, view.GetType());
    // _regionManager.RequestNavigate(RegionNames.SidebarRegion, "SidebarView");
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterForNavigation<LayoutView>();
    containerRegistry.RegisterForNavigation<SidebarView>();
  }
}