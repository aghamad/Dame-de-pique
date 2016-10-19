using System.Drawing;
using System.Windows.Forms;
using ClassLibrary;

namespace DameDePique

{
    public partial class FormJeu : Form
    {
        private Jeu jeu;

        public FormJeu()
        {
            InitializeComponent();
            
            // Disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Ouvre form de style ou l'usager choisit son bonhomme et ecrit son nom (a faire)
            Joueur player = new Joueur("Moi", "image.png");

            // Commencement du jeu / Intialize 
            this.jeu = new Jeu(player);

            jeu.distribuer();
            jeu.AssignerUnePosition(); // Starting Initilaize un positionnement a tout le monde 

            InitializePlayingField();

            if (jeu.Player.Positionnement == 1)
            {
                // highlight sa carte 
                comboBox1.BackColor = Color.Yellow;
            }
            else {

            }
            

        }

        // met les cartes du joueur non ordinateur dans ses mains
        public void InitializePlayingField() {
            for (int i = 0; i < jeu.Player.Paquet.Count; i++) {
                comboBox1.Items.Add(jeu.Player.Paquet[i]);
            }

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

            comboBox1.SelectedIndex = 0;
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
