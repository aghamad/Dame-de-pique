using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblio
{
    enum Couleur {Pique, Coeur, Carreau, Trefle};
    enum Valeur { As = 1, Deux = 2, Trois = 3, Quatre = 4, Cinq = 5, Six = 6, Sept = 7, Huit = 8, Neuf = 9, Dix = 10, Valet = 11, Dame = 12, Roi = 13}

    public class Carte: IEquatable<Carte>
    {
        private Couleur Color
        {
            get; set;
        }

        private Valeur Value {
            get; set;
        }

        // Set dans le constructeur 
        public String Image {
            get; set;
        }

        private Carte(Couleur coleur, Valeur value) {
            this.Color = coleur;
            this.Value = value;
        }

        public override String ToString() {
            return this.Color.ToString() + ", " + this.Value.ToString();
        }

        public bool Equals(Carte other) {
            return this.Color == other.Color &&
                this.Value == other.Value;
        }
    }
}
