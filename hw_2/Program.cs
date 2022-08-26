using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
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
		public void StartTask2()
		{
			

		}
	}
	class Task3
	{
		public void StartTask3()
		{
			

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
