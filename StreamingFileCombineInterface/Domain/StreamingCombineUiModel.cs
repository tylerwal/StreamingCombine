using FileCombiner.Annotations;
using StreamingFileCombineInterface.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace StreamingFileCombineInterface.Domain
{
	/// <summary>
	/// The view model used to pass data between view and presenter.
	/// </summary>
	public class StreamingCombineUiModel : IStreamingCombineUiModel, INotifyPropertyChanged
	{
		#region Fields

		private Queue<Uri> _parsedChunks;
		private string _chunkListFileUrl;
		private int _numberOfChunkFiles;
		private int _percentDoneChunkFileList;
		private string _tempDirectory;
		private string _unconvertedFilePath;
		private string _convertedFilePath;
		private bool _canDeleteOldChunkFiles;
		private bool _canDeleteUnconvertedFile;

		#endregion Fields

		#region Properties

		#region Chunk File List

		/// <summary>
		/// Gets or sets the parsed chunks.
		/// </summary>
		/// <value>
		/// The parsed chunks.
		/// </value>
		public Queue<Uri> ParsedChunks
		{
			get
			{
				return _parsedChunks;
			}
			set
			{
				_parsedChunks = value;
				OnPropertyChanged("ParsedChunks");
			}
		}

		/// <summary>
		/// Gets or sets the chunk list file URL.
		/// </summary>
		/// <value>
		/// The chunk list file URL.
		/// </value>
		public string ChunkListFileUrl
		{
			get
			{
				return _chunkListFileUrl;
			}
			set
			{
				_chunkListFileUrl = value;
				OnPropertyChanged("ChunkListFileUrl");
			}
		}

		/// <summary>
		/// Gets or sets the number of chunk files.
		/// </summary>
		/// <value>
		/// The number of chunk files.
		/// </value>
		public int NumberOfChunkFiles
		{
			get
			{
				return _numberOfChunkFiles;
			}
			set
			{
				_numberOfChunkFiles = value;
				OnPropertyChanged("NumberOfChunkFiles");
			}
		}

		#endregion Chunk File List

		/// <summary>
		/// Gets or sets the temporary directory.
		/// </summary>
		/// <value>
		/// The temporary directory.
		/// </value>
		public string TempDirectory
		{
			get
			{
				return _tempDirectory;
			}
			set
			{
				_tempDirectory = value;
				OnPropertyChanged("TempDirectory");
			}
		}

		/// <summary>
		/// Gets or sets the unconverted file path.
		/// </summary>
		/// <value>
		/// The unconverted file path.
		/// </value>
		public string UnconvertedFilePath
		{
			get
			{
				return _unconvertedFilePath;
			}
			set
			{
				_unconvertedFilePath = value;
				OnPropertyChanged("UnconvertedFilePath");
			}
		}

		/// <summary>
		/// Gets or sets the converted file path.
		/// </summary>
		/// <value>
		/// The converted file path.
		/// </value>
		public string ConvertedFilePath
		{
			get
			{
				return _convertedFilePath;
			}
			set
			{
				_convertedFilePath = value;
				OnPropertyChanged("ConvertedFilePath");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance can delete old chunk files.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance can delete old chunk files; otherwise, <c>false</c>.
		/// </value>
		public bool CanDeleteOldChunkFiles
		{
			get
			{
				return _canDeleteOldChunkFiles;
			}
			set
			{
				_canDeleteOldChunkFiles = value;
				OnPropertyChanged("CanDeleteOldChunkFiles");
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance can delete unconverted file.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance can delete unconverted file; otherwise, <c>false</c>.
		/// </value>
		public bool CanDeleteUnconvertedFile
		{
			get
			{
				return _canDeleteUnconvertedFile;
			}
			set
			{
				_canDeleteUnconvertedFile = value;
				OnPropertyChanged("CanDeleteUnconvertedFile");
			}
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="StreamingCombineUiModel"/> class.
		/// </summary>
		public StreamingCombineUiModel()
		{
			TempDirectory = Path.Combine(Path.GetTempPath(), "StreamingCombine");

			if (UnconvertedFilePath == null)
			{
				UnconvertedFilePath = Path.Combine(TempDirectory, "StreamingFile.ts");
			}

			CanDeleteOldChunkFiles = true;
			CanDeleteUnconvertedFile = true;
		}

		#endregion Constructor

		#region Events

		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Called when [property changed].
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		[NotifyPropertyChangedInvocator]
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion Events
	}
}