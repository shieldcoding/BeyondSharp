using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Graphics
{
    /// <summary>
    /// The server stores changes to images as operations to be executed by the client.
    /// </summary>
    public abstract class ImageOperation<ImageType>
        where ImageType : Image<ImageType>
    {
        [JsonProperty]
        public ImageOperationType OperationType { get; private set; }

        public class ImageBlendOperation : ImageOperation<ImageType>
        {
            [JsonProperty]
            public ImageType Image { get; private set; }

            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }

            public ImageBlendOperation(ImageType image, ImageBlendMethod method)
            {
                OperationType = ImageOperationType.ImageBlend;
                Image = image;
                Method = method;
            }
        }

        public class ColorBlendOperation : ImageOperation<ImageType>
        {
            [JsonProperty]
            public Color Color { get; private set; }

            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }

            public ColorBlendOperation(Color color, ImageBlendMethod method)
            {
                OperationType = ImageOperationType.ColorBlend;
                Color = color;
                Method = method;
            }
        }

        public class CropOperation : ImageOperation<ImageType>
        {
            [JsonProperty]
            public Rectangle Area { get; private set; }

            public CropOperation(Rectangle area)
            {
                OperationType = ImageOperationType.Crop;
                Area = area;
            }
        }

        public enum ImageOperationType
        {
            ImageBlend,
            ColorBlend,
            Crop
        }
    }
}
