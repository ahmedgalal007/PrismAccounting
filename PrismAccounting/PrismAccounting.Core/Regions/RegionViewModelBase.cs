using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismAccounting.Core.Regions;
public class RegionViewModelBase: BindableBase
{
    public static readonly DependencyProperty LayoutRegionProperty =
        DependencyProperty.RegisterAttached("LayoutRegion",
        typeof(LayoutRegion), typeof(RegionViewModelBase),
        new PropertyMetadata(default(LayoutRegion)));

  public static void SetLayoutRegion(DependencyObject element, LayoutRegion value)
  {
    element.SetValue(LayoutRegionProperty, value);
  }

  public static LayoutRegion GetLayoutRegion(DependencyObject element)
  {
    return (LayoutRegion)element.GetValue(LayoutRegionProperty);
  }
}
