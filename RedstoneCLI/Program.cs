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

DrippingHoney honey = new DrippingHoney();
Particle particle = (Particle) honey;
Console.WriteLine("Honey: " + honey.Name);
Console.WriteLine("Particle: " + particle.Name);
Console.ReadLine();
