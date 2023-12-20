using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Data;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        ParkeerOpgaveContext context = new ParkeerOpgaveContext();
        MapFromDB MapFromDB = new MapFromDB();
        MapToDB MapToDB = new MapToDB();

        public void AnnuleerContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }
        //text voor push change
        public Huurcontract GeefContract(string id)
        {
            
            var dataHuurContract = context.huurContract.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            var dataHuurder = context.huurder.Where(hu => hu.Id == dataHuurContract.HuurderId).AsNoTracking().FirstOrDefault();
            var dataContactGegevens = context.contactGegevens.Where(c => c.telefoon == dataHuurder.Gegevenstelefoon).AsNoTracking().FirstOrDefault();
            var DataHuurPeriode = context.huurPeriode.Where(huu => huu.Id == dataHuurContract.HuurPeriodeId).AsNoTracking().FirstOrDefault();
            var dataHuis = context.huis.Where(hui => hui.Id == dataHuurContract.HuisId).AsNoTracking().FirstOrDefault();
            var dataPark = context.park.Where(p => p.Id == dataHuis.ParkId).AsNoTracking().FirstOrDefault();
            Huurcontract huurcontract = MapFromDB.HuurContractFromDataHuurcontact(dataHuurContract, DataHuurPeriode,dataHuurder,dataContactGegevens,dataHuis,dataPark);
            return huurcontract;
            throw new NotImplementedException();
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            IEnumerable<DataHuurContract> dataHuurContracten = context.huurContract.Where(h => h.HuurPeriode.startDatum >= dtBegin & h.HuurPeriode.eindDatum <= dtEinde).AsNoTracking();
            List<Huurcontract> huurcontracten = new List<Huurcontract>();
            foreach (var huurcontract in dataHuurContracten)
            {
                huurcontracten.Add(GeefContract(huurcontract.Id));
            }
            return huurcontracten;
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(string id)
        {
            bool heeftContract = false;
            var DataHuurContract = context.huurContract.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            if (DataHuurContract is DataHuurContract)
            {
                heeftContract = true;
            }
            return heeftContract;
        }

        public void UpdateContract(Huurcontract contract)
        {
            var newDataHuurcontract = MapToDB.DataHuurContractFromHuurcontact(contract);
            var oldDataHuurContract = context.huurContract.Where(h => h.Id == newDataHuurcontract.Id).AsNoTracking().FirstOrDefault();
            if(newDataHuurcontract is DataHuurContract)
            {
                oldDataHuurContract = newDataHuurcontract;
            }
            context.SaveChanges();
        }

        public void VoegContractToe(Huurcontract contract)
        {
            var dataHuurContract = MapToDB.DataHuurContractFromHuurcontact(contract);
            context.huurContract.Add(dataHuurContract);
            context.SaveChanges();
        }
    }
}
