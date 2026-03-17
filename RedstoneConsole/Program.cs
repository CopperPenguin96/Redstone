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
            string file = "lines.txt";
            string[] entLines = File.ReadAllLines(file);

            var outLines = new List<string>();
            foreach (var raw in entLines)
            {
                if (string.IsNullOrWhiteSpace(raw))
                    continue;

                var line = raw.Trim();
                var tokens = line.Split(',');

                string a = string.Empty, b = string.Empty, c = string.Empty, d = string.Empty, e = string.Empty;

                if (tokens.Length >= 5)
                {
                    b = tokens[0].Trim();
                    a = tokens[1].Trim();
                    c = tokens[2].Trim();
                    d = tokens[3].Trim();
                    e = tokens[4].Trim();
                }
                else if (tokens.Length == 4)
                {
                    // expected formats like: {b},{a},{c}{d},{e} or {b},{a},{c} {d},{e}
                    b = tokens[0].Trim();
                    a = tokens[1].Trim();

                    var mid = tokens[2].Trim();
                    // try common separators between c and d
                    var mdParts = mid.Split(new[] { ' ', ':', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (mdParts.Length >= 2)
                    {
                        c = mdParts[0].Trim();
                        d = mdParts[1].Trim();
                    }
                    else
                    {
                        // fallback: assign same value to c and d
                        c = mid;
                        d = mid;
                    }

                    e = tokens[3].Trim();
                }
                else
                {
                    // can't parse this line, skip it
                    continue;
                }

                // clean up e from surrounding quotes
                e = e.Trim('"');

                var formatted = $"public static readonly EntityType {a} = new({b}, {c}, {d}, \"{e}\");";
                outLines.Add(formatted);
                Console.WriteLine(formatted);
            }

            File.WriteAllLines("new.txt", outLines);
            Console.WriteLine($"Wrote {outLines.Count} lines to new.txt");

        }
    }
}
