using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Paquet : List<Carte>
    {

        static Random random = new Random();

        public Paquet() {
            Createpaquet();
        }

        /// <summary>
        /// Creation du Paquet du Jeu
        /// </summary>
        public void Createpaquet() {
            int imageID = 1;
            foreach (Couleur coleur in Enum.GetValues(typeof(Couleur))) {
                foreach (Valeur valeur in Enum.GetValues(typeof(Valeur))){
                    String image = imageID + ".png";
                    Carte carte = new Carte(coleur, valeur, image);
                    this.Add(carte);
                    imageID++;
                }
            }
        }

        /// <summary>
        /// Distribue un paquet de 13 Cartes random a chaque membre dans le jeu. 
        /// Chaque deroulement de cette fonction enlevera 13 Cartes du Paquet du Jeu 
        /// </summary>
        /// <returns> Une Liste de 13 Cartes </returns>
        public List<Carte> Distribuer() {
            List<Carte> paquetDuJoueur = null;
            if (this.Count >= 13) {
                paquetDuJoueur = new List<Carte>();
                for (int i = 0; i < 13; i++) {
                    // La Carte random a ajouter
                    Carte carte = this[random.Next(this.Count)];
                    // Ajout une Carte random au paquet. La position de la Carte varie de 0 entre le length de la liste
                    paquetDuJoueur.Add(carte);
                    this.Remove(carte);
                }
            }
            return paquetDuJoueur;
        }
    }
}
