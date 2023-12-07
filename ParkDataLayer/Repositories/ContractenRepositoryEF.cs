using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Data;
using ParkDataLayer.Mappers;
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

        public Huurcontract GeefContract(string id)
        {
            // huis
            //var dataHuis = context.huis.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            //var dataPark = context.park.Where(p => p.Id == dataHuis.ParkId).AsNoTracking().FirstOrDefault();
            //var huurcontract = MapFromDB.HuisFromDataHuis(dataHuis, dataPark);
            //return huurcontract;
            throw new NotImplementedException();
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }

        public void VoegContractToe(Huurcontract contract)
        {
            throw new NotImplementedException();
        }
    }
}
