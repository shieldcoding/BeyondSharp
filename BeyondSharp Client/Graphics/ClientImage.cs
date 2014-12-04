using BeyondSharp.Common.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Client.Graphics
{
    public class ClientImage : Image<ClientImage>
    {
        /// <summary>
        /// Applies an image blend operation to the source image using the supplied image via the supplied method.
        /// </summary>
        /// <param name="image">The image to be blended into the source image.</param>
        /// <param name="method">The method by which to blend the two images.</param>
        /// <returns>The client image with the image operation applied.</returns>
        public override ClientImage Blend(ClientImage image, ImageBlendMethod method)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Applies a color blend operation to the source image using the supplied color via the supplied method.
        /// </summary>
        /// <param name="color">The color to be blended into the source image.</param>
        /// <param name="method">The method by which to blend the two images.</param>
        /// <returns>The client image with the image operation applied.</returns>
        public override ClientImage Blend(Color color, ImageBlendMethod method)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Applies a crop operation to the source image using the supplied area.
        /// </summary>
        /// <param name="area">The area to be cropped from the source image.</param>
        /// <returns>The client image with the image operation applied.</returns>
        public override ClientImage Crop(Rectangle area)
        {
            throw new NotImplementedException();
        }

    }
}
