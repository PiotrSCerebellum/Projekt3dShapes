
namespace Projekt3_Skupiński_59369
{
    partial class PokazInitialForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btZłożoneBryły = new System.Windows.Forms.Button();
            this.btPrezentacjaBrył = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btZłożoneBryły
            // 
            this.btZłożoneBryły.Location = new System.Drawing.Point(434, 173);
            this.btZłożoneBryły.Name = "btZłożoneBryły";
            this.btZłożoneBryły.Size = new System.Drawing.Size(168, 74);
            this.btZłożoneBryły.TabIndex = 0;
            this.btZłożoneBryły.Text = "Wizualizacja złożonych brył";
            this.btZłożoneBryły.UseVisualStyleBackColor = true;
            this.btZłożoneBryły.Click += new System.EventHandler(this.btZłożoneBryły_Click);
            // 
            // btPrezentacjaBrył
            // 
            this.btPrezentacjaBrył.Location = new System.Drawing.Point(154, 173);
            this.btPrezentacjaBrył.Name = "btPrezentacjaBrył";
            this.btPrezentacjaBrył.Size = new System.Drawing.Size(180, 74);
            this.btPrezentacjaBrył.TabIndex = 1;
            this.btPrezentacjaBrył.Text = "Przejdź do prezentcji brył";
            this.btPrezentacjaBrył.UseVisualStyleBackColor = true;
            this.btPrezentacjaBrył.Click += new System.EventHandler(this.btPrezentacjaBrył_Click);
            // 
            // PokazBrył
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btPrezentacjaBrył);
            this.Controls.Add(this.btZłożoneBryły);
            this.Name = "PokazBrył";
            this.Text = "Pokaz Brył";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btZłożoneBryły;
        private System.Windows.Forms.Button btPrezentacjaBrył;
    }
}

