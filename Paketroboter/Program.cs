using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketroboter {
    class Program {
        static void Main (string [] args) {
            Roboter päcky = new Roboter ();
            päcky.NimmPaket ();
            päcky.BestimmeGewicht ();
            päcky.BestimmeAbmessungen ();
            päcky.BestimmePaketTyp ();
            päcky.BestimmeSender ();
            päcky.BestimmeEmpfänger ();
            päcky.DruckeBelege ();

            Console.ReadLine ();
        }
    }
}
