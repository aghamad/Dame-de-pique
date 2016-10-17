using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DameDePique
{
    class Joueur
    {
        // Les Carte(s) qu'il aura/a en main 
        public List<Carte> Paquet {
            get; set;
        }

        public String Nom {
            get; set;
        }

        public String Image {
            get; set;
        }

        // Le joueur a que ces couleurs
        public List<int> Couleurs {
            get; set;
        }

        // Le 0 commence , le 1 suit, etc ... 
        public int Positionnement
        {
            get; set;
        }

        public Joueur(String nom, String image) {
            this.Nom = nom;
            this.Image = image;
            this.Couleurs = new List<int>() {0, 1, 2, 3}; /// 0 pour Pique, etc ... 
            this.Positionnement = 0; // Par defaut 
        }

        public override String ToString() {
            String deckEnString = "";
            foreach (Carte carte in Paquet) {
                deckEnString += carte.ToString() + "\n";
            }
            return deckEnString;
        }

    }
}
