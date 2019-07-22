using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Kalkulator
{
    enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Exponentiation,
        SquareRoot,
        Logarithm,
        Modulo,
        Factorial,

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            History.ItemsSource = calcHistory;
        }

        double register = 0;
        Operation operation;
        bool lastOperation = false;
        ObservableCollection<string> calcHistory = new ObservableCollection<string>();

        public void ButtonNumberClick(object sender, RoutedEventArgs e)
        {
            if (lastOperation)
            {
                Display.Text = ((Button)sender).Content.ToString();
            }
            else
            {
                if (Display.Text == "0")
                {
                    if (((Button)sender).Content.ToString() != "0")
                    {
                        Display.Text = ((Button)sender).Content.ToString();
                    }
                }
                else
                {
                    Display.Text += ((Button)sender).Content.ToString();
                }
            }

            lastOperation = false;
        }

        private void ButtonOperationClick(object sender, RoutedEventArgs e)
        {
            register = double.Parse(Display.Text);

            switch (((Button)sender).Tag.ToString())
            {
                case "Addition":
                    operation = Operation.Addition;
                    break;
                case "Subtraction":
                    operation = Operation.Subtraction;
                    break;
                case "Multiplication":
                    operation = Operation.Multiplication;
                    break;
                case "Division":
                    operation = Operation.Division;
                    break;
                case "Exponentiation":
                    operation = Operation.Exponentiation;
                    break;
                case "SquareRoot":
                    operation = Operation.SquareRoot;
                    break;
                case "Logarithm":
                    operation = Operation.Logarithm;
                    break;
                case "Modulo":
                    operation = Operation.Modulo;
                    break;
                case "Factorial":
                    operation = Operation.Factorial;
                    break;
                default:
                    break;
            }

            lastOperation = true;

        }

        private void ButtonResultClick(object sender, RoutedEventArgs e)
        {
            string historyRecord = string.Empty;

            switch (operation)
            {
                case Operation.Addition:
                    historyRecord = register.ToString() + " + " + Display.Text + " = ";
                    Display.Text = (register + double.Parse(Display.Text)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Subtraction:
                    historyRecord = register.ToString() + " - " + Display.Text + " = ";
                    Display.Text = (register - double.Parse(Display.Text)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Multiplication:
                    historyRecord = register.ToString() + " * " + Display.Text + " = ";
                    Display.Text = (register * double.Parse(Display.Text)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Division:
                    historyRecord = register.ToString() + " / " + Display.Text + " = ";
                    Display.Text = (register / double.Parse(Display.Text)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Exponentiation:
                    historyRecord = register.ToString() + "^" + Display.Text + " = ";
                    Display.Text = (Math.Pow(double.Parse(register), 2)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.SquareRoot:
                    historyRecord = "sqrt(" + Display.Text + ")" + " = ";
                    Display.Text = (Math.Sqrt(double.Parse(Display.Text))).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Logarithm:
                    historyRecord = "log10(" + Display.Text + ")" + " = ";
                    Display.Text = (Math.Log10(double.Parse(Display.Text))).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Modulo:
                    historyRecord = register.ToString() + " % " + Display.Text + " = ";
                    Display.Text = (register % double.Parse(Display.Text)).ToString();
                    historyRecord += Display.Text;
                    break;
                case Operation.Factorial:
                    historyRecord = Display.Text + "!" + " = ";
                    double result = 1;
                    double n = double.Parse(Display.Text);
                    for (int i = 1; i <= n; i++)
                    {
                        result *= i;
                    }
                    Display.Text = result.ToString();
                    historyRecord += Display.Text;
                    break;
                default:
                    break;
            }

            calcHistory.Add(historyRecord);
        }
       
        private void ButtonSignClick(object sender, RoutedEventArgs e)
        {
            if (Display.Text[0] == '-')
            {
                Display.Text = Display.Text.TrimStart('-');
            }
            else
            {
                Display.Text = "-" + Display.Text;
            }
        }

        private void ButtonDelimiterClick(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }
        }

        private void ButtonBackspaceClick(object sender, RoutedEventArgs e)
        {
            if (!lastOperation)
            {
                if (Display.Text.Length > 1)
                {
                    Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                }
                else
                {
                    Display.Text = "0";
                }
            }
        }

        private void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            register = 0;
            lastOperation = false;
        }

        private void ButtonClearEClick(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
        }
    }
}
