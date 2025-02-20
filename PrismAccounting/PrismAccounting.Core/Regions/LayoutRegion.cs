using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Windows;

namespace PrismAccounting.Core.Regions;

public class LayoutRegion : DependencyObject, INotifyPropertyChanged
{
  public LayoutRegion(string name, GridLength? width, GridLength? height, bool visible = true, int gridColumn = 0, int gridRow = 0, int gridColSpans = 1, int gridRowSpans = 1)
  {
    NameProperty = name;
    if (width == null)
      Width = new GridLength(1, GridUnitType.Star);
    if (height == null)
      Height = new GridLength(1, GridUnitType.Star);
    // GridColumn = gridColumn;
    SetValue(GridColumnProperty, gridColumn);
    SetValue(GridRowProperty, gridRow);
    GridColSpansProperty = gridColSpans;
    GridRowSpansProperty = gridRowSpans;
    VisibleProperty = visible;
  }



  private string _name;
  public string NameProperty
  {
    get { return _name; }
    set { 
      // SetProperty(ref _name, value);
      _name = value;
      OnPropertyChanged(nameof(NameProperty));
    }
  }
  private bool _visible = true;
  public bool VisibleProperty
  {
    get { return _visible; }
    set { 
      // SetProperty(ref _visible, value);
      _visible = value;
      OnPropertyChanged(nameof(VisibleProperty));
    }
  }

  private GridLength _height;
  public static readonly DependencyProperty HeightProperty =
      DependencyProperty.Register("Height",
      typeof(GridLength), typeof(LayoutRegion),
      new PropertyMetadata(new GridLength(1, GridUnitType.Star)));
  public GridLength Height
  {
    get { return _height; }
    set { 
      // SetProperty(ref _height, value);
      _height = value;
      OnPropertyChanged(nameof(Height));
    }
  }

  private GridLength _width;
  public static readonly DependencyProperty WidthProperty =
    DependencyProperty.Register("Width",
    typeof(GridLength), typeof(LayoutRegion),
    new PropertyMetadata(new GridLength(1, GridUnitType.Star)));
  public GridLength Width
  {
    get { return _width; }
    set { 
      // SetProperty(ref _width, value);
      _width = value;
      OnPropertyChanged(nameof(Width));
    }
  }

  private int _gridColSpans = 1;
  public int GridColSpansProperty
  {
    get { return _gridColSpans; }
    set { 
      // SetProperty(ref _gridColSpans, value);
      _gridColSpans = value;
      OnPropertyChanged(nameof(GridColSpansProperty));
    }
  }

  // private int _gridColumn = 0;

  public static readonly DependencyProperty GridColumnProperty =
        DependencyProperty.Register("GridColumn",
        typeof(int), typeof(LayoutRegion),
        new PropertyMetadata(default(int)));
  public int GridColumn
  {
    get { return (int)GetValue(GridColumnProperty); }
    set {
      // SetProperty(ref _gridColumn, value);
      SetValue(GridColumnProperty, value);
      OnPropertyChanged(nameof(GridColumnProperty));
    }
  }

  private int _gridRowSpans = 1;
  public int GridRowSpansProperty
  {
    get { return _gridRowSpans; }
    set {
      // SetProperty(ref _gridRowSpans, value);
      _gridRowSpans = value;
      OnPropertyChanged(nameof(GridRowSpansProperty));
    }
  }

  public static readonly DependencyProperty GridRowProperty =
      DependencyProperty.Register("GridRow",
      typeof(int), typeof(LayoutRegion),
      new PropertyMetadata(default(int)));
  public int GridRow
  {
    get { return (int)GetValue(GridRowProperty); }
    set
    {
      // SetProperty(ref _gridColumn, value);
      SetValue(GridRowProperty, value);
      OnPropertyChanged(nameof(GridRowProperty));
    }
  }

  private bool _collapsed = false;
  public bool CollapsedProperty
  {
    get { return _collapsed; }
    set {
      // SetProperty(ref _collapsed, value);
      _collapsed = value;
      OnPropertyChanged(nameof(CollapsedProperty));
    }
  }

  private bool Show => _visible = true;
  private bool Hide => _visible = false;
  private bool IsVisible => _visible;

  private bool Collapse => _collapsed = true;
  private bool Expand => _collapsed = false;
  private bool IsCollapsed => _collapsed;
  private bool IsExpanded => !IsCollapsed;

  public event PropertyChangedEventHandler PropertyChanged;

  private void OnPropertyChanged(string info)
  {
    PropertyChangedEventHandler handler = PropertyChanged;
    if (handler != null)
    {
      handler(this, new PropertyChangedEventArgs(info));
    }
  }
}
