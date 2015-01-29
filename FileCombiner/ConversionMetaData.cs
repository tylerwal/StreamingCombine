﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

using FileCombiner.Annotations;
using FileCombiner.Contracts;

namespace FileCombiner
{
	public class ConversionMetaData : IConversionMetaData, INotifyPropertyChanged
	{
		#region Fields

		private const string _outputCombinedFileExtension = ".ts";

		private Queue<Uri> _parsedChunks;
		private string _chunkListFileUrl;
		private int _numberOfChunkFiles;
		private int _percentDoneChunkFileList;

		private string _mediaName;

		private string _outputDirectory;

		private string _tempDirectory;

		private string _unconvertedFilePath;

		private string _convertedFilePath;

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
		
		public string MediaName
		{
			get
			{
				return _mediaName;
			}
			set
			{
				_mediaName = value;
				OnPropertyChanged("MediaName");
			}
		}

		public string OutputDirectory
		{
			get
			{
				return _outputDirectory;
			}
			set
			{
				_outputDirectory = value;
				OnPropertyChanged("OutputDirectory");
			}
		}

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

		public string UnConvertedFilePath
		{
			get
			{
				return _unconvertedFilePath;
			}
			set
			{
				_unconvertedFilePath = value;
				OnPropertyChanged("UnConvertedFilePath");
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

		#endregion Properties

		#region Constructor

		public ConversionMetaData()
		{
			//TempDirectory = ConfigurationManager.AppSettings["tempFileLocation"];
		}

		#endregion Constructor

		#region PublicMethods

		public string GetFilePathCorrectedName()
		{
			return MediaName.Replace(" ", string.Empty);
		}

		public string CreateOutputFilePath()
		{
			StringBuilder combinedFilePathBuilder = new StringBuilder();
			combinedFilePathBuilder.Append(GetFilePathCorrectedName());
			combinedFilePathBuilder.Append(_outputCombinedFileExtension);

			return Path.Combine(OutputDirectory, combinedFilePathBuilder.ToString());
		}

		#endregion PublicMethods

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