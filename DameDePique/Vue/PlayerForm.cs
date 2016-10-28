using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.Threading;

namespace DameDePique
{
    public partial class PlayerForm : Form {
        int position;
        string nomFichier;
        public PlayerForm() {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)  {
            //définit le path des images
            string path = Application.StartupPath + @"/Resources/";
            //initialise le controle ImageList avec des images
            for (int i = 0; i < 4; i++)  {
                nomFichier = path + "criminel" + i + ".jpg";
                imageListPersonnages.Images.Add(Image.FromFile(nomFichier));
                // Associe la clé de l’image(Nom du fichier) à un indice dans imageList
                this.imageListPersonnages.Images.SetKeyName(i, nomFichier);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)  {
            if (listView1.SelectedItems.Count > 0) {
                int i = listView1.SelectedIndices[0];
                position = i;
                pictureBox1.Image = imageListPersonnages.Images[i];
            }
            else  {
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            this.Close();
            // Run form in another thread 
            var threadGame = new Thread(() => Application.Run(new FormJeu(position)));
            threadGame.Start();
        }
    }
}
