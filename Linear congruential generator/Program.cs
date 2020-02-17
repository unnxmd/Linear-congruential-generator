using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp6
{
	class Program
	{
		static int a = 29;
		static int c = 7;
		static int m = 167;
		static int x0 = 5;

		static void Main(string[] args)
		{
			while (true)
			{
				string f_num = "";

				Console.Title = "Линейный конгруэнтный генератор псевдослучайных последовательностей";
				Console.WriteLine("Выбирите функию:");
				Console.WriteLine("1. Сгенерировать и вывести массив чисел");
				Console.WriteLine("2. Длина периода генератора в битах");
				Console.WriteLine("3. Определение количества четных и нечетных чисел в одном периоде при однобайтовом\nпредставлении выходной последовательности");
				Console.WriteLine("4. Определение количества нулей и единиц в одном периоде при битовом представлении\nвыходной последовательности");
				Console.WriteLine("5. Выход");
				Console.Write("Функция: ");
				f_num = Console.ReadLine();

				switch (f_num)
				{
					case "1":
						foreach (int i in GenerateArray(x0)) Console.Write(i + " ");
						Console.WriteLine();
						break;
					case "2":
						Console.WriteLine("Длина периода генератора в битах равна " + FindPeriodLenght(x0));
						break;
					case "3":
						CountOfEvenAndOdd(x0);
						break;
					case "4":
						CountOfZeroesAndOne(x0);
						break;
					case "5":
						return;
					default:
						Console.WriteLine("Выберите номер функции!");
						break;
				}
				Console.ReadLine();
				Console.Clear();
			}
		}

		static int Generator(int xn)
		{
			return (a * xn + c) % m;
		}

		static int[] GenerateArray(int x_0)
		{
			List<int> IntArray = new List<int>();
			IntArray.Add(x_0);
			int xn = Generator(x_0);
			while (xn != x_0)
			{
				IntArray.Add(xn);
				xn = Generator(xn);
			}
			return IntArray.ToArray();
		}

		static int FindPeriodLenght(int x_0)
		{
			BitArray array = new BitArray(GenerateArray(x_0));
			return array.Length;
		}

		static void CountOfEvenAndOdd(int x_0)
		{
			int countofeven = 0;
			int countofodd = 0;
			BitArray array = new BitArray(GenerateArray(x_0));
			byte[] bytes = new byte[array.Length / 8];
			array.CopyTo(bytes, 0);
			foreach (byte b in bytes) if (b % 2 == 0) countofeven++;
			Console.WriteLine("Четных: " + countofeven);
			foreach (byte b in bytes) if (b % 2 == 1) countofodd++;
			Console.WriteLine("Нечетных: " + countofodd);
		}

		static void CountOfZeroesAndOne(int x_0)
		{
			int countofzeroes = 0;
			int countofone = 0;
			BitArray array = new BitArray(GenerateArray(x_0));
			foreach (bool b in array)
			{
				if (b) countofone++;
				else countofzeroes++;
			}
			Console.WriteLine("Единиц: " + countofone);
			Console.WriteLine("Нулей: " + countofzeroes);
		}
	}
}
