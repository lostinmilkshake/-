using System;
using System.Collections.Generic;
using System.Linq;

namespace FifthTask
{
    class Parser
    {
        class RPN
        {
            public static string toRPN(string infixString)
            {
                if (!CheckInput.checkInputString(infixString))
                    return "";
                Stack<char> operationStack = new Stack<char>(); //Stack for all operations
                char lastOperation;
                string resultString = ""; //String with result

                infixString = infixString.Replace(" ", "");
                for (int i = 0; i < infixString.Length; i++)
                {
                    //If it is number, than add to resultString
                    if (SignChecker.isVariable(infixString[i]))
                    {
                        resultString += infixString[i];
                    }
                    else if (SignChecker.isOperation(infixString[i]))
                        {
                            if (infixString[i] == '-' && (((i == 0) || (infixString[i-1] == '(')) && (SignChecker.isVariable(infixString[i+1]))))
                            {
                            resultString += 0;    
                            }
                            if (operationStack.Count != 0)
                            {
                                lastOperation = operationStack.Peek();

                                if (SignChecker.getOperationPriority(lastOperation) < SignChecker.getOperationPriority(infixString[i]))
                                {
                                    operationStack.Push(infixString[i]);
                                    resultString += " ";
                                }
                                else
                                {
                                    resultString += operationStack.Pop();
                                    operationStack.Push(infixString[i]);
                                    resultString += " ";
                                }
                            }
                            else
                            {
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

            public static Double CalculateRPN(string rpnString, double[] values)
            {
                Stack<Double> numbersStack = new Stack<Double>();
                Double value1, value2;
                int pos = 0;
                string variable = "";

                for (int i = 0; i < rpnString.Length; i++)
                {
                    if (SignChecker.isVariable(rpnString[i]))
                    {
                        variable += rpnString[i];
                    }
                    else if(rpnString[i] == ' ')
                    {
                        if (variable != "")
                        {
                            numbersStack.Push(int.Parse(variable));
                        }
                        variable = "";
                    }
                    else {
                        if (variable != "")
                        {
                            numbersStack.Push(int.Parse(variable));
                            variable = "";
                        }
                        value2 = numbersStack.Pop();
                        value1 = numbersStack.Pop();
                        numbersStack.Push(SignChecker.useOperator(rpnString[i], value1, value2));
                    }
                }
                return numbersStack.Pop();
            }

            public static IEnumerable<string> findAllX(string rpnString)
            {
                Stack<Double> numbersStack = new Stack<Double>();
                List<string> stringList = new List<string>();
                string variable = "";

                for (int i = 0; i < rpnString.Length; i++)
                {
                    if (SignChecker.isVariable(rpnString[i]))
                    {
                        variable += rpnString[i];
                    }
                    else
                    {
                        if (variable.Any(c => char.IsLetter(c)))
                        {
                            stringList.Add(variable);
                        }
                        variable = "";
                    }

                }
                return stringList.Distinct();
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

            public static bool isVariable(char symbol)
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

            public static double useOperator(char operation, Double value1, Double value2)
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
            public static bool checkInputString(string formula)
            {
                int counter1=0, 
                    counter2=2;
                if (SignChecker.isOperation(formula[0]) && formula[0] != '-')
                    return false;
                if (SignChecker.isOperation(formula[formula.Length-1]) )
                    return false;
                counter1 = formula.ToCharArray().Where(x => x == '(').Count();
                counter2 = formula.ToCharArray().Where(x => x == ')').Count();
                if (counter1 != counter2)
                    return false;

                for (int i = 1; i < formula.Length; i ++)
                {
                    if (SignChecker.isOperation(formula[i]) && SignChecker.isOperation(formula[i - 1]))
                        return false;
                }

                return true;

            }
        }

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
        }
    }
}
