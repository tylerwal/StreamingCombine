using FileCombiner;
using StreamingFileCombineInterface.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StreamingFileCombineInterface
{
	/// <summary>
	/// UI for the application.
	/// </summary>
	public partial class StreamingCombineView : Form, IStreamingCombineView
	{
		#region Fields

		private readonly IStreamingCombinePresenter _presenter;

		private List<Tuple<Button, bool>> _buttonsAndInitialStates;

		#endregion Fields

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="StreamingCombineView"/> class.
		/// </summary>
		public StreamingCombineView()
		{
			InitializeComponent();

			_presenter = new StreamingCombineViewPresenter(this);

			bsConversionMetaData.DataSource = new ConversionMetaData();

			btnGetChunkFileList.Click += DownloadChunkFileListClick;
			btnSetChunkFileLocation.Click += SetTempLocationClick;
			btnDownloadChunkFiles.Click += DownloadChunkFilesClick;
			btnSetCombinedFileLocation.Click += SetCombinedFileLocationClick;
			btnSetUnconvertedFileLocation.Click += SetCombinedFileLocationClick;
			btnSetConvertedFileLocation.Click += SetConvertedFilePathClick;
			btnConvertFile.Click += ConvertFileClick;

			txtChunkFileUrl.TextChanged += ChunkFileUrlTextChanged;
			txtCombinedFileLocation.TextChanged += ConvertFileTextChanged;
			txtConvertedFileLocation.TextChanged += ConvertFileTextChanged;
			
			_buttonsAndInitialStates = new List<Tuple<Button, bool>>
			{
				new Tuple<Button, bool>(btnGetChunkFileList, false),
				new Tuple<Button, bool>(btnSetChunkFileLocation, true),
				new Tuple<Button, bool>(btnDownloadChunkFiles, false),
				new Tuple<Button, bool>(btnSetCombinedFileLocation, true),
				new Tuple<Button, bool>(btnCombineChunks, false),
				new Tuple<Button, bool>(btnSetUnconvertedFileLocation, true),
				new Tuple<Button, bool>(btnSetConvertedFileLocation, true),
				new Tuple<Button, bool>(btnConvertFile, false)
			};
			
			InitializeControls();
		}

		#endregion Constructor
		
		#region Event Handlers

		/// <summary>
		/// The Chunks file URL text has changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void ChunkFileUrlTextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(((TextBox)sender).Text))
			{
				SetSuggestedControl(btnGetChunkFileList, true);
			}
			else
			{
				SetSuggestedControl(txtChunkFileUrl, true);
				btnGetChunkFileList.Enabled = false;
			}
		}

		/// <summary>
		/// Enables the 'Convert File' button if both the 'Combined File Location' and 'Converted File Location' are not empty.
		/// </summary>
		/// <param name="sender">Not used.</param>
		/// <param name="e">Not Used.</param>
		private void ConvertFileTextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtCombinedFileLocation.Text)
				&& !string.IsNullOrWhiteSpace(txtConvertedFileLocation.Text))
			{
				btnConvertFile.Enabled = true;
			}
			else
			{
				btnConvertFile.Enabled = false;
			}
		}

		/// <summary>
		/// Downloads the chunk file list.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void DownloadChunkFileListClick(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();
			
			_presenter.GetChunkFileList(conversionData);

			btnGetChunkFileList.ResetBackColor();

			SetSuggestedControl(btnDownloadChunkFiles, true);
		}

		/// <summary>
		/// Sets the temporary location.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void SetTempLocationClick(object sender, EventArgs e)
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

		/// <summary>
		/// Sets the converted file path.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void SetConvertedFilePathClick(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();

			SaveFileDialog dialog = new SaveFileDialog()
			{
				AddExtension = true,
				DefaultExt = ".mp4",
				Filter = "MP4 File (*.mp4)|*.mp4|MKV File (*.mkv)|*.mkv"
			};

			dialog.ShowDialog();

			SetSuggestedControl(btnConvertFile, false);

			conversionData.ConvertedFilePath = dialog.FileName;
		}

		/// <summary>
		/// Downloads the chunk files.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void DownloadChunkFilesClick(object sender, EventArgs e)
		{
			_presenter.DownloadChunkFiles(GetBoundMetaData());
		}

		/// <summary>
		/// Sets the combined file location click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		void SetCombinedFileLocationClick(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = GetBoundMetaData();

			OpenFileDialog dialog = new OpenFileDialog()
			{
				AddExtension = true,
				DefaultExt = ".ts",
				Filter = "MPEG Transport Stream File (*.ts)|*.ts"
			};

			dialog.ShowDialog();

			conversionData.UnconvertedFilePath = dialog.FileName;

			SetSuggestedControl(btnSetConvertedFileLocation, true);
		}

		private void ConvertFileClick(object sender, EventArgs e)
		{
			ConversionMetaData conversionMetaData = GetBoundMetaData();

			_presenter.ConvertFile(conversionMetaData);
		}

		#endregion Event Handlers

		#region Helper Methods

		/// <summary>
		/// Initializes the controls to their initial starting enabled/disabled state.
		/// </summary>
		private void InitializeControls()
		{
			foreach (Tuple<Button, bool> button in _buttonsAndInitialStates)
			{
				button.Item1.Enabled = button.Item2;
			}

			SetSuggestedControl(txtChunkFileUrl, true);
		}

		/// <summary>
		/// Gets the bound meta data.
		/// </summary>
		/// <returns>The ConversionMetaData object.</returns>
		private ConversionMetaData GetBoundMetaData()
		{
			return bsConversionMetaData.DataSource as ConversionMetaData;
		}

		/// <summary>
		/// Sets the suggested control - by highlighting the particlar control.
		/// </summary>
		/// <param name="buttonToColorize">The button to colorize.</param>
		/// <param name="setControlEnabled">if set to <c>true</c> [set control enabled].</param>
		private void SetSuggestedControl(Control buttonToColorize, bool setControlEnabled)
		{
			ResetBackcolorOfControls(Controls);

			buttonToColorize.BackColor = Color.DarkOrange;
			buttonToColorize.Enabled = setControlEnabled;
		}

		/// <summary>
		/// Resets the backcolor of controls.
		/// </summary>
		/// <param name="controls">The controls.</param>
		private void ResetBackcolorOfControls(IEnumerable controls)
		{
			foreach (object control in controls)
			{
				if (control is GroupBox)
				{
					ResetBackcolorOfControls(((GroupBox)control).Controls);
				}
				else if(control is Control)
				{
					((Control)control).ResetBackColor();
				}
			}
		}

		#endregion Helper Methods
	}
}
