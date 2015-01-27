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
			this.btnGetChunkFiles = new System.Windows.Forms.Button();
			this.txtChunkFileUrl = new System.Windows.Forms.TextBox();
			this.bsConversionMetaData = new System.Windows.Forms.BindingSource(this.components);
			this.gbxChunkFile = new System.Windows.Forms.GroupBox();
			this.txtNumberOfChunks = new System.Windows.Forms.TextBox();
			this.lblNumberOfChunks = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.gbxChunkFiles = new System.Windows.Forms.GroupBox();
			this.btnDoItAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).BeginInit();
			this.gbxChunkFile.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblChunkFileUrl
			// 
			this.lblChunkFileUrl.AutoSize = true;
			this.lblChunkFileUrl.Location = new System.Drawing.Point(6, 22);
			this.lblChunkFileUrl.Name = "lblChunkFileUrl";
			this.lblChunkFileUrl.Size = new System.Drawing.Size(114, 13);
			this.lblChunkFileUrl.TabIndex = 0;
			this.lblChunkFileUrl.Text = "Chunk File (m3u8) Url: ";
			// 
			// btnGetChunkFiles
			// 
			this.btnGetChunkFiles.Location = new System.Drawing.Point(9, 45);
			this.btnGetChunkFiles.Name = "btnGetChunkFiles";
			this.btnGetChunkFiles.Size = new System.Drawing.Size(111, 23);
			this.btnGetChunkFiles.TabIndex = 1;
			this.btnGetChunkFiles.Text = "Get Chunk File";
			this.btnGetChunkFiles.UseVisualStyleBackColor = true;
			// 
			// txtChunkFileUrl
			// 
			this.txtChunkFileUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtChunkFileUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "ChunkListFileUrl", true));
			this.txtChunkFileUrl.Location = new System.Drawing.Point(126, 19);
			this.txtChunkFileUrl.Name = "txtChunkFileUrl";
			this.txtChunkFileUrl.Size = new System.Drawing.Size(814, 20);
			this.txtChunkFileUrl.TabIndex = 2;
			// 
			// bsConversionMetaData
			// 
			this.bsConversionMetaData.DataSource = typeof(FileCombiner.ConversionMetaData);
			// 
			// gbxChunkFile
			// 
			this.gbxChunkFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxChunkFile.Controls.Add(this.txtNumberOfChunks);
			this.gbxChunkFile.Controls.Add(this.lblNumberOfChunks);
			this.gbxChunkFile.Controls.Add(this.progressBar1);
			this.gbxChunkFile.Controls.Add(this.lblChunkFileUrl);
			this.gbxChunkFile.Controls.Add(this.btnGetChunkFiles);
			this.gbxChunkFile.Controls.Add(this.txtChunkFileUrl);
			this.gbxChunkFile.Location = new System.Drawing.Point(12, 12);
			this.gbxChunkFile.Name = "gbxChunkFile";
			this.gbxChunkFile.Size = new System.Drawing.Size(946, 106);
			this.gbxChunkFile.TabIndex = 3;
			this.gbxChunkFile.TabStop = false;
			this.gbxChunkFile.Text = "Chunk File List";
			// 
			// txtNumberOfChunks
			// 
			this.txtNumberOfChunks.Location = new System.Drawing.Point(112, 74);
			this.txtNumberOfChunks.Name = "txtNumberOfChunks";
			this.txtNumberOfChunks.ReadOnly = true;
			this.txtNumberOfChunks.Size = new System.Drawing.Size(100, 20);
			this.txtNumberOfChunks.TabIndex = 5;
			// 
			// lblNumberOfChunks
			// 
			this.lblNumberOfChunks.AutoSize = true;
			this.lblNumberOfChunks.Location = new System.Drawing.Point(6, 77);
			this.lblNumberOfChunks.Name = "lblNumberOfChunks";
			this.lblNumberOfChunks.Size = new System.Drawing.Size(100, 13);
			this.lblNumberOfChunks.TabIndex = 4;
			this.lblNumberOfChunks.Text = "Number Of Chunks:";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(126, 45);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(330, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// gbxChunkFiles
			// 
			this.gbxChunkFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxChunkFiles.Location = new System.Drawing.Point(12, 125);
			this.gbxChunkFiles.Name = "gbxChunkFiles";
			this.gbxChunkFiles.Size = new System.Drawing.Size(946, 100);
			this.gbxChunkFiles.TabIndex = 4;
			this.gbxChunkFiles.TabStop = false;
			this.gbxChunkFiles.Text = "Chunk Files";
			// 
			// btnDoItAll
			// 
			this.btnDoItAll.Location = new System.Drawing.Point(12, 548);
			this.btnDoItAll.Name = "btnDoItAll";
			this.btnDoItAll.Size = new System.Drawing.Size(75, 23);
			this.btnDoItAll.TabIndex = 5;
			this.btnDoItAll.Text = "Do It All!!";
			this.btnDoItAll.UseVisualStyleBackColor = true;
			// 
			// StreamingCombineView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 583);
			this.Controls.Add(this.btnDoItAll);
			this.Controls.Add(this.gbxChunkFiles);
			this.Controls.Add(this.gbxChunkFile);
			this.Name = "StreamingCombineView";
			this.Text = "Streaming Combine";
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).EndInit();
			this.gbxChunkFile.ResumeLayout(false);
			this.gbxChunkFile.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblChunkFileUrl;
		private System.Windows.Forms.Button btnGetChunkFiles;
		private System.Windows.Forms.TextBox txtChunkFileUrl;
		private System.Windows.Forms.BindingSource bsConversionMetaData;
		private System.Windows.Forms.GroupBox gbxChunkFile;
		private System.Windows.Forms.TextBox txtNumberOfChunks;
		private System.Windows.Forms.Label lblNumberOfChunks;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox gbxChunkFiles;
		private System.Windows.Forms.Button btnDoItAll;
	}
}

