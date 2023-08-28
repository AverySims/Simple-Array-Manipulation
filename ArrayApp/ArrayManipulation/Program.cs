namespace ArrayManipulation
{
	internal class Program
	{
		static int[] array;
		static int size;

		static void Main(string[] args)
		{
			Console.Write("Enter the initial size of the array: ");
			size = int.Parse(Console.ReadLine());

			array = new int[size];

			Console.WriteLine("Enter the elements of the array:");
			for (int i = 0; i < size; i++)
			{
				Console.Write($"Element {i + 1}: ");
				array[i] = int.Parse(Console.ReadLine());
			}

			bool exit = false;
			while (!exit)
			{
				PrintMenu();
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						FindMinMax();
						break;

					case 2:
						CalculateSumAndAverage();
						break;

					case 3:
						ReverseArray();
						break;

					case 4:
						SortArray();
						break;

					case 5:
						AddElement();
						break;

					case 6:
						RemoveElement();
						break;

					case 7:
						ViewArray();
						break;

					case 8:
						exit = true;
						Console.WriteLine("Exiting program.");
						break;

					default:
						Console.WriteLine("Invalid choice. Please enter a valid option.");
						break;
				}
			}
		}

		static void PrintMenu()
		{
			Console.WriteLine("\nMenu:");
			Console.WriteLine("1. Find minimum and maximum");
			Console.WriteLine("2. Calculate sum and average");
			Console.WriteLine("3. Reverse the array");
			Console.WriteLine("4. Sort the array");
			Console.WriteLine("5. Add element");
			Console.WriteLine("6. Remove element");
			Console.WriteLine("7. View array");
			Console.WriteLine("8. Exit");
			Console.Write("Enter your choice: ");
		}

		static void FindMinMax()
		{
			int min = array[0];
			int max = array[0];
			for (int i = 1; i < size; i++)
			{
				if (array[i] < min)
					min = array[i];
				if (array[i] > max)
					max = array[i];
			}
			Console.WriteLine($"Minimum: {min}");
			Console.WriteLine($"Maximum: {max}");
		}

		static void CalculateSumAndAverage()
		{
			int sum = 0;
			for (int i = 0; i < size; i++)
			{
				sum += array[i];
			}
			double average = (double)sum / size;
			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"Average: {average}");
		}

		static void ReverseArray()
		{
			Array.Reverse(array);
			Console.WriteLine("Array reversed.");
		}

		static void SortArray()
		{
			Array.Sort(array);
			Console.WriteLine("Array sorted.");
		}

		static void AddElement()
		{
			Console.Write("Enter the element to add: ");
			int newElement = int.Parse(Console.ReadLine());

			if (size == array.Length)
			{
				Array.Resize(ref array, size * 2); // Double the array size
			}

			array[size] = newElement;
			size++;
			Console.WriteLine("Element added.");
		}

		static void RemoveElement()
		{
			if (size > 0)
			{
				Console.Write("Enter the index of the element to remove: ");
				int indexToRemove = int.Parse(Console.ReadLine());
				if (indexToRemove >= 0 && indexToRemove < size)
				{
					for (int i = indexToRemove; i < size - 1; i++)
					{
						array[i] = array[i + 1];
					}
					size--;
					Console.WriteLine("Element removed.");
				}
				else
				{
					Console.WriteLine("Invalid index.");
				}
			}
			else
			{
				Console.WriteLine("Array is empty, cannot remove elements.");
			}
		}

		static void ViewArray()
		{
			Console.WriteLine("Array Contents:");
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine($"Index {i}: {array[i]}");
			}
		}
	}
}