using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Modules.Layout.ViewModels;
internal class FooterViewModel : BindableBase
{
  private string _message;
  public string Message
  {
    get { return _message; }
    set { SetProperty(ref _message, value); }
  }

    public FooterViewModel()
    {
    Message = "This is Footer Region";
    }
}
