using CadastroDeProdutos.ViewModel;
using System.Windows;

namespace App_Cadastro_de_Produtos {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			DataContext = new MainViewModel();
		}

		private void DataGrid_ColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e) {

		}
	}
}