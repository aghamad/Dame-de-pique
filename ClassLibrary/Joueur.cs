using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Joueur: IComparable<Joueur>, IEquatable<Joueur>
    {
        // Les Carte(s) qu'il aura/a en main 
        public List<Carte> Paquet {
            get; set;
        }

        public string Nom {
            get; set;
        }

        public string Image {
            get; set;
        }

        // Le joueur a que ces couleurs
        public List<int> Couleurs {
            get; set;
        }

        // Le 0 commence , le 1 suit, etc ... 
        public int Positionnement {
            get; set;
        }

        public Joueur(string nom, string image) {
            this.Nom = nom;
            this.Image = image;
            this.Couleurs = new List<int>() {0, 1, 2, 3}; /// 0 pour Pique, etc ... 
            this.Positionnement = 0; // Par defaut 
        }

        public override string ToString() {
            string deckEnString = "";
            foreach (Carte carte in Paquet) {
                deckEnString += carte.ToString() + "\n";
            }
            return deckEnString;
        }

        public int CompareTo(Joueur other) {
            return Positionnement.CompareTo(other.Positionnement);
        }

        // + Image pour plus de verification 
        public bool Equals(Joueur other) {
            return this.Nom == other.Nom &&
                this.Image == other.Image;
        }

    }
}
