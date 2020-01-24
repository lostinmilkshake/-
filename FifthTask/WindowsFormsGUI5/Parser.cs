using System;
using System.Collections.Generic;
using System.Linq;

namespace FifthTask
{
    class Bolzano
    {
        //Tolerance of minimum
        static double tol = 0.00000001;

        //Finding minimum
        public static double findMinimum(double a, double b, string rpnFunc, List<string> variables)
        {
            //Throws exception if we have unsatisfying points 
            if (derivative(rpnFunc, a, variables) * derivative(rpnFunc, b, variables) > 0)
                throw new Exception("Неверно введены интервалы поиска");
            double x; //Current point
            do
            {
                x = (a + b) / 2; //Finding x at this position
                //If derivative in x point is bigger than 0
                if (derivative(rpnFunc, x, variables) > 0)
                    //Than b becomes x
                    b = x;
                else
                    //Else a becomes x
                    a = x;
            } while ((Math.Abs(derivative(rpnFunc, x, variables)) >= tol) && (Math.Abs(b - a) >= tol));
            return x;
        }

        //Findin derivative in x point
        private static double derivative(string rpnFunc, double x, List<string> variables)
        {
            //Making an array for x + derivative tolerance
            double[] dx = new double[1];
            dx[0] = x + 1E-12;
            //Making an array for x point
            double[] xArr = new double[1];
            xArr[0] = x;
            //Finding f(x) and f(x+dx)
            double fxdx = RPN.CalculateRPN(rpnFunc, variables, dx);
            double fx = RPN.CalculateRPN(rpnFunc, variables, xArr);
            //Finding derivative
            double result = (fxdx - fx) / 1E-12;
            return result;
        }
    }
        class RPN
        {
            public static string toRPN(string infixString)
            {
                infixString = infixString.Replace(" ", ""); //Replacing all spaces
                if (!CheckInput.checkInputString(infixString)) //If we have wrong input string
                    throw new ArgumentException();            //Than throw exception
                Stack<char> operationStack = new Stack<char>(); //Stack for all operations
                char lastOperation; //Keeping last operation
                string resultString = ""; //String with result

                
                for (int i = 0; i < infixString.Length; i++)
                {
                    //If it is number, than add to resultString
                    if (SignChecker.isVariable(infixString[i]))
                    {
                        resultString += infixString[i];
                    }
                    //If it is operation
                    else if (SignChecker.isOperation(infixString[i]))
                        {
                            //If it is unary minus< then add 0 to result string
                            if (infixString[i] == '-' && (((i == 0) || (infixString[i-1] == '(')) && (SignChecker.isVariable(infixString[i+1]))))
                            {
                                resultString += 0;    
                            }
                            //If we have operations in stack
                            if (operationStack.Count != 0)
                            {
                                //Taking last operation of stack
                                lastOperation = operationStack.Peek();
                                //If priority of operation from stack is higher, then pirority of current operation
                                if (SignChecker.getOperationPriority(lastOperation) < SignChecker.getOperationPriority(infixString[i]))
                                {
                                    //Add current operation to stack
                                    operationStack.Push(infixString[i]);
                                    resultString += " ";
                                }
                                else
                                {
                                    //Add operation from stack to result string
                                    resultString += operationStack.Pop();
                                    //Add current operation to stack
                                    operationStack.Push(infixString[i]);
                                    resultString += " ";
                                }
                            }
                            else
                            {
                                //Add current operation to stack  
                                resultString += " ";
                                operationStack.Push(infixString[i]);
                            }
                        }
                    //If current symbol is (, then add it to stack
                    else if(infixString[i] == '(') {
                        operationStack.Push(infixString[i]);
                    }
                    //If current symbol is ), then return all symbols from stack, until (
                    else if(infixString[i] == ')')
                    {
                        while (operationStack.Peek() != '(')
                        {
                            resultString +=  operationStack.Pop();
                        }
                        operationStack.Pop();
                    }
                }
                //In the end, return all the values from stack
                while (operationStack.Count != 0)
                {
                    resultString += operationStack.Pop() + " ";
                }
                return resultString;
            }
            
            //Calculating function 
            public static Double CalculateRPN(string rpnString, List<string> variables, double[] values)
            {
                Stack<Double> numbersStack = new Stack<Double>(); //stack for numbers
                Double value1, value2; //first and second values
                string variable = ""; //Current variable
                //Replaces all variables from rpn string to variables values
                for (int i = 0; i < variables.Count; i++)
                {
                    rpnString = rpnString.Replace(variables[i], values[i].ToString());
                }

                for (int i = 0; i < rpnString.Length; i++)
                {
                    //If current symbol is variable
                    if (SignChecker.isVariable(rpnString[i]))
                    {
                        //Add to variable
                        variable += rpnString[i];
                    }
                    else if(rpnString[i] == ' ')
                    {       
                        //If current symbol is space and we have something in variable
                        if (variable != "")
                        {
                            //Add variable to stack
                            numbersStack.Push(double.Parse(variable));
                        }
                        variable = "";
                    }
                    else if(rpnString[i] == '-' && i != rpnString.Length - 1 && SignChecker.isVariable(rpnString[i + 1]))
                    {
                        variable += rpnString[i];
                    }
                    else {
                        //If variable has something
                        if (variable != "")
                        {
                            //Add to stack
                            numbersStack.Push(double.Parse(variable));
                            variable = "";
                        }
                        //Take two values from stack
                        value2 = numbersStack.Pop();
                        value1 = numbersStack.Pop();
                        //Calculate them
                        numbersStack.Push(SignChecker.useOperator(rpnString[i], value1, value2));
                    }
                }
                if (variable != "")
                {
                    numbersStack.Push(double.Parse(variable));
                }
                return numbersStack.Pop();
            }
            
            //Finding all variables in rpnString
            public static List<string> findAllX(string rpnString)
            {
                Stack<Double> numbersStack = new Stack<Double>();//Stack for numbers
                List<string> stringList = new List<string>(); //List of all variables
                string variable = "";

                for (int i = 0; i < rpnString.Length; i++)
                {
                    //If current symbol is variable
                    if (SignChecker.isVariable(rpnString[i]))
                    {
                        //Add to current variable
                        variable += rpnString[i];
                    }
                    else
                    {
                        //If variable has symbols in itself
                        if (variable.Any(c => char.IsLetter(c)))
                        {
                            //Add variable to variable list
                            stringList.Add(variable);
                        }
                        variable = "";
                    }
                }
                if (variable != "")
                {
                    //If variable has symbols in itself
                    if (variable.Any(c => char.IsLetter(c)))
                    {
                        //Add variable to variable list
                        stringList.Add(variable);
                    }
                }
                //Return list of variables
                return stringList.Distinct().ToList();
            }
        }

        class SignChecker
        {

            public static bool isOperation(char symbol) //Checking if the symbol is operation
            {
                if (symbol == '+' ||
                    symbol == '*' ||
                    symbol == '-' ||
                    symbol == '/' ||
                    symbol == '^')
                {
                    return true;
                }
                else return false;
            }

            public static bool isVariable(char symbol) //Checking if symbol is variable
            {
                if (Char.IsDigit(symbol) ||
                    Char.IsLetter(symbol) ||
                    symbol == '.' ||
                    symbol == ',' ||
                    symbol == '—')
                {
                    return true;
                }
                else return false;
            }

            public static int getOperationPriority(char symbol) //Returns the priority of the symbol
            {
                switch (symbol)
                {
                    case '+': return 1;
                    case '-': return 1;
                    case '*': return 2;
                    case '/': return 2;
                    case '^': return 3;
                    default: return 0;
                }
            }

            public static double useOperator(char operation, Double value1, Double value2) //Calculating two values
            {
                switch (operation)
                {
                    case '+': return value1 + value2;
                    case '-': return value1 - value2;
                    case '*': return value1 * value2;
                    case '/': return value1 / value2;
                    case '^': return Math.Pow(value1, value2);
                    default: return 0;
                }
            }

        }

        class CheckInput
        {
            //Checks function
            public static bool checkInputString(string formula)
            {
                int counter1=0, 
                    counter2=2;
                //Returns false if first symbol in function is operation (besides minus)
                if (SignChecker.isOperation(formula[0]) && formula[0] != '-')
                    return false;
                //Returs false if last symbol in string is operation
                if (SignChecker.isOperation(formula[formula.Length-1]) )
                    return false;
                //Counts ammount of opening and closing brackets
                counter1 = formula.ToCharArray().Where(x => x == '(').Count();
                counter2 = formula.ToCharArray().Where(x => x == ')').Count();
                //If ammount of brackets doesn't equal, then returns false
                if (counter1 != counter2)
                    return false;
                //Checks if there is no two operations side by side
                for (int i = 1; i < formula.Length; i ++)
                {
                    if (SignChecker.isOperation(formula[i]) && SignChecker.isOperation(formula[i - 1]))
                        return false;
                }

                return true;

            }
        }
    class Program
    {/*
        static void Main(string[] args)
        {
            string newString = Console.ReadLine();
            string resultSTR = RPN.toRPN(newString);
            IEnumerable<string> stringList = RPN.findAllX(resultSTR);
            double[] n = new double[stringList.Count()];
            int i = 0;
            foreach(string current in stringList)
            { 
                n[i] = int.Parse(Console.ReadLine());
                resultSTR = resultSTR.Replace(current, n[i].ToString());
                i++;
            }
            
            Console.WriteLine(resultSTR);
            Console.WriteLine(RPN.CalculateRPN(resultSTR, n));
        }*/
    }
}
