using IL2X64.IL.Syntax;
namespace IL2X64
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fil = "C:\\Users\\alexm\\source\\repos\\IL2X64\\bin\\Debug\\net9.0\\IL2X64.dll";
            string outdirect = "C:\\Users\\alexm\\source\\repos\\IL2X64\\bin\\Debug\\net9.0\\out.il";
            GunnerIL gunner = new GunnerIL();
            gunner.SetParameters(true);
            gunner.Load(fil);
            gunner.PrintILInfo(outdirect, true);
        }
    }
}
