namespace DameDePique
{
    partial class FormJeu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMyCarte = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.labelName1 = new System.Windows.Forms.Label();
            this.labelName2 = new System.Windows.Forms.Label();
            this.labelName3 = new System.Windows.Forms.Label();
            this.labelName4 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyCarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMyCarte
            // 
            this.pictureBoxMyCarte.BackColor = System.Drawing.Color.Green;
            this.pictureBoxMyCarte.Location = new System.Drawing.Point(494, 345);
            this.pictureBoxMyCarte.Name = "pictureBoxMyCarte";
            this.pictureBoxMyCarte.Size = new System.Drawing.Size(73, 97);
            this.pictureBoxMyCarte.TabIndex = 8;
            this.pictureBoxMyCarte.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Green;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(415, 286);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 97);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Green;
            this.pictureBox3.Location = new System.Drawing.Point(494, 221);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 97);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Green;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Location = new System.Drawing.Point(573, 286);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(73, 97);
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // panelDisplay
            // 
            this.panelDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDisplay.BackColor = System.Drawing.Color.DarkGreen;
            this.panelDisplay.Location = new System.Drawing.Point(21, 613);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1031, 98);
            this.panelDisplay.TabIndex = 12;
            // 
            // labelName1
            // 
            this.labelName1.AutoSize = true;
            this.labelName1.Location = new System.Drawing.Point(491, 445);
            this.labelName1.Name = "labelName1";
            this.labelName1.Size = new System.Drawing.Size(40, 13);
            this.labelName1.TabIndex = 13;
            this.labelName1.Text = "-----------";
            // 
            // labelName2
            // 
            this.labelName2.AutoSize = true;
            this.labelName2.Location = new System.Drawing.Point(412, 240);
            this.labelName2.Name = "labelName2";
            this.labelName2.Size = new System.Drawing.Size(40, 13);
            this.labelName2.TabIndex = 14;
            this.labelName2.Text = "-----------";
            // 
            // labelName3
            // 
            this.labelName3.AutoSize = true;
            this.labelName3.Location = new System.Drawing.Point(491, 179);
            this.labelName3.Name = "labelName3";
            this.labelName3.Size = new System.Drawing.Size(40, 13);
            this.labelName3.TabIndex = 15;
            this.labelName3.Text = "-----------";
            // 
            // labelName4
            // 
            this.labelName4.AutoSize = true;
            this.labelName4.Location = new System.Drawing.Point(570, 240);
            this.labelName4.Name = "labelName4";
            this.labelName4.Size = new System.Drawing.Size(40, 13);
            this.labelName4.TabIndex = 16;
            this.labelName4.Text = "-----------";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(494, 507);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(73, 23);
            this.buttonGo.TabIndex = 17;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.Green;
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.labelStatus);
            this.panelStatus.Controls.Add(this.labelRound);
            this.panelStatus.Location = new System.Drawing.Point(21, 12);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(308, 115);
            this.panelStatus.TabIndex = 18;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.labelStatus.Location = new System.Drawing.Point(4, 28);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(46, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "-------------";
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.ForeColor = System.Drawing.SystemColors.Control;
            this.labelRound.Location = new System.Drawing.Point(4, 4);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(49, 13);
            this.labelRound.TabIndex = 0;
            this.labelRound.Text = "Round #";
            // 
            // FormJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DameDePique.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1075, 709);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.labelName4);
            this.Controls.Add(this.labelName3);
            this.Controls.Add(this.labelName2);
            this.Controls.Add(this.labelName1);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBoxMyCarte);
            this.DoubleBuffered = true;
            this.Name = "FormJeu";
            this.Text = "Dame de Pique";
            this.Shown += new System.EventHandler(this.FormJeu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMyCarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMyCarte;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Label labelName1;
        private System.Windows.Forms.Label labelName2;
        private System.Windows.Forms.Label labelName3;
        private System.Windows.Forms.Label labelName4;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Label labelStatus;
    }
}

