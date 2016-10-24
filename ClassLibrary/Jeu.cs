﻿
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

        public List<Carte> ListeCartesEnJeu {
            get; set;
        }

        // ------ Vous
        public Joueur Player
        {
            get { return getJoueur(PlayerStatic); }
        }

        // Ordinateur
        public Joueur PlayerA
        {
            get { return getJoueur(PlayerAStatic); }
        }

        // Ordinateur
        public Joueur PlayerN
        {
            get { return getJoueur(PlayerNStatic); }
        }

        // Ordinateur
        public Joueur PlayerH {
            get { return getJoueur(PlayerHStatic); }
        }

        // ----- Vous / STATIC: Ne Quitte pas la liste 
        public Joueur PlayerStatic
        {
            get; set;
        }

        // Ordinateur
        public Joueur PlayerAStatic {
            get; set;
        }

        // Ordinateur
        public Joueur PlayerNStatic
        {
            get; set;
        }

        // Ordinateur
        public Joueur PlayerHStatic
        {
            get; set;
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

        // L'usager choisit d'abord son nom et son image et apres le jeu commence
        public Jeu(Joueur player) {
            this.PlayerStatic = player;
            this.PlayerAStatic = new Joueur("Ahmad", "player-A.png");
            this.PlayerNStatic = new Joueur("Nassim", "player-N.png");
            this.PlayerHStatic = new Joueur("Halim", "player-H.png");

            // AJOUT dans la liste de joueurs 
            ListeDesJoueurs = new ListJoueurs();
            ListeDesJoueurs.Add(PlayerStatic);
            ListeDesJoueurs.Add(PlayerAStatic);
            ListeDesJoueurs.Add(PlayerNStatic);
            ListeDesJoueurs.Add(PlayerHStatic);

            // Initialize le Deck 
            this.Deck = new Paquet(); // Creation des Carte(s) 

            // Initialize la liste pour mettre les Cartes en jeu (4 cartes en total) 
            this.ListeCartesEnJeu = new List<Carte>();

            // Couleur trefle qui commence
            this.Suit = Couleur.Trefle;
            // Distribuer
            distribuer();
            // Position
            AssignerUnePosition();
        }

        private Joueur getJoueur(Joueur player) {
            foreach (Joueur joueur in ListeDesJoueurs) {
                if (joueur.Equals(player)) {
                    return joueur;
                }
            }
            return null;
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

        // Methode Ordinateur
        // A tour de role Thread.sleep pour les Ordinateurs
        // Jusqu'a qu'il trouve une Carte random qui correspont a la Coleur/Suit joue de la partie 
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
            //Console.WriteLine(cartesValide[0].Value + " Ass");
            // Si elle n'est pas vide. Cela dit que le Joueur-Ordi a une carte de la couleur en question qui peut etre joue
            if (cartesValide.Count != 0)  {
                carte = cartesValide[0];
                ListeCartesEnJeu.Add(carte);
                joueur.Paquet.Remove(carte);
                return carte;
            }
            else {
                // Get l'index de la Couleur
                int index = (int) Suit;
                List<int> couleursRestant = joueur.Couleurs;
                if (couleursRestant.Count == 0) {
                    // Jouer n'a plus de carte / Jeu terminé 
                    return null;
                }
                // Apres enleve l'index de la couleur dans joueur 
                couleursRestant.Remove(index);
                // L'ordinateur joue une autre Couleur/Suit random et ne prend pas en consideration la couleur qu'il ne possede pas 
                int indexCouleur = joueur.Couleurs[random.Next(couleursRestant.Count)];
                // Nouvelle Suit du jeu 
                this.Suit = (Couleur)indexCouleur; // il faut update le suit dans FormJeu alors 
                // Rejoue pour mettre une carte 
                putCarte(joueur);
            }

   
            // Jouer n'a plus de carte / Jeu terminé 
            return null;
            
        }

        public void verification() {
            // Utilise la liste ListeCartesEnJeu
        }

    }
}
