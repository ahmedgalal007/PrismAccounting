using System;
using System.Windows.Controls;

namespace PrismAccounting.Core.Interfaces;
public interface ILayoutManager
{
  public void Bind(Grid grid);
  public void AddLayoutRegion(UserControl view, LayoutRegion region);
  public void RegisterViewWithRegion(string regionName, Type viewType);
  public void RemoveLayoutRegion(string name);
}
