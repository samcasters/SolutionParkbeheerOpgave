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
    public class HuurderRepositoryEF : IHuurderRepository
    {
        ParkeerOpgaveContext context = new ParkeerOpgaveContext();
        MapFromDB MapFromDB = new MapFromDB();
        MapToDB MapToDB = new MapToDB();

        public Huurder GeefHuurder(int id)
        {
            var dataHuurder = context.huurder.Where(h => h.Id == id).AsNoTracking().FirstOrDefault();
            var dataContactGegevens = context.contactGegevens.Where(c => c.telefoon == dataHuurder.Gegevenstelefoon).AsNoTracking().FirstOrDefault();
            var huurder = MapFromDB.HuurderFromDataHuurder(dataHuurder, dataContactGegevens);
            return huurder;
        }

        public List<Huurder> GeefHuurders(string naam)
        {
           IEnumerable<DataHuurder> dataHuurders = context.huurder.Where(h => h.naam == naam).AsNoTracking();
            List<Huurder> huurders = new List<Huurder>();
            foreach (DataHuurder huurder in dataHuurders)
            {
                huurders.Add(GeefHuurder(huurder.Id));
            }
            return huurders;
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            var dataHuurder = context.huurder.Where(h => h.naam == naam & h.Gegevenstelefoon == contact.Tel).AsNoTracking().FirstOrDefault();
            bool heefthuurder = false;
            if(dataHuurder is DataHuurder) { heefthuurder = true; }
            return heefthuurder;
        }

        public bool HeeftHuurder(int id)
        {
            var dataHuurder = context.huurder.Where(h => h.Id ==id).AsNoTracking().FirstOrDefault();
            bool heefthuurder = false;
            if (dataHuurder is DataHuurder) { heefthuurder = true; }
            return heefthuurder;
        }

        public void UpdateHuurder(Huurder huurder)
        {
            var dataHuurder = context.huurder.Where(h => h.Id == huurder.Id).AsNoTracking().FirstOrDefault();
            var dataContactGegevens = context.contactGegevens.Where(c => c.telefoon == dataHuurder.Gegevenstelefoon).AsNoTracking().FirstOrDefault();
            if (dataHuurder is DataHuurder) 
            {
                dataHuurder.naam = huurder.Naam;
                dataContactGegevens.email = huurder.Contactgegevens.Email;
                dataContactGegevens.adres = huurder.Contactgegevens.Adres;
            }
            context.SaveChanges();
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            DataHuurder dataHuurder = MapToDB.DataHuurderFromHuurder(h);
            context.huurder.Add(dataHuurder);
            context.SaveChanges();
            return h;
        }
    }
}
