using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EInvoicing.Clients.WPF.CustomControls
{
	/// <summary>
	/// Interaction logic for DataGridToolBarControl.xaml
	/// </summary>
	public partial class DataGridToolBarControl : UserControl
	{
		public static DependencyProperty AddCommandProperty = DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(DataGridToolBarControl), new PropertyMetadata(null, (s, ev) => { }, (s, ev) => true));
		public ICommand AddCommand { 
			get { return (ICommand)GetValue(AddCommandProperty); } 
			set { SetValue(AddCommandProperty, value); }
		}


		public static RoutedEvent onAddCommandEvent = EventManager.RegisterRoutedEvent("onAddCommand", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataGridToolBarControl));
		public event RoutedEventHandler onAddCommand
		{
			add { AddHandler(onAddCommandEvent, value); }
			remove { RemoveHandler(onAddCommandEvent,value); }
		}

		protected virtual void OnAddCommand()
		{
			RaiseEvent(new RoutedEventArgs(onAddCommandEvent, this));
		}
		public DataGridToolBarControl()
		{
			InitializeComponent();

			btnAdd.IsEnabled = AddCommand == null ? false: true;
			btnAdd.Command = btnAdd.IsEnabled?AddCommand:null;

			btnAdd.Click += (s,e) => OnAddCommand() ;
		}
	}
}
