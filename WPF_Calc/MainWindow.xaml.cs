using System;
using System.Windows;
using System.Windows.Controls;


namespace WPF_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num1 = 0;
        int num2 = 0;
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String str = button.Content.ToString();
            int num = Int32.Parse(str);
            if (operation == "")
            {
                num1 = num1 * 10 + num;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 10 + num;
                txtValue.Text = num2.ToString();
            }
        }

        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            txtValue.Text = "";
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "min":
                    result = Math.Min(num1, num2);
                    break;
                case "max":
                    result = Math.Max(num1, num2);
                    break;
                case "avg":
                    result = (num1 + num2) / 2;
                    break;
                case "x^y":
                    result = (int)Math.Pow(num1, num2);
                    break;

            }
            txtValue.Text = result.ToString();
            operation = "";
            num1 = result;
            num2 = 0;
        }
        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operation = "";
            txtValue.Text = "";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "") num1 = 0;
            else num2 = 0;

            txtValue.Text = "0";
        }

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                num1 /= 10;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 /= 10;
                txtValue.Text = num2.ToString();
            }
        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                num1 *= -1;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtValue.Text = num2.ToString();
            }
        }
    }
}
