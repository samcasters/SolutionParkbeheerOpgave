using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Data;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    
    public class HuizenRepositoryEF : IHuizenRepository
    {
        ParkeerOpgaveContext context = new ParkeerOpgaveContext();
        MapFromDB MapFromDB = new MapFromDB();

        public Huis GeefHuis(int id)
        {
            var dataHuis = context.huis.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            var dataPark = context.park.Where(p => p.Id == dataHuis.ParkId).AsNoTracking().FirstOrDefault();
            var huis = MapFromDB.HuisFromDataHuis(dataHuis, dataPark);
            return huis;

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            throw new NotImplementedException();
        }

        public bool HeeftHuis(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHuis(Huis huis)
        {
            throw new NotImplementedException();
        }

        public Huis VoegHuisToe(Huis h)
        {
            throw new NotImplementedException();
        }
    }
}
