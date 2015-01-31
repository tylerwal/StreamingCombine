﻿namespace StreamingFileCombineInterface
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
			this.btnGetChunkFileList = new System.Windows.Forms.Button();
			this.txtChunkFileUrl = new System.Windows.Forms.TextBox();
			this.bsConversionMetaData = new System.Windows.Forms.BindingSource(this.components);
			this.gbxChunkFile = new System.Windows.Forms.GroupBox();
			this.txtNumberOfChunks = new System.Windows.Forms.TextBox();
			this.lblNumberOfChunks = new System.Windows.Forms.Label();
			this.pbChunkFileList = new System.Windows.Forms.ProgressBar();
			this.gbxChunkFiles = new System.Windows.Forms.GroupBox();
			this.txtChunkFileTempLocation = new System.Windows.Forms.TextBox();
			this.btnSetChunkTempLocation = new System.Windows.Forms.Button();
			this.pbChunkFiles = new System.Windows.Forms.ProgressBar();
			this.btnDownloadChunkFiles = new System.Windows.Forms.Button();
			this.btnDoItAll = new System.Windows.Forms.Button();
			this.btnCombineChunks = new System.Windows.Forms.Button();
			this.pbCombineChunks = new System.Windows.Forms.ProgressBar();
			this.gbxConvertFile = new System.Windows.Forms.GroupBox();
			this.btnSetCombinedFileLocation = new System.Windows.Forms.Button();
			this.txtCombinedFileLocation = new System.Windows.Forms.TextBox();
			this.txtUnconvertedFileLocation = new System.Windows.Forms.TextBox();
			this.btnSetUnconvertedFileLocation = new System.Windows.Forms.Button();
			this.pbFileConversion = new System.Windows.Forms.ProgressBar();
			this.btnConvertFile = new System.Windows.Forms.Button();
			this.txtConvertedFileLocation = new System.Windows.Forms.TextBox();
			this.btnSetConvertedFileLocation = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).BeginInit();
			this.gbxChunkFile.SuspendLayout();
			this.gbxChunkFiles.SuspendLayout();
			this.gbxConvertFile.SuspendLayout();
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
			// btnGetChunkFileList
			// 
			this.btnGetChunkFileList.BackColor = System.Drawing.SystemColors.Control;
			this.btnGetChunkFileList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGetChunkFileList.Location = new System.Drawing.Point(9, 45);
			this.btnGetChunkFileList.Name = "btnGetChunkFileList";
			this.btnGetChunkFileList.Size = new System.Drawing.Size(111, 23);
			this.btnGetChunkFileList.TabIndex = 1;
			this.btnGetChunkFileList.Text = "Get Chunk File";
			this.btnGetChunkFileList.UseVisualStyleBackColor = false;
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
			this.gbxChunkFile.Controls.Add(this.pbChunkFileList);
			this.gbxChunkFile.Controls.Add(this.lblChunkFileUrl);
			this.gbxChunkFile.Controls.Add(this.btnGetChunkFileList);
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
			this.gbxChunkFiles.Controls.Add(this.txtCombinedFileLocation);
			this.gbxChunkFiles.Controls.Add(this.btnSetCombinedFileLocation);
			this.gbxChunkFiles.Controls.Add(this.pbCombineChunks);
			this.gbxChunkFiles.Controls.Add(this.btnCombineChunks);
			this.gbxChunkFiles.Controls.Add(this.txtChunkFileTempLocation);
			this.gbxChunkFiles.Controls.Add(this.btnSetChunkTempLocation);
			this.gbxChunkFiles.Controls.Add(this.pbChunkFiles);
			this.gbxChunkFiles.Controls.Add(this.btnDownloadChunkFiles);
			this.gbxChunkFiles.Location = new System.Drawing.Point(12, 125);
			this.gbxChunkFiles.Name = "gbxChunkFiles";
			this.gbxChunkFiles.Size = new System.Drawing.Size(946, 146);
			this.gbxChunkFiles.TabIndex = 4;
			this.gbxChunkFiles.TabStop = false;
			this.gbxChunkFiles.Text = "Chunk Files";
			// 
			// txtChunkFileTempLocation
			// 
			this.txtChunkFileTempLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtChunkFileTempLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "TempDirectory", true));
			this.txtChunkFileTempLocation.Location = new System.Drawing.Point(179, 22);
			this.txtChunkFileTempLocation.Name = "txtChunkFileTempLocation";
			this.txtChunkFileTempLocation.ReadOnly = true;
			this.txtChunkFileTempLocation.Size = new System.Drawing.Size(761, 20);
			this.txtChunkFileTempLocation.TabIndex = 6;
			// 
			// btnSetChunkTempLocation
			// 
			this.btnSetChunkTempLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetChunkTempLocation.Location = new System.Drawing.Point(9, 20);
			this.btnSetChunkTempLocation.Name = "btnSetChunkTempLocation";
			this.btnSetChunkTempLocation.Size = new System.Drawing.Size(164, 23);
			this.btnSetChunkTempLocation.TabIndex = 5;
			this.btnSetChunkTempLocation.Text = "Set Chunk File Temp Location";
			this.btnSetChunkTempLocation.UseVisualStyleBackColor = true;
			// 
			// pbChunkFiles
			// 
			this.pbChunkFiles.Location = new System.Drawing.Point(126, 49);
			this.pbChunkFiles.Name = "pbChunkFiles";
			this.pbChunkFiles.Size = new System.Drawing.Size(330, 23);
			this.pbChunkFiles.TabIndex = 4;
			// 
			// btnDownloadChunkFiles
			// 
			this.btnDownloadChunkFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDownloadChunkFiles.Location = new System.Drawing.Point(7, 49);
			this.btnDownloadChunkFiles.Name = "btnDownloadChunkFiles";
			this.btnDownloadChunkFiles.Size = new System.Drawing.Size(113, 23);
			this.btnDownloadChunkFiles.TabIndex = 0;
			this.btnDownloadChunkFiles.Text = "Download Chunks";
			this.btnDownloadChunkFiles.UseVisualStyleBackColor = true;
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
			// btnCombineChunks
			// 
			this.btnCombineChunks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCombineChunks.Location = new System.Drawing.Point(6, 109);
			this.btnCombineChunks.Name = "btnCombineChunks";
			this.btnCombineChunks.Size = new System.Drawing.Size(113, 23);
			this.btnCombineChunks.TabIndex = 7;
			this.btnCombineChunks.Text = "Combine Chunks";
			this.btnCombineChunks.UseVisualStyleBackColor = true;
			// 
			// pbCombineChunks
			// 
			this.pbCombineChunks.Location = new System.Drawing.Point(125, 109);
			this.pbCombineChunks.Name = "pbCombineChunks";
			this.pbCombineChunks.Size = new System.Drawing.Size(330, 23);
			this.pbCombineChunks.TabIndex = 8;
			// 
			// gbxConvertFile
			// 
			this.gbxConvertFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxConvertFile.Controls.Add(this.txtConvertedFileLocation);
			this.gbxConvertFile.Controls.Add(this.btnSetConvertedFileLocation);
			this.gbxConvertFile.Controls.Add(this.pbFileConversion);
			this.gbxConvertFile.Controls.Add(this.btnConvertFile);
			this.gbxConvertFile.Controls.Add(this.txtUnconvertedFileLocation);
			this.gbxConvertFile.Controls.Add(this.btnSetUnconvertedFileLocation);
			this.gbxConvertFile.Location = new System.Drawing.Point(12, 277);
			this.gbxConvertFile.Name = "gbxConvertFile";
			this.gbxConvertFile.Size = new System.Drawing.Size(947, 113);
			this.gbxConvertFile.TabIndex = 6;
			this.gbxConvertFile.TabStop = false;
			this.gbxConvertFile.Text = "File Conversion";
			// 
			// btnSetCombinedFileLocation
			// 
			this.btnSetCombinedFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCombinedFileLocation.Location = new System.Drawing.Point(6, 80);
			this.btnSetCombinedFileLocation.Name = "btnSetCombinedFileLocation";
			this.btnSetCombinedFileLocation.Size = new System.Drawing.Size(155, 23);
			this.btnSetCombinedFileLocation.TabIndex = 9;
			this.btnSetCombinedFileLocation.Text = "Set Combined File Location";
			this.btnSetCombinedFileLocation.UseVisualStyleBackColor = true;
			// 
			// txtCombinedFileLocation
			// 
			this.txtCombinedFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCombinedFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "TempDirectory", true));
			this.txtCombinedFileLocation.Location = new System.Drawing.Point(168, 80);
			this.txtCombinedFileLocation.Name = "txtCombinedFileLocation";
			this.txtCombinedFileLocation.ReadOnly = true;
			this.txtCombinedFileLocation.Size = new System.Drawing.Size(772, 20);
			this.txtCombinedFileLocation.TabIndex = 10;
			// 
			// txtUnconvertedFileLocation
			// 
			this.txtUnconvertedFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnconvertedFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "TempDirectory", true));
			this.txtUnconvertedFileLocation.Location = new System.Drawing.Point(168, 19);
			this.txtUnconvertedFileLocation.Name = "txtUnconvertedFileLocation";
			this.txtUnconvertedFileLocation.ReadOnly = true;
			this.txtUnconvertedFileLocation.Size = new System.Drawing.Size(772, 20);
			this.txtUnconvertedFileLocation.TabIndex = 12;
			// 
			// btnSetUnconvertedFileLocation
			// 
			this.btnSetUnconvertedFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetUnconvertedFileLocation.Location = new System.Drawing.Point(6, 19);
			this.btnSetUnconvertedFileLocation.Name = "btnSetUnconvertedFileLocation";
			this.btnSetUnconvertedFileLocation.Size = new System.Drawing.Size(155, 23);
			this.btnSetUnconvertedFileLocation.TabIndex = 11;
			this.btnSetUnconvertedFileLocation.Text = "Set Unconverted File Location";
			this.btnSetUnconvertedFileLocation.UseVisualStyleBackColor = true;
			// 
			// pbFileConversion
			// 
			this.pbFileConversion.Location = new System.Drawing.Point(125, 77);
			this.pbFileConversion.Name = "pbFileConversion";
			this.pbFileConversion.Size = new System.Drawing.Size(330, 23);
			this.pbFileConversion.TabIndex = 14;
			// 
			// btnConvertFile
			// 
			this.btnConvertFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConvertFile.Location = new System.Drawing.Point(6, 77);
			this.btnConvertFile.Name = "btnConvertFile";
			this.btnConvertFile.Size = new System.Drawing.Size(113, 23);
			this.btnConvertFile.TabIndex = 13;
			this.btnConvertFile.Text = "Convert File";
			this.btnConvertFile.UseVisualStyleBackColor = true;
			// 
			// txtConvertedFileLocation
			// 
			this.txtConvertedFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConvertedFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsConversionMetaData, "TempDirectory", true));
			this.txtConvertedFileLocation.Location = new System.Drawing.Point(168, 48);
			this.txtConvertedFileLocation.Name = "txtConvertedFileLocation";
			this.txtConvertedFileLocation.ReadOnly = true;
			this.txtConvertedFileLocation.Size = new System.Drawing.Size(772, 20);
			this.txtConvertedFileLocation.TabIndex = 16;
			// 
			// btnSetConvertedFileLocation
			// 
			this.btnSetConvertedFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetConvertedFileLocation.Location = new System.Drawing.Point(6, 48);
			this.btnSetConvertedFileLocation.Name = "btnSetConvertedFileLocation";
			this.btnSetConvertedFileLocation.Size = new System.Drawing.Size(155, 23);
			this.btnSetConvertedFileLocation.TabIndex = 15;
			this.btnSetConvertedFileLocation.Text = "Set Converted File Location";
			this.btnSetConvertedFileLocation.UseVisualStyleBackColor = true;
			// 
			// StreamingCombineView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 583);
			this.Controls.Add(this.gbxConvertFile);
			this.Controls.Add(this.btnDoItAll);
			this.Controls.Add(this.gbxChunkFiles);
			this.Controls.Add(this.gbxChunkFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "StreamingCombineView";
			this.Text = "Streaming Combine";
			((System.ComponentModel.ISupportInitialize)(this.bsConversionMetaData)).EndInit();
			this.gbxChunkFile.ResumeLayout(false);
			this.gbxChunkFile.PerformLayout();
			this.gbxChunkFiles.ResumeLayout(false);
			this.gbxChunkFiles.PerformLayout();
			this.gbxConvertFile.ResumeLayout(false);
			this.gbxConvertFile.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblChunkFileUrl;
		private System.Windows.Forms.Button btnGetChunkFileList;
		private System.Windows.Forms.TextBox txtChunkFileUrl;
		private System.Windows.Forms.BindingSource bsConversionMetaData;
		private System.Windows.Forms.GroupBox gbxChunkFile;
		private System.Windows.Forms.TextBox txtNumberOfChunks;
		private System.Windows.Forms.Label lblNumberOfChunks;
		private System.Windows.Forms.ProgressBar pbChunkFileList;
		private System.Windows.Forms.GroupBox gbxChunkFiles;
		private System.Windows.Forms.Button btnDoItAll;
		private System.Windows.Forms.Button btnDownloadChunkFiles;
		private System.Windows.Forms.ProgressBar pbChunkFiles;
		private System.Windows.Forms.TextBox txtChunkFileTempLocation;
		private System.Windows.Forms.Button btnSetChunkTempLocation;
		private System.Windows.Forms.ProgressBar pbCombineChunks;
		private System.Windows.Forms.Button btnCombineChunks;
		private System.Windows.Forms.GroupBox gbxConvertFile;
		private System.Windows.Forms.TextBox txtCombinedFileLocation;
		private System.Windows.Forms.Button btnSetCombinedFileLocation;
		private System.Windows.Forms.TextBox txtConvertedFileLocation;
		private System.Windows.Forms.Button btnSetConvertedFileLocation;
		private System.Windows.Forms.ProgressBar pbFileConversion;
		private System.Windows.Forms.Button btnConvertFile;
		private System.Windows.Forms.TextBox txtUnconvertedFileLocation;
		private System.Windows.Forms.Button btnSetUnconvertedFileLocation;
	}
}

