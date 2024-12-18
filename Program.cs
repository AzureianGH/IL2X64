using IL2X64.Error;
using IL2X64.IL.Syntax;
namespace IL2X64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fil = "I:\\source\\CosmosNTFS\\bin\\Debug\\net6.0\\CosmosNTFS.dll";
            string outdirect = "I:\\ZureLib\\IL2X64\\out.il";
            try
            {
                GunnerIL gunner = new GunnerIL();
                gunner.SetParameters(true);
                gunner.Load(fil);
                gunner.PrintILInfo(outdirect, true, true);
            }
            catch (Exception ex)
            {
                if (ex is IL2X64RuntimeException)
                {
                    IL2X64RuntimeException ex1 = (IL2X64RuntimeException)ex;
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
