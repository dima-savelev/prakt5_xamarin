using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private bool _number = false;
        private bool _operation = false;
        private bool _comma = false;
        private bool _error = false;
        private bool _zeroAhead = false;
        private void Number_Clicked(object sender, EventArgs e)
        {
            string temp = calculator.Text;
            string digits = "123456789,";
            string operations = "×÷-+";
            if (_zeroAhead)
            {
                return;
            }
            if (calculator.Text.LastIndexOf("0") == 0 && calculator.Text.Length == 1)
            {
                calculator.Text = "";
            }
            Button button = sender as Button;
            if (_error)
            {
                calculator.Text = button.Text;
                _error = false;
                return;
            }
            switch(button.Text)
            {
                case "1":
                    calculator.Text += button.Text;
                    break;
                case "2":
                    calculator.Text += button.Text;
                    break;
                case "3":
                    calculator.Text += button.Text;
                    break;
                case "4":
                    calculator.Text += button.Text;
                    break;
                case "5":
                    calculator.Text += button.Text;
                    break;
                case "6":
                    calculator.Text += button.Text;
                    break;
                case "7":
                    calculator.Text += button.Text;
                    break;
                case "8":
                    calculator.Text += button.Text;
                    break;
                case "9":
                    calculator.Text += button.Text;
                    break;
                case "0":
                    if (calculator.Text == "")
                    {
                       calculator.Text += button.Text;
                       return;
                    }
                    else
                    {
                        if (_operation == false)
                        {
                            if (operations.IndexOf(temp[temp.Length - 1]) != -1)
                            {
                                calculator.Text += button.Text;
                                _operation = true;
                                _number = false;
                                _zeroAhead = true;
                                return;
                            }
                        }
                        else
                        {
                            _operation = false;
                            calculator.Text += button.Text;
                            _zeroAhead = true;
                            return;
                        }
                        if (_number == false)
                        {
                            if (digits.IndexOf(temp[temp.Length - 1]) != -1)
                            {
                                calculator.Text += button.Text;
                                _number = true;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            calculator.Text += button.Text;
                        }

                    }
                    break;
            }
        }

        private void Operations_Clicked(object sender, EventArgs e)
        {
            string number = "1234567890";
            string operations = "×÷-+";
            string comma = ",";
            string temp = calculator.Text;
            Button button = sender as Button;
            if (operations.IndexOf(temp[temp.Length - 1]) != -1 && operations.IndexOf(button.Text) != -1)
            {
                temp = temp.Remove(temp.Length - 1);
                temp += button.Text;
                calculator.Text = temp;
                return;
            }
            switch (button.Text)
            {
                case "÷":
                    if (number.IndexOf(temp[temp.Length - 1]) == -1)
                    {
                        return;
                    }
                    calculator.Text += button.Text;
                    _comma = false;
                    _zeroAhead = false;
                    break;
                case "×":
                    if (number.IndexOf(temp[temp.Length - 1]) == -1)
                    {
                        return;
                    }
                    calculator.Text += button.Text;
                    _comma = false;
                    _zeroAhead = false;
                    break;
                case "-":
                    if (number.IndexOf(temp[temp.Length - 1]) == -1)
                    {
                        return;
                    }
                    calculator.Text += button.Text;
                    _comma = false;
                    _zeroAhead = false;
                    break;
                case "+":
                    if (number.IndexOf(temp[temp.Length - 1]) == -1)
                    {
                        return;
                    }
                    calculator.Text += button.Text;
                    _comma = false;
                    _zeroAhead = false;
                    break;
                case ",":
                    if (calculator.Text.Length > 1 && Convert.ToString(temp[temp.Length - 1]) == "0" && operations.IndexOf(temp[temp.Length - 2]) != -1)
                    {
                        _zeroAhead = false;
                    }
                    if (number.IndexOf(temp[temp.Length - 1]) == -1)
                    {
                        return;
                    }
                    if (_comma == false)
                    {
                        _operation = false;
                        calculator.Text += button.Text;
                        _comma = true;
                    }
                    else return;
                    break;
                case "AC":
                    calculator.Text = "0";
                    _number = false;
                    _operation = false;
                    _comma = false;
                    _zeroAhead = false;
                    break;
                case "Del":
                    if (calculator.Text == "Делить на ноль нельзя")
                    {
                        calculator.Text = "0";
                        _number = false;
                        _operation = false;
                        _comma = false;
                        _zeroAhead = false;
                        return;
                    }
                    if (calculator.Text.Length > 2 && Convert.ToString(temp[temp.Length - 1]) == "," && Convert.ToString(temp[temp.Length - 2]) == "0")
                    {
                        _zeroAhead = true;
                    }
                    if (calculator.Text.Length > 2 && Convert.ToString(temp[temp.Length - 1]) == "0" && operations.IndexOf(temp[temp.Length - 2]) != -1)
                    {
                        _zeroAhead = false;
                    }
                    if (calculator.Text.Length > 2 && Convert.ToString(temp[temp.Length - 2]) == "0" && operations.IndexOf(temp[temp.Length - 1]) != -1)
                    {
                        _zeroAhead = true;
                    }
                    if (calculator.Text.LastIndexOf("0") == 0 && calculator.Text.Length == 1)
                    {
                        return;
                    }
                    if (calculator.Text.Length == 1)
                    {
                        calculator.Text = "0";
                        return;
                    }
                    if (calculator.Text.Length == 2 && operations.IndexOf(temp[temp.Length - 2]) != -1)
                    {
                        calculator.Text = "0";
                        return;
                    }
                    if (operations.IndexOf(temp[temp.Length - 1]) != -1)
                    {
                        _operation = false;
                        _number = true;
                    }
                    if (comma.IndexOf(temp[temp.Length - 1]) != -1)
                    {
                        _comma = false;
                    }
                    temp = temp.Remove(temp.Length - 1);
                    calculator.Text = temp;
                    break;
                case "=":
                    if (operations.IndexOf(temp[temp.Length - 1]) != -1)
                    {
                        temp = temp.Remove(temp.Length - 1);
                    }
                    _zeroAhead = false;
                    _operation = false;
                    _number = true;
                    temp = temp.Replace("×", "*");
                    temp = temp.Replace("÷", "/");
                    temp = temp.Replace(",", ".");
                    try
                    {
                        if (_error)
                        {
                            return;
                        }
                        var result = new DataTable().Compute(temp, null);
                        if (Convert.ToString(result) == "бесконечность" || Convert.ToString(result) == "-бесконечность" || Convert.ToString(result) == "не число")
                        {
                            calculator.Text = "Делить на ноль нельзя";
                            _error = true;
                            return;
                        }
                        calculator.Text = Convert.ToString(result);
                        if (calculator.Text.IndexOf(comma) != -1)
                        {
                            _comma = true;
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        calculator.Text = "Делить на ноль нельзя";
                        _error = true;
                    }
                    catch (OverflowException)
                    {
                        calculator.Text = "Куда так много";
                        _error = true;
                    }
                    break;
            }
        }
    }
}
