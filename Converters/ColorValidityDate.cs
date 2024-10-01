using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace App_Cadastro_de_Produtos.Converters;

public class ColorValidityDate : IValueConverter {
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
		if (value is DateTime validityDate) {
			if (validityDate < DateTime.Now) {
				return (SolidColorBrush)new BrushConverter().ConvertFromString("#EF5350");
			}
			else if (validityDate < DateTime.Now.AddDays(2)) {
				return (SolidColorBrush)new BrushConverter().ConvertFromString("#FFB74D");
			}
		}
		
		return (SolidColorBrush)new BrushConverter().ConvertFromString("#C5CAE9");
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
		throw new NotImplementedException();
	}
}

