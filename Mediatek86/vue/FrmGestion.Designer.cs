namespace Mediatek86.vue
{
    partial class FrmGestion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
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
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.grpPersonnel = new System.Windows.Forms.GroupBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnulerPersonnel = new System.Windows.Forms.Button();
            this.btnGererAbsences = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.grpPersonnel.SuspendLayout();
            this.SuspendLayout();
            //
            // dgvPersonnel
            //
            this.dgvPersonnel.AllowUserToAddRows = false;
            this.dgvPersonnel.AllowUserToDeleteRows = false;
            this.dgvPersonnel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonnel.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(12, 12);
            this.dgvPersonnel.MultiSelect = false;
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.RowHeadersVisible = false;
            this.dgvPersonnel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.Size = new System.Drawing.Size(490, 270);
            this.dgvPersonnel.TabIndex = 0;
            //
            // lblNom
            //
            this.lblNom.Location = new System.Drawing.Point(12, 28);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(78, 20);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            this.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtNom
            //
            this.txtNom.Location = new System.Drawing.Point(93, 26);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(148, 23);
            this.txtNom.TabIndex = 1;
            //
            // lblPrenom
            //
            this.lblPrenom.Location = new System.Drawing.Point(12, 67);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(78, 20);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom :";
            this.lblPrenom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtPrenom
            //
            this.txtPrenom.Location = new System.Drawing.Point(93, 65);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(148, 23);
            this.txtPrenom.TabIndex = 3;
            //
            // lblTel
            //
            this.lblTel.Location = new System.Drawing.Point(12, 106);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(78, 20);
            this.lblTel.TabIndex = 4;
            this.lblTel.Text = "Téléphone :";
            this.lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTel
            //
            this.txtTel.Location = new System.Drawing.Point(93, 104);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(148, 23);
            this.txtTel.TabIndex = 5;
            //
            // lblMail
            //
            this.lblMail.Location = new System.Drawing.Point(12, 145);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(78, 20);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Mail :";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtMail
            //
            this.txtMail.Location = new System.Drawing.Point(93, 143);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(148, 23);
            this.txtMail.TabIndex = 7;
            //
            // lblService
            //
            this.lblService.Location = new System.Drawing.Point(12, 184);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(78, 20);
            this.lblService.TabIndex = 8;
            this.lblService.Text = "Service :";
            this.lblService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboService
            //
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(93, 181);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(148, 23);
            this.cboService.TabIndex = 9;
            //
            // grpPersonnel
            //
            this.grpPersonnel.Controls.Add(this.cboService);
            this.grpPersonnel.Controls.Add(this.lblService);
            this.grpPersonnel.Controls.Add(this.txtMail);
            this.grpPersonnel.Controls.Add(this.lblMail);
            this.grpPersonnel.Controls.Add(this.txtTel);
            this.grpPersonnel.Controls.Add(this.lblTel);
            this.grpPersonnel.Controls.Add(this.txtPrenom);
            this.grpPersonnel.Controls.Add(this.lblPrenom);
            this.grpPersonnel.Controls.Add(this.txtNom);
            this.grpPersonnel.Controls.Add(this.lblNom);
            this.grpPersonnel.Location = new System.Drawing.Point(515, 12);
            this.grpPersonnel.Name = "grpPersonnel";
            this.grpPersonnel.Size = new System.Drawing.Size(257, 270);
            this.grpPersonnel.TabIndex = 1;
            this.grpPersonnel.TabStop = false;
            this.grpPersonnel.Text = "Personnel";
            //
            // btnAjouter
            //
            this.btnAjouter.Location = new System.Drawing.Point(12, 295);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(78, 28);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            //
            // btnModifier
            //
            this.btnModifier.Location = new System.Drawing.Point(98, 295);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(78, 28);
            this.btnModifier.TabIndex = 3;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            //
            // btnSupprimer
            //
            this.btnSupprimer.Location = new System.Drawing.Point(184, 295);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(85, 28);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Location = new System.Drawing.Point(277, 295);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(95, 28);
            this.btnEnregistrer.TabIndex = 5;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            //
            // btnAnnulerPersonnel
            //
            this.btnAnnulerPersonnel.Location = new System.Drawing.Point(380, 295);
            this.btnAnnulerPersonnel.Name = "btnAnnulerPersonnel";
            this.btnAnnulerPersonnel.Size = new System.Drawing.Size(105, 28);
            this.btnAnnulerPersonnel.TabIndex = 6;
            this.btnAnnulerPersonnel.Text = "Annuler";
            this.btnAnnulerPersonnel.UseVisualStyleBackColor = true;
            //
            // btnGererAbsences
            //
            this.btnGererAbsences.Location = new System.Drawing.Point(515, 295);
            this.btnGererAbsences.Name = "btnGererAbsences";
            this.btnGererAbsences.Size = new System.Drawing.Size(257, 28);
            this.btnGererAbsences.TabIndex = 7;
            this.btnGererAbsences.Text = "Gérer les absences";
            this.btnGererAbsences.UseVisualStyleBackColor = true;
            //
            // FrmGestion
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 341);
            this.Controls.Add(this.btnGererAbsences);
            this.Controls.Add(this.btnAnnulerPersonnel);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.grpPersonnel);
            this.Controls.Add(this.dgvPersonnel);
            this.Name = "FrmGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaTek86 - Gestion du personnel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.grpPersonnel.ResumeLayout(false);
            this.grpPersonnel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.GroupBox grpPersonnel;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnulerPersonnel;
        private System.Windows.Forms.Button btnGererAbsences;
    }
}
