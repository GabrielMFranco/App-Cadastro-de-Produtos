using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace App_Cadastro_de_Produtos.Foundation;

internal static class ThemeManager {
	private static Color _mainBackgroundColorLight = Colors.White;
	private static Color _textColorLight = Colors.Black;
	private static Color _dataGridBackgroundLight = Color.FromRgb(0xF0, 0xF0, 0xF0);
	private static Color _textBoxBackgroundLight = Colors.White;
	private static Color _mainBackgroundColorDark = Color.FromRgb(0x21, 0x21, 0x21);
	private static Color _textColorDark = Colors.White;
	private static Color _dataGridBackgroundDark = Color.FromRgb(0x42, 0x42, 0x42);
	private static Color _textBoxBackgroundDark = Color.FromRgb(0x9E, 0x9E, 0x9E);

	public static void ChangeToDark() {
		Application.Current.Resources["MainBackgroundBrush"] = new SolidColorBrush(_mainBackgroundColorDark);
		Application.Current.Resources["TextBrush"] = new SolidColorBrush(_textColorDark);
		Application.Current.Resources["DataGridBackgroundBrush"] = new SolidColorBrush(_dataGridBackgroundDark);
		Application.Current.Resources["TextBoxBackgroundBrush"] = new SolidColorBrush(_textBoxBackgroundDark);
		Application.Current.Resources["DarkModeToggleContent"] = new TextBlock {
			Text = "🌜"
		};
	}
	public static void ChangeToLight() {
		Application.Current.Resources["MainBackgroundBrush"] = new SolidColorBrush(_mainBackgroundColorLight);
		Application.Current.Resources["TextBrush"] = new SolidColorBrush(_textColorLight);
		Application.Current.Resources["DataGridBackgroundBrush"] = new SolidColorBrush(_dataGridBackgroundLight);
		Application.Current.Resources["TextBoxBackgroundBrush"] = new SolidColorBrush(_textBoxBackgroundLight);
		Application.Current.Resources["DarkModeToggleContent"] = new TextBlock {
			Text = "☀"
		};
	}
}