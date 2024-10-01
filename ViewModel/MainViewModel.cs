using App_Cadastro_de_Produtos.Foundation;
using App_Cadastro_de_Produtos.Fundation;
using App_Cadastro_de_Produtos.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.ComponentModel;

namespace CadastroDeProdutos.ViewModel {
	public class MainViewModel : ObservableObject {
		public MainViewModel() {
			Product = new ObservableCollection<Products>();
			AddProductCommand = new RelayCommand(AddProduct);
			DeleteProductCommand = new RelayCommand<Products>(DeleteProduct);
			NewProductExpirationDate = DateTime.Today;
			SaveCommand = new RelayCommand(SaveProducts);
			LoadProductsCommand = new RelayCommand(LoadProducts);
			LoadProducts();
			IsDarkMode = false;
		}

		public ObservableCollection<Products> Product { get; }
		public string NewProductName {
			get => Get<string>();
			set => Set(value);
		}
		public int NewProductUnits {
			get => Get<int>();
			set => Set(value);
		}
		public decimal NewProductPrice {
			get => Get<decimal>();
			set => Set(value);
		}
		public bool IsDarkMode {
			get => Get<bool>();
			set {
				if (Set(value)) {
					if (IsDarkMode) {
						ThemeManager.ChangeToDark();
						return;
					}
					ThemeManager.ChangeToLight();
				}
			}
		}	
		public bool UnsavedItems {
			get {
				string currentContent = JsonConvert.SerializeObject(Product);
				return currentContent != _lastSavedContent;
			}
		}
		public string ErrorMessage {
			get => Get<string>();
			set {
				Set(value);
				NotifyPropertyChanged(nameof(IsErrorVisible));
			}
		}
		public bool IsErrorVisible => !string.IsNullOrEmpty(ErrorMessage);
		public DateTime NewProductExpirationDate {
			get => Get<DateTime>();
			set => Set(value);
		}
		public ICommand AddProductCommand { get;}
		public ICommand DeleteProductCommand { get; }
		public ICommand SaveCommand { get; }
		public ICommand LoadProductsCommand { get; }
		private bool IsValid
			=> !string.IsNullOrWhiteSpace(NewProductName)
				&& NewProductUnits >= 0
				&& NewProductPrice > 0
				&& NewProductExpirationDate >= DateTime.Today;

		private readonly List<Products> _allProducts = [];
		private string _lastSavedContent = string.Empty;

		private void AddProduct() {
			if (IsValid) {
				Products item = CreateProduct();
				Product.Add(item);
				;
				ClearFields();
				NotifyPropertyChanged(nameof(UnsavedItems));
				ErrorMessage = string.Empty;
				return;
			}
			else { 
				ErrorMessage = "ERRO \nVerifique os dados";
			}
		}
		private void ClearFields() {
			NewProductName = string.Empty;
			NewProductPrice = NewProductUnits = 0;
			NewProductExpirationDate = DateTime.Today;
		}
		private Products CreateProduct() {
			Products item = new() {
				ProductName = NewProductName,
				ProductUnits = NewProductUnits,
				ProductPrice = NewProductPrice,
				ProductExpirationDate = NewProductExpirationDate,
			};
			return item;
		}
		private void DeleteProduct(Products product) {
			if (product != null) { 
				Product.Remove(product);
				NotifyPropertyChanged(nameof(UnsavedItems));
			}
		}
		private void SaveProducts() {
			string json = JsonConvert.SerializeObject(Product);
			File.WriteAllText("product.json", json);
			_lastSavedContent = json;
			NotifyPropertyChanged(nameof(UnsavedItems));
			MessageBox.Show("Salvo com sucesso");
		}
		private void LoadProducts() {
			ErrorMessage = string.Empty;
			if (File.Exists("product.json")) {
				string json = File.ReadAllText("product.json");
				ObservableCollection<Products> products = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
				if (products != null) {
					Product.Clear();
					foreach (Products product in products) {
						Product.Add(product);
						NotifyPropertyChanged(nameof(UnsavedItems));
					}
				}
			}
			_lastSavedContent = JsonConvert.SerializeObject(Product);
		}
	}
}

