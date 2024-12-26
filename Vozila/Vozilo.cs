
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila {
    internal abstract class Vozilo {

        public int Id { get; protected set; }
        public string Model { get; protected set; }
        public double Potrosnja { get; protected set; }
        public List<Tuple<DateTime, DateTime>> Rezervacije { get; protected set; }

        public Vozilo(int id, string model, double potrosnja) {
            Id = id;
            Model = model;
            Potrosnja = potrosnja;
            Rezervacije = new List<Tuple<DateTime, DateTime>>();
        }

        public Vozilo(int id, string model, double potrosnja, List<Tuple<DateTime, DateTime>> rezervacije) {
            Id = id;
            Model = model;
            Potrosnja = potrosnja;
            Rezervacije = rezervacije;
        }

        /// <summary>
        /// Doda period nove rezervacije u listu opsega kada je vozilo rezervisano
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        public void DodajRezervaciju(DateTime pocetak, DateTime kraj) {
            Rezervacije.Add(new Tuple<DateTime, DateTime>(pocetak, kraj));
        }

        /// <summary>
        /// Uklanja period rezervacije iz liste opsega kada je vozilo rezervisano
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        public void ObrisiRezervaciju(DateTime pocetak, DateTime kraj) {
            Rezervacije.Remove(new Tuple<DateTime, DateTime>(pocetak, kraj));
        }

        /// <summary>
        /// Proverava da li je vozilo slobodno u zadatom periodu
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        /// <returns></returns>
        public bool DaLiJeSlobodan(DateTime pocetak, DateTime kraj) {
            foreach (var r in Rezervacije) {
                if(r.Item1 <= kraj && r.Item2 >= pocetak) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Racuna cenu po danu za vozilo
        /// </summary>
        /// <returns></returns>
        public abstract double CenaPoDanu();

        /// <summary>
        /// Dohvata pocetnu cenu vozila
        /// </summary>
        /// <returns></returns>
        public abstract double PocetnaCena();

        public override string ToString() {
            string s = Constants.LINE + Environment.NewLine;
            s += "Id:" + Id + Environment.NewLine + "Model:" + Model + Environment.NewLine + "Cena po danu:" + CenaPoDanu() + "e" + Environment.NewLine;
            return s;
        }
    }
}
