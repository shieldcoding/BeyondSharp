namespace BeyondSharp.Common.Display.Graphics
{
    using System.Drawing;

    using Newtonsoft.Json;

    /// <summary>
    ///     The server stores changes to images as operations to be executed by the client.
    /// </summary>
    public abstract class ImageOperation<ImageType>
        where ImageType : Image<ImageType>
    {
        public enum ImageOperationType
        {
            ImageBlend,

            ColorBlend,

            Crop
        }

        [JsonProperty]
        public ImageOperationType OperationType { get; private set; }

        public class ImageBlendOperation : ImageOperation<ImageType>
        {
            public ImageBlendOperation(ImageType image, ImageBlendMethod method)
            {
                OperationType = ImageOperationType.ImageBlend;
                Image = image;
                Method = method;
            }

            [JsonProperty]
            public ImageType Image { get; private set; }

            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }
        }

        public class ColorBlendOperation : ImageOperation<ImageType>
        {
            public ColorBlendOperation(Color color, ImageBlendMethod method)
            {
                OperationType = ImageOperationType.ColorBlend;
                Color = color;
                Method = method;
            }

            [JsonProperty]
            public Color Color { get; private set; }

            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }
        }

        public class CropOperation : ImageOperation<ImageType>
        {
            public CropOperation(Rectangle area)
            {
                OperationType = ImageOperationType.Crop;
                Area = area;
            }

            [JsonProperty]
            public Rectangle Area { get; private set; }
        }
    }
}