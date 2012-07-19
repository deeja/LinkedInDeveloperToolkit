namespace LinkedIn.Samples.WindowsForms
{
  partial class Main
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
      this.networkUpdatesGridView = new System.Windows.Forms.DataGridView();
      this.getNetworkUpdatesButton = new System.Windows.Forms.Button();
      this.getConnectionsButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.networkUpdatesGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // networkUpdatesGridView
      // 
      this.networkUpdatesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.networkUpdatesGridView.Location = new System.Drawing.Point(13, 41);
      this.networkUpdatesGridView.Name = "networkUpdatesGridView";
      this.networkUpdatesGridView.Size = new System.Drawing.Size(472, 253);
      this.networkUpdatesGridView.TabIndex = 0;
      // 
      // getNetworkUpdatesButton
      // 
      this.getNetworkUpdatesButton.Location = new System.Drawing.Point(115, 12);
      this.getNetworkUpdatesButton.Name = "getNetworkUpdatesButton";
      this.getNetworkUpdatesButton.Size = new System.Drawing.Size(124, 23);
      this.getNetworkUpdatesButton.TabIndex = 1;
      this.getNetworkUpdatesButton.Text = "Get Network Updates";
      this.getNetworkUpdatesButton.UseVisualStyleBackColor = true;
      this.getNetworkUpdatesButton.Click += new System.EventHandler(this.getNetworkUpdatesButton_Click);
      // 
      // getConnectionsButton
      // 
      this.getConnectionsButton.Location = new System.Drawing.Point(12, 12);
      this.getConnectionsButton.Name = "getConnectionsButton";
      this.getConnectionsButton.Size = new System.Drawing.Size(97, 23);
      this.getConnectionsButton.TabIndex = 2;
      this.getConnectionsButton.Text = "Get Connections";
      this.getConnectionsButton.UseVisualStyleBackColor = true;
      this.getConnectionsButton.Click += new System.EventHandler(this.getConnectionsButton_Click);
      // 
      // NetworkUpdates
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(497, 306);
      this.Controls.Add(this.getConnectionsButton);
      this.Controls.Add(this.getNetworkUpdatesButton);
      this.Controls.Add(this.networkUpdatesGridView);
      this.Name = "NetworkUpdates";
      this.Text = "Windows Forms Sample";
      ((System.ComponentModel.ISupportInitialize)(this.networkUpdatesGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView networkUpdatesGridView;
    private System.Windows.Forms.Button getNetworkUpdatesButton;
    private System.Windows.Forms.Button getConnectionsButton;
  }
}

