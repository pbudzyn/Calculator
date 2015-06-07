using AnalizerClass;
using CalcClass;
using System;
using System.Collections.Generic;
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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Analizer calc = new Analizer();

            Output.Text = calc.Estimate(Input.Text);
        }

        #region clava bind

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Input.Text += '1';
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Input.Text += '2';
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Input.Text += '3';
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Input.Text += '4';
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Input.Text += '5';
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Input.Text += '6';
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Input.Text += '7';
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Input.Text += '8';
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Input.Text += '9';
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Input.Text += '0';
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Input.Text += '/';
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Input.Text += '*';
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Input.Text += '-';
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Input.Text += '+';
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Input.Text += 'm';
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (Input.Text[Input.Text.Length - 1] == '-')
            {
                Input.Text = Input.Text.Remove(Input.Text.Length - 1);
                Input.Text += '+';
            }
            else
            {
                if (Input.Text[Input.Text.Length - 1] == '+')
                {
                    Input.Text = Input.Text.Remove(Input.Text.Length - 1);
                    Input.Text += '-';
                }
            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Input.Text = "";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Input.Text = Input.Text.Remove(Input.Text.Length - 1);
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Input.Text += ')';
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Input.Text += '(';
        }

        #endregion
    }
}
