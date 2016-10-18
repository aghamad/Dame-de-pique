using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DameDePique
{
    public partial class PlayerForm : Form
    {
        int posCour = 0;
        string nomFichier;
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        { //définit le path des images
            string path = Application.StartupPath + @"/Resources/";
            MessageBox.Show(path);
            //initialise le controle ImageList avec des images
            for (int i = 0; i < 4; i++)
            {
                nomFichier = path + "criminel" + i + ".jpg";
                MessageBox.Show(nomFichier);
                imageListPersonnages.Images.Add(Image.FromFile(nomFichier));
                //Associe la clé de l’image(Nom du fichier) à un indice dans imageList
                this.imageListPersonnages.Images.SetKeyName(i, nomFichier);
                //    // ajoute un item dans la listeView
                this.listView1.Items.Add(new ListViewItem("", i));
            }//fin for
             // //définir les 2 propriétés de listView1
            this.listView1.LargeImageList = this.imageListPersonnages;
            this.listView1.SmallImageList = this.imageListPersonnages;
        }
        //au click sur bouton, afficher image courante dans Picturebox
        private void button1_Click(object sender, EventArgs e)
        {
            posCour = posCour < 2 ? posCour + 1 : 0;
            pictureBox1.Image = imageListPersonnages.Images[posCour];
        }
        //au click sur un item activé,afficher dans picturebox
        private void listView1_ItemActivate(object sender, EventArgs e)
        {


          
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int i = listView1.SelectedIndices[0];
                pictureBox1.Image = imageListPersonnages.Images[i];
            }
            else
            {
                return;
            }
            
        }
    }
}
