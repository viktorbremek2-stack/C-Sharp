using System;
using System.Numerics;


var rakety = new List<Raketa>
{
    new("Aurora 1","ESA",2018,420m,true,new List<string>{"led na Měsíci","sluneční vítr"}),
    new("Falcon X","NovaSpace",2020,550m,true,new List<string>{"nová exoplaneta","kosmický prach"}),
    new("Titan Explorer","NASA",2016,780m,true,new List<string>{"metanová jezera","atmosféra Titanu"}),
    new("Orion Scout","JAXA",2022,310m,false,new List<string>()),
    new("Red Horizon","SpaceX",2024,650m,true,new List<string>{"vzorky z Marsu","podzemní led"})
};


var vysky = rakety
    .OrderByDescending(p => p.MaximalniVyskaKm);
foreach (var raketa in vysky)
{
  Console.WriteLine
  ($"{raketa.Nazev}: {raketa.MaximalniVyskaKm} km");
}






var nejnizsi = rakety.MinBy(y => y.MaximalniVyskaKm);
var nejvyssi = rakety.MaxBy(p => p.MaximalniVyskaKm);
if (nejnizsi is not null)
{
  Console.WriteLine(
      $"Nejnižší raketa: {nejnizsi.Nazev} - {nejnizsi.MaximalniVyskaKm} km");
}

if (nejvyssi is not null)
{
  Console.WriteLine(
      $"Nejvyšší raketa: {nejvyssi.Nazev} - {nejvyssi.MaximalniVyskaKm} km");
}

decimal celkem = rakety.Sum(p => p.MaximalniVyskaKm);
Console.WriteLine(
    $"Součet maximálních výšek: {celkem} km");
var skip = rakety
    .Skip(3)
    .Take(2);
foreach (var raketa in rakety)
{
  Console.WriteLine(raketa.Nazev);
}

bool vsechnyUspesne = rakety
    .All(r => r.MiseUspesna);

Console.WriteLine(vsechnyUspesne);


var groupByResult = rakety.GroupBy(x => x.RokStartu);

foreach (var y in groupByResult)
{
  Console.WriteLine(y.Key);
  foreach (var item in y)
  {
    Console.WriteLine(item.Nazev);
  }
}




record Raketa(string Nazev, string Agentura, int RokStartu, decimal MaximalniVyskaKm, bool MiseUspesna, List<string> Objevy);
