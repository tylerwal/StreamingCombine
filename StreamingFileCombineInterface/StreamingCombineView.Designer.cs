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
			this.gbxChunkFile = new System.Windows.Forms.GroupBox();
			this.txtNumberOfChunks = new System.Windows.Forms.TextBox();
			this.lblNumberOfChunks = new System.Windows.Forms.Label();
			this.pbChunkFileList = new System.Windows.Forms.ProgressBar();
			this.gbxChunkFiles = new System.Windows.Forms.GroupBox();
			this.btnDoItAll = new System.Windows.Forms.Button();
			this.btnDownloadChunks = new System.Windows.Forms.Button();
			this.pbChunkFiles = new System.Windows.Forms.ProgressBar();
			this.btnSetTempLocation = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.bsConversionMetaData = new System.Windows.Forms.BindingSource(this.components);
			this.gbxChunkFile.SuspendLayout();
			this.gbxChunkFiles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).BeginInit();
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
			this.btnGetChunkFiles.BackColor = System.Drawing.SystemColors.Control;
			this.btnGetChunkFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGetChunkFiles.Location = new System.Drawing.Point(9, 45);
			this.btnGetChunkFiles.Name = "btnGetChunkFiles";
			this.btnGetChunkFiles.Size = new System.Drawing.Size(111, 23);
			this.btnGetChunkFiles.TabIndex = 1;
			this.btnGetChunkFiles.Text = "Get Chunk File";
			this.btnGetChunkFiles.UseVisualStyleBackColor = false;
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
			// gbxChunkFile
			// 
			this.gbxChunkFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxChunkFile.Controls.Add(this.txtNumberOfChunks);
			this.gbxChunkFile.Controls.Add(this.lblNumberOfChunks);
			this.gbxChunkFile.Controls.Add(this.pbChunkFileList);
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
			this.txtNumberOfChunks.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "NumberOfChunkFiles", true));
			this.txtNumberOfChunks.Location = new System.Drawing.Point(112, 74);
			this.txtNumberOfChunks.Name = "txtNumberOfChunks";
			this.txtNumberOfChunks.ReadOnly = true;
			this.txtNumberOfChunks.Size = new System.Drawing.Size(86, 20);
			this.txtNumberOfChunks.TabIndex = 5;
			this.txtNumberOfChunks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			// pbChunkFileList
			// 
			this.pbChunkFileList.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsConversionMetaData, "PercentDoneChunkFileList", true));
			this.pbChunkFileList.Location = new System.Drawing.Point(126, 45);
			this.pbChunkFileList.Name = "pbChunkFileList";
			this.pbChunkFileList.Size = new System.Drawing.Size(330, 23);
			this.pbChunkFileList.TabIndex = 3;
			// 
			// gbxChunkFiles
			// 
			this.gbxChunkFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxChunkFiles.Controls.Add(this.textBox1);
			this.gbxChunkFiles.Controls.Add(this.btnSetTempLocation);
			this.gbxChunkFiles.Controls.Add(this.pbChunkFiles);
			this.gbxChunkFiles.Controls.Add(this.btnDownloadChunks);
			this.gbxChunkFiles.Location = new System.Drawing.Point(12, 125);
			this.gbxChunkFiles.Name = "gbxChunkFiles";
			this.gbxChunkFiles.Size = new System.Drawing.Size(946, 93);
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
			// btnDownloadChunks
			// 
			this.btnDownloadChunks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDownloadChunks.Location = new System.Drawing.Point(7, 58);
			this.btnDownloadChunks.Name = "btnDownloadChunks";
			this.btnDownloadChunks.Size = new System.Drawing.Size(113, 23);
			this.btnDownloadChunks.TabIndex = 0;
			this.btnDownloadChunks.Text = "Download Chunks";
			this.btnDownloadChunks.UseVisualStyleBackColor = true;
			// 
			// pbChunkFiles
			// 
			this.pbChunkFiles.Location = new System.Drawing.Point(126, 58);
			this.pbChunkFiles.Name = "pbChunkFiles";
			this.pbChunkFiles.Size = new System.Drawing.Size(330, 23);
			this.pbChunkFiles.TabIndex = 4;
			// 
			// btnSetTempLocation
			// 
			this.btnSetTempLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetTempLocation.Location = new System.Drawing.Point(9, 20);
			this.btnSetTempLocation.Name = "btnSetTempLocation";
			this.btnSetTempLocation.Size = new System.Drawing.Size(111, 23);
			this.btnSetTempLocation.TabIndex = 5;
			this.btnSetTempLocation.Text = "Set Temp Location";
			this.btnSetTempLocation.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "TempDirectory", true));
			this.textBox1.Location = new System.Drawing.Point(127, 22);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(813, 20);
			this.textBox1.TabIndex = 6;
			// 
			// bsConversionMetaData
			// 
			this.bsConversionMetaData.DataSource = typeof(FileCombiner.ConversionMetaData);
			// 
			// StreamingCombineView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 583);
			this.Controls.Add(this.btnDoItAll);
			this.Controls.Add(this.gbxChunkFiles);
			this.Controls.Add(this.gbxChunkFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "StreamingCombineView";
			this.Text = "Streaming Combine";
			this.gbxChunkFile.ResumeLayout(false);
			this.gbxChunkFile.PerformLayout();
			this.gbxChunkFiles.ResumeLayout(false);
			this.gbxChunkFiles.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).EndInit();
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
		private System.Windows.Forms.ProgressBar pbChunkFileList;
		private System.Windows.Forms.GroupBox gbxChunkFiles;
		private System.Windows.Forms.Button btnDoItAll;
		private System.Windows.Forms.Button btnDownloadChunks;
		private System.Windows.Forms.ProgressBar pbChunkFiles;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnSetTempLocation;
	}
}

