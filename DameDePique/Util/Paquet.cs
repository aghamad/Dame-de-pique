using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DameDePique
{
    class Paquet : List<Carte>
    {

        static Random random = new Random();

        public Paquet() {
            Createpaquet();
        }

        // Creation du paquet 
        public void Createpaquet() {
            foreach (Couleur coleur in Enum.GetValues(typeof(Couleur))) {
                foreach (Valeur valeur in Enum.GetValues(typeof(Valeur))){
                    Carte carte = new Carte(coleur, valeur);
                    this.Add(carte);
                }
            }
        }

        // Distribue un paquet de 13 Carte(s) random a chaque membre dans la partie
        public List<Carte> Distribuer() {
            List<Carte> paquetDuJoueur = null;
            if (this.Count >= 13) {
                paquetDuJoueur = new List<Carte>();
                for (int i = 0; i < 13; i++) {
                    Carte carte = this[random.Next(this.Count)]; // La Carte random a ajouter
                    paquetDuJoueur.Add(carte); // Ajout une Carte random au paquet. La position de la Carte varie de 0 entre le length de la liste
                    this.Remove(carte); // En totale chaque deroulement de cette fonction enlevera 13 Carte du paquet. A la fin 0 carte
                }
            }
            return paquetDuJoueur;
        }
    }
}
