using ConsoleFunctions;
using GenericParse;


namespace ArrayManipulation
{
	internal class Program
	{
		static double[] customArray;
		static int customSize;
		
		private static readonly string[] MenuOptions = 
			{"Find minimum and maximum", 
				"Calculate sum and average", 
				"Reverse the array", 
				"Sort the array", 
				"Add element", 
				"Remove element", 
				"View elements",
				"Exit program"
			};

		static void Main(string[] args)
		{
			bool loopMain = true;
			bool loopSelections = true;

			while (loopMain)
			{
				InitializeArray();
				
				while (loopSelections)
				{
					PrintMenu();
					SelectMenuOption();
				}
				
			}
		}

		static void InitializeArray()
		{
			bool tempValid = false;
			
			// user input for array size
			Console.Write("Enter the size of your array: ");
			do
			{
				customSize = GenericReadLine.TryReadLine<int>();
				if (customSize >= 1)
				{
					// valid array size, continue program
					tempValid = true;
				}
				else
				{
					// array size invalid
					ConsoleHelper.PrintInvalidSelection();
				}
			} while( !tempValid );

			// initializing new array
			customArray = new double[customSize];

			Console.WriteLine("Enter the elements of your array:");
			for (int i = 0; i < customSize; i++)
			{
				Console.Write($"Index {i}: ");
				customArray[i] = GenericReadLine.TryReadLine<double>();
			}
		}
		
		static void PrintMenu()
		{
			Console.WriteLine("- - - Menu - - -");

			for (int i = 0; i < MenuOptions.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {MenuOptions[i]}");
			}

			Console.Write("Enter your choice: ");
		}

		static void SelectMenuOption()
		{
			bool loopTemp = true;

			int tempSelect = 0;

			while (loopTemp)
			{
				bool tempValid = false;
				Console.Write("Select option: ");
				do
				{
					 tempSelect = GenericReadLine.TryReadLine<int>();
					if (tempSelect >= 1 && tempSelect <= MenuOptions.Length)
					{
						// selection valid, continue program
						tempValid = true;
					}
					else
					{
						// selection invalid
						ConsoleHelper.PrintInvalidSelection();
					}
				} while (!tempValid);

				switch (tempSelect)
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
						// exit = true;
						Console.WriteLine("Exiting program.");
						break;
					default:
						ConsoleHelper.PrintInvalidSelection();
						break;
				}
				
			}
			
		}
		
		static void FindMinMax()
		{
			var min = customArray[0];
			var max = customArray[0];
			for (int i = 1; i < customSize; i++)
			{
				if (customArray[i] < min)
					min = customArray[i];
				if (customArray[i] > max)
					max = customArray[i];
			}
			Console.WriteLine($"Minimum: {min}, Maximum: {max}");
		}

		static void CalculateSumAndAverage()
		{
			double sum = 0;
			for (int i = 0; i < customSize; i++)
			{
				sum += customArray[i];
			}
			double average = sum / customSize;
			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"Average: {average}");
		}

		static void ReverseArray()
		{
			Array.Reverse(customArray);
			Console.WriteLine("Array reversed.");
		}

		static void SortArray()
		{
			Array.Sort(customArray);
			Console.WriteLine("Array sorted.");
		}

		static void AddElement()
		{
			Console.Write("Enter the element to add: ");
			var newElement = GenericReadLine.TryReadLine<double>();

			if (customSize == customArray.Length)
			{
				Array.Resize(ref customArray, customSize * 2); // Double the array size
			}

			customArray[customSize] = newElement;
			customSize++;
			Console.WriteLine("Element added.");
		}

		static void RemoveElement()
		{
			if (customSize > 0)
			{
				Console.Write("Enter the index of the element to remove: ");
				int indexToRemove = GenericReadLine.TryReadLine<int>();
				if (indexToRemove >= 0 && indexToRemove < customSize)
				{
					for (int i = indexToRemove; i < customSize - 1; i++)
					{
						customArray[i] = customArray[i + 1];
					}
					customSize--;
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
			for (int i = 0; i < customSize; i++)
			{
				Console.WriteLine($"Index {i}: {customArray[i]}");
			}
		}
	}
}