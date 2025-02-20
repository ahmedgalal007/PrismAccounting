using System;
using System.Windows.Controls;
using PrismAccounting.Core.Regions;

namespace PrismAccounting.Core.Interfaces;
public interface ILayoutManager
{
  public void AddLayoutRegion<T>(LayoutRegion region) where T : UserControl, new();
  public LayoutRegion GetRegionByName(string name);
  public void RegisterViewWithRegion(string regionName, Type viewType);
  public void RemoveLayoutRegion(string name); 
  public void SetContainer(Grid grid);

  public ref Grid GetGrid { get; }
}
