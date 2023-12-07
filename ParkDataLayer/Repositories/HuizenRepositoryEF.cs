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
        MapToDB MapToDB = new MapToDB();

        public Huis GeefHuis(int id)
        {
            var dataHuis = context.huis.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            var dataPark = context.park.Where(p => p.Id == dataHuis.ParkId).AsNoTracking().FirstOrDefault();
            var huis = MapFromDB.HuisFromDataHuis(dataHuis, dataPark);
            return huis;

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            var dataPark = context.park.Where(p => p.Id == park.Id ).AsNoTracking().FirstOrDefault();
            bool heeftHuis = false;
            foreach(Huis huis in park.Huizen())
            {
                if(huis.Straat == straat & huis.Nr == nummer)
                {
                    heeftHuis = true; break;
                }
            }
            return heeftHuis;
        }

        public bool HeeftHuis(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHuis(Huis huis)
        {
            var dataHuis = context.huis.Where(h => h.Id == huis.Id).AsNoTracking().FirstOrDefault();

            if(dataHuis is DataHuis)
            {
                dataHuis.actief = huis.Actief;
                dataHuis.nr = huis.Nr;
                dataHuis.straat = huis.Straat;
                dataHuis.ParkId = huis.Park.Id;
            }
            context.SaveChanges();
        }

        public Huis VoegHuisToe(Huis h)
        {
            DataHuis dataHuis = MapToDB.DataHuisFromHuis(h);
            context.huis.Add(dataHuis);
            context.SaveChanges();
            return h;
        }
    }
}
