using PrismAccounting.Core.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace PrismAccounting.Views;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  public MainWindow(ILayoutManager layoutManager)
  {
    InitializeComponent();
    layoutManager.SetContainer(LayoutGrid);
  }
}
