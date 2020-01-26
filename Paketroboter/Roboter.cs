using System;

namespace Paketroboter {
    class Roboter {
        // TESTDATEN
        private double TestGewicht = 2.0;
        //private Abmessung TestAbmessung = new Abmessung () { Länge = 10, Breite = 10, Tiefe = 10 };
        private Abmessung TestAbmessung = new Abmessung () { Länge = 62, Breite = 12, Tiefe = 15 };
        //private Abmessung TestAbmessung = new Abmessung () { Länge = 100, Breite = 90, Tiefe = 55 };
        //private Abmessung TestAbmessung = new Abmessung () { Länge = 100, Breite = 100, Tiefe = 100 };

        // Sender und Empfänger
        private Adresse TestSender = new Adresse () { Anrede = "Herr", Vorname = "Boris", Nachname = "Johnson", Stadt = "London", Land = "England", Straße = "Dowing Street", Hausnummer = "10", Personalausweisnummer = "123BREXIT" };
        private Adresse TestEmpfänger = new Adresse () { Anrede = "Herr", Vorname = "Ian", Nachname = "XXXXX", Stadt = "Lomdonderry", Land = "Irland", Straße = "Loosing Streek", Hausnummer = "10b", Personalausweisnummer = "XXXXXXXXX1XXXX" };

        /** Roboter-Gedächnis
            PaketInfo: Array der dem Roboter bekannten 3 Pakettypen mit deren Eigenschaften
            aktuelesPäckchen ist das mit SÄMTLICHNE Angeben versehenes zu verarbeitende 
            Päckchen inklusive Absender und Empfänger Variablen
        */
        public Päckchen [] PaketInfo = { new Päckchen () { Abmessungen = new Abmessung () { Länge = 35, Breite = 25, Tiefe = 10 }, Gewicht = 2.0, Preis = 2.97 }, new Päckchen () { Abmessungen = new Abmessung () { Länge = 60, Breite = 30, Tiefe = 15 }, Gewicht = 2.0, Preis = 3.97 }, new Päckchen () { Abmessungen = new Abmessung () { Länge = 100, Breite = 100, Tiefe = 100 }, Gewicht = 100.0, Preis = 12.90 } };
        private VersandtPäckchen aktuellesPäckchen; // Var-Deklaration - kein Objekt!
        private int aktuelleNummer = 1; // aktuelle Paketnummer

        // Methoden
        public void NimmPaket () {
            aktuellesPäckchen = new VersandtPäckchen (); // Objekterstellung
            aktuellesPäckchen.Id = aktuelleNummer; // Zuweisung der aktuellen Nummer
            aktuelleNummer++;  // inkrementiere NUmmer für weitere Pakete
            aktuellesPäckchen.Datum = System.DateTime.Today;
        }

        /** Simuliere eine Waage - TESTDATEN*/
        public void BestimmeGewicht () {
            this.aktuellesPäckchen.Gewicht = TestGewicht;
        }

        /** Simuliere Scanner zur Bestimmung der Paketgröße - TESTDATEN */
        public void BestimmeAbmessungen () {
            this.aktuellesPäckchen.Abmessungen = TestAbmessung;
        }

        // Bestimme Paketvolumen für den einfachen Vergleich von Pakete-Abwessungen
        private int BestimmePaketVolumen (Abmessung abmessung) {
            return abmessung.Breite * abmessung.Länge * abmessung.Tiefe;
        }


        public void BestimmePaketTyp () {
            int volumenAktuellesPaket = BestimmePaketVolumen ( aktuellesPäckchen.Abmessungen ); // Berechne Volumen des aktuellen Pakets

            //Console.WriteLine ( $"Volumen aktuelles Paket: {volumenAktuellesPaket}" );
            //Console.WriteLine ($"v0 = {BestimmePaketVolumen ( PaketInfo [ 0 ].Abmessungen )} " +
            //    $"v1={BestimmePaketVolumen ( PaketInfo [ 1 ].Abmessungen )}" +
            //    $" v2= {BestimmePaketVolumen ( PaketInfo [ 2 ].Abmessungen )}" );

            if ( ( volumenAktuellesPaket > 0 ) && ( volumenAktuellesPaket < BestimmePaketVolumen ( PaketInfo [ 0 ].Abmessungen ) ) ) {
                aktuellesPäckchen.Preis = PaketInfo [ 0 ].Preis;
            }
            else if ( ( volumenAktuellesPaket >= BestimmePaketVolumen ( PaketInfo [ 0 ].Abmessungen ) ) &&
                ( volumenAktuellesPaket < BestimmePaketVolumen ( PaketInfo [ 1 ].Abmessungen ) ) ) {
                aktuellesPäckchen.Preis = PaketInfo [ 1 ].Preis;
            }
            else if ( ( volumenAktuellesPaket >= BestimmePaketVolumen ( PaketInfo [ 1 ].Abmessungen ) ) &&
                ( volumenAktuellesPaket < BestimmePaketVolumen ( PaketInfo [ 2 ].Abmessungen ) ) ) {
                aktuellesPäckchen.Preis = PaketInfo [ 2 ].Preis;
            }
            else {
                Console.WriteLine ( "Ich kann das so nicht benutzen ... ;-)" );
            }

            //Console.WriteLine ( aktuellesPäckchen.Preis );
        }

        public void BestimmeSender () {
            // Scan Sender
            aktuellesPäckchen.SenderAdresse = TestSender;
        }
        public void BestimmeEmpfänger () {
            // Scan Empfänger
            aktuellesPäckchen.EmpfängerAdresse = TestEmpfänger;
        }


        public void DruckeBelege () {
            Console.WriteLine ( $"Paketid: #{aktuellesPäckchen.Id} Datum: {aktuellesPäckchen.Datum}" );
            Console.WriteLine ( "Adresse: Sender" );
            Console.WriteLine ( $"{aktuellesPäckchen.SenderAdresse.Anrede} " +
                $"{aktuellesPäckchen.SenderAdresse.Vorname} " +
                $"{aktuellesPäckchen.SenderAdresse.Nachname} " +
                $"{aktuellesPäckchen.SenderAdresse.Land} " +
                $"{aktuellesPäckchen.SenderAdresse.Stadt} " +
                $"{aktuellesPäckchen.SenderAdresse.Straße} " +
                $"{aktuellesPäckchen.SenderAdresse.Hausnummer} " +
                $"" );

            Console.WriteLine ( "Adresse: Empfänger" );
            Console.WriteLine ( $"{aktuellesPäckchen.EmpfängerAdresse.Anrede} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Vorname} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Nachname} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Land} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Stadt} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Straße} " +
                $"{aktuellesPäckchen.EmpfängerAdresse.Hausnummer} " +
                $"" );

            Console.WriteLine ( $"Abmessungen:\nLänge:{aktuellesPäckchen.Abmessungen.Länge}" +
                $" Breite:{aktuellesPäckchen.Abmessungen.Breite}" +
                $" Tiefe:{aktuellesPäckchen.Abmessungen.Tiefe}" );

            Console.WriteLine ( $"Gewicht: {aktuellesPäckchen.Gewicht}" );
            Console.WriteLine ( $"Preis: {aktuellesPäckchen.Preis}" );

        }
    }

}

class Abmessung {
    public int Länge { get; set; }
    public int Breite { get; set; }
    public int Tiefe { get; set; }
};

class Adresse {
    public string Anrede { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Personalausweisnummer { get; set; }
    public string Stadt { get; set; }
    public string Plz { get; set; }
    public string Straße { get; set; }
    public string Hausnummer { get; set; }
    public string Land { get; set; } = "Deutschland";
}

class Päckchen {
    public double Gewicht { get; set; }
    public Abmessung Abmessungen { get; set; }
    public double Preis { get; set; }

}

class VersandtPäckchen : Päckchen {
    public VersandtPäckchen () {
        base.Abmessungen = new Abmessung ();
    }
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public Adresse SenderAdresse { get; set; } = new Adresse ();
    public Adresse EmpfängerAdresse { get; set; } = new Adresse ();
}

