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
        // Chaque PictureBox Sera assigne a une Carte
        private List<PictureBox> pictureBoxList;
        private List<Carte> paquetDuJoueur;
        // Suit/ Couleur du Jeu
        private Couleur suit;

        // PictureBoxe List et list des Cartes joue
        private List<PictureBox> pictureBoxJoue;
        private List<Carte> cartesJoue;

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
            jeu.distribuer();
            jeu.AssignerUnePosition();
            // Le Paquet du Joueur Ajoute et Delete a partir de cette Liste
            this.paquetDuJoueur = jeu.Player.Paquet;
            this.pictureBoxList = new List<PictureBox>();

            // Pour le Jeu
            this.pictureBoxJoue = new List<PictureBox>();
            pictureBoxJoue.Add(pictureBox1);
            pictureBoxJoue.Add(pictureBox2);
            pictureBoxJoue.Add(pictureBox3);
            pictureBoxJoue.Add(pictureBox4);

            Size size = new Size(80, 120);
            for (int i = 0; i < pictureBoxJoue.Count; i++) {
                pictureBoxJoue[i].Visible = false;
                pictureBoxJoue[i].Size = size;
            }


            // Les Cartes du Joueur 
            InitializeDeckField();
            UpdateSuit();
            DisableWithSuit();

        }


        private void InitializeDeckField() {
            this.pictureBoxList.Clear();

            for (int i = 0; i < paquetDuJoueur.Count; i++) {
                PictureBox pictureBox = new PictureBox {
                    Name = "pictureBox" + i,
                    Size = new Size(80, 120), // W and H 
                    Location = new Point(i * 80, 0),
                    // BorderStyle = BorderStyle.FixedSingle,
                    // SizeMode = PictureBoxSizeMode.Zoom
                };

                pictureBox.Image = Image.FromFile(pathCarteImages + paquetDuJoueur[i].Image);
                // Click Listener
                pictureBox.Click += new System.EventHandler(Carte_Click);
                pictureBoxList.Add(pictureBox);
            }

            // Les Mettres (PictureBoxes) sur la Table
            foreach (PictureBox pictureBox in pictureBoxList) {
                panelDisplay.Controls.Add(pictureBox);
            }

        }

        private void UpdateSuit() {
            this.suit = jeu.Suit; 
        }

        /// <summary>
        /// Disables les Cartes qui ne peuvent pas etre joue
        /// </summary>
        private void DisableWithSuit() {
            // Disable Avec le Suit
            foreach (PictureBox pictureBox in pictureBoxList) {
                int pos = pictureBoxList.IndexOf(pictureBox);
                Carte carte = paquetDuJoueur[pos];
                if (carte.Color != suit) {
                    // Disable them
                    pictureBox.Enabled = false;
                    pictureBox.Image = Image.FromFile(pathCarteImages + "0.png");
                }
            }
        }

        private void Carte_Click(object sender, EventArgs e) {

            if (pictureBox1.Visible == false) {
                for (int i = 0; i < pictureBoxJoue.Count; i++){
                    pictureBoxJoue[i].Visible = true;
                }
            }

            PictureBox pictureBox = (PictureBox) sender;
            int position = pictureBoxList.IndexOf(pictureBox);
            Carte carte = paquetDuJoueur[position];


            // A la fin Remove
            if (panelDisplay.Controls.Contains(pictureBox)) {
                // Add
                pictureBox1.Image = Image.FromFile(pathCarteImages + carte.Image);
                // Remove in Runtime
                pictureBox.Click -= new System.EventHandler(this.Carte_Click);
                panelDisplay.Controls.Remove(pictureBox);
                pictureBox.Dispose();
                // Remove from this Carte Paquet du Joueur
                //this.paquetDuJoueur.Remove(carte);
                //InitializeDeckField();
                // Methode qui fuck up tout InitializeDeckField();
            }
        }
   
    }
}
