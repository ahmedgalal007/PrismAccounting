﻿using PrismAccounting.Core;
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
    InitializeComponent();
    // _layoutManager.Bind(Main);

  }
}
