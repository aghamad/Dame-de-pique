﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Jeu
    {
        static Random random = new Random();

        // La classe Mere de notre Projet
        // Ces methodes seront called by le forme

        // Trois autres Joueur(s) ordinateur et vous 
        public List<Joueur> ListeDesJoueurs {
            get; set;
        }

        public List<Carte> ListeCartesEnJeu {
            get; set;
        }

        // Vous
        public Joueur Player
        {
            get { return ListeDesJoueurs[0]; }
        }

        // Ordinateur
        public Joueur PlayerA {
            get { return ListeDesJoueurs[1]; }
        }

        // Ordinateur
        public Joueur PlayerN
        {
            get { return ListeDesJoueurs[2]; }
        }

        // Ordinateur
        public Joueur PlayerH
        {
            get { return ListeDesJoueurs[3]; }
        }

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
            Joueur playerA = new Joueur("Ahmad", "player-A.png");
            Joueur playerN = new Joueur("Nassim", "player-N.png");
            Joueur playerH = new Joueur("Halim", "player-H.png");

            // AJOUT dans la liste de joueurs 
            ListeDesJoueurs = new List<Joueur>();
            ListeDesJoueurs.Add(player);
            ListeDesJoueurs.Add(playerA);
            ListeDesJoueurs.Add(playerN);
            ListeDesJoueurs.Add(playerH);

            // Initialize le Deck 
            this.Deck = new Paquet(); // Creation des Carte(s) 

            // Initialize la liste pour mettre les Cartes en jeu (4 cartes en total) 
            this.ListeCartesEnJeu = new List<Carte>();

            // Couleur trefle qui commence
            this.Suit = Couleur.Trefle;
        }

        // Distribue les cartes aux Joueurs
        public void distribuer() {
            foreach (Joueur joueur in ListeDesJoueurs) {
                joueur.Paquet = Deck.Distribuer();
            }
        }

        // Donne à chacun un positionnement 
        public void Starting() {
            // Celui qui a Deux de Trefle commence la partie
            Carte carte = new Carte(Couleur.Trefle, Valeur.Deux);
            // le joueur qui commence 
            Joueur joueur = null; 
            foreach (Joueur player in ListeDesJoueurs) {
                if (player.Paquet.Contains(carte)) {
                    // 1 = Celui qui commence, apres c'est dans le sens horaire
                    player.Positionnement = 1;
                    joueur = player;
                    break;
                }
            }

            // Son positionnement dans le array 
            int pos = ListeDesJoueurs.IndexOf(joueur);

            switch (pos) {

                case 0:
                    // Assignation normale
                    for (int i = 0; i < ListeDesJoueurs.Count; i++) {
                        ListeDesJoueurs[i].Positionnement = i + 1;
                    }
                    break;
                case 1:
                    ListeDesJoueurs[0].Positionnement = 4;
                    ListeDesJoueurs[2].Positionnement = 2;
                    ListeDesJoueurs[3].Positionnement = 3;
                    break;
                case 2:
                    ListeDesJoueurs[0].Positionnement = 3;
                    ListeDesJoueurs[1].Positionnement = 4;
                    ListeDesJoueurs[3].Positionnement = 2;
                    break;
                case 3:
                    ListeDesJoueurs[0].Positionnement = 2;
                    ListeDesJoueurs[1].Positionnement = 3;
                    ListeDesJoueurs[2].Positionnement = 4;
                    break;

            }
        }

        // Le perdant commence le nouveau tour  
        public void RegleLePos(Joueur perdant) {
            // A faire 
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
        public void putCarte(Joueur joueur)
        {
            Carte carte = null;
            List<Carte> paquetDuJoueur = joueur.Paquet;
            List<Carte> cartesValide = new List<Carte>();

            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (Carte card in paquetDuJoueur)
            {
                if (card.Color == Suit)
                {
                    cartesValide.Add(carte);
                }
            }

            // Si elle n'est pas vide. Cela dit que le Joueur-Ordi a une carte de la couleur en question qui peut etre joue
            if (cartesValide.Count != 0)
            {
                carte = cartesValide[random.Next(cartesValide.Count)];
            }
            else
            {
                // Get l'index de la Couleur
                int index = (int)Suit;
                List<int> couleursRestant = joueur.Couleurs;
                if (couleursRestant.Count == 0)
                {
                    // Jouer n'a plus de carte / Jeu terminé 
                }
                // Apres enleve l'index de la couleur 
                couleursRestant.Remove(index);
                // L'ordinateur joue une autre Couleur/Suit random et ne prend pas en consideration la couleur qu'il ne possede pas 
                int indexCouleur = joueur.Couleurs[random.Next(couleursRestant.Count)];
                // Nouvelle Suit du jeu 
                this.Suit = (Couleur)indexCouleur;
                // Rejoue pour mettre une carte 
                putCarte(joueur);
            }

            // Ajout Success
            if (carte != null)
            {
                ListeCartesEnJeu.Add(carte);
                joueur.Paquet.Remove(carte);
            }
            else
            {
                // Jouer n'a plus de carte / Jeu terminé 
            }
        }

        public void verification() {
            // Utilise la liste ListeCartesEnJeu
        }

    }
}
