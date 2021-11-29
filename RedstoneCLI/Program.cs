// See https://aka.ms/new-console-template for more information

using Redstone;
using Redstone.ChatSystem;
using Redstone.Entities;
using Redstone.Entities.Particles;
using Redstone.Utils;

Server.Start();

foreach (string file in Directory.GetFiles("Redstone/"))
{
    Console.WriteLine(file);
}

Console.ReadLine();
