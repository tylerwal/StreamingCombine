using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FileCombiner;

namespace StreamingFileCombineInterface
{
	public partial class StreamingCombineView : Form
	{
		public StreamingCombineView()
		{
			InitializeComponent();

			bsConversionMetaData.DataSource = new ConversionMetaData();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ConversionMetaData conversionData = bsConversionMetaData.DataSource as ConversionMetaData;
			
			SaveFileDialog saveDialog = new SaveFileDialog
			{
				AddExtension = true,
				DefaultExt = ".mp4",
				Filter = "MP4 File (*.mp4)|*.mp4|MKV File (*.mkv)|*.mkv"
			};

			saveDialog.ShowDialog();

			conversionData.Name = Path.GetFileNameWithoutExtension(saveDialog.FileName);
			conversionData.OutputDirectory = Path.GetDirectoryName(saveDialog.FileName);

			ChunkFileCombinerService fileCombinerService = new ChunkFileCombinerService();
			fileCombinerService.CreateCombinedFile(conversionData);
		}
	}
}
