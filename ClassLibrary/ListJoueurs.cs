using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ListJoueurs: List<Joueur>
    {
        /// <summary>
        /// Le Joueur pointeur est soit le premier soit le perdant 
        /// </summary>
        public Joueur Premier {
            get; set;
        }

        /// <summary>
        /// Get la position dans la liste du Joueur pointeur 
        /// </summary>
        /// <returns> La position du Joueur pointeur </returns>
        public int getIndexDuPremier() {
            Console.Write(this.IndexOf(Premier));
            return this.IndexOf(Premier);
        }

        /// <summary>
        /// Cette méthode boucle dans la liste des joueurs et assigne à chaque joueur une position
        /// </summary>
        public void MoveAndAssigne() {
            int pos = getIndexDuPremier();
            int position = 0;
            int positionRestart = 0;
            for (int i = pos; i < this.Count + pos; i++) {
                if (i < this.Count) {
                    position++;
                    this[i].Positionnement = position;
                }
                else {
                    if (i >= this.Count) {
                        // La liste recommence de le debut
                        position++;
                        this[positionRestart].Positionnement = position;
                        positionRestart++;
                    }
                }
            }
        }




    }
}
