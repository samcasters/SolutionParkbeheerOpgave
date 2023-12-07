using ParkBusinessLayer.Model;
using ParkDataLayer.Data;
using ParkDataLayer.Migrations;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ParkeerOpgaveContext context = new ParkeerOpgaveContext();
            HuizenRepositoryEF huizenRepository = new HuizenRepositoryEF();
            //InitializeDatabase(context);
            //GeefHuisVanId(1,huizenRepository);
            MainMenu(context);
        }

        static void MainMenu(ParkeerOpgaveContext context)
        {
            Console.Write($"1:Opvraagen\n" +
                          $"2:Aanmaken\n" +
                          $"3:Aanpasen\n" +
                          $"4:Verwijderen\n" +
                          $"5:Reset Databank\n" +
                          $"6:Exit\n\n" +
                          $"Geef 1tot6 :");
            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":

                     break;
                case "2":

                     break;
                case "3":

                     break;
                case "4":

                    break;
                case "5":
                    InitializeDatabase(context);
                    Console.WriteLine("databank reset succesvol");
                    MainMenu(context);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"|{input}| is geen geldige optie je moet een getal van 1tot6 geven");
                    MainMenu(context);
                    break;
            }
        }
        static void DeleteAllRowsFromTable()
        {

        }
        static void InitializeDatabase(ParkeerOpgaveContext context)
        {
            ///data
            //park
            DataPark park = new DataPark() { Id = "parkId1", Naam = "park1", Locatie = "parkLocatie1" };
            //huis
            DataHuis huis1 = new DataHuis() { actief = true, nr = 1,ParkId = park.Id, Park = park, straat = "straat1" };
            context.huis.Add(huis1);
            DataHuis huis2 = new DataHuis() { actief = false, nr = 2, ParkId = park.Id, Park = park, straat = "straat1" };
            context.huis.Add(huis2);
            DataHuis huis3 = new DataHuis() { actief = true, nr = 3, ParkId = park.Id, Park = park, straat = "straat2" };
            context.huis.Add(huis3);
            DataHuis huis4 = new DataHuis() { actief = true, nr = 4, ParkId = park.Id, Park = park, straat = "straat2" };
            context.huis.Add(huis4);
            //huisen in park steken
            List<DataHuis> huisen = new List<DataHuis>() { huis1, huis2, huis3, huis4 };
            park.huisen = huisen;
            context.park.Add(park);

            //huurGegevens
            DataContactGegevens contactgegevens1 = new DataContactGegevens() { email = "email1", adres = "adres1", telefoon = "telefoon1" };
            context.contactGegevens.Add(contactgegevens1);
            DataContactGegevens contactgegevens2 = new DataContactGegevens() { email = "email2", adres = "adres2", telefoon = "telefoon2" };
            context.contactGegevens.Add(contactgegevens2);
            DataContactGegevens contactgegevens3 = new DataContactGegevens() { email = "email3", adres = "adres3", telefoon = "telefoon3" };
            context.contactGegevens.Add(contactgegevens3);

            DataHuurder huurder1 = new DataHuurder() { naam = "huurder1", Gegevens = contactgegevens1 };
            context.huurder.Add(huurder1);
            DataHuurder huurder2 = new DataHuurder() { naam = "huurder2", Gegevens = contactgegevens2 };
            context.huurder.Add(huurder2);
            DataHuurder huurder3 = new DataHuurder() { naam = "huurder3", Gegevens = contactgegevens3 };
            context.huurder.Add(huurder3);

            DataHuurPeriode huurperiode1 = new DataHuurPeriode() { startDatum = DateTime.Now, dagenVerhuurd = 1, eindDatum = DateTime.Now.AddDays(1) };
            context.huurPeriode.Add(huurperiode1);
            DataHuurPeriode huurperiode2 = new DataHuurPeriode() { startDatum = DateTime.Now, dagenVerhuurd = 2, eindDatum = DateTime.Now.AddDays(2) };
            context.huurPeriode.Add(huurperiode2);
            DataHuurPeriode huurperiode3 = new DataHuurPeriode() { startDatum = DateTime.Now, dagenVerhuurd = 3, eindDatum = DateTime.Now.AddDays(3) };
            context.huurPeriode.Add(huurperiode3);

            //huurcontract
            DataHuurContract huurContract1 = new DataHuurContract() { Id = "huurcontract1", Huis = huis1, Huurder = huurder1, HuurPeriode = huurperiode1 };
            context.huurContract.Add(huurContract1);
            DataHuurContract huurContract2 = new DataHuurContract() { Id = "huurcontract2", Huis = huis2, Huurder = huurder2, HuurPeriode = huurperiode2 };
            context.huurContract.Add(huurContract2);
            DataHuurContract huurContract3 = new DataHuurContract() { Id = "huurcontract3", Huis = huis3, Huurder = huurder3, HuurPeriode = huurperiode3 };
            context.huurContract.Add(huurContract3);

            context.SaveChanges();
        }
        static void GeefHuisVanId(int id, HuizenRepositoryEF huizenRepository)
        {
            Huis huis = huizenRepository.GeefHuis(id);
            Console.WriteLine($"HUIS:{huis.Id}: Str={huis.Straat},Nr={huis.Nr},Prk={huis.Park.Naam}");
        }
    }
}