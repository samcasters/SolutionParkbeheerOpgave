using ParkBusinessLayer.Model;
using ParkDataLayer.Data;
using ParkDataLayer.Migrations;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//text voor de start
namespace StartUp
{
    internal class Program
    {
        enum option { Huis,Park,Huurder,ContactGegevens,HuurPeriode,HuurContract}

        static void Main(string[] args)
        {
            using ParkeerOpgaveContext context = new ParkeerOpgaveContext();
            HuizenRepositoryEF huizenRepository = new HuizenRepositoryEF();
            HuurderRepositoryEF huurderRepository = new HuurderRepositoryEF();
            ContractenRepositoryEF contractenRepository = new ContractenRepositoryEF();
            //InitializeDatabase(context);
            //GeefHuisVanId(1,huizenRepository);
            MainMenu(context,huizenRepository,huurderRepository,contractenRepository);
        }

        static void MainMenu(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository,HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Clear();
            Console.Write($"Wat will je doen?\n" +
                          $"1:Opvraagen\n" +
                          $"2:Aanmaken\n" +
                          $"3:Aanpasen\n" +
                          $"4:Verwijderen\n" +
                          $"5:Alles Opvragen\n" +
                          $"6:Reset Databank\n" +
                          $"7:Exit\n\n" +
                          $"Geef 1tot6 :");
            string input = Console.ReadLine();
            int option;
            string OperationNr;
            switch (input)
            {
                case "1":
                    option = ToonOptions("Opvragen");
                    OperationNr = $"1{option}";
                    ExecuteOparation(OperationNr,context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "2":
                    option = ToonOptions("Aanmaken");
                    OperationNr = $"2{option}";
                    ExecuteOparation(OperationNr, context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "3":
                    option = ToonOptions("Aanpasen");
                    OperationNr = $"3{option}";
                    ExecuteOparation(OperationNr, context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "4":
                    option = ToonOptions("Verwijderen");
                    OperationNr = $"4{option}";
                    ExecuteOparation(OperationNr, context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "5":
                    option = ToonOptions("Alles Opvragen");
                    OperationNr = $"4{option}";
                    ExecuteOparation(OperationNr, context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "6":
                    InitializeDatabase(context);
                    Console.WriteLine("databank reset succesvol");
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                case "cls":
                    Console.Clear();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "help":
                    Console.WriteLine("\nlorem ipsum \n\nEnter to continue\n");
                    Console.ReadLine();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                default:
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
            }
        }
        static int ToonOptions(string extraInfo)
        {
            Console.Clear();
            Console.Write($"{extraInfo}\n" +
                          $"1:Huis\n" +
                          $"2:Huurder\n" +
                          $"3:HuurContract\n\n" +
                          $"Geef 1tot3 :");
            string input = Console.ReadLine();
            int inputInt;
            bool isInt = int.TryParse(input, out inputInt);
            if (isInt)
            {
                if (inputInt > 0 & inputInt < 4)
                {
                    return inputInt;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{input} is geen geldig getal. het getal moet van 1 tot 3 zijn");
                    return ToonOptions(extraInfo);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{input} is geen geldig getal");
                return ToonOptions(extraInfo);
            }
            
        }
        static void ExecuteOparation(string oparationNr, ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Clear();
            switch (oparationNr)
            {
                //OPVRAGEN
                case"11":
                    // huis opvragen
                    GeefHuisVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "12":
                    //huurder opvragen
                    GeefHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "13":
                    //contract opvragen
                    GeefContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;

                //AANMAKEN
                case "21":
                    //huis aanmaken
                    huizenRepository.VoegHuisToe(MaakHuisAan(context, huizenRepository, huurderRepository, contractenRepository));
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "22":
                    //huurder aanmaken
                    huurderRepository.VoegHuurderToe(MaakHuurderAan(context, huizenRepository, huurderRepository, contractenRepository));
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "23":
                    //contract aanmaken
                    contractenRepository.VoegContractToe(MaakContractAan(context, huizenRepository, huurderRepository, contractenRepository));
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;

                //AANPASEN
                case "31":
                    //huis aanpasen
                    PasHuisAanVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "32":
                    //huurder aanpasen
                    PasHuurderAanVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "33":
                    //contract aanpasen
                    PasContractAanVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;

                //VERWIJDEREN
                case "41":
                    //huis verwijderen
                    VerwijderHuisVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "42":
                    //huurder verwijderen
                    VerwijderHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "43":
                    //contract verwijderen
                    VerwijderContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;

                //ALLES OPVRAGEN
                case "51":
                    //huis verwijderen
                    VerwijderHuisVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "52":
                    //huurder verwijderen
                    VerwijderHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
                case "53":
                    //contract verwijderen
                    VerwijderContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
                    enterToContinue();
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;

                default:
                    MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
                    break;
            }
        }
        //static void DeleteAllRowsFromAllTables()
        //{

        //}
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
        static void VraagvoorTerugNaarMainMenuTeGaan(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Write("type back om terug naar main menu te gaan : ");
            string input = Console.ReadLine();
            if(input.ToLower() == "back")
            {
                Console.Clear();
                MainMenu(context, huizenRepository, huurderRepository, contractenRepository);
            }
        }
        static int VraagVoorInt(string vraag)
        {
            bool isInt = false;
            Console.Write(vraag);
            string input = Console.ReadLine();
            int output = 0;
            while (!isInt)
            {
                isInt = int.TryParse(input, out output);
            }
            return output;
        }
        static DateTime VraagVoorDateTime(string vraag)
        {
            
            Console.Write(vraag);
            string dtString = Console.ReadLine();
            DateTime dt = DateTime.MinValue;
            bool isDt = false;
            while(!isDt)
            {
               isDt = DateTime.TryParse(dtString, out dt);
            }
            return dt;
        }
        static void enterToContinue()
        {
            Console.WriteLine("enter om door te gaan");
            Console.Read();
        }

        //Opvragen
        static Huis GeefHuisVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {

            Console.Write($"huisId: ");
            string huisId = Console.ReadLine();
            bool isInt = int.TryParse(huisId, out int id);
            if (!isInt) 
            {
                Console.Clear();
                Console.WriteLine($"{huisId} geen geldig getal");
                VraagvoorTerugNaarMainMenuTeGaan(context, huizenRepository, huurderRepository, contractenRepository);
                GeefHuisVanId(context,huizenRepository,huurderRepository,contractenRepository);
            }
            Huis huis = huizenRepository.GeefHuis(id);
            Console.WriteLine($"HUIS:{huis.Id}: Str={huis.Straat},Nr={huis.Nr},Prk={huis.Park.Naam}");
            return huis;
        }
        static Huurder GeefHuurderVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {

            Console.Write($"hurderId: ");
            string huurderId = Console.ReadLine();
            bool isInt = int.TryParse(huurderId, out int id);
            if (!isInt)
            {
                Console.Clear();
                Console.WriteLine($"{huurderId} geen geldig getal");
                VraagvoorTerugNaarMainMenuTeGaan(context, huizenRepository, huurderRepository, contractenRepository);
                GeefHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
            }
            Huurder huurder = huurderRepository.GeefHuurder(id);
            Console.WriteLine($"HUURDER:{huurder.Id}: naam={huurder.Naam},adr={huurder.Contactgegevens.Adres},email={huurder.Contactgegevens.Email},tel={huurder.Contactgegevens.Tel}");
            return huurder;
        }
        static Huurcontract GeefContractVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {

            Console.Write($"contractId: ");
            string contractId = Console.ReadLine();
            
            if (contractenRepository.HeeftContract(contractId))
            {
                Console.Clear();
                Console.WriteLine($"geen contract gevonden onder {contractId}");
                VraagvoorTerugNaarMainMenuTeGaan(context, huizenRepository, huurderRepository, contractenRepository);
                GeefContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
            }
            Huurcontract huurcontract = contractenRepository.GeefContract(contractId);
            Console.WriteLine($"HUURCONTRACT:{huurcontract.Id}: huisId={huurcontract.Huis.Id},huurderId={huurcontract.Huurder.Id},start={huurcontract.Huurperiode.StartDatum},einde={huurcontract.Huurperiode.EindDatum}");
            Console.WriteLine("enter om door te gaan");
            Console.Read();
            return huurcontract;
        }
        //Aanmaken
        static Huis MaakHuisAan(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            
            Console.Write("huis-straat : ");
            string huisStraat = Console.ReadLine();

            int huisNr = VraagVoorInt("huis-nr : ");
            
            Console.Write("park-naam : ");
            string parkNaam = Console.ReadLine();
            
            Console.Write("park-locatie : ");
            string parkLocatie = Console.ReadLine();

            Park newPark = new Park(parkNaam,parkLocatie) ;
            Huis newHuis = new Huis(huisStraat,huisNr,newPark);

            Console.WriteLine($"HUIS:{newHuis.Id}: Str={newHuis.Straat},Nr={newHuis.Nr},Prk={newHuis.Park.Naam}");
            return newHuis;
        }
        static Huurder MaakHuurderAan(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Write("huurder-naam  : ");
            string huurderNaam = Console.ReadLine();
            Console.Write("contact-tel   : ");
            string contactTel = Console.ReadLine();
            Console.Write("contact-email : ");
            string contactEmail = Console.ReadLine();
            Console.Write("contact-adres : ");
            string contactAdres = Console.ReadLine();

            Contactgegevens newContactgegevens = new Contactgegevens(contactEmail,contactTel,contactAdres);
            Huurder newHuurder = new Huurder(huurderNaam,newContactgegevens);

            Console.WriteLine($"HUURDER:{newHuurder.Id}: naam={newHuurder.Naam},adr={newHuurder.Contactgegevens.Adres},email={newHuurder.Contactgegevens.Email},tel={newHuurder.Contactgegevens.Tel}");
            return newHuurder;
        }
        static Huurcontract MaakContractAan(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            
            Huis huis = GeefHuisVanId(context, huizenRepository, huurderRepository, contractenRepository);
            Huurder huurder = GeefHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
            DateTime huurperiodeStartDatum = VraagVoorDateTime("huurperiode-StartDatum  : ");
            int huurperiodeAantalDagen = VraagVoorInt("huurperiode-aantaldagen : ");

            Huurperiode newHuurperiode = new Huurperiode(huurperiodeStartDatum, huurperiodeAantalDagen);
            Huurcontract newHuurcontract = new Huurcontract(null,newHuurperiode,huurder,huis);

            Console.WriteLine($"HUURCONTRACT:{newHuurcontract.Id}: huisId={newHuurcontract.Huis.Id},huurderId={newHuurcontract.Huurder.Id},start={newHuurcontract.Huurperiode.StartDatum},einde={newHuurcontract.Huurperiode.EindDatum}");
            return newHuurcontract;
        }
        //Aanpasen
        static void PasHuisAanVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.WriteLine("Update-Huis");
            Huis huis = GeefHuisVanId(context, huizenRepository, huurderRepository, contractenRepository);
            Huis updatedHuis = MaakHuisAan(context, huizenRepository, huurderRepository, contractenRepository);
            updatedHuis.ZetId(huis.Id);
            huizenRepository.UpdateHuis(updatedHuis);
        }
        static void PasHuurderAanVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.WriteLine("Update-Huurder");
            Huurder huurder = GeefHuurderVanId(context, huizenRepository, huurderRepository, contractenRepository);
            Huurder updatedHuurder = MaakHuurderAan(context, huizenRepository, huurderRepository, contractenRepository);
            updatedHuurder.ZetId(huurder.Id);
            huurderRepository.UpdateHuurder(updatedHuurder);
        }
        static void PasContractAanVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.WriteLine("Update-Contract");
            Huurcontract huurcontract = GeefContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
            Huurcontract updatedHuurcontract = MaakContractAan(context, huizenRepository, huurderRepository, contractenRepository);
            updatedHuurcontract.ZetId(huurcontract.Id);
            contractenRepository.UpdateContract(updatedHuurcontract);
        }
        //Verwijderen
        static void VerwijderHuisVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Write($"huisen kunnen niet verwijderd worden");
        }
        static void VerwijderHuurderVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {
            Console.Write($"hurders kunnen niet verwijderd worden");
        }
        static void VerwijderContractVanId(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        {

            Console.Write($"contractId: ");
            string contractId = Console.ReadLine();

            if (contractenRepository.HeeftContract(contractId))
            {
                Console.Clear();
                Console.WriteLine($"geen contract gevonden onder {contractId}");
                VraagvoorTerugNaarMainMenuTeGaan(context, huizenRepository, huurderRepository, contractenRepository);
                GeefContractVanId(context, huizenRepository, huurderRepository, contractenRepository);
            }
            contractenRepository.AnnuleerContract(contractenRepository.GeefContract(contractId));
            Console.WriteLine("enter om door te gaan");
            Console.Read();
        }
        //Alles Opvragen
        //static void GeefAlleHuisen(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        //{
        //}
        //static void GeefAlleHuurders(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        //{
        //}
        //static void GeefAlleContracten(ParkeerOpgaveContext context, HuizenRepositoryEF huizenRepository, HuurderRepositoryEF huurderRepository, ContractenRepositoryEF contractenRepository)
        //{
        //}



    }
}