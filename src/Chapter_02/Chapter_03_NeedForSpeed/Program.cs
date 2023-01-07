// See https://aka.ms/new-console-template for more information
using Chapter_03_NeedForSpeed;

Console.WriteLine("Speed: Making adding water a constant speed:");

var containerA = new ContainerForConstantAddingWater();
var containerB = new ContainerForConstantAddingWater();
var containerC = new ContainerForConstantAddingWater();
var containerD = new ContainerForConstantAddingWater();

containerA.AddWater(12);
containerB.AddWater(8);
containerA.ConnectTo(containerB);

Console.WriteLine($"Container A: {containerA.GetAmount()}");
Console.WriteLine($"Container B: {containerB.GetAmount()}");
Console.WriteLine($"Container C: {containerC.GetAmount()}");
Console.WriteLine($"Container D: {containerD.GetAmount()}");

Console.ReadKey(); 