namespace Processos_MXM
{
    partial class FrmProcesso
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
            this.lstProcesso = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstProcesso
            // 
            this.lstProcesso.BackColor = System.Drawing.Color.Silver;
            this.lstProcesso.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstProcesso.HideSelection = false;
            this.lstProcesso.Location = new System.Drawing.Point(25, 39);
            this.lstProcesso.Name = "lstProcesso";
            this.lstProcesso.Size = new System.Drawing.Size(653, 417);
            this.lstProcesso.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstProcesso.TabIndex = 0;
            this.lstProcesso.UseCompatibleStateImageBehavior = false;
            this.lstProcesso.View = System.Windows.Forms.View.Details;
            this.lstProcesso.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstProcesso_ColumnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "OneShare Processos";
            // 
            // FrmProcesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstProcesso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmProcesso";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "One Share Processos";
            this.Load += new System.EventHandler(this.FrmProcesso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProcesso;
        private System.Windows.Forms.Label label1;
    }
}

