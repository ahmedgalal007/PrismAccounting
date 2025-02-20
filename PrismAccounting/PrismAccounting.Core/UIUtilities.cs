using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PrismAccounting.Core;
public static class UIUtilities
{
  public static Window GetWindow(DependencyObject element)
  {
    return Window.GetWindow(element);
  }
  public static void SetBinding(FrameworkElement target, DependencyProperty property, object source, string sourcePropertyName)
  {
    Binding myBinding = new Binding(sourcePropertyName);
    myBinding.Source = source;
    target.SetBinding(property, myBinding);
  }
  public static void SetBindingAttached(FrameworkElement target, DependencyProperty targetProperty, DependencyObject source, DependencyProperty sourceProperty)
  {
    //PropertyPath path = new PropertyPath("(0)", new object[] { targetProperty });
    //var binding = new Binding { Path = path };
    var binding = new Binding
    {
      Path = new PropertyPath(sourceProperty), // here
      Source = source
    };
    BindingOperations.SetBinding(target, targetProperty, binding);
  }
}
