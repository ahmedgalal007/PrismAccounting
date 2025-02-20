using Prism.Regions;
using PrismAccounting.Core.Interfaces;
using PrismAccounting.Core.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace PrismAccounting.Core;
public class LayoutManager : INotifyPropertyChanged, ILayoutManager
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
  public Grid LayoutGrid;
  public string LayoutName { get; set; }
  public GridLength Width { get; set; }
  public GridLength Height { get; set; }
  public Dictionary<string, LayoutRegion> LayoutRegions { get; set; } = new Dictionary<string, LayoutRegion>();

  #endregion


  #region Public Actions
  public ref Grid GetGrid
  {
    get
    {
      return ref LayoutGrid;
    }
  }

  public void AddLayoutRegion<T>(LayoutRegion region) where T : UserControl, new()
  {
    LayoutRegions[region.NameProperty] = region;
    AddregionToLayoutGrid<T>(region);
    OnPropertyChanged("AddLayoutRegion");
  }
  private void AddregionToLayoutGrid<T>(LayoutRegion region) where T : UserControl, new()
  {
    AddregionToLayoutGrid<T>(this._regionManager, this.LayoutGrid, region);
  }
  public LayoutRegion GetRegionByName(string name)
  {
    return LayoutRegions[name];
  }
  public void SetContainer(Grid grid)
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
  
  
  public static void AddregionToLayoutGrid<T>(IRegionManager regionManager, Grid grid, LayoutRegion region) where T : UserControl , new() 
  {
    // 1- Create and bind Panel to Region data
    var panel = new StackPanel();
    UIUtilities.SetBinding(panel, StackPanel.WidthProperty, region, nameof(region.WidthProperty));
    UIUtilities.SetBinding(panel, StackPanel.HeightProperty, region, nameof(region.HeightProperty));
    //panel.SetBinding(panel.Width ,new Binding($"LayoutRegions[{region.NameProperty}].Width");
    // UIUtilities.SetBindingAttached(panel, Grid.ColumnProperty, panel, region.GridColumnProperty);
    Grid.SetColumn(panel, region.GridColumnProperty);
    Grid.SetRow(panel, region.GridRowProperty);
    Grid.SetColumnSpan(panel, region.GridColSpansProperty);
    Grid.SetRowSpan(panel, region.GridRowSpansProperty);
    grid.Children.Add(panel);
    ContentControl contentControl = new ContentControl();
    panel.Children.Add(contentControl);

    RegionManager.SetRegionName(contentControl, region.NameProperty);
    regionManager.RegisterViewWithRegion(region.NameProperty, typeof(T));
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
