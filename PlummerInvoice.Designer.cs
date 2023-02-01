

namespace PlummerCompany
{
    partial class PlummerInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlummerInvoice));
            this.lblClientInvoice = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClientInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClientInvoice
            // 
            this.lblClientInvoice.AutoSize = true;
            this.lblClientInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientInvoice.Location = new System.Drawing.Point(12, 20);
            this.lblClientInvoice.Name = "lblClientInvoice";
            this.lblClientInvoice.Size = new System.Drawing.Size(192, 28);
            this.lblClientInvoice.TabIndex = 0;
            this.lblClientInvoice.Text = "Sök efter kundnamn:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(224, 17);
            this.txtSearch.MinimumSize = new System.Drawing.Size(359, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(459, 34);
            this.txtSearch.TabIndex = 1;
            // 
            // btnClientInvoice
            // 
            this.btnClientInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClientInvoice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientInvoice.Location = new System.Drawing.Point(736, 17);
            this.btnClientInvoice.Name = "btnClientInvoice";
            this.btnClientInvoice.Size = new System.Drawing.Size(193, 43);
            this.btnClientInvoice.TabIndex = 2;
            this.btnClientInvoice.Text = "Skapa faktura";
            this.btnClientInvoice.UseVisualStyleBackColor = true;
            this.btnClientInvoice.Click += new System.EventHandler(this.BtnClientInvoice_Click);
            // 
            // PlummerInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PlummerCompany.Properties.Resources.invoices_stack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(959, 649);
            this.Controls.Add(this.btnClientInvoice);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblClientInvoice);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlummerInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Plummer´s Invoice";
            this.Load += new System.EventHandler(this.PlummerInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientInvoice;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClientInvoice;
    }
}