using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is a string";
            int age = 35;
            DateTime now = DateTime.Now;
            double amount = 0;

            string string2 = text + "a second string" + age + now + amount;

            string string3 = string.Format("The age is {0}, the time is {1}, and the amount is {2}", age, now, amount);

            string string4 = $"The age is {age}, the time is {now}, and the amount is {amount}";

            char sampleChar = 'C';
            char[] arrayChar = string4.ToCharArray();

            /* for(int i = 0; i < arrayChar.Length; i++)
             {
                 Console.WriteLine(arrayChar[i]);    
             }*/

            amount = (double)10 / (double)3;

            DateTime dataTime = new DateTime(2000, 1, 1);

            TimeSpan timeSamp1 = now - dataTime;
            //var otherText = "this is a text";


            Console.WriteLine(timeSamp1.TotalDays);
            Console.ReadKey();
        }
    }
}