using Gunner.IL.Error;
using Gunner.IL.Syntax;
namespace Gunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: gil <input file> [{-o/v/c} {--version} {--help/-?}] <output file>");
                Environment.Exit(0);
            }
            if (args.Length == 1)
            {
                if (args[0] == "--version")
                {
                    Console.WriteLine("Gunner Intermediate Language Decompiler v1.0.0.0");
                    Console.WriteLine("Written by: AzureianGH.");
                    Console.WriteLine("License: MIT");
                    Environment.Exit(0);
                }
                else if (args[0] == "--help" || args[0] == "-?")
                {
                    Console.WriteLine("Usage: gil <input file> [{-o/v/c} {--version} {--help/-?}] <output file>");
                    Console.WriteLine("Options:");
                    Console.WriteLine("  -o: Output the IL to the console.");
                    Console.WriteLine("  -v: Verbose mode.");
                    Console.WriteLine("  -c: Output the IL in C-like syntax.");
                    Console.WriteLine("  --version: Display the version of the program.");
                    Console.WriteLine("  --help/-?: Display this help message.");
                    Console.WriteLine("  <input file>: The input file to decompile.");
                    Console.WriteLine("  <output file>: The output file to write the decompiled IL to.");
                    //Example of args
                    Console.WriteLine("Example: gil test.dll -cv test.gil");
                    Console.WriteLine("Example: gil test.dll -oc");
                    Environment.Exit(0);
                }
            }
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: gil <input file> [{-o/v/c} {--version} {--help/-?}] <output file>");
                Environment.Exit(1);
            }

            string fil = args[0];
            bool Verbose = false;
            bool Output = false;
            bool CLike = false;

            //check flags
            string flag = args[1].Replace("-","");
            if (flag.Contains("v"))
            {
                Verbose = true;
            }
            if (flag.Contains("o"))
            {
                Output = true;
            }
            if (flag.Contains("c"))
            {
                CLike = true;
            }

            string outdirect = "";
            if (!Output)
            {
                outdirect = args[args.Length - 1];
            }

            // o = output
            // v = verbose
            // c = CLike
            try
            {
                GunnerIL gunner = new GunnerIL();
                gunner.SetParameters(true);
                gunner.Load(fil);
                gunner.PrintILInfo(outdirect, CLike, Verbose);
            }
            catch (Exception ex)
            {
                if (ex is GunnerRuntimeException)
                {
                    GunnerRuntimeException ex1 = (GunnerRuntimeException)ex;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    if (ex1.iType == ILErrorType.IL_INVALID_SWITCH)
                    {
                        Console.WriteLine("IL2X64: Invalid switch at: " + ex1.Message);
                        if (ex1.iChild != null)
                        {
                            if (ex1.iChild.iType == ILErrorType.IL_ARBITRARY_LIMIT_REACHED)
                            {
                                Console.WriteLine("IL2X64: Arbitrary case limit reached: " + ex1.iChild.Message);
                            }
                        }
                    }
                    Console.WriteLine("IL2X64: Stop.");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("IL2X64: Unhandled exception: " + ex.Message);
                    Console.WriteLine("IL2X64: Stack trace: " + ex.StackTrace);
                    Console.WriteLine("IL2X64: Stop.");
                    Console.ResetColor();
                    Environment.Exit(1);
                }
            }
        }
    }
}
