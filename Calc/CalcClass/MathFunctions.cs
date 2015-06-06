using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClass
{
    public static class MathFunctions
    {
        /// <summary>
        /// Останнє повідомлення про помилку.
        /// Поле і властивість для нього
        /// </summary>
        private static string _lastError { get; set; }

        /// <summary>
        /// Функція складання числа а і b
        /// </summary>
        /// <param name="a">доданок</param>
        /// <param name="b">доданок</param>
        /// <returns>сума</returns>
        public static long Add(long a, long b)
        {
            return a + b;
        }

        /// <summary>
        /// функція віднімання чисел а і b
        /// </summary>
        /// <param name="a">зменшуване</param>
        /// <param name="b">від’ємне</param>
        /// <returns>різниця</returns>
        public static long Sub(long a, long b)
        {
            return a - b;
        }

        /// <summary>
        /// функція множення чисел а і b
        /// </summary>
        /// <param name="a">множник</param>
        /// <param name="b">множник</param>
        /// <returns>добуток</returns>
        public static long Mult(long a, long b)
        {
            return a * b;
        }

        /// <summary>
        /// функція знаходження частки
        /// </summary>
        /// <param name="a">ділене</param>
        /// <param name="b">дільник</param>
        /// <returns>частка</returns>
        public static long Div(long a, long b)
        {
            return a / b;
        }

        /// <summary>
        /// функція ділення по модулю
        /// </summary>
        /// <param name="a">ділене</param>
        /// <param name="b">дільник</param>
        /// <returns>остача</returns>
        public static long Mod(long a, long b)
        {
            return a % b;
        }

        /// <summary>
        /// унарний плюс
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long ABS(long a)
        {
            if (a < 0)
                a = -1 * a;

            return a;
        }

        /// <summary>
        /// унарний мінус
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long IABS(long a)
        {
            if (a > 0)
                a = -1 * a;

            return a;
        }

    }
}
