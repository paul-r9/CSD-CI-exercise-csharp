using System;
using System.Collections.Generic;
using System.Text;

namespace ISBN
{
   public class ISBN13Validator
   {
      public static bool Validate(string isbn)
      {
         isbn = RemoveValidWhitespace(isbn);

         // make sure it's 13 digits
         if (isbn.Length == 13)
         {
            foreach (char ch in isbn)
            {
               if (!char.IsDigit(ch))
               {
                  return false;
               }
            }

            return ValidateCheckSumIsbn13(isbn);
         }

         return false;
      }

      private static string RemoveValidWhitespace(string isbn)
      {
         return isbn.Replace(" ", "").Replace("-", "");
      }

      private static bool ValidateCheckSumIsbn13(string number)
      {
         int checkSumTotal = 0;

         for (int i = 0; i < number.Length - 1; i++)
         {
            var numberDigit = number[i] - '0';
            int multiplyBy = (((i % 2) == 1) ? 3 : 1);
            //Console.WriteLine("RUSS" + numberDigit.ToString() + "-" + multiplyBy.ToString());
            checkSumTotal += numberDigit * multiplyBy;
         }

         int calculatedCheckSum = 10 - (checkSumTotal % 10);
         int givenCheckSum = number[12] - '0';
         //Console.WriteLine("TheEnd:" + givenCheckSum.ToString() + "-" + calculatedCheckSum.ToString());

         return calculatedCheckSum == givenCheckSum;
      }
   }
}
