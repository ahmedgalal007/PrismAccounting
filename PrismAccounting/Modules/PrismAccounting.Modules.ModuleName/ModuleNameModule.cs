﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAccounting.Core.Regions;
using PrismAccounting.Modules.ModuleName.Views;

namespace PrismAccounting.Modules.ModuleName;
public class ModuleNameModule : IModule
{
  private readonly IRegionManager _regionManager;

  public ModuleNameModule(IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }

  public void OnInitialized(IContainerProvider containerProvider)
  {
    _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.RegisterForNavigation<ViewA>();
  }
}