using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;
using System.Collections.Generic;
using System;
using System.Drawing.Imaging;

namespace DameDePique
{
    public partial class FormJeu : Form
    {
        private Jeu jeu;
        private string pathCarteImages;
        // Suit/ Couleur du Jeu
        private Couleur suit;
        // PictureBoxe List et list des Cartes joue
        private List<PictureBox> pictureBoxJoue;

        // Les Cartes du Joueur
        private Dictionary<PictureBox, Carte> mesCartes;

        public FormJeu(Joueur joueur) {
            InitializeComponent();
            // Disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Path
            this.pathCarteImages = Application.StartupPath + @"\CarteImages\";

            // Ouvre form de style ou l'usager choisit son bonhomme et ecrit son nom (a faire)
            Joueur player = new Joueur("Bledard", "image.png");

            // Commencement du jeu / Intialize le Jeu avec le Joueur 
            this.jeu = new Jeu(player);

            // Pour le Jeu les 4 Cartes Joue
            this.pictureBoxJoue = new List<PictureBox>();
            pictureBoxJoue.Add(pictureBoxMyCarte);
            pictureBoxJoue.Add(pictureBox2);
            pictureBoxJoue.Add(pictureBox3);
            pictureBoxJoue.Add(pictureBox4);

            // Les Cartes du Joueur 
            InitializeMesCartes();
            InitializeDeckField();
            UpdateSuit();
            //DisableWithSuit();

        }
        
        // Only called once / In order to Update the Panel / Create an Update method
        private void InitializeMesCartes() {
            this.mesCartes = new Dictionary<PictureBox, Carte>();
            for (int i = 0; i < jeu.Player.Paquet.Count; i++) {
                PictureBox pictureBox = new PictureBox {
                    Name = "pictureBox" + i,
                    Size = new Size(80, 120), // W and H 
                    Location = new Point(i * 80, 0),
                    // BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.AutoSize
                };

                // Other Settings
                pictureBox.Image = Image.FromFile(pathCarteImages + jeu.Player.Paquet[i].Image);
                pictureBox.Click += new System.EventHandler(Carte_Click);

                mesCartes.Add(pictureBox, jeu.Player.Paquet[i]);
            }
        }

        private void InitializeDeckField() {
            // Met ou Update les Cartes du Joueur dans la table
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                panelDisplay.Controls.Add(entry.Key);
            }
        }

        // Get La Carte associated with the PictureBox
        private Carte GetCarteWithPicBox(PictureBox pictureBox) {
            Carte carte = null;
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                if (pictureBox.Equals(entry.Key)) {
                    carte = entry.Value;
                }
            }
            return carte;
        }


        private void Carte_Click(object sender, EventArgs e) {

            if (pictureBoxMyCarte.Visible == false) {
                for (int i = 0; i < pictureBoxJoue.Count; i++) {
                    pictureBoxJoue[i].Visible = true;
                }
            }

            PictureBox pictureBox = (PictureBox) sender;

            if (panelDisplay.Controls.Contains(pictureBox)) {
                Carte carte = GetCarteWithPicBox(pictureBox);
                // Put la Carte pour verification / Doit etre de la meme Suit joue 
                if (PutCarte(carte)) {
                    // Add Image to pictureBoxMyCarte
                    pictureBoxMyCarte.Image = Image.FromFile(pathCarteImages + carte.Image);
                    // Remove in Runtime
                    pictureBox.Click -= new System.EventHandler(this.Carte_Click);
                    panelDisplay.Controls.Remove(pictureBox);
                    pictureBox.Dispose();
                    // Remove from Dictionnary mesCartes
                    mesCartes.Remove(pictureBox);
                    jeu.Player.Paquet.Remove(carte);
                }
            }
        }

        private void UpdateSuit() {
            this.suit = jeu.Suit;
        }

        /// <summary>
        /// Disables les PictureBoxes/Cartes qui ne peuvent pas etre joue
        /// </summary>
        private void DisableWithSuit() {
            // Disable Avec le Suit
            foreach (KeyValuePair < PictureBox, Carte > entry in mesCartes) {
                Carte carte = entry.Value;
                if (!carte.Color.Equals(suit)) {
                    // Disable them
                    entry.Key.Enabled = false;
                    // pictureBox.Image = Image.FromFile(pathCarteImages + "0.png");
                }
            }
        }


        private bool PutCarte(Carte carte) {
            // Cartes that do not correspond with suit are already disabled 
            List<Carte> cartesValide = new List<Carte>();

            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                if (entry.Value.Color.Equals(suit)) {
                    cartesValide.Add(entry.Value);
                }
            }

            // Il a des Cartes de se Suit
            if (cartesValide.Count > 0 && carte.Color.Equals(suit))
            {
                this.jeu.ListeCartesEnJeu.Add(carte);
                return true;
            }
            else if (cartesValide.Count == 0) {
                // Ca veut dire qu'il faut changer de Suit, il n'a pas plus de carte de cette suit 
                int index = (int) suit;
                MessageBox.Show("Changement de Suit");
                //reput la carte de cette suit
                this.jeu.Player.Couleurs.Remove(index); // Il n'a plus de cette Couleur 
                this.suit = carte.Color;
                return PutCarte(carte);
            }
            else if (!carte.Color.Equals(suit)){
                MessageBox.Show("La carte choisie doit etre de la Couleur " + suit.ToString());
                return false;
            }
            return false;
        }

        /*
        // Methode Joueur 
        // Jusqu'a qu'il trouve une Carte random qui correspont a la Coleur/Suit joue de la partie 
        public void putCarte(Carte carte) {
            List<Carte> cartesValide = new List<Carte>();

            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                if (entry.Value.Color.Equals(suit)) {
                    cartesValide.Add(entry.Value);
                }
            }

            // Si elle n'est pas vide. Cela dit que le Joueur-Ordi a une carte de la couleur en question qui peut etre joue
            if (cartesValide.Count != 0) {
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
        */

    }
}
