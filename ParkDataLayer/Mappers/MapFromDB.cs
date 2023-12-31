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
    public class MapFromDB
    {
        //huurperiode
        public Huurperiode HuurperiodeFromDataHuurperiode(DataHuurPeriode dataHuurPeriode)
        {
            Huurperiode huurperiode = new Huurperiode(dataHuurPeriode.startDatum,dataHuurPeriode.dagenVerhuurd);
            return huurperiode;
        }
        //park
        public Park ParkFromDataPark(DataPark dataPark)
        {
            Park park = new Park(dataPark.Id,dataPark.Naam,dataPark.Locatie);
            return park;
        }
        //huis
        public Huis HuisFromDataHuis(DataHuis dataHuis,DataPark dataPark)
        {
            Huis huis = new Huis(dataHuis.Id,dataHuis.straat,dataHuis.nr,dataHuis.actief,ParkFromDataPark(dataPark));
            return huis;
        }
        //contactgegevens
        public Contactgegevens ContactGegevensFromDataContactGegevens(DataContactGegevens dataContactGegevens)
        {
            Contactgegevens contact = new Contactgegevens(dataContactGegevens.email,dataContactGegevens.telefoon,dataContactGegevens.adres);
            return contact;
        }
        //huurder
        public Huurder HuurderFromDataHuurder(DataHuurder dataHuurder,DataContactGegevens dataContactgegevens)
        {
            Huurder huurder = new Huurder(dataHuurder.Id, dataHuurder.naam,ContactGegevensFromDataContactGegevens(dataContactgegevens));
            return huurder;
        }
        //huurcontact
        public Huurcontract HuurContractFromDataHuurcontact(DataHuurContract dataHuurContract, DataHuurPeriode dataHuurPeriode, 
            DataHuurder dataHuurder, DataContactGegevens dataContactgegevens, DataHuis dataHuis, DataPark dataPark)
        {
            Huurcontract huurcontract = new Huurcontract(
                dataHuurContract.Id,
                HuurperiodeFromDataHuurperiode(dataHuurPeriode),
                HuurderFromDataHuurder(dataHuurder, dataContactgegevens),
                HuisFromDataHuis(dataHuis,dataPark)
                );
            return huurcontract;
        }
    }
}