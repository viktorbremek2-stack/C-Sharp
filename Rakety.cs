using System;
using System.Collections.Generic;
using System.Numerics;

namespace Rakety
{
  internal class Program
  {
    static void Main(string[] args)
    {


      //seznam raket linq
      var rakety = new List<Raketa>
{
    new("Aurora 1","ESA",2018,420m,true,new List<string>{"led na Měsíci","sluneční vítr"}),
    new("Falcon X","NovaSpace",2020,550m,true,new List<string>{"nová exoplaneta","kosmický prach"}),
    new("Titan Explorer","NASA",2016,780m,true,new List<string>{"metanová jezera","atmosféra Titanu"}),
    new("Orion Scout","JAXA",2022,310m,false,new List<string>()),
    new("Red Horizon","SpaceX",2024,650m,true,new List<string>{"vzorky z Marsu","podzemní led"}),
    new("Red Horizon","SpaceX",2024,650m,true,new List<string>{"vzorky z Marsu","podzemní led"}),
    new("Sakura One","JAXA",2019,470m,true,new List<string>{"minerály na asteroidu"}),
    new("Bharat Star","ISRO",2021,530m,true,new List<string>{"stopy vody","povrchové horniny"}),
    new("Dragon Quest","SpaceX",2023,720m,true,new List<string>{"vzorky atmosféry Marsu"}),
    new("Nebula Scout","NovaSpace",2014,280m,false,new List<string>()),
    new("Atlas Pioneer","NASA",2012,860m,true,new List<string>{"nová kometa","kosmický led"}),
    new("Orion Deep","ESA",2020,690m,true,new List<string>{"organické molekuly","sluneční bouře"}),
    new("Hikari Explorer","JAXA",2016,350m,false,new List<string>()),
    new("Mars Falcon","SpaceX",2025,910m,true,new List<string>{"podzemní voda","sopečný prach"}),
    new("Shenzhou Nova","CNSA",2018,580m,true,new List<string>{"krystaly v měsíční půdě"}),
    new("Europa Glider","NASA",2022,640m,true,new List<string>{"ledové pukliny","slané částice"}),
    new("Aurora Scout","ESA",2013,315m,true,new List<string>{"polární záření"}),
    new("Kibo Runner","JAXA",2024,760m,true,new List<string>{"mikroorganismy","nové plyny"}),
    new("Sirius Explorer","ISRO",2011,430m,false,new List<string>()),
    new("Blue Origin One","Blue Origin",2023,500m,true,new List<string>{"vlastnosti horní atmosféry"}),
    new("Terra Watch","NovaSpace",2010,245m,true,new List<string>{"změny magnetického pole"}),
    new("Red Comet","CNSA",2021,835m,true,new List<string>{"nový asteroid","kovové částice"}),
    new("Luna Voyager","NASA",2015,575m,false,new List<string>()),
    new("Phoenix Rise","SpaceX",2026,980m,true,new List<string>{"hluboké zásoby ledu","nové minerály"})
};




      //vypsani menu raket

      static void napsaniMenu()
      {
        Console.WriteLine("   === MENU RAKET ===");
        Console.WriteLine("1 - Vypsat všechny rakety");
        Console.WriteLine("2 - Najít raketu podle názvu");
        Console.WriteLine("3 - Vypsat raketu která vyletěla nejvýše");
        Console.WriteLine("4 - Vypsat rakety s úspěšnými misemi");
        Console.WriteLine("0 - Ukončit program");
        Console.Write("Vyber možnost: ");


      }


      string volba;
      do
      {
        napsaniMenu();
        volba = Console.ReadLine() ?? string.Empty;

        switch (volba)

        {
          case "1":
            var vypis = rakety
           .Select(r => $"{r.Nazev} - {r.Agentura} - {r.MaximalniVyskaKm} km byla nejvíce vysoko");
            foreach (var jmeno in vypis)
            {
              Console.WriteLine(jmeno);
            }
            break;
          case "2":
            Console.Write("Zadej název rakety: ");
            string hledanyNazev = Console.ReadLine() ?? string.Empty;

            var nalezenaRaketa = rakety
                .FirstOrDefault(x => x.Nazev == hledanyNazev);

            if (nalezenaRaketa is null)
            {
              Console.WriteLine("Raketa nebyla nalezena.");
            }
            else
            {
              Console.WriteLine(
                  $"raketa byla nalezena: {nalezenaRaketa.Nazev} - {nalezenaRaketa.Agentura} - {nalezenaRaketa.MaximalniVyskaKm} km");
            }

            break;
          case "3":

            var nejvyssiRaketa = rakety.MaxBy(x => x.MaximalniVyskaKm);
            if (nejvyssiRaketa is not null)
            {
              Console.WriteLine(
                  $"{nejvyssiRaketa.Nazev} - {nejvyssiRaketa.Agentura}");
            }

            break;

          case "4":
            var úspěšnéMise = rakety.Where(y => y.MiseUspesna);
            foreach (var mise in úspěšnéMise)
            {
              Console.WriteLine($"{mise.Nazev} - {mise.Agentura} - {mise.MaximalniVyskaKm} km");
            }
            break;
          default:
            Console.WriteLine("Neplatná volba");
            break;
          case "0":
            return;

        }
      } while (volba != "0");




    }







  }

};




public record Raketa(
    string Nazev,
    string Agentura,
    int RokStartu,
    decimal MaximalniVyskaKm,
    bool MiseUspesna,
    List<string> Objevy);





