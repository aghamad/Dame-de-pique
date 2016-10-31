
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Jeu
    {
        public static Random random = new Random();

        // La classe Mere de notre Projet
        // Ces methodes seront called by le forme

        // Trois autres Joueur(s) ordinateur et vous 
        public ListJoueurs ListeDesJoueurs {
            get; set;
        }

        public Dictionary<Carte, Joueur> ListeCartesEnJeu {
            get; set;
        }

        // ------ Vous / Afin de le Get dans le formjeu 
        public Joueur JoueurNonOrdinateur {
            get; set;
        }

        // Peu n'importe sa position dans la liste toujours le retourne / Cette liste sera ordered souvent par positionnement 
        public Joueur Player
        {
            get { return getJoueur(JoueurNonOrdinateur); }
        }

        // Les Joueurs ordinateurs 
        public Joueur PlayerAhmad
        {
            get { return getJoueur("Ahmad"); }
        }

        public Joueur PlayerNassim
        {
            get { return getJoueur("Nassim"); }
        }

        public Joueur PlayerHalim
        {
            get { return getJoueur("Halim"); }
        }

        // ----- DECK DU JEU 
        // Les Cartes 
        public Paquet Deck {
            get; set;
        }

        // La Coleur/Suit en jeu
        public Couleur Suit {
            get; set;
        }

        // Marque la fin
        // Si un Joueur n'a plus de carte 
        public bool Fin {
            get; set;
        }

        // L'usager choisit d'abord son nom et son image et apres le jeu commence
        public Jeu(Joueur player) {
            this.JoueurNonOrdinateur = player;
            Joueur playerAhmad = new Joueur("Ahmad", "player-A.png");
            Joueur playerNassim = new Joueur("Nassim", "player-N.png");
            Joueur playerHalim = new Joueur("Halim", "player-H.png");

            // AJOUT dans la liste de joueurs Note: Cette liste va etre order by positionnement souvent 
            ListeDesJoueurs = new ListJoueurs();
            ListeDesJoueurs.Add(player);
            ListeDesJoueurs.Add(playerAhmad);
            ListeDesJoueurs.Add(playerNassim);
            ListeDesJoueurs.Add(playerHalim);

            // Initialize le Deck 
            this.Deck = new Paquet(); // Creation des Carte(s) 

            // Initialize la liste pour mettre les Cartes en jeu (4 cartes en total) 
            this.ListeCartesEnJeu = new Dictionary<Carte, Joueur>();

            // Couleur trefle qui commence / Essayer de tester tout les Couleurs ici surtout la Couleur Coueur (car elle valent des points)
            this.Suit = Couleur.Trefle;
            // Distribuer
            distribuer();
            // Position au premier lancement 
            AssignerUnePosition();
            // Fin
            this.Fin = false;
        }

        public Dictionary<Joueur, Carte> Verification() {

            // Le Dict qui sera send back to FormJeu
            Dictionary<Joueur, Carte> info = new Dictionary<Joueur, Carte>();

            //  Il suffit d'essayer de ne pas ramasser de cartes de coeurs ou la dame de pique.
            //  Une carte de type coeurs = 1 point et la dame de pique = 12 points. 
            //  La carte la plus forte de la sorte demandée remporte la levée
            // Pointeur
            Carte highest = null;
            foreach (KeyValuePair<Carte, Joueur> entry in ListeCartesEnJeu) {
                // Le pointeur sera le dernier
                highest = entry.Key;
            }

            // Regarde avec la position de l'enum
            foreach (KeyValuePair<Carte, Joueur> entry in ListeCartesEnJeu) {
                if ((int)highest.Value < (int)entry.Key.Value) {
                    highest = entry.Key;
                }
            }

            // Ceci est le perdant 
            // Adjust l'info du Joueur perdant
            Joueur perdant = ListeCartesEnJeu[highest];
            Carte dameDePique = new Carte(Couleur.Pique, Valeur.Dame);
            // Apres il faut voir si le perdant a rammaser une carte de type coueurs ou la dame de pique 
            foreach (KeyValuePair<Carte, Joueur> entry in ListeCartesEnJeu) {
                if (entry.Key.Equals(dameDePique)) {
                    perdant.Pointage += 12;
                } else if (entry.Key.Color == Couleur.Coeur) {
                    perdant.Pointage += 1;
                }
            }

            RegleLePos(perdant);
            this.ListeCartesEnJeu.Clear();

            info.Add(perdant, highest);
            return info;
        }

        // Pour get le joueur, nom ici est dynamique alors c'est pour ca on ne get pas avec le nom 
        private Joueur getJoueur(Joueur player) {
            foreach (Joueur joueur in ListeDesJoueurs) {
                if (joueur.Equals(player)) {
                    return joueur;
                }
            }
            return null;
        }

        // Pour get les ordi dasn cette unordered list 
        private Joueur getJoueur(string name)  {
            foreach (Joueur joueur in ListeDesJoueurs){
                if (joueur.Nom.Equals(name)) {
                    return joueur;
                }
            }
            return null;
        }

        // Perdant
        public Joueur GetPerdant()  {
            Joueur perdant = ListeDesJoueurs[0]; // Pointeur 
            foreach (Joueur joueur in ListeDesJoueurs) {
                if (perdant.Pointage < joueur.Pointage) {
                    perdant = joueur;
                }
            }
            return perdant;
        }

        // Distribue les cartes aux Joueurs
        public void distribuer() {
            foreach (Joueur joueur in ListeDesJoueurs) {
                joueur.Paquet = Deck.Distribuer();
            }
        }

        /// <summary>
        /// Au commencement du jeu, cette méthode assigne a tour de role une position a chaque joueur 
        /// </summary>
        public void AssignerUnePosition() {
            // Celui qui a la Carte (Deux de Trefle) commence le jeu 
            Carte carte = new Carte(Couleur.Trefle, Valeur.Deux);
            foreach (Joueur joueur in ListeDesJoueurs) {
                if (joueur.Paquet.Contains(carte)) {
                    ListeDesJoueurs.Premier = joueur;
                }
            }

            ListeDesJoueurs.MoveAndAssigne();
        }

        /// <summary>
        /// Cette méthode régle les positions pour le prochain tour  
        /// </summary>
        /// <param name="perdant"> Le joueur perdant dans le tour en question </param>
        public void RegleLePos(Joueur perdant) {
            ListeDesJoueurs.Premier = perdant;
            ListeDesJoueurs.MoveAndAssigne();
        }

        /// <summary>
        /// Trie en ordre croissant les joueurs avec leur positionnement 
        /// </summary>
        /// <returns> La liste des joueurs en ordre de commencement </returns>
        public void OrderListAvecPos() {
            ListeDesJoueurs.Sort();
        }

        public Carte PutCarte(Joueur joueur) {
            Carte carte = null;
            List<int> couleursRestant = joueur.Couleurs; // en int 
            List<Carte> paquetDuJoueur = joueur.Paquet;
            List<Carte> cartesValide = new List<Carte>();
            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (Carte card in paquetDuJoueur) {
                if (card.Color.Equals(this.Suit)) {
                    cartesValide.Add(card);
                }
            }

            if (cartesValide.Count != 0) {
                carte = cartesValide[random.Next(cartesValide.Count)]; 
                ListeCartesEnJeu.Add(carte, joueur);
                joueur.Paquet.Remove(carte);
            } else if (cartesValide.Count == 0 && couleursRestant.Count != 0) {
                int index = (int) Suit;
                couleursRestant.Remove(index);
                int indexCouleur = joueur.Couleurs[random.Next(couleursRestant.Count)];
                this.Suit = (Couleur) indexCouleur;

                // Pour ajoute une nouvelle carte de cette suite
                // cartesValides est a 0 ici 
                foreach (Carte card in paquetDuJoueur)  {
                    if (card.Color.Equals(this.Suit)){
                        cartesValide.Add(card);
                    }
                }
                carte = cartesValide[random.Next(cartesValide.Count)];
            }

            // return null si le joueur n'a plus de carte 
            return carte;
        }

        // Methode Depricated 
        /// <summary>
        /// Methode Ordinateur
        /// A tour de role Thread.sleep pour les Ordinateurs
        /// Jusqu'a qu'il trouve une Carte random qui correspont a la Coleur/Suit joue de la partie 
        /// </summary>
        /// <param name="joueur"> Le Joueur Ordinateur </param>
        /// <returns></returns>
        public Carte putCarte(Joueur joueur) {
            Carte carte = null;
            List<Carte> paquetDuJoueur = joueur.Paquet;
            List<Carte> cartesValide = new List<Carte>();
            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (Carte card in paquetDuJoueur) {
                if (card.Color.Equals(Suit)) {
                    cartesValide.Add(card);
                }
            }
            // Si elle n'est pas vide. Cela dit que le Joueur-Ordi a une carte de la couleur en question qui peut etre joue
            if (cartesValide.Count != 0) {
                carte = cartesValide[random.Next(cartesValide.Count)]; // Incluant 0 
                ListeCartesEnJeu.Add(carte, joueur);
                joueur.Paquet.Remove(carte);
            } else if (paquetDuJoueur.Count != 0) {
                // Il n'a plus de Cette couleur mais que son paquet n'est pas encore vide
                // Get l'index de la Couleur
                int index = (int) Suit;
                List<int> couleursRestant = joueur.Couleurs; // en int 
                // Apres enleve l'index de la couleur dans joueur 
                couleursRestant.Remove(index);
                // L'ordinateur joue une autre Couleur/Suit random et ne prend pas en consideration la couleur qu'il ne possede pas 
                int indexCouleur = joueur.Couleurs[random.Next(couleursRestant.Count)];
                // Nouvelle Suit du jeu 
                this.Suit = (Couleur)indexCouleur; // il faut update le suit dans FormJeu alors 
                // Rejoue pour mettre une carte 
                putCarte(joueur);
            }

            // else si cette methode return carte null ca veut dire que l'usager n'a plus de carte 0 dans son paquet
            // Jouer n'a plus de carte / Jeu terminé 
            // this.Fin = false if carte is null
            return carte;
            
        }

    }
}
