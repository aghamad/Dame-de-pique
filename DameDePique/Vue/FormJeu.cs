using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;
using System.Collections.Generic;
using System;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace DameDePique
{
    public partial class FormJeu : Form
    {
        private Jeu jeu;
        private string pathCarteImages;
        // Les Cartes du Joueur
        private Dictionary<PictureBox, Carte> mesCartes;
        // Les Quatres PictureBoxes qui seront en jeu 
        private PictureBox[] pictureBoxes;
        // Les PictureBoxes des Joueurs Ordinateurs et le joueur non-ordi 
        private Dictionary<Joueur, PictureBox> mesPictureBoxes;
        //Round
        private int round = 0;

        public FormJeu(Joueur joueur) {
            InitializeComponent();
            // Disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Path
            this.pathCarteImages = Application.StartupPath + @"\CarteImages\";

            // Ouvre form de style ou l'usager choisit son bonhomme et ecrit son nom (a faire)
            Joueur player = new Joueur("Moi", "image.png");

            // Commencement du jeu / Intialize le Jeu avec le Joueur 
            this.jeu = new Jeu(player);

            // Pour le Jeu les 4 Cartes qui seront en Jeu 
            this.pictureBoxes = new PictureBox[] { pictureBoxMyCarte, pictureBox2, pictureBox3, pictureBox4}; 

            // Assignation 
            this.mesPictureBoxes = new Dictionary<Joueur, PictureBox>();
            
            // La liste des joueurs en ordre: Moi (en bas), Ahmad (gauche), Nassim (haut), Halim (droite)
            for (int i = 0; i < jeu.ListeDesJoueurs.Count; i++) {
                // Player , pictureBoxMyCarte 
                mesPictureBoxes.Add(jeu.ListeDesJoueurs[i], pictureBoxes[i]);
            }

            // Les Cartes du Joueur 
            InitializeMesCartes();
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
                // Image de la Carte
                pictureBox.Image = Image.FromFile(pathCarteImages + jeu.Player.Paquet[i].Image);
                // Click Event 
                pictureBox.Click += new System.EventHandler(Carte_Click);
                mesCartes.Add(pictureBox, jeu.Player.Paquet[i]);
            }

            // Init les Cartes dans la table
            InitializeDeckField();
        }

        private void InitializeDeckField() {
            // Met ou Update les Cartes du Joueur dans la table
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                panelDisplay.Controls.Add(entry.Key);
            }
        }

        // Get La Carte associated with the PictureBox / Joueur 
        private Carte GetCarteWithPicBox(PictureBox pictureBox) {
            Carte carte = null;
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                if (pictureBox.Equals(entry.Key)) {
                    carte = entry.Value;
                }
            }
            return carte;
        }

        // He can click on any Carte 
        private void Carte_Click(object sender, EventArgs e) {
            PictureBox pictureBox = (PictureBox) sender;
            if (panelDisplay.Controls.Contains(pictureBox)) {
                // Get la carte 
                Carte carte = GetCarteWithPicBox(pictureBox);
                if (PutMyCarte(carte)) {
                    DisablePictureBoxes();
                    mesPictureBoxes[jeu.Player].Image = Image.FromFile(pathCarteImages + carte.Image);
                    // Remove from Runtime
                    pictureBox.Click -= new System.EventHandler(this.Carte_Click);
                    panelDisplay.Controls.Remove(pictureBox);
                    pictureBox.Dispose();
                    // Remove from Dictionnary mesCartes
                    mesCartes.Remove(pictureBox);
                    jeu.Player.Paquet.Remove(carte);
                    //TogglePictureBoxesDeck(false); // Disable pictureboxes du joueur principal 
                }
                else {
                    // Cancel the event 
                    MessageBox.Show("La Carte choisit n'est pas de la Couleur: " + jeu.Suit, "Warning");
                    return; 
                }
            }
        }

        /// <summary>
        /// Enable les pictureboxes du joueur
        /// </summary>
        private void EnablePictureBoxes()  {
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                entry.Key.Enabled = true;
            }
        }

        /// <summary>
        /// Disable les pictureboxes du joueur
        /// </summary>
        private void DisablePictureBoxes() {
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                entry.Key.Enabled = false;
            }
        }

        /// <summary>
        /// Methode User afin de mettre une Carte en jeu
        /// </summary>
        /// <param name="carte"></param>
        /// <returns></returns>
        private bool PutMyCarte(Carte carte) {
            if (carte.Color.Equals(jeu.Suit)) {
                this.jeu.ListeCartesEnJeu.Add(carte, jeu.Player);
                buttonGo.Enabled = true; // Avec Plaisir 
                return true;
            }

            // Avant de mettre une Carte d'une autre Couleur
            // Il faut regarder si l'usager n'a plus de cette Couleur 
            List<Carte> cartesValide = new List<Carte>();
            // Met les cartes qui peuvent etre joue dans une Liste [cartesValide]
            foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                if (entry.Value.Color.Equals(jeu.Suit)) {
                    cartesValide.Add(entry.Value);
                }
            }

            // if is empty / Essaye de changer la couleur 
            if (!carte.Color.Equals(jeu.Suit) && cartesValide.Count == 0) {
                jeu.Suit = carte.Color;
                return PutMyCarte(carte);
            }
            return false;
        }

        // Update Form
        private void UpdateTable() {
            // Update Positionnement dans le form 
            labelName1.Text = "Nom : " + jeu.Player.Nom + "\nPosition:  " + jeu.Player.Positionnement + "\nPoints:" + jeu.Player.Pointage;
            labelName2.Text = "Nom : " + jeu.PlayerAhmad.Nom + "\nPosition:  " + jeu.PlayerAhmad.Positionnement + "\nPoints:" + jeu.PlayerAhmad.Pointage;
            labelName3.Text = "Nom : " + jeu.PlayerNassim.Nom + "\nPosition:  " + jeu.PlayerNassim.Positionnement + "\nPoints:" + jeu.PlayerNassim.Pointage;
            labelName4.Text = "Nom : " + jeu.PlayerHalim.Nom + "\nPosition:  " + jeu.PlayerHalim.Positionnement + "\nPoints:" + jeu.PlayerHalim.Pointage;
        }

        private async void Start() {
            while (!jeu.Fin) {
                await Play();
            }
        }

        // Simulation d'un Round
        private async Task Play() {
            this.jeu.OrderListAvecPos();
            buttonGo.Enabled = false;
            // Montre et update le positionnement de chaque joueur dans le label approprié
            UpdateTable();
            // Nouveau Round
            this.round++;
            labelRound.Text = "Round #" + round;
      
            foreach (Joueur joueur in jeu.ListeDesJoueurs) {
                // if c'est le tour du Joueur non-ordi 
                if (joueur.Equals(jeu.Player)) {
                    // Enable if player's turn 
                    EnablePictureBoxes();
                    // Afin de get le nb de PictureBoxes restant
                    List<PictureBox> restant = new List<PictureBox>();
                    foreach (KeyValuePair<PictureBox, Carte> entry in mesCartes) {
                        restant.Add(entry.Key);
                    }
                    await buttonGo.WhenClicked();
                }
                else {
                    // Les ordinateurs
                    await Task.Delay(400);
                    Carte carte = jeu.putCarte(joueur);
                    if (carte == null) {
                        MessageBox.Show("Le joueur " + joueur.Nom + " n'a plus de carte. Cela marque la fin du jeu.", "The end");
                        this.jeu.Fin = true;
                    }
                    else {
                        // Cette line de code est dans la methode putCarte(joueur) : jeu.ListeCartesEnJeu.Add(carte, joueur);
                        // Set dans son pictureBox
                        mesPictureBoxes[joueur].Image = Image.FromFile(pathCarteImages + carte.Image);
                        // Il n'a plus de cette carte
                        joueur.Paquet.Remove(carte);
                    }
                }
            }

            // After the loop / Quand tout les Joueurs ont choisit / Cela determine le perdant: verification()
            Dictionary<Joueur, Carte> infoSurLePerdant = jeu.Verification();
            Joueur perdant = null;
            Carte cartePerdant = null;
            foreach (KeyValuePair<Joueur, Carte> entry in infoSurLePerdant) {
                perdant = entry.Key;
                cartePerdant = entry.Value;
            }

            labelStatus.Text = String.Format("{0} a perdu ce tour \nCe joueur a ramasser la carte la plus haute la {1} de {2} \nCela lui donc fait un totale de {3} point(s)", perdant.Nom, cartePerdant.Value, cartePerdant.Color, perdant.Pointage);
            buttonGo.Enabled = false;

            // Attend avant d'enlever les images 
            await Task.Delay(1800);
            for (int i = 0; i < pictureBoxes.Length; i++) {
                pictureBoxes[i].Image = null;
            }

            // read some data from device; we need to wait for this to return
            await Play();
        }

        // First 
        private void FormJeu_Shown(object sender, EventArgs e) {
            // Play qu'un seul round
            //Play();
            // Play la game jusqu'a la fin
            Start();
        }
    }
}
