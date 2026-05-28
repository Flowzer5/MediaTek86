namespace Mediatek86.vue
{
    partial class FrmAbsences
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
            this.lblPersonnel = new System.Windows.Forms.Label();
            this.dgvAbsences = new System.Windows.Forms.DataGridView();
            this.grpAbsence = new System.Windows.Forms.GroupBox();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblMotif = new System.Windows.Forms.Label();
            this.cboMotif = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).BeginInit();
            this.grpAbsence.SuspendLayout();
            this.SuspendLayout();
            //
            // lblPersonnel
            //
            this.lblPersonnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonnel.Location = new System.Drawing.Point(12, 12);
            this.lblPersonnel.Name = "lblPersonnel";
            this.lblPersonnel.Size = new System.Drawing.Size(648, 25);
            this.lblPersonnel.TabIndex = 0;
            this.lblPersonnel.Text = "Personnel :";
            //
            // dgvAbsences
            //
            this.dgvAbsences.AllowUserToAddRows = false;
            this.dgvAbsences.AllowUserToDeleteRows = false;
            this.dgvAbsences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAbsences.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsences.Location = new System.Drawing.Point(12, 47);
            this.dgvAbsences.MultiSelect = false;
            this.dgvAbsences.Name = "dgvAbsences";
            this.dgvAbsences.ReadOnly = true;
            this.dgvAbsences.RowHeadersVisible = false;
            this.dgvAbsences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsences.Size = new System.Drawing.Size(440, 255);
            this.dgvAbsences.TabIndex = 1;
            //
            // lblDateDebut
            //
            this.lblDateDebut.Location = new System.Drawing.Point(12, 28);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(80, 20);
            this.lblDateDebut.TabIndex = 0;
            this.lblDateDebut.Text = "Date début :";
            this.lblDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpDateDebut
            //
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(12, 52);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(165, 23);
            this.dtpDateDebut.TabIndex = 1;
            //
            // lblDateFin
            //
            this.lblDateFin.Location = new System.Drawing.Point(12, 95);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(80, 20);
            this.lblDateFin.TabIndex = 2;
            this.lblDateFin.Text = "Date fin :";
            this.lblDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dtpDateFin
            //
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Location = new System.Drawing.Point(12, 119);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(165, 23);
            this.dtpDateFin.TabIndex = 3;
            //
            // lblMotif
            //
            this.lblMotif.Location = new System.Drawing.Point(12, 162);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(80, 20);
            this.lblMotif.TabIndex = 4;
            this.lblMotif.Text = "Motif :";
            this.lblMotif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboMotif
            //
            this.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotif.FormattingEnabled = true;
            this.cboMotif.Location = new System.Drawing.Point(12, 185);
            this.cboMotif.Name = "cboMotif";
            this.cboMotif.Size = new System.Drawing.Size(165, 23);
            this.cboMotif.TabIndex = 5;
            //
            // grpAbsence
            //
            this.grpAbsence.Controls.Add(this.cboMotif);
            this.grpAbsence.Controls.Add(this.lblMotif);
            this.grpAbsence.Controls.Add(this.dtpDateFin);
            this.grpAbsence.Controls.Add(this.lblDateFin);
            this.grpAbsence.Controls.Add(this.dtpDateDebut);
            this.grpAbsence.Controls.Add(this.lblDateDebut);
            this.grpAbsence.Location = new System.Drawing.Point(465, 47);
            this.grpAbsence.Name = "grpAbsence";
            this.grpAbsence.Size = new System.Drawing.Size(195, 255);
            this.grpAbsence.TabIndex = 2;
            this.grpAbsence.TabStop = false;
            this.grpAbsence.Text = "Absence";
            //
            // btnAjouter
            //
            this.btnAjouter.Location = new System.Drawing.Point(12, 316);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 28);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            //
            // btnModifier
            //
            this.btnModifier.Location = new System.Drawing.Point(95, 316);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(78, 28);
            this.btnModifier.TabIndex = 4;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            //
            // btnSupprimer
            //
            this.btnSupprimer.Location = new System.Drawing.Point(181, 316);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(85, 28);
            this.btnSupprimer.TabIndex = 5;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Location = new System.Drawing.Point(274, 316);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(95, 28);
            this.btnEnregistrer.TabIndex = 6;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            //
            // btnAnnuler
            //
            this.btnAnnuler.Location = new System.Drawing.Point(377, 316);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(78, 28);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            //
            // btnFermer
            //
            this.btnFermer.Location = new System.Drawing.Point(463, 316);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(75, 28);
            this.btnFermer.TabIndex = 8;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            //
            // FrmAbsences
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 362);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.grpAbsence);
            this.Controls.Add(this.dgvAbsences);
            this.Controls.Add(this.lblPersonnel);
            this.Name = "FrmAbsences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MediaTek86 - Gestion des absences";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsences)).EndInit();
            this.grpAbsence.ResumeLayout(false);
            this.grpAbsence.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblPersonnel;
        private System.Windows.Forms.DataGridView dgvAbsences;
        private System.Windows.Forms.GroupBox grpAbsence;
        private System.Windows.Forms.Label lblDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.ComboBox cboMotif;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnFermer;
    }
}
