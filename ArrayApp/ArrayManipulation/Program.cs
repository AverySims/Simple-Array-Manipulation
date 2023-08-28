using ConsoleFunctions;
using GenericParse;


namespace ArrayManipulation
{
	internal class Program
	{
		private static double[] _customArray;
		private static int _customSize;

		// splitting menu options into separate string arrays for "easier" sorting
		private static readonly string[] ArrayOptions =
			{ "Create new array", "Add array element", "Remove array element", "View array elements" };

		private static readonly string[] ArrayFunctionOptions =
			{ "Find minimum and maximum", "Calculate sum and average", "Reverse the array", "Sort the array" };

		private static readonly string[] ProgramOptions = { "Exit program" };

		static void Main(string[] args)
		{
			bool loopMain = true;
			
			// combining array lengths to find the range of selectable menu options
			int menuOptions = ArrayOptions.Length + ArrayFunctionOptions.Length + ProgramOptions.Length;

			// having separate loops for the program, allowing 
			while (loopMain)
			{
				bool loopSelections = true;

				InitializeArray();
				
				while (loopSelections)
				{
					PrintMenu();

					SelectMenuOption(menuOptions, out loopMain, out loopSelections);
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
				_customSize = GenericReadLine.TryReadLine<int>();
				if (_customSize >= 1)
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
			_customArray = new double[_customSize];

			Console.WriteLine("Enter the elements of your array:");
			for (int i = 0; i < _customSize; i++)
			{
				Console.Write($"Array element {i}: ");
				_customArray[i] = GenericReadLine.TryReadLine<double>();
			}
		}

		static void PrintMenu()
		{
			// saving all option arrays in an array of string arrays and calling printing them via a foreach loop.
			// if you want a unique option that doesn't really fit in a array with other options, just make it an
			// array with a single entry and add it to the local array below.
			string[][] tempArray = { ArrayOptions, ArrayFunctionOptions, ProgramOptions };
			
			int tempIndex = 0;

			Console.Clear();

			Console.WriteLine("- - - Menu - - -");

			foreach (var option in tempArray)
			{
				for (int i = 0; i < option.Length; i++)
				{
					Console.WriteLine($"{tempIndex + 1}. {option[i]}");
					tempIndex++;
				}
				ConsoleHelper.PrintBlank();
			}

		}

		static void SelectMenuOption(int menuOptions, out bool loopMain, out bool loopSub)
		{
			bool loopTemp = true;
			loopMain = true;
			loopSub = true;

			while (loopTemp)
			{
				bool tempValid = false;
				int tempSelect = 0;

				ConsoleHelper.PrintBlank();

				Console.Write("Select option: ");
				do
				{
					tempSelect = GenericReadLine.TryReadLine<int>();
					if (tempSelect >= 1 && tempSelect <= menuOptions)
					{
						// selection valid, continue program
						tempValid = true;

						
						PrintMenu();

					}
					else
					{
						// selection invalid
						ConsoleHelper.PrintInvalidSelection();
					}
				} while (!tempValid);

				switch (tempSelect)
				{
					case 1: // Create new array
						loopSub = false;
						loopTemp = false;
						Console.Clear();
						break;
					case 2: // Add array element
						AddElement();
						break;
					case 3: // Remove array element
						RemoveElement();
						break;
					case 4: // View array elements
						ViewArray();
						break;
					case 5: // Find min and max
						FindMinMax();
						break;
					case 6: // Calc sum and average
						CalculateSumAndAverage();
						break;
					case 7: // Reverse array
						ReverseArray();
						break;
					case 8: // Sort array
						SortArray();
						break;
					case 9: // Exit program
						loopMain = false;
						loopSub = false;
						loopTemp = false;
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
			var min = _customArray[0];
			var max = _customArray[0];
			for (int i = 1; i < _customSize; i++)
			{
				if (_customArray[i] < min)
					min = _customArray[i];
				if (_customArray[i] > max)
					max = _customArray[i];
			}
			Console.WriteLine($"Minimum: {min}, Maximum: {max}");
		}

		static void CalculateSumAndAverage()
		{
			double sum = 0;
			for (int i = 0; i < _customSize; i++)
			{
				sum += _customArray[i];
			}
			double average = sum / _customSize;
			Console.WriteLine($"Sum: {sum}");
			Console.WriteLine($"Average: {average}");
		}

		static void ReverseArray()
		{
			Array.Reverse(_customArray);
			Console.WriteLine("Array reversed.");
		}

		static void SortArray()
		{
			Array.Sort(_customArray);
			Console.WriteLine("Array sorted.");
		}

		static void AddElement()
		{
			Console.Write("Enter the element to add: ");
			var newElement = GenericReadLine.TryReadLine<double>();

			if (_customSize == _customArray.Length)
			{
				Array.Resize(ref _customArray, _customSize * 2); // Double the array size
			}

			_customArray[_customSize] = newElement;
			_customSize++;
			Console.WriteLine("Element added.");
		}

		static void RemoveElement()
		{
			if (_customSize > 0)
			{
				Console.Write("Enter the index of the element to remove: ");
				int indexToRemove = GenericReadLine.TryReadLine<int>();
				if (indexToRemove >= 0 && indexToRemove < _customSize)
				{
					for (int i = indexToRemove; i < _customSize - 1; i++)
					{
						_customArray[i] = _customArray[i + 1];
					}
					_customSize--;
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
			// checking if array size is 0 to determine displayed console message
			if (_customSize <= 0)
			{
				Console.WriteLine("Array is empty, cannot display elements");
			}
			else
			{
				Console.WriteLine("Array Contents:");

				for (int i = 0; i < _customSize; i++)
				{
					Console.WriteLine($"Index {i}: {_customArray[i]}");
				}
			}
			
		}
	}
}