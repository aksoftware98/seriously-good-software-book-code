// See https://aka.ms/new-console-template for more information
using Chapter_03_NeedForSpeed;
using Chapter_03_NeedForSpeed.Speed1;

#region Speed 1 Test
//Console.WriteLine("Speed: Making adding water a constant speed:");
//var containerA = new ContainerForConstantAddingWater();
//var containerB = new ContainerForConstantAddingWater();
//var containerC = new ContainerForConstantAddingWater();
//var containerD = new ContainerForConstantAddingWater();
#endregion

#region Speed 2 Test
Console.WriteLine("Speed: Making adding water a constant speed:");
var containerA = new Chapter_03_NeedForSpeed.Speed2.Container();
var containerB = new Chapter_03_NeedForSpeed.Speed2.Container();
var containerC = new Chapter_03_NeedForSpeed.Speed2.Container();
var containerD = new Chapter_03_NeedForSpeed.Speed2.Container();
#endregion

containerA.AddWater(12);
containerB.AddWater(8);
containerA.ConnectTo(containerB);

Console.WriteLine($"Container A: {containerA.GetAmount()}");
Console.WriteLine($"Container B: {containerB.GetAmount()}");
Console.WriteLine($"Container C: {containerC.GetAmount()}");
Console.WriteLine($"Container D: {containerD.GetAmount()}");

Console.ReadKey(); 