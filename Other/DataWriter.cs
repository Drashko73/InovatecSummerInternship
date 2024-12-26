using Rent_A_Car.Rezervacije;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Other {
    internal sealed class DataWriter {
        /// <summary>
        /// Upisuje nove rezervacije u fajl.
        /// Format fajla: VoziloId,KupacId,PocetakRezervacije,KrajRezervacije
        /// </summary>
        /// <param name="putanjaDirektorijuma"></param>
        /// <param name="nazivFajla"></param>
        /// <param name="nove_rezervacije"></param>
        internal static void UpisiRezervacije(string putanjaDirektorijuma, string nazivFajla, List<Rezervacija> nove_rezervacije) {

            // provera da li postoji direktorijum
            if (!System.IO.Directory.Exists(putanjaDirektorijuma)) {
                Console.WriteLine("Direktorijum ne postoji, kreiram novi direktorijum: " + putanjaDirektorijuma);
                System.IO.Directory.CreateDirectory(putanjaDirektorijuma);
            }

            string putanja = putanjaDirektorijuma + nazivFajla;

            // upisuje nove rezervacije u fajl
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(putanja)) {
                // upis header-a fajla
                file.WriteLine("VoziloId,KupacId,PocetakRezervacije,KrajRezervacije");

                foreach (var r in nove_rezervacije) {
                    file.WriteLine(r.VoziloId + "," + r.KupacId + "," + r.PocetakRezervacije.ToShortDateString() + "," + r.KrajRezervacije.ToShortDateString());
                }
            }

            Console.WriteLine("Uspesno upisane nove rezervacije u fajl na putanji: " + putanja);
        }
    }
}
