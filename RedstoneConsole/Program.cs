#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Redstone
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Debug();
#endif

#if TEST
            TestSanction();
#endif

#if RELEASE
            // todo: add release mode
             Server.Init("release");
#endif
            Console.ReadLine();
        }

        private static void Debug()
        {
            Core.Redstone.Init("debug");
        }

        private static void TestSanction()
        {
            Console.WriteLine("***Redstone Test Mode***");
            Test2();
        }

        private static void Test1()
        {
            Core.Redstone.Init("test", "debug");

        }

        private static void Test2()
        {
            string dir = "C:\\Users\\super\\Documents\\Redstone\\work\\generated\\data\\minecraft\\worldgen\\biome";

        }
    }
}
