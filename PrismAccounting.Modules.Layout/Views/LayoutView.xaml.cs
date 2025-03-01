using PrismAccounting.Core;
using PrismAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismAccounting.Modules.Layout.Views;
/// <summary>
/// Interaction logic for ViewA.xaml
/// </summary>
public partial class LayoutView : UserControl
{
  private ILayoutManager _layoutManager;
  public LayoutView(ILayoutManager layoutManager)
  {
    Resources.MergedDictionaries.Add(new ResourceDictionary()
    {
      Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml")
    });
    Resources.MergedDictionaries.Add(new ResourceDictionary()
    {
      Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml")
    }); Resources.MergedDictionaries.Add(new ResourceDictionary()
    {
      Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml")
    }); Resources.MergedDictionaries.Add(new ResourceDictionary()
    {
      Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml")
    });
    InitializeComponent();
    // _layoutManager.Bind(Main);

  }
}
