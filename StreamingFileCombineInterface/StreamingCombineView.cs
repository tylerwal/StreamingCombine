using System.Collections.Generic;
using System.Drawing;

using FileCombiner;
using System;
using System.IO;
using System.Windows.Forms;

using StreamingFileCombineInterface.Contracts;

namespace StreamingFileCombineInterface
{
	public partial class StreamingCombineView : Form, IStreamingCombineView
	{
		private IStreamingCombinePresenter _presenter;

		public StreamingCombineView()
		{
			_presenter = new StreamingCombineViewPresenter(this);

			InitializeComponent();
			bsConversionMetaData.DataSource = new ConversionMetaData();
			
			btnGetChunkFiles.Click += GetChunkFiles;
			btnDoItAll.Click += DoItAll;

			txtChunkFileUrl.TextChanged += txtChunkFileUrl_TextChanged;
			
			List<Button> buttons = new List<Button>
			{
				btnGetChunkFiles,
				btnDownloadChunks
			};

			foreach (Button button in buttons)
			{
				button.Enabled = false;
			}

			btnGetChunkFiles.BackColor = Color.DarkOrange;
		}

		void txtChunkFileUrl_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace((sender as TextBox).Text))
			{
				btnGetChunkFiles.Enabled = true;
			}
			else
			{
				btnGetChunkFiles.Enabled = false;
			}
		}

		private void GetChunkFiles(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = bsConversionMetaData.DataSource as ConversionMetaData;
			
			_presenter.GetChunkFiles(ref conversionData);

			btnGetChunkFiles.ResetBackColor();

			btnDownloadChunks.BackColor = Color.DarkOrange;
			btnDownloadChunks.Enabled = true;
		}

		private void DoItAll(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = bsConversionMetaData.DataSource as ConversionMetaData;

			SaveFileDialog saveDialog = new SaveFileDialog
			{
				AddExtension = true,
				DefaultExt = ".mp4",
				Filter = "MP4 File (*.mp4)|*.mp4|MKV File (*.mkv)|*.mkv"
			};

			saveDialog.ShowDialog();

			conversionData.MediaName = Path.GetFileNameWithoutExtension(saveDialog.FileName);
			conversionData.OutputDirectory = Path.GetDirectoryName(saveDialog.FileName);

			_presenter.DoItAll(conversionData);
		}
	}
}
