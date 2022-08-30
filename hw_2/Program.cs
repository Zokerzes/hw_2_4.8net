using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;

namespace hw2
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

		/*Создайте приложение, которое производит операции над матрицами:
		■■Умножение матрицы на число;	bi,j = k · ai,j
		■■Сложение матриц;				Аm×n + Bm×n = Cm×n
		■■Произведение матриц.          Cij=SUM(from 1 to r)(Air*Bir) */  

		public void multiOnNumber(int [,] matrixA, int i, int r, int k) 
		{
			Console.WriteLine("умножение матрицы A ");
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	//вывод матрицы А
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					Console.Write(matrixA[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("на число k = "+k);
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	//сборка матрицы А
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					matrixA[ii,jj] *= k;
				}
			}
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	//вывод матрицы А
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					Console.Write(matrixA[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
		}

		public void sumMatrix(int [,] matrixA, int i, int r,int [,] matrixB, int rr, int j) 
		{
			if(r==j && i == rr) 
			{ 
				Console.WriteLine("сумма матриц A ");
				for (int ii = 0; ii < matrixA.GetLength(0); ii++)	
				{
					for (int jj = 0; jj < matrixA.GetLength(1); jj++)
					{
						Console.Write(matrixA[ii,jj]+ "\t");
					}
					Console.WriteLine();
				}
				Console.WriteLine("и В ");
				for (int ii = 0; ii < matrixB.GetLength(0); ii++)	
				{
					for (int jj = 0; jj < matrixB.GetLength(1); jj++)
					{
						Console.Write(matrixB[ii,jj]+ "\t");
					}
					Console.WriteLine();
				}
				Console.WriteLine("Равна ");
				for (int ii = 0; ii < matrixA.GetLength(0); ii++)	
				{
					for (int jj = 0; jj < matrixA.GetLength(1); jj++)
					{
						Console.Write(matrixA[ii,jj]+matrixB[ii,jj] +"\t");
					}
					Console.WriteLine();
				}
			}
			else Console.WriteLine("Сумма матриц - Ошибка: попытка сложения разноразмерных матриц");
		}
		public void multyMatrix(int [,] matrixA, int i, int r,int [,] matrixB, int rr, int j) 
		{
			Console.WriteLine("произведение матриц A ");
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					Console.Write(matrixA[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("и В ");
			for (int ii = 0; ii < matrixB.GetLength(0); ii++)	
			{
				for (int jj = 0; jj < matrixB.GetLength(1); jj++)
				{
					Console.Write(matrixB[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine("Равно ");
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					int tempSum=0;
					for (int k = 0; k < r; k++)
					{
						tempSum+= matrixA[ii, k] * matrixB[k,jj];
					}
					Console.Write(tempSum+ "\t");
					
				}
				Console.WriteLine();
			}
		}

		public void StartTask4()
		{
			Console.Write("Введите размеры матриц\n матрица Аi =      ");
			int i = int.Parse(Console.ReadLine());
			Console.Write(" матрица Аj = Bi = ");
			int r = int.Parse(Console.ReadLine());
			Console.Write(" матрица Bj =      ");
			int j = int.Parse(Console.ReadLine());
			Random ran = new Random ();
			int[,] matrixA = new int[i,r];
			int[,] matrixB = new int[r,j];
			int[,] matrixC = new int[i,j];
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	//сборка матрицы А
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					int rand = ran.Next(-10,10);
					matrixA[ii,jj] = rand;
				}
			}
			for (int ii = 0; ii < matrixB.GetLength(0); ii++)	//сборка матрицы B
			{
				for (int jj = 0; jj < matrixB.GetLength(1); jj++)
				{
					int rand = ran.Next(-10,10);
					matrixB[ii,jj] = rand;
				}
			}
			for (int ii = 0; ii < matrixA.GetLength(0); ii++)	//вывод матрицы А
			{
				for (int jj = 0; jj < matrixA.GetLength(1); jj++)
				{
					Console.Write(matrixA[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();Console.WriteLine();
			for (int ii = 0; ii < matrixB.GetLength(0); ii++)	//вывод матрицы B
			{
				for (int jj = 0; jj < matrixB.GetLength(1); jj++)
				{
					Console.Write(matrixB[ii,jj]+ "\t");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
			int k = ran.Next(1,10);

			multiOnNumber(matrixA, i, r, k);
			sumMatrix(matrixA, i, r, matrixB, r, j); 
			multyMatrix(matrixA, i, r, matrixB, r, j);
		}
	}
	class Task5
	{
        /*Пользователь с клавиатуры вводит в строку арифметическое
         выражение. Приложение должно посчитать его результат.*/
        public void StartTask5()
		
		{
			Console.WriteLine("Введите строку математического выражения");
            string expression = Console.ReadLine();
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            Console.WriteLine(double.Parse((string)row["expression"]));
        }
	}
	class Task6
	{
        /*Пользователь с клавиатуры вводит некоторый текст.
		Приложение должно изменять регистр первой буквы
		каждого предложения на букву в верхнем регистре.*/
        public void StartTask6()
		{
			string userInput = Console.ReadLine();
			string result="";
            string[] strArr = userInput.Split(".".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArr)
			{
				string tempStr = str.Trim();
				result += tempStr[0].ToString().ToUpper() + tempStr.Substring(1) + ". ";   
            }
            Console.WriteLine(result); 
        }
	}
	class Task7
	{
        /*Создайте приложение, проверяющее текст на недопустимые слова. 
        Если недопустимое слово найдено, оно должно быть заменено на набор символов *. 
		*/
        public void StartTask7()
		{
			string userInput;
            Console.WriteLine("Введите текст для форматирования \n " +
                "или оставьте ввод пустым для текста по умаолчанию");
			userInput = Console.ReadLine();
			if (userInput == "")
			{
				userInput = "And by opposing end them? To die: to sleep;\r\n" +
				"No more; and by a sleep to say we end\r\n" +
				"The heart-ache and the thousand natural shocks\r\n" +
				"That flesh is heir to, 'tis a consummation\r\n" +
				"Devoutly to be wish'd. To die, to sleep";
			}
			string censored;
			Console.WriteLine("введите слово для его цензуры \n " +
                "или оставьте ввод пустым для текста по умаолчанию");
            censored = Console.ReadLine();
            if (censored == "")
			{
				censored = "die";
			}

            string outCens = "";
            for (int i = 0; i < censored.Length; i++)
			{
				outCens += "*"; 
			}
            Console.WriteLine(userInput);
            userInput =userInput.Replace(censored, outCens);
			Console.WriteLine();
			Console.WriteLine($"закрытое слово {censored}");
            Console.WriteLine();
            Console.WriteLine(userInput);
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
