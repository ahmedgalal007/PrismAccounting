using System;
using System.ComponentModel;
using System.Windows;

namespace PrismAccounting.Core;

public class LayoutRegion: INotifyPropertyChanged
{
  public LayoutRegion(string name, GridLength? width, GridLength? height, bool visible = true, int gridColumn = 0, int gridRow = 0, int gridColSpans = 1, int gridRowSpans = 1)
  {
    NameProperty = name;
    if (width == null)
      WidthProperty = new GridLength(100, GridUnitType.Star);
    if (height == null)
      HeightProperty = new GridLength(100, GridUnitType.Star);
    GridColumnProperty = gridColumn;
    GridRowProperty = gridRow;
    GridColSpansProperty = gridColSpans;
    GridRowSpansProperty = gridRowSpans;
    VisibleProperty = visible;
  }
  private string _name { get; set; }
  private bool _visible { get; set; } = true;
  private GridLength _height { get; set; } = new GridLength();
  private GridLength _width { get; set; } = new GridLength();
  private int _gridColSpans { get; set; }
  private int _gridColumn { get; set; }
  private int _gridRowSpans { get; set; }
  private int _gridRow { get; set; }
  private bool Show => _visible = true;
  private bool Hide => _visible = false;

  public String NameProperty
  {
    get { return _name; }
    set
    {
      _name = value;
      OnPropertyChanged("NameProperty");
    }
  }
  public bool VisibleProperty
  {
    get { return _visible; }
    set
    {
      _visible = value;
      OnPropertyChanged("VisibleProperty");
    }
  }
  public GridLength HeightProperty
  {
    get { return _height; }
    set
    {
      _height = value;
      OnPropertyChanged("HeightProperty");
    }
  }
  public GridLength WidthProperty
  {
    get { return _width; }
    set
    {
      _width = value;
      OnPropertyChanged("WidthProperty");
    }
  }
  public int GridColSpansProperty
  {
    get { return _gridColSpans; }
    set
    {
      _gridColSpans = value;
      OnPropertyChanged("GridColSpansProperty");
    }
  }
  public int GridColumnProperty
  {
    get { return _gridColumn; }
    set
    {
      _gridColumn = value;
      OnPropertyChanged("GridColumnProperty");
    }
  }
  public int GridRowSpansProperty
  {
    get { return _gridRowSpans; }
    set
    {
      _gridRowSpans = value;
      OnPropertyChanged("GridRowSpansProperty");
    }
  }
  public int GridRowProperty
  {
    get { return _gridRow; }
    set
    {
      _gridRow = value;
      OnPropertyChanged("GridRowProperty");
    }
  }
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
