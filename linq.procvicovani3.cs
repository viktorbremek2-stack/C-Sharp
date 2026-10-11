using System;
using System.Collections.Generic;
using System.Linq;

var objednavky = new List<Objednavka>
{
    new(1, "Anna", "Praha", 1200m, new() { "myš", "klávesnice" }),
    new(2, "Petr", "Brno", 300m, new() { "kabel" }),
    new(3, "Anna", "Praha", 800m, new() { "monitor" }),
    new(4, "Jana", "Brno", 1500m, new() { "myš", "sluchátka", "kabel" }),
    new(5, "Petr", "Praha", 450m, new() { "klávesnice" }),
};

var avg = objednavky.Average(x => x.Celkem);


var groupby = objednavky.GroupBy(x => x.Mesto);
foreach (var y in groupby)
{
  Console.WriteLine($"{y.Key}: {y.Count()} objednavky");
  Console.WriteLine($"{y.Key}: {y.Average(o => o.Celkem):F2}");
}


var selectmany = objednavky.SelectMany(x => x.Polozky);
foreach (var polozka in selectmany)
{
  Console.WriteLine(polozka);

}


var unikatni = objednavky.SelectMany(x => x.Polozky).Distinct();
foreach (var polozka in unikatni)
{
  Console.WriteLine(polozka);
}

















record Objednavka(int Id, string Zakaznik, string Mesto, decimal Celkem, List<string> Polozky);
