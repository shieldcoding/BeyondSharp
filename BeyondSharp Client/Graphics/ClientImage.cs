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
        public override ClientImage Blend(ClientImage image, ImageBlendMethod method)
        {
            throw new NotImplementedException();
        }

        public override ClientImage Blend(Color color, ImageBlendMethod method)
        {
            throw new NotImplementedException();
        }

        public override ClientImage Crop(Rectangle area)
        {
            throw new NotImplementedException();
        }

    }
}
