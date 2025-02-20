using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrismAccounting.Core.UI;
public static class LayoutGridUtility
{
  static ref T LRef<T>(ref T y) { return ref y; }
  static ref ColumnDefinition ColRef(ref ColumnDefinition y) { return ref y; }
  static ref RowDefinition RowRef(ref RowDefinition y) { return ref y; }
  public static ColumnDefinition AddGridColumnDefinition(ref Grid grid, GridLength width, int index = 0, string Name = "")
  {
    ColumnDefinition col = new ColumnDefinition();
    ref ColumnDefinition colRef = ref col;
    col.Width = width;
    if (!string.IsNullOrEmpty(Name)) col.Name = Name;
    grid.ColumnDefinitions.Insert(index, colRef);

    return colRef;
  }

  public static void RemoveGridColumnDefinition(ref Grid grid, int index)
  {
    grid.ColumnDefinitions.RemoveAt(index);
  }

  public static RowDefinition AddGridRowDefinition(ref Grid grid, GridLength height, int index = 0, string Name = "")
  {
    RowDefinition row = new RowDefinition();
    ref RowDefinition rowRef = ref row;
    row.Height = height;
    if (!string.IsNullOrEmpty(Name)) row.Name = Name;
    grid.RowDefinitions.Insert(index, rowRef);
    return rowRef;
  }

  public static void RemoveGridRowDefinition(ref Grid grid, int index)
  {
    grid.RowDefinitions.RemoveAt(index);
  }

  public static GridLength ToGridLength(this string str)
  {
    if (str == "*")
    {
      return new GridLength(1, GridUnitType.Star);
    }
    else if (str.Length > 1 && str.EndsWith('*'))
    {
      return new GridLength(double.TryParse(str.Replace("*", ""), out double rslt2) ? rslt2 : 1, GridUnitType.Star);
    }
    else if (double.TryParse(str, out double rslt2))
    {
      return new GridLength(rslt2);
    }
    return new GridLength(1, GridUnitType.Auto);
  }

  public static bool IsGridLength(this string str)
  {
    //if (str == "*")
    //{
    //  return true;
    //}
    //else if (str.Length > 1 && str.EndsWith('*'))
    //{
    //  return double.TryParse(str.Replace("*", ""), out double rslt2);
    //}
    //else if (double.TryParse(str, out double rslt2))
    //{
    //  return true;
    //}
    // return false;
    return str == "*" ||
      double.TryParse(str, out double x1) ||
      (str.EndsWith('*') ? double.TryParse(str.Replace("*", ""), out double x2) : false);

  }
}
