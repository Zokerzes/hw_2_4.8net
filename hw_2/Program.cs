using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Win32;

namespace hw1
{
	class Task1
	{
		public void StartTask1()
		{
			double [] a = new double[5];
			double[,] b = new double[3, 2];
			Console.WriteLine("введите 5 чисел:(в формате \"n,n\")");
            for (int i = 0; i < a.Length; i++)
            {
				a[i] = Convert.ToDouble(Console.ReadLine());
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Random rnd = new Random();
           
			for (int i = 0; i < 3; i++)
            {
				for (int j = 0; j < 2; j++)
				{
					double r= rnd.NextDouble();
					b[i, j] =Math.Round(r*100,2);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                   
                    Console.Write(b[i, j] + "\t");
                }
                Console.WriteLine();
            }

			double max=0;
			foreach (double i in a)
			{
				if (max < i) max = i;
			}

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (max < b[i,j]) max = b[i, j];
                }
            }
           
			double min = b[0,0];
            foreach (double i in a)
            {
                if (min> i) min = i;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (min > b[i, j]) min = b[i, j];
                }
            }

            
			double sum;
			sum = a.Sum();
			//Console.WriteLine("test sum a " + sum);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                   sum += b[i, j];
                }
            }
			
			double mult = 1;
            foreach (double i in a)
            {
                mult *= i;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    mult *= b[i, j];
                }
            }
			double sumCh = 0;
			for (int i = 0; i < 5; i++)
			{
				double ii = a[i]*10;
				if (Convert.ToInt32(ii) % 2 == 0) sumCh += a[i];
            }
			Console.WriteLine();
			double sumNCh = 0; 
			for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                   if(j%2!=0) sumNCh += b[i, j];
                }
            }

            Console.WriteLine("максимальный элемент = {0}\nминимальный элемент = {1}\nсумма = {2}"+
                "\nпроизведение = {3}\nсумма четных элементов массива а = {4}"+
                "\nсумма нечетных столбцов массива b = {5}",
				max, min, sum, mult,sumCh, sumNCh);

        }
    }
	class Task2
	{
        /*Дан двумерный массив размерностью 5×5, заполнен-
ный случайными числами из диапазона от –100 до 100.
Определить сумму элементов массива, расположенных
между минимальным и максимальным элементами.*/
        public void StartTask2()
		{
            Console.WriteLine();
            int row=5,col =5;
            int[,] b = new int[row, col];
            Random rnd = new Random();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    int r = rnd.Next(-100,100);
					b[i, j] = r;
                }
            }
 
            int ii = 0,iMax=0,iMin=0; // итератор 1 мерного массива
            int[] bStr = new int[row * col];
            
            for ( int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
					bStr[ii] = b[i, j];
					ii++;
					Console.Write(b[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            foreach (int i in bStr)
			{
				Console.Write(i+" ");
			}
			Console.WriteLine();

            int max = bStr[0], min = bStr[0],start=0,stop=0;
            for (int i = 0; i < bStr.GetLength(0); i++)
            {
                if(max < bStr[i])
				{
					max = bStr[i];
					iMax = i;
				};
                if (min > bStr[i])
                {
                    min = bStr[i];
                    iMin = i;
                };
            }
            Console.WriteLine("iMax = {0} max = {1}\niMin = {2} min = {3}",iMax,max,iMin,min);
			if (iMax > iMin) 
			{
				start = iMin;
				stop = iMax;
			}
			else 
			{
                start = iMax;
				stop = iMin;
            }
			int sum = 0;
			for (int i = start+1; i < stop; i++)
			{
				sum += bStr[i];
			}
            Console.WriteLine("Сумма элементов массива, расположенных между минимальным и максимальным элементами\nsum = " + sum);
        }
    }
	class Task3
	{
        /*Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря.*/
        public void StartTask3()
		{
			string userInput;
			userInput = Console.ReadLine();
			if(userInput=="") userInput = "Эта строка зашифровывается кодом цезаря";
			int strafe = 10;
			char [] ChIn = userInput.ToCharArray();

			Console.Write(ChIn); Console.WriteLine(" - start value");

			for (int i = 0; i < ChIn.GetLength(0); i++)
			{
				ChIn[i] = ((char)(Convert.ToInt32(ChIn[i])+strafe));   
			}

			Console.Write(ChIn); Console.WriteLine(" - cripted");

			for (int i = 0; i < ChIn.GetLength(0); i++)
			{
				ChIn[i] = ((char)(Convert.ToInt32(ChIn[i])-strafe));   
			}

			Console.Write(ChIn);  Console.WriteLine(" - uncripted");

		}
	}
	class Task4
	{
		public void StartTask4()
		
		{
			

		}
	}
	class Task5
	{
		public void StartTask5()
		
		{
			
		}
	}
	class Task6
	{
		public void StartTask6()
		{

			
		}
	}
	class Task7
	{
		public void StartTask7()
		{
			
		}

	}
	class HomeWork
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("1 - задача 1\n2 - задача 2\n3 - задача 3\n" +
				"4 - задача 4\n5 - задача 5\n6 - задача 6\n7 - задача 7");
			Int32 key = Convert.ToInt32(Console.ReadLine());
			switch (key)
			{
				case 1:
					Task1 task1 = new Task1();
					task1.StartTask1();
					break;
				case 2:
					Task2 task2 = new Task2();
					task2.StartTask2();
					break;
				case 3:
					Task3 task3 = new Task3();
					task3.StartTask3();
					break;
				case 4:
					Task4 task4 = new Task4();
					task4.StartTask4();
					break;
				case 5:
					Task5 task5 = new Task5();
					task5.StartTask5();
					break;
				case 6:
					Task6 task6 = new Task6();
					task6.StartTask6();
					break;
				case 7:
					Task7 task7 = new Task7();
					task7.StartTask7();
					break;

				default:
					break;

			}


		}
	}
}
