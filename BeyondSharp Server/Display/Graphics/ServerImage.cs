namespace BeyondSharp.Server.Display.Graphics
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using BeyondSharp.Common.Display.Graphics;

    public class ServerImage : Image<ServerImage>
    {
        private readonly List<ImageOperation<ServerImage>> _operations = new List<ImageOperation<ServerImage>>();

        private void StoreImageOperation(ImageOperation<ServerImage> operation)
        {
            lock (_operations)
                _operations.Add(operation);
        }

        /// <summary>
        ///     Creates a blend operation of the source image blended with the supplied image using the supplied method.
        /// </summary>
        /// <param name="image">The image with which to blend the source image with.</param>
        /// <param name="method">The method by which to blend the source image.</param>
        /// <returns>The server image with the image operation stored.</returns>
        public override ServerImage Blend(ServerImage image, ImageBlendMethod method)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            var operation = new ImageOperation<ServerImage>.ImageBlendOperation(image, method);
            StoreImageOperation(operation);

            return this;
        }

        /// <summary>
        ///     Creates a blend operation of the source image blended with the supplied color using the supplied method.
        ///     Effectively this blends the source image with a solid color image.
        /// </summary>
        /// <param name="color">The color with which to blend the source image with.</param>
        /// <param name="method">The method by which to blend the source image.</param>
        /// <returns>The server image with the image operation stored.</returns>
        public override ServerImage Blend(Color color, ImageBlendMethod method)
        {
            var operation = new ImageOperation<ServerImage>.ColorBlendOperation(color, method);
            StoreImageOperation(operation);

            return this;
        }

        /// <summary>
        ///     Creates a crop operation of the source image cropped the supplied area.
        /// </summary>
        /// <param name="area">The area with which to crop the source image to.</param>
        /// <returns>The server image with the image operation stored.</returns>
        public override ServerImage Crop(Rectangle area)
        {
            var operation = new ImageOperation<ServerImage>.CropOperation(area);
            StoreImageOperation(operation);

            return this;
        }
    }
}