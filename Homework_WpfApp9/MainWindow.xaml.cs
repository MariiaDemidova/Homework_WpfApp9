using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("White.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }

            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as String;
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);
            }
        }
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
            {
                textBox.FontSize = (double)fontSize;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.FontWeight != FontWeights.UltraBold)
            {
                textBox.FontWeight = FontWeights.UltraBold;
            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle != FontStyles.Italic)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations != TextDecorations.Underline)
            {
                textBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                textBox.TextDecorations = null;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Red;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                if (styleBox.SelectedIndex == 0)
                {
                    textBox.Foreground = Brushes.Black;
                }
                else
                {
                    textBox.Foreground = Brushes.White;
                }
            }
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (of.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(of.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (sf.ShowDialog() == true)
            {
                File.WriteAllText(sf.FileName, textBox.Text);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
