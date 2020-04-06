using System;

namespace TestBars
{
    /// <summary>
    /// Класс, который преобразует килобайты в гигабайты.
    /// </summary>
    public static class Converter  // Класс конвертер 
    {
        /// <summary>
        /// Преобразует килобайты в гигабайты.
        /// </summary>
        /// <param name="bytes">предает килобайты</param>
        /// <returns>Строку с преобразованным числом в гигабайты.</returns>
        public static string CalculateBytetoGB(double bytes) 
        {
            const int CONVERSION_VALUE = 1024;
            double result = bytes / Math.Pow(CONVERSION_VALUE, 3);
            return String.Format("{0:0.000##}", result);
        }
    }
}
