using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BankOfBitsAndBytes
{
    class Program
    {
        static BankOfBitsNBytes bbb = new BankOfBitsNBytes();
        static int moneyValue = 0;

        static void Main(string[] args)
        {
            guessPassword();

            Console.ReadLine();
        }

        static void guessPassword()
        {
            //char[] convertedArr = convertToCharArray(intArr);

            //for (int i = 0; i < bbb.passwordLength; i++)
            //{
            //    int[] intArr = new int[bbb.passwordLength];
            //    initializeArr(intArr);
            //    StartThread(i, intArr);
            //}

            int[] intArr = new int[bbb.passwordLength];
            initializeArr(intArr);
            intArr[intArr.Length - 1]++;

            while (moneyValue < 5000)
            {
                char[] convertedArr = convertToCharArray(intArr);
                Debug_CharArray(convertedArr);

                moneyValue += bbb.WithdrawMoney(convertedArr);
                Console.WriteLine(moneyValue);

                intArr[intArr.Length - 1]++;

                if (intArr[intArr.Length - 1] >= BankOfBitsNBytes.acceptablePasswordChars.Length)
                {
                    incrementArray(ref intArr);
                }
            }

            Console.WriteLine("We robbed the bank! Press any key to continue");
        }

        static char[] convertToCharArray(int[] myArr)
        {
            char[] toRet = new char[myArr.Length];

            for (int i = 0; i < myArr.Length; i++)
            {
                toRet[i] = BankOfBitsNBytes.acceptablePasswordChars[myArr[i]];
            }

            return toRet;
        }

        static void incrementArray(ref int[] toIncrement)
        {
            toIncrement[toIncrement.Length - 1]++;
            for (int i = toIncrement.Length-1; i >= 0; i--)
            {
                if (toIncrement[i] >= BankOfBitsNBytes.acceptablePasswordChars.Length)
                {
                    toIncrement[i] = 0;
                    if (i != 0)
                        toIncrement[toIncrement.Length - 2]++;
                }
                else
                    return;
            }
        }

        static void initializeArr(int[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
                myArr[i] = 0;
        }

        static void Debug_CharArray(char[] convertedArr)
        {
            Console.WriteLine(new string(convertedArr));
        }

        //static void StartThread(ref int[] toIncrement)
        //{
        //    ThreadStart ts = new ThreadStart(() => incrementArray(ref toIncrement));
        //    Thread t = new Thread(ts);
        //    t.Start();
        //}

        static void CheckPassword(int charId, int[] intArray)
        {
            while (moneyValue < 5000)
            {
                Thread.Sleep(1000);

                char[] newArr = convertToCharArray(intArray);
                newArr[charId] = BankOfBitsNBytes.acceptablePasswordChars[intArray[charId]];

                Console.WriteLine("Thread for : " + charId + " and guessed : " + new string(newArr));

                moneyValue += bbb.WithdrawMoney(newArr);
                Console.WriteLine("money : " + moneyValue);

                intArray[charId]++;
                if (intArray[charId] >= BankOfBitsNBytes.acceptablePasswordChars.Length)
                {
                    intArray[charId] = 0;
                }
            }
        }
    }
}
