using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clearing.Msc.Business.MasterCom.ModelData
{
    public class FileAttachment
    {
        /// <summary>
        /// File name of image. The filename will have an extension of .zip.
        /// </summary>
        public string filename { get; set; }
        /// <summary>
        /// File converted to a base64 encoded string. File Format is ZIP Note: ZIP file may contain these formats...JPG, TIFF, PDF
        /// </summary>
        public string file { get; set; }
    }
}
