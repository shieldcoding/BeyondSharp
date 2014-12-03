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
        public class ImageBlendOperation : ImageOperation<ImageType>
        {
            public ImageType Image { get; private set; }

            public ImageBlendMethod Method { get; private set; }

            public ImageBlendOperation(ImageType image, ImageBlendMethod method)
            {
                Image = image;
                Method = method;
            }
        }

        public class ColorBlendOperation : ImageOperation<ImageType>
        {
            public Color Color { get; private set; }

            public ImageBlendMethod Method { get; private set; }

            public ColorBlendOperation(Color color, ImageBlendMethod method)
            {
                Color = color;
                Method = method;
            }
        }

        public class CropOperation : ImageOperation<ImageType>
        {
            public Rectangle Area { get; private set; }

            public CropOperation(Rectangle area)
            {
                Area = area;
            }
        }
    }
}
