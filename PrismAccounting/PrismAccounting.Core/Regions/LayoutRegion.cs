using Prism.Mvvm;
using System;
using System.ComponentModel;
using System.Windows;

namespace PrismAccounting.Core.Regions;

public class LayoutRegion : BindableBase
{
    public LayoutRegion(string name, GridLength? width, GridLength? height, bool visible = true, int gridColumn = 0, int gridRow = 0, int gridColSpans = 1, int gridRowSpans = 1)
    {
        NameProperty = name;
        if (width == null)
            WidthProperty = new GridLength(1, GridUnitType.Star);
        if (height == null)
            HeightProperty = new GridLength(1, GridUnitType.Star);
        GridColumnProperty = gridColumn;
        GridRowProperty = gridRow;
        GridColSpansProperty = gridColSpans;
        GridRowSpansProperty = gridRowSpans;
        VisibleProperty = visible;
    }



    private string _name;
    public string NameProperty
    {
        get { return _name; }
        set { SetProperty(ref _name, value); }
    }
    private bool _visible = true;
    public bool VisibleProperty
    {
        get { return _visible; }
        set { SetProperty(ref _visible, value); }
    }

    private GridLength _height = new GridLength(1, GridUnitType.Star);
    public GridLength HeightProperty
    {
        get { return _height; }
        set { SetProperty(ref _height, value); }
    }

    private GridLength _width = new GridLength(1, GridUnitType.Star);
    public GridLength WidthProperty
    {
        get { return _width; }
        set { SetProperty(ref _width, value); }
    }

    private int _gridColSpans = 1;
    public int GridColSpansProperty
    {
        get { return _gridColSpans; }
        set { SetProperty(ref _gridColSpans, value); }
    }

    private int _gridColumn = 0;
    public int GridColumnProperty
    {
        get { return _gridColumn; }
        set { SetProperty(ref _gridColumn, value); }
    }

    private int _gridRowSpans = 1;
    public int GridRowSpansProperty
    {
        get { return _gridRowSpans; }
        set { SetProperty(ref _gridRowSpans, value); }
    }

    private int _gridRow = 0;
    public int GridRowProperty
    {
        get { return _gridRow; }
        set { SetProperty(ref _gridRow, value); }
    }

    private bool _collapsed = false;
    public bool CollapsedProperty
    {
        get { return _collapsed; }
        set { SetProperty(ref _collapsed, value); }
    }

    private bool Show => _visible = true;
    private bool Hide => _visible = false;
    private bool IsVisible => _visible;

    private bool Collapse => _collapsed = true;
    private bool Expand => _collapsed = false;
    private bool IsCollapsed => _collapsed;
    private bool IsExpanded => !IsCollapsed;

    //public event PropertyChangedEventHandler PropertyChanged;

    //private void OnPropertyChanged(string info)
    //{
    //  PropertyChangedEventHandler handler = PropertyChanged;
    //  if (handler != null)
    //  {
    //    handler(this, new PropertyChangedEventArgs(info));
    //  }
    //}
}
