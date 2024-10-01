using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace App_Cadastro_de_Produtos.MarkupExtensions;

/// <summary>
/// Provides a binding aware of the user current culture.
/// </summary>
public class CultureAwareBinding : Binding {
	/// <summary>
	/// Creates the binding.
	/// </summary>
	public CultureAwareBinding() => ConverterCulture = CultureInfo.CurrentCulture;
	/// <summary>
	/// Creates the binding with the given path.
	/// </summary>
	/// <param name="path">Path to use.</param>
	public CultureAwareBinding(string path) : base(path) => ConverterCulture = CultureInfo.CurrentCulture;
}
