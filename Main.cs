/*
 * Wrapper class for 3683's GetOSProductName function 
 * Visit Longhorn.ms
 */
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace GetOSProductName
{
	class MainClass
	{
		[DllImport("Kernel32.dll", CharSet=CharSet.Unicode, EntryPoint="GetOSProductNameW")]
		public static extern int GetOSProductName(StringBuilder str, UInt32 length, UInt32 returnType);
			
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Possible return types are: 1, 2, 4, 8, 16 32, 64 and other 2^i values.\nCombinations (e.g. adding return types together) are possible.");
			processInput();
		}
		
		public static void processInput() {
			String input = Console.ReadLine();
			try {	
				printOSProductName(Convert.ToUInt32(input));
			} catch (Exception e) {
				Console.WriteLine(e.Message);
				Console.WriteLine();
				processInput();
			}
		}
		
		public static void printOSProductName(UInt32 returnType){
			StringBuilder sbBuffer = new StringBuilder(0x104);
			int result;
			result = GetOSProductName(sbBuffer, (UInt32)sbBuffer.Capacity, returnType);	
			Console.WriteLine(sbBuffer.ToString());
			processInput();
		}
	}
}
