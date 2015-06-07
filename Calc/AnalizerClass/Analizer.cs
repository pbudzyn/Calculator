using CalcClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AnalizerClass
{
    public class Analizer
    {
        public Analizer()
        {
            operators = new List<string>(standart_operators);
        }
        private List<string> operators;
        private List<string> standart_operators =
            new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "m" });

        /// <summary>
        /// позиція виразу, на якій знайдена синтаксична помилка (у
        ///випадку відловлення на рівні виконання - не визначається)
        /// </summary>
        private static int erposition = 0;
        /// <summary>
        /// Вхідний вираз
        /// </summary>
        public static string expression = "";
        /// <summary>
        /// Показує, чи є необхідність у виведенні повідомлень про помилки.
        ///У разі консольного запуску програми це значення - false.
        /// </summary>
        public static bool ShowMessage = true;
        /// <summary>
        /// Перевірка коректності структури в дужках вхідного виразу
        /// </summary>
        /// <returns>true - якщо все нормально, false- якщо є
        ///помилка</returns>
        /// метод біжить по вхідному виразу, символ за символом аналізуючи
        ///його, і рахуючи кількість дужок. У разі виникнення
        /// помилки повертає false, а в erposition записує позицію, на
        ///якій виникла помилка.
        private IEnumerable<string> CheckCurrency(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];

                if ((input[pos] == '+' && pos == 0) || (input[pos] == '-' && pos == 0))
                {
                    s = input[pos].ToString(); pos++;
                    if (!standart_operators.Contains(input[pos].ToString()))
                    {
                        if (Char.IsDigit(input[pos]))
                            for (int i = pos; i < input.Length &&
                                (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                                s += input[i];
                        else if (Char.IsLetter(input[pos]))
                            for (int i = pos; i < input.Length &&
                                (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                                s += input[i];
                    }
                    pos--;
                }
                else
                {
                    if ((input[pos] == '+' && input[pos - 1] == '(') || (input[pos] == '-' && input[pos - 1] == '('))
                    {
                        s = input[pos].ToString(); pos++;
                        if (!standart_operators.Contains(input[pos].ToString()))
                        {
                            if (Char.IsDigit(input[pos]))
                                for (int i = pos; i < input.Length &&
                                    (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                                    s += input[i];
                            else if (Char.IsLetter(input[pos]))
                                for (int i = pos; i < input.Length &&
                                    (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                                    s += input[i];
                        }
                        pos--;
                    }
                }

                if (!standart_operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
        /// <summary>
        /// Форматує вхідний вираз, виставляючи між операторами
        ///пропуски і видаляючи зайві, а також знаходить нерозпізнані оператори, стежить за кінцем рядка
        /// а також знаходить помилки в кінці рядка
        /// </summary>
        /// <returns>кінцевий рядок або повідомлення про помилку, що починаються з спец. символу &</returns>
        public string[] Format(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string c in CheckCurrency(input))
            {
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) > GetPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated.ToArray();
        }
        /// <summary>
        /// Формує масив, в якому розташовуються оператори і символи
        ///представлені в зворотному польському записі (без дужок)
        /// На цьому ж етапі відшукується решта всіх помилок (див.
        ///код). По суті - це компіляція.
        /// </summary>
        /// <returns>массив зворотнього польського запису</returns>
        public static System.Collections.ArrayList CreateStack()
        {
            return new System.Collections.ArrayList();
        }
        /// <summary>
        /// Обчислення зворотнього польського запису
        /// </summary>
        ///<returns>результат обчислень,або повідомлення про помилку</returns>
        public string RunEstimate(string input)
        {
            if (input.Length > 65536)
            {
                return "Error 07 — Дуже довгий вираз. Максмальная довжина — 65536 символів.";
            }

            int countOfSumbols = input.Count(n => Char.IsNumber(n) || standart_operators.Contains(n.ToString()));
            if (countOfSumbols > 30)
            {
                return "Error 08 — Сумарна кількість чисел і операторів перевищує 30.";
            }

            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>(Format(input));

            try
            {
                string str = queue.Dequeue();
                while (queue.Count >= 0)
                {
                    if (!operators.Contains(str))
                    {
                        stack.Push(str);
                        str = queue.Dequeue();
                    }
                    else
                    {
                        decimal summ = 0;

                        switch (str)
                        {

                            case "+":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    long b = Convert.ToInt64(stack.Pop());
                                    summ = MathFunctions.Add(b, a);
                                    break;
                                }
                            case "-":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    long b = Convert.ToInt64(stack.Pop());
                                    summ = MathFunctions.Sub(b, a);
                                    break;
                                }
                            case "*":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    long b = Convert.ToInt64(stack.Pop());
                                    summ = MathFunctions.Mult(b, a);
                                    break;
                                }
                            case "/":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    long b = Convert.ToInt64(stack.Pop());
                                    summ = MathFunctions.Div(b, a);
                                    break;
                                }
                            case "m":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    long b = Convert.ToInt64(stack.Pop());
                                    summ = MathFunctions.Mod(b, a);
                                    break;
                                }
                        }
                        stack.Push(summ.ToString());
                        if (queue.Count > 0)
                            str = queue.Dequeue();
                        else
                            break;
                    }
                }
            }
            catch (OverflowException ex)
            {
                return "Error 06 - Дуже мале, або дуже велике значення числа для int. Числа повинні бути в межах від -2147483648 до 2147483647.";
            }
            catch (DivideByZeroException ex)
            {
                return "Error 09 – Помилка ділення на 0.";
            }
            catch (InvalidOperationException ex)
            {
                return "Error 03 — Невірна синтаксична конструкція вхідного виразу..";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return stack.Pop();
        }
        /// <summary>
        /// Метод, який організовує обчислення. По черзі запускає
        ///CheckCorrncy, Format, CreateStack і RunEstimate
        /// </summary>
        /// <returns></returns>
        public string Estimate(string input)
        {
            return RunEstimate(input);
        }

        private byte GetPriority(string s)
        {
            switch (s)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "m":
                    return 3;
                default:
                    return 4;
            }
        }

    }
}
