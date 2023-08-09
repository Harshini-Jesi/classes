using System;

namespace NumberConverter {
    class Program {
        static string[] ones = {
            "", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten",
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
            "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        static string[] tens = {
            "", "", "Twenty", "Thirty", "Forty", "Fifty",
            "Sixty", "Seventy", "Eighty", "Ninety"
        };

        static string ConvertToWords (int number) {
            if (number < 0) {
                return "Negative " + ConvertToWords (-number);
            }

            if (number < 20) {
                return ones[number];
            }

            if (number < 100) {
                return tens[number / 10] + (number % 10 != 0 ? " " + ones[number % 10] : "");
            }

            if (number < 1000) {
                return ones[number / 100] + " Hundred" + (number % 100 != 0 ? " and " + ConvertToWords (number % 100) : "");
            }

            if (number < 1000000) {
                return ConvertToWords (number / 1000) + " Thousand" + (number % 1000 != 0 ? " " + ConvertToWords (number % 1000) : "");
            }

            return "Number out of range"; // Modify this as needed for larger numbers
        }

        static string ConvertToRoman (int number) {
            if (number < 1 || number > 3999) {
                return "Out of Roman numeral range";
            }

            string[] romanSymbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            string romanNumeral = "";
            for (int i = 0; i < values.Length; i++) {
                while (number >= values[i]) {
                    romanNumeral += romanSymbols[i];
                    number -= values[i];
                }
            }

            return romanNumeral;
        }

        static void Main (string[] args) {
            Console.Write ("Enter a number: ");
            int number = int.Parse (Console.ReadLine ());

            string words = ConvertToWords (number);
            string roman = ConvertToRoman (number);

            Console.WriteLine ($"Number in words: {words}");
            Console.WriteLine ($"Number in Roman numerals: {roman}");
        }
    }
}
