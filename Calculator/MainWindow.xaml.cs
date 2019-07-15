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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //create new instance of calculation and set calculator to off by default
        Calculation newCalc = new Calculation();
        Boolean isOff = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        //turn calculator on
        private void onClick(object sender, RoutedEventArgs e)
        {
            setDisplay("On");
            isOff = false;
        }

        //turn calculator off
        private void offClick(object sender, RoutedEventArgs e)
        {
            setDisplay("Off");
            newCalc = new Calculation();
            isOff = true;
        }

        private void equalsClick(object sender, RoutedEventArgs e)
        {
            //check to make sure two numbers and operand have been selected
            if (newCalc.firstNum != -1 && newCalc.secondNum != -1 && newCalc.operand != ' ')
            {
                newCalc.calculateResult();

                //check if non-division result has been calculated
                if (newCalc.resultCalculated == true)
                {
                    setDisplay(newCalc.result.ToString());
                    newCalc = new Calculation();
                }
                //check if division result has been calculated
                else if (newCalc.resultCalculated == false && newCalc.divResultCalculated == true)
                {
                    setDisplay(newCalc.divResult.ToString());
                    newCalc = new Calculation();
                }
                //else user attempted to divide by 0
                else
                {
                    setDisplay("Error - cannot divide by 0");
                    newCalc = new Calculation();
                }
            }

            //display error if only one number has been selected and no operand
            else if (newCalc.firstNum != -1 && newCalc.secondNum == -1)
            {
                setDisplay("Error - no operation selected");
                newCalc = new Calculation();
            }
        }

        //clear display
        private void clearClick(object sender, RoutedEventArgs e)
        {
            setDisplay(" ");
            newCalc = new Calculation();
        }

        private void plusClick(object sender, RoutedEventArgs e)
        {
            checkOperand('+');
        }

        private void sevenClick(object sender, RoutedEventArgs e)
        {
            checkNum(7);
        }

        private void eightClick(object sender, RoutedEventArgs e)
        {
            checkNum(8);
        }

        private void nineClick(object sender, RoutedEventArgs e)
        {
            checkNum(9);
        }

        private void divideClick(object sender, RoutedEventArgs e)
        {
            checkOperand('/');
        }

        private void fourClick(object sender, RoutedEventArgs e)
        {
            checkNum(4);
        }

        private void fiveClick(object sender, RoutedEventArgs e)
        {
            checkNum(5);
        }

        private void sixClick(object sender, RoutedEventArgs e)
        {
            checkNum(6);
        }

        private void multiplyClick(object sender, RoutedEventArgs e)
        {
            checkOperand('*');
        }

        private void zeroClick(object sender, RoutedEventArgs e)
        {
            checkNum(0);
        }

        private void oneClick(object sender, RoutedEventArgs e)
        {
            checkNum(1);
        }

        private void twoClick(object sender, RoutedEventArgs e)
        {
            checkNum(2);
        }

        private void threeClick(object sender, RoutedEventArgs e)
        {
            checkNum(3);
        }

        private void minusClick(object sender, RoutedEventArgs e)
        {
            checkOperand('-');
        }

        //method to update string displayed
        public void setDisplay(string s)
        {
            display.Text = s;
        }

        //check number entered before assigning it to attribute of calculation
        private void checkNum(int i)
        {
            //check if calculator is on
            if (isOff == false)
            {
                //check if number has been assigned to first number attribute
                if (newCalc.firstNum == -1)
                {
                    newCalc.firstNum = i;
                    setDisplay(newCalc.firstNum.ToString());
                }
                //else check to see if number has been assigned to first number and operand has been selected
                else if (newCalc.secondNum == -1 && newCalc.operand != ' ')
                {
                    newCalc.secondNum = i;
                    setDisplay(newCalc.secondNum.ToString());
                }
                //else check to see if user is attempting more than one digit
                else
                {
                    setDisplay("Error - please only enter single digit numbers");
                    newCalc = new Calculation();
                }
            }
        }

        //check operand selected before assigning
        private void checkOperand(char c)
        {
            //check if calculator is off
            if (isOff == false)
            {
                //only assign operand if first number has been selected and second number has not been selected
                if (newCalc.firstNum == -1 || newCalc.secondNum != -1)
                {
                    setDisplay("Error");
                    newCalc = new Calculation();
                }

                else
                {
                    newCalc.operand = c;
                }
            }
        }
        
    }

    public class Calculation
    {
        //attributes
        public int firstNum;
        public char operand;
        public int secondNum;
        public int result;
        public double divResult;
        public Boolean resultCalculated;
        public Boolean divResultCalculated;

        //constructors
        public Calculation()
        {
            firstNum = -1;
            operand = ' ';
            secondNum = -1;
            result = -111;
            divResult = -111;
            resultCalculated = false;
            divResultCalculated = false;
        }

        public Calculation(int fN, char op, int sN, int r, double dR)
        {
            this.firstNum = fN;
            this.operand = op;
            this.secondNum = sN;
            this.result = r;
            this.divResult = dR;
            this.resultCalculated = false;
            this.divResultCalculated = false;
        }

        //calculate result of equation entered into calculator
        public void calculateResult()
        {
            if (operand == '+')
            {
                result = firstNum + secondNum;
                resultCalculated = true;
            }
            else if (operand == '-')
            {
                result = firstNum - secondNum;
                resultCalculated = true;
            }
            else if (operand == '*')
            {
                result = firstNum * secondNum;
                resultCalculated = true;
            }
            else if (operand == '/')
            {
                if (this.secondNum != 0)
                {
                    double first = Convert.ToDouble(firstNum);
                    double second = Convert.ToDouble(secondNum);

                    divResult = first / second;
                    divResultCalculated = true;
                }
                else
                {
                    resultCalculated = false;
                }
            }
        }
        

    }
}
