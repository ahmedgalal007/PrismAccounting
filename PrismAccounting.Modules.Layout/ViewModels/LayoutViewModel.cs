using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Modules.Layout.ViewModels;
public class LayoutViewModel : BindableBase
{
  private string _message;
  public string Message
  {
    get { return _message; }
    set { SetProperty(ref _message, value); }
  }

  public LayoutViewModel()
  {
    Message = "Main View  from Layout Prism Module";
  }
}
