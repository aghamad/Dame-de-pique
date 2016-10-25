using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum Couleur {Pique = 0, Coeur = 1, Carreau = 2, Trefle = 3};
    public enum Valeur { As = 1, Deux = 2, Trois = 3, Quatre = 4, Cinq = 5, Six = 6, Sept = 7, Huit = 8, Neuf = 9, Dix = 10, Valet = 11, Dame = 12, Roi = 13}

    public class Carte: IEquatable<Carte>
    {
        public Couleur Color
        {
            get; set;
        }

        public Valeur Value {
            get; set;
        }

        public string Image {
            get; set;
        }

        public Carte(Couleur coleur, Valeur value, string image) {
            this.Color = coleur;
            this.Value = value;
            this.Image = image;
        }

        public Carte(Couleur coleur, Valeur value) {
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
