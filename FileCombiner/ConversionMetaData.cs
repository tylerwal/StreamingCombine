using FileCombiner.Annotations;
using FileCombiner.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace FileCombiner
{
	public class ConversionMetaData : IConversionMetaData, INotifyPropertyChanged
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

		public int PercentDoneChunkFileList
		{
			get
			{
				return _percentDoneChunkFileList;
			}
			set
			{
				_percentDoneChunkFileList = value;
				OnPropertyChanged("PercentDoneChunkFileList");
			}
		}

		#endregion Chunk File List

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

		public ConversionMetaData()
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
		
		public event PropertyChangedEventHandler PropertyChanged;

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