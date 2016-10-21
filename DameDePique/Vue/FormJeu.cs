using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;
using System.Collections.Generic;

namespace DameDePique
{
    public partial class FormJeu : Form
    {
        private Jeu jeu;
        private List<PictureBox> pictureBoxList;
        private string pathCarteImages;

        public FormJeu()
        {
            InitializeComponent();
            // Disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Path
            this.pathCarteImages = Application.StartupPath + @"/CarteImages/";

            // Ouvre form de style ou l'usager choisit son bonhomme et ecrit son nom (a faire)
            Joueur player = new Joueur("Moi", "image.png");

            // Commencement du jeu / Intialize le Jeu avec le Joueur 
            this.jeu = new Jeu(player);
            jeu.distribuer();
            jeu.AssignerUnePosition();

            // Les Cartes du Joueur 
            InitializeDeckField();

        }


        private void InitializeDeckField() {
            this.pictureBoxList = new List<PictureBox>();
            List<Carte> paquetDuJoueur = jeu.Player.Paquet;

            for (int i = 0; i < paquetDuJoueur.Count; i++) {
                PictureBox pictureBox = new PictureBox {
                    Name = "pictureBox" + i,
                    Size = new Size(80, 120),
                    Location = new Point(i * 80, 1),
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // Abddel fix ceci ca crash!! Les images sont sauvergarder avec leur extention .png exemple: 1.png
                pictureBox.Image = Image.FromFile(pathCarteImages + paquetDuJoueur[i].Image); 
                pictureBoxList.Add(pictureBox);
            }

            // Les Mettres (PictureBoxes) sur la Table
            foreach (PictureBox pictureBox in pictureBoxList) {
                panelDisplay.Controls.Add(pictureBox);
            }

        }



        // met les cartes du joueur non ordinateur dans ses mains
        /*
        InitializePlayingField();

        if (jeu.Player.Positionnement == 1)
        {
            // highlight sa carte 
            comboBox1.BackColor = Color.Yellow;
        }
        else {

        }
        */
        public void InitializePlayingFieldAss() {

            for (int i = 0; i < jeu.PlayerA.Paquet.Count; i++) {
                comboBox2.Items.Add(jeu.PlayerA.Paquet[i]);
            }

            for (int i = 0; i < jeu.PlayerN.Paquet.Count; i++) {
                comboBox3.Items.Add(jeu.PlayerN.Paquet[i]);
            }

            for (int i = 0; i < jeu.PlayerH.Paquet.Count; i++)
            {
                comboBox4.Items.Add(jeu.PlayerH.Paquet[i]);
            }

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;


            label1.Text = jeu.Player.Positionnement + "";
            label2.Text = jeu.PlayerA.Positionnement + "";
            label3.Text = jeu.PlayerN.Positionnement + "";
            label4.Text = jeu.PlayerH.Positionnement + ""; 
        }


    }
}
