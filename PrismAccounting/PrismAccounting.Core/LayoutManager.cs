using Prism.Regions;
using PrismAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PrismAccounting.Core;
public class LayoutManager: INotifyPropertyChanged, ILayoutManager
{
  private readonly IRegionManager _regionManager;

  public LayoutManager(IRegionManager regionManager)
  {
    _regionManager = regionManager;
    // LayoutGrid = FindChild<Grid>(window, "LayoutGrid");
    //foreach (Grid grid in FindVisualChildren<Grid>(window))
    //{
    //  if (grid.Name == "LayoutGrid") LayoutGrid = grid;
    //}
  }

  #region Properities
  public Grid LayoutGrid { get; set; }
  public string LayoutName { get; set; }
  public GridLength Width { get; set; }
  public GridLength Height { get; set; }
  public Dictionary<string, LayoutRegion> LayoutRegions { get; set; } = new Dictionary<string, LayoutRegion>();

  #endregion


  #region Actions
  public void AddLayoutRegion(UserControl view, LayoutRegion region)
  {
    LayoutRegions[region.NameProperty] = region;
    AddregionToLayoutGrid(view,region);
    OnPropertyChanged("AddLayoutRegion");
  }
  private void AddregionToLayoutGrid(UserControl view, LayoutRegion region)
  {
    AddregionToLayoutGrid(this._regionManager, this.LayoutGrid,view, region);
  }
  public void Bind(Grid grid)
  {
    LayoutGrid = grid;
  }
  public void RegisterViewWithRegion(string regionName, Type viewType)
  {
    _regionManager.RegisterViewWithRegion(regionName, viewType);
  }
  public void RemoveLayoutRegion(string name)
  {
    LayoutRegions.Remove(name);
    OnPropertyChanged("RemoveLayoutRegion");
  }

  #endregion
  //public LayoutRegion TopMenu { get; set; } // , TopToolbar, Sidebar, HorizontalDrawer, VerticalDrawer

  public event PropertyChangedEventHandler PropertyChanged;

  private void OnPropertyChanged(string info)
  {
    PropertyChangedEventHandler handler = PropertyChanged;
    if (handler != null)
    {
      handler(this, new PropertyChangedEventArgs(info));
    }
  }

  
  #region Static Functions
  private static void SetBinding(FrameworkElement target, DependencyProperty property, object source, string sourcePropertyName)
  {
    Binding myBinding = new Binding(sourcePropertyName);
    myBinding.Source = source;
    // Bind the new data source to the myText TextBlock control's Text dependency property.
    target.SetBinding(property, myBinding);
  }

  public static void AddregionToLayoutGrid(IRegionManager regionManager, Grid grid, UserControl view, LayoutRegion region)
  {
    // 1- Create and bind Panel to Region data
    var panel = new StackPanel
    {
      Name = region.NameProperty,
      // Width = new Binding($"LayoutRegions[{region.NameProperty}].Width"),
    };

    SetBinding(panel, StackPanel.WidthProperty, region, nameof(region.WidthProperty));
    SetBinding(panel, StackPanel.HeightProperty, region, nameof(region.HeightProperty));
    //panel.SetBinding(panel.Width ,new Binding($"LayoutRegions[{region.NameProperty}].Width");
    Grid.SetColumn(panel, region.GridColumnProperty);
    Grid.SetRow(panel, region.GridRowProperty);
    Grid.SetColumnSpan(panel, region.GridColSpansProperty);
    Grid.SetRowSpan(panel, region.GridRowSpansProperty);
    grid.Children.Add(panel);
    ContentControl contentControl = new ContentControl();
    panel.Children.Add(contentControl);
    // 2- Create The ContentControl  

    // 3- Create Region and it To RegionManager
    /*
    regionManager.Regions.Add(region.NameProperty,new Region());
    IRegion newRegion = regionManager.Regions[region.NameProperty];

    newRegion.Add(view);
    newRegion.Activate(view);
    */
    // regionManager.RegisterViewWithRegion(region.NameProperty, view.GetType().Name);
    // IRegion rgn = regionManager.Regions[region.NameProperty];
    // rgn.Add(view);
    // rgn.Activate(view);


    // InboxView view = this.container.Resolve<InboxView>();
    // regionManager.AddToRegion(region.NameProperty, view);
    /*
    Binding myBinding = new Binding("ActiveViews");
    myBinding.Source = newRegion;
    // DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached("prism:RegionManager.RegionName", typeof(string), typeof(ContentControl), new PropertyMetadata(null));
    DependencyProperty RegionNameProperty = DependencyProperty.RegisterAttached("prism:RegionManager.RegionName", typeof(string), typeof(ContentControl), new PropertyMetadata());
    // DependencyProperty RegionNameProperty = DependencyProperty.Register("prism:RegionManager.RegionName", typeof(string), typeof(ContentControl));
    // DependencyProperty RegionNameProperty = DependencyProperty.Register("RegionName", typeof(string), typeof(ContentControl));
    contentControl.SetValue(RegionNameProperty, region.NameProperty);

    contentControl.SetBinding(ContentControl.ContentProperty, myBinding);
    // regionManager.RequestNavigate(region.NameProperty, view.GetType().Name);
    */
    RegionManager.SetRegionName(contentControl, region.NameProperty);
    regionManager.RegisterViewWithRegion(region.NameProperty, view.GetType().Name);
    // Prism.Regions.RegionManager.RegionNameProperty
    // panel.RegisterName(region.NameProperty, newRegion);

    // newRegion.Activate(view);
    // regionManager.RequestNavigate(region.NameProperty, view.GetType().Name);

    // newRegion.Activate(view);
  }
  public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
  {
    if (depObj != null)
    {
      for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
      {
        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        if (child != null && child is T)
        {
          yield return (T)child;
        }

        foreach (T childOfChild in FindVisualChildren<T>(child))
        {
          yield return childOfChild;
        }
      }
    }
  }


  private static T FindChild<T>(DependencyObject parent, string childName)
   where T : DependencyObject
  {
    // Confirm parent and childName are valid. 
    if (parent == null)
    {
      return null;
    }

    T foundChild = null;

    int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
    for (int i = 0; i < childrenCount; i++)
    {
      var child = VisualTreeHelper.GetChild(parent, i);
      // If the child is not of the request child type child
      T childType = child as T;
      if (childType == null)
      {
        // recursively drill down the tree
        foundChild = FindChild<T>(child, childName);

        // If the child is found, break so we do not overwrite the found child. 
        if (foundChild != null)
        {
          break;
        }
      }
      else if (!string.IsNullOrEmpty(childName))
      {
        var frameworkElement = child as FrameworkElement;
        // If the child's name is set for search
        if (frameworkElement != null && frameworkElement.Name == childName)
        {
          // if the child's name is of the request name
          foundChild = (T)child;
          break;
        }
      }
      else
      {
        // child element found.
        foundChild = (T)child;
        break;
      }
    }

    return foundChild;
  }

  
  #endregion


}
