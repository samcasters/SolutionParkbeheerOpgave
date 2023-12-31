using ParkBusinessLayer.Model;
using ParkDataLayer.Migrations;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class MapToDB
    {
        //huurperiode
        public DataHuurPeriode DataHuurPeriodeFromHuurperiode(Huurperiode huurperiode)
        {
            DataHuurPeriode dataHuurperiode = new DataHuurPeriode() {startDatum = huurperiode.StartDatum, dagenVerhuurd = huurperiode.Aantaldagen, eindDatum = huurperiode.EindDatum };
            return dataHuurperiode;
        }
        //park
        public DataPark DataParkFromPark(Park Park)
        {
            DataPark dataPark = new DataPark() { Id = Park.Id, Naam = Park.Naam, Locatie = Park.Locatie };
            return dataPark;
        }
        //huis
        public DataHuis DataHuisFromHuis(Huis Huis)
        {
            DataHuis dataHuis = new DataHuis() {Id = Huis.Id, actief = Huis.Actief, nr = Huis.Nr,ParkId = DataParkFromPark(Huis.Park).Id, Park = DataParkFromPark(Huis.Park), straat = Huis.Straat };
            return dataHuis;
        }
        //contactgegevens
        public DataContactGegevens DataContactGegevensFromContactGegevens(Contactgegevens contactGegevens)
        {
            DataContactGegevens dataContact = new DataContactGegevens() { email = contactGegevens.Email, adres = contactGegevens.Adres, telefoon = contactGegevens.Tel };
            return dataContact;
        }
        //huurder
        public DataHuurder DataHuurderFromHuurder(Huurder huurder)
        {
            DataHuurder dataHuurder = new DataHuurder() {Id = huurder.Id, naam = huurder.Naam,Gegevenstelefoon = DataContactGegevensFromContactGegevens(huurder.Contactgegevens).telefoon, Gegevens = DataContactGegevensFromContactGegevens(huurder.Contactgegevens)};
            return dataHuurder;
        }
        //huurcontact
        public DataHuurContract DataHuurContractFromHuurcontact(Huurcontract huurcontract)
        {
            DataHuurContract dataHuurContract = new DataHuurContract() { 
                Id = huurcontract.Id,
                HuisId = DataHuisFromHuis(huurcontract.Huis).Id,
                Huis = DataHuisFromHuis(huurcontract.Huis), 
                HuurderId = DataHuurderFromHuurder(huurcontract.Huurder).Id,
                Huurder = DataHuurderFromHuurder(huurcontract.Huurder), 
                HuurPeriodeId = DataHuurPeriodeFromHuurperiode(huurcontract.Huurperiode).Id,
                HuurPeriode = DataHuurPeriodeFromHuurperiode(huurcontract.Huurperiode) 
            };
            return dataHuurContract;
        }
    }
}
