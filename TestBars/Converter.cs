using System;

namespace TestBars
{
    static class Converter // Класс конвертер 
    {
        public static string CalculateBytetoGB(double bytes) // Метод конвертирует байты в ГБ
        {
            const int CONVERSION_VALUE = 1024;
            double result = bytes / Math.Pow(CONVERSION_VALUE, 3);
            return String.Format("{0:0.000##}", result);
        }
    }
}
