namespace CreatingDataTable
{
    partial class Form1
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
            System.Windows.Forms.Button AddRowButton;
            this.TableGrid = new System.Windows.Forms.DataGridView();
            this.AddTableButton = new System.Windows.Forms.Button();
            AddRowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddRowButton
            // 
            AddRowButton.Location = new System.Drawing.Point(12, 12);
            AddRowButton.Name = "AddRowButton";
            AddRowButton.Size = new System.Drawing.Size(291, 70);
            AddRowButton.TabIndex = 0;
            AddRowButton.Text = "Add Row";
            AddRowButton.UseVisualStyleBackColor = true;
            AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // TableGrid
            // 
            this.TableGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableGrid.Location = new System.Drawing.Point(12, 149);
            this.TableGrid.Name = "TableGrid";
            this.TableGrid.RowHeadersWidth = 62;
            this.TableGrid.RowTemplate.Height = 28;
            this.TableGrid.Size = new System.Drawing.Size(1335, 289);
            this.TableGrid.TabIndex = 1;
            // 
            // AddTableButton
            // 
            this.AddTableButton.Location = new System.Drawing.Point(341, 12);
            this.AddTableButton.Name = "AddTableButton";
            this.AddTableButton.Size = new System.Drawing.Size(299, 70);
            this.AddTableButton.TabIndex = 2;
            this.AddTableButton.Text = "AddTable";
            this.AddTableButton.UseVisualStyleBackColor = true;
            this.AddTableButton.Click += new System.EventHandler(this.AddTableButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 450);
            this.Controls.Add(this.AddTableButton);
            this.Controls.Add(this.TableGrid);
            this.Controls.Add(AddRowButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TableGrid;
        private System.Windows.Forms.Button AddTableButton;
    }
}

