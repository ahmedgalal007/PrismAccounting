using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismAccounting.Core.Regions;
public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
{
  public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
  {
  }

  protected override void Adapt(IRegion region, StackPanel regionTarget)
  {
    region.Views.CollectionChanged += (s, e) =>
    {
      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
      {
        foreach (FrameworkElement item in e.NewItems)
        {
          regionTarget.Children.Add(item);
        }
      }else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
      {
        foreach (FrameworkElement item in e.NewItems)
        {
          regionTarget.Children.Remove(item);
        }
      } 
    };
  }

  protected override IRegion CreateRegion() => new Region();
}
