using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Common.Graphics
{
    public abstract class Image<ImageType>
        where ImageType : Image<ImageType>
    {
        /// <summary>
        /// Blends the current image with the supplied image using the specified blending method.
        /// </summary>
        /// <param name="image">The image to be blended into this one.</param>
        /// <param name="method">The blending method to be used.</param>
        /// <returns>An image representing the source image blended by the supplied image.</returns>
        public abstract ImageType Blend(ImageType image, ImageBlendMethod method);

        /// <summary>
        /// Crops the image to the specified area.
        /// </summary>
        /// <param name="area">The area to crop this image to.</param>
        /// <returns>An image representing the source image cropped to the supplied area.</returns>
        public abstract ImageType Crop(Rectangle area);
    }
}
