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
			InitializeComponent();

			_presenter = new StreamingCombineViewPresenter(this);

			bsConversionMetaData.DataSource = new ConversionMetaData();
			
			btnGetChunkFiles.Click += GetChunkFiles;
			btnDoItAll.Click += DoItAll;
			btnSetTempLocation.Click += BtnSetTempLocationClick;
			txtChunkFileUrl.TextChanged += TxtChunkFileUrlTextChanged;

			InitializeButtons();
		}

		private void BtnSetTempLocationClick(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();
			string tempDirectory = conversionData.TempDirectory;

			FolderBrowserDialog dialog = new FolderBrowserDialog()
			{
				ShowNewFolderButton = true,
			};

			if (Directory.Exists(tempDirectory))
			{
				dialog.SelectedPath = tempDirectory;
			}
			else
			{
				dialog.RootFolder = Environment.SpecialFolder.Desktop;
			}

			dialog.ShowDialog();

			conversionData.TempDirectory = dialog.SelectedPath;
		}
		
		#region Event Handlers

		private void TxtChunkFileUrlTextChanged(object sender, EventArgs e)
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
			ConversionMetaData conversionData = GetBoundMetaData();
			
			_presenter.GetChunkFileList(conversionData);

			btnGetChunkFiles.ResetBackColor();

			btnDownloadChunks.BackColor = Color.DarkOrange;
			btnDownloadChunks.Enabled = true;
		}

		private void DoItAll(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();

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

		#endregion Event Handlers

		#region Helper Methods

		private void InitializeButtons()
		{
			List<Tuple<Button, bool>> buttons = new List<Tuple<Button, bool>>
			{
				new Tuple<Button, bool>(btnGetChunkFiles, false),
				new Tuple<Button, bool>(btnSetTempLocation, true),
				new Tuple<Button, bool>(btnDownloadChunks, false),
				new Tuple<Button, bool>(btnDoItAll, true),
			};

			foreach (Tuple<Button, bool> button in buttons)
			{
				button.Item1.Enabled = button.Item2;
			}

			btnGetChunkFiles.BackColor = Color.DarkOrange;			
		}

		private ConversionMetaData GetBoundMetaData()
		{
			return bsConversionMetaData.DataSource as ConversionMetaData;
		}

		#endregion Helper Methods
	}
}
