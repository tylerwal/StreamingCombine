namespace StreamingFileCombineInterface
{
	partial class StreamingCombineView
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
			this.components = new System.ComponentModel.Container();
			this.lblChunkFileUrl = new System.Windows.Forms.Label();
			this.btnExecuteCombineAndSave = new System.Windows.Forms.Button();
			this.txtChunkFileUrl = new System.Windows.Forms.TextBox();
			this.bsConversionMetaData = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).BeginInit();
			this.SuspendLayout();
			// 
			// lblChunkFileUrl
			// 
			this.lblChunkFileUrl.AutoSize = true;
			this.lblChunkFileUrl.Location = new System.Drawing.Point(13, 13);
			this.lblChunkFileUrl.Name = "lblChunkFileUrl";
			this.lblChunkFileUrl.Size = new System.Drawing.Size(95, 13);
			this.lblChunkFileUrl.TabIndex = 0;
			this.lblChunkFileUrl.Text = "ChunkFile (m3u8): ";
			// 
			// btnExecuteCombineAndSave
			// 
			this.btnExecuteCombineAndSave.Location = new System.Drawing.Point(16, 45);
			this.btnExecuteCombineAndSave.Name = "btnExecuteCombineAndSave";
			this.btnExecuteCombineAndSave.Size = new System.Drawing.Size(224, 23);
			this.btnExecuteCombineAndSave.TabIndex = 1;
			this.btnExecuteCombineAndSave.Text = "Combine Chunk Files and Save";
			this.btnExecuteCombineAndSave.UseVisualStyleBackColor = true;
			this.btnExecuteCombineAndSave.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtChunkFileUrl
			// 
			this.txtChunkFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtChunkFileUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "ChunkListFileUrl", true));
			this.txtChunkFileUrl.Location = new System.Drawing.Point(115, 13);
			this.txtChunkFileUrl.Name = "txtChunkFileUrl";
			this.txtChunkFileUrl.Size = new System.Drawing.Size(740, 20);
			this.txtChunkFileUrl.TabIndex = 2;
			// 
			// bsConversionMetaData
			// 
			this.bsConversionMetaData.DataSource = typeof(FileCombiner.ConversionMetaData);
			// 
			// StreamingCombineView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(867, 80);
			this.Controls.Add(this.txtChunkFileUrl);
			this.Controls.Add(this.btnExecuteCombineAndSave);
			this.Controls.Add(this.lblChunkFileUrl);
			this.Name = "StreamingCombineView";
			this.Text = "Streaming Combine";
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblChunkFileUrl;
		private System.Windows.Forms.Button btnExecuteCombineAndSave;
		private System.Windows.Forms.TextBox txtChunkFileUrl;
		private System.Windows.Forms.BindingSource bsConversionMetaData;
	}
}

