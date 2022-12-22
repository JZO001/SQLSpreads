namespace SQLSpreadsTestProjectDec22
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnFetch = new System.Windows.Forms.Button();
            this.lbCurrencies = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(12, 12);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 0;
            this.btnFetch.Text = "Fetch currencies";
            this.toolTip1.SetToolTip(this.btnFetch, "Fetch the currency prices");
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // lbCurrencies
            // 
            this.lbCurrencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCurrencies.FormattingEnabled = true;
            this.lbCurrencies.ItemHeight = 15;
            this.lbCurrencies.Location = new System.Drawing.Point(12, 41);
            this.lbCurrencies.Name = "lbCurrencies";
            this.lbCurrencies.Size = new System.Drawing.Size(395, 154);
            this.lbCurrencies.TabIndex = 1;
            this.toolTip1.SetToolTip(this.lbCurrencies, "List of the prices");
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lStatus.ForeColor = System.Drawing.Color.Green;
            this.lStatus.Location = new System.Drawing.Point(91, 17);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(81, 15);
            this.lStatus.TabIndex = 2;
            this.lStatus.Text = "Please wait....";
            this.lStatus.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 213);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.lbCurrencies);
            this.Controls.Add(this.btnFetch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Spreads Test Project Dec 2022 by Zoltan Juhasz";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnFetch;
        private ListBox lbCurrencies;
        private ToolTip toolTip1;
        private Label lStatus;
    }
}