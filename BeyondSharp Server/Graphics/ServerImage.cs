using BeyondSharp.Common.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSharp.Server.Graphics
{
    public class ServerImage : Image<ServerImage>
    {
        /// <summary>
        /// Creates a blend operation of the supplied method using the source image and the supplied image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public override ServerImage Blend(ServerImage image, ImageBlendMethod method)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            throw new NotImplementedException();
        }

        public override ServerImage Crop(Rectangle area)
        {

            throw new NotImplementedException();
        }
    }
}
