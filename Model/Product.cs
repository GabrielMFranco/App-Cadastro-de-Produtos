using App_Cadastro_de_Produtos.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Cadastro_de_Produtos.Model;

public class Products : ObservableObject {
	public string ProductName {
		get => Get<string>();
		set => Set(value); 
	}
	public decimal ProductPrice {
		get => Get<decimal>();
		set => Set(value);
	}
	public int ProductUnits {
		get => Get<int>();
		set => Set(value);
	}
	public DateTime ProductExpirationDate {
		get => Get<DateTime>();
		set => Set(value);
	}
}

