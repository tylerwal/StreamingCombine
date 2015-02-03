using FileCombiner;
using StreamingFileCombineInterface.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StreamingFileCombineInterface
{
	public partial class StreamingCombineView : Form, IStreamingCombineView
	{
		#region Fields

		private readonly IStreamingCombinePresenter _presenter; 

		#endregion Fields

		#region Constructor

		public StreamingCombineView()
		{
			InitializeComponent();

			_presenter = new StreamingCombineViewPresenter(this);

			bsConversionMetaData.DataSource = new ConversionMetaData();

			btnGetChunkFileList.Click += DownloadChunkFileListList;
			btnSetChunkFileLocation.Click += SetTempLocation;
			btnDownloadChunkFiles.Click += DownloadChunkFiles;
			txtChunkFileUrl.TextChanged += TxtChunkFileUrlTextChanged;

			InitializeButtons();
		}

		#endregion Constructor
		
		#region Event Handlers

		private void TxtChunkFileUrlTextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace((sender as TextBox).Text))
			{
				btnGetChunkFileList.Enabled = true;
			}
			else
			{
				btnGetChunkFileList.Enabled = false;
			}
		}

		private void DownloadChunkFileListList(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();
			
			_presenter.GetChunkFileList(conversionData);

			btnGetChunkFileList.ResetBackColor();

			btnDownloadChunkFiles.BackColor = Color.DarkOrange;
			btnDownloadChunkFiles.Enabled = true;
		}

		private void SetTempLocation(object sender, EventArgs e)
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

		private void DownloadChunkFiles(object sender, EventArgs e)
		{
			_presenter.DownloadChunkFiles(GetBoundMetaData());
		}

		/*private void DoItAll(object sender, EventArgs e)
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
		}*/

		#endregion Event Handlers

		#region Helper Methods

		private void InitializeButtons()
		{
			List<Tuple<Button, bool>> buttons = new List<Tuple<Button, bool>>
			{
				new Tuple<Button, bool>(btnGetChunkFileList, false),
				new Tuple<Button, bool>(btnSetChunkFileLocation, true),
				new Tuple<Button, bool>(btnDownloadChunkFiles, false),
			};

			foreach (Tuple<Button, bool> button in buttons)
			{
				button.Item1.Enabled = button.Item2;
			}

			btnGetChunkFileList.BackColor = Color.DarkOrange;			
		}

		private ConversionMetaData GetBoundMetaData()
		{
			return bsConversionMetaData.DataSource as ConversionMetaData;
		}

		#endregion Helper Methods
	}
}
