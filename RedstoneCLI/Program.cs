// See https://aka.ms/new-console-template for more information

using Redstone;
using Redstone.ChatSystem;
using Redstone.Entities;
using Redstone.Entities.Particles;
using Redstone.Utils;

/*Server.Start();

foreach (string file in Directory.GetFiles("Redstone/"))
{
    Console.WriteLine(file);
}*/

string csFile = @"using Redstone.Types;

namespace Redstone.Worlds.Blocks
{
    public class {0} : Block
    {
        public override string Name => ""{1}"";

        public override Identifier Id => ""{2}"";

        public override int Type => {3};

        public override int Meta => {4};
    }
}";

string newDir = "classes/";
string file = "new.txt";
string[] lines = File.ReadAllLines(file);

foreach (string line in lines)
{
    string[] parts = line.Split("&");
    string newFileName = newDir + parts[0] + ".cs";
    Console.WriteLine("Writing to " + newFileName);
    var writer = File.CreateText(newFileName);

    string newLine = csFile.Replace("{0}", parts[0]);
    newLine = newLine.Replace("{1}", parts[1]);
    newLine = newLine.Replace("{2}", parts[2]);
    newLine = newLine.Replace("{3}", parts[3]);
    newLine = newLine.Replace("{4}", parts[4]);
    
    //string.Format(csFile, parts[0], parts[1], parts[2], parts[3], parts[4]);

    writer.WriteLine(newLine);
    writer.Flush();
    writer.Close();
}

Console.ReadLine();
