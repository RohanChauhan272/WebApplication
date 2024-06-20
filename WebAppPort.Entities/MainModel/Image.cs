using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppPort.Entities.MainModel
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
