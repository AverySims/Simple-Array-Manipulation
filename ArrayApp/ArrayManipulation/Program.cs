using CustomConsole;
using GenericParse;


namespace ArrayManipulation
{
	internal class Program
	{
		// initializing array with 1 element to prevent 'nullreference' warnings
		private static double[] _customArray = { 0 };
		private static int _customSize;

		// splitting menu options into separate string arrays for "easier" sorting
		private static readonly string[] ArrayOptions =
			{ "Create new array", "Add array element", "Remove array element", "View array elements" };

		private static readonly string[] ArrayFunctionOptions =
			{ "Find minimum and maximum", "Calculate sum and average", "Reverse the array", "Sort the array" };

		private static readonly string[] ProgramOptions = { "Exit program" };

		private static bool _loopMain = true;
		private static bool _loopMenu = true;

		static void Main(string[] args)
		{
			while (_loopMain)
			{
				InitializeArray();

				_loopMenu = true;

				while (_loopMenu)
				{
					Console.Clear();
					
					PrintMenu();

					SelectMenuOption();
				}
			}
		}

		static void InitializeArray()
		{
			// user input for array size
			Console.Write("Enter the size of your array: ");

			SetArraySize(out _customSize);

			// initializing new array
			_customArray = new double[_customSize];

			Console.WriteLine("Enter the elements of your array (doubles only):");
			for (int i = 0; i < _customSize; i++)
			{
				Console.Write($"Array element {i}: ");
				_customArray[i] = GenericReadLine.TryReadLine<double>();
			}
		}

		private static void SetArraySize(out int size)
		{
			bool tempValid = false;

			// looping until a valid array size is selected
			do
			{
				size = GenericReadLine.TryReadLine<int>();
				if (size >= 1)
				{
					// valid array size, continue program
					tempValid = true;
				}
				else
				{
					// array size invalid
					ConsoleHelper.PrintInvalidSelection();
				}
			} while (!tempValid);

		}

		static void PrintMenu()
		{
			// saving all option arrays in an array of string arrays and calling printing them via a foreach loop.
			// if you want a unique option that doesn't really fit in a array with other options, just make it an
			// array with a single entry and add it to the local array below.
			string[][] tempArray = { ArrayOptions, ArrayFunctionOptions, ProgramOptions };

			// printing menu options to console
			Console.WriteLine("- - - Menu - - -");
			ConsoleHelper.PrintStrings(tempArray);
		}

		static void SelectMenuOption()
		{
			_loopMain = true;
			_loopMenu = true;

			// looping until a valid option is selected
			while (true)
			{
				ConsoleHelper.PrintBlank();
				Console.Write("Select option: ");
				int tempSelect = GenericReadLine.TryReadLine<int>();

				if (!SwitchOnMenuSelection(tempSelect))
				{
					break;
				}
			}
		}

		private static bool SwitchOnMenuSelection(int selection)
		{
			bool tempReturnValue = true;

			// clearing console and printing menu again to prevent clutter
			Console.Clear();
			PrintMenu();
			ConsoleHelper.PrintBlank();

			switch (selection)
			{
				case 1: // Create new array
					_loopMenu = false;
					tempReturnValue = false;
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
					ViewArray();
					break;
				case 8: // Sort array
					SortArray();
					ViewArray();
					break;
				case 9: // Exit program
					// setting both loops to false will exit the program
					tempReturnValue = false;
					_loopMain = false;
					_loopMenu = false;
					Console.WriteLine("Exiting program.");
					break;
				default:
					ConsoleHelper.PrintInvalidSelection();
					break;
			}
			// returning true will keep the program running, false will exit the program
			return tempReturnValue;
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
			Console.WriteLine($"Sum: {sum}, Average: {average}");
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
			Console.WriteLine("New element added.");
		}

		static void RemoveElement()
		{
			if (_customSize > 0)
			{
				Console.Write("Enter the index of the element to remove: ");
				while (true)
				{
					int indexToRemove = GenericReadLine.TryReadLine<int>();
					if (indexToRemove >= 0 && indexToRemove < _customSize)
					{
						for (int i = indexToRemove; i < _customSize - 1; i++)
						{
							_customArray[i] = _customArray[i + 1];
						}
						_customSize--;
						Console.WriteLine("Element removed.");
						break;
					}
					else
					{
						Console.Write("Invalid index, enter a valid index: ");
					}
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