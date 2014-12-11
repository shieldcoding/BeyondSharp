// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerImage.cs" company="ShieldCoding">
//   No license available, currently privately owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Server.Graphics
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using BeyondSharp.Common.Graphics;

    /// <summary>
    /// The server image.
    /// </summary>
    public class ServerImage : Image<ServerImage>
    {
        #region Fields

        /// <summary>
        /// The operations.
        /// </summary>
        private List<ImageOperation<ServerImage>> operations = new List<ImageOperation<ServerImage>>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates a blend operation of the source image blended with the supplied image using the supplied method.
        /// </summary>
        /// <param name="image">
        /// The image with which to blend the source image with.
        /// </param>
        /// <param name="method">
        /// The method by which to blend the source image.
        /// </param>
        /// <returns>
        /// The server image with the image operation stored.
        /// </returns>
        public override ServerImage Blend(ServerImage image, ImageBlendMethod method)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            var operation = new ImageOperation<ServerImage>.ImageBlendOperation(image, method);
            this.StoreImageOperation(operation);

            return this;
        }

        /// <summary>
        /// Creates a stored blend operation of the source image blended with the supplied color as a solid image using the supplied method.
        /// </summary>
        /// <param name="color">
        /// The color with which to blend the source image with.
        /// </param>
        /// <param name="method">
        /// The method by which to blend the source image.
        /// </param>
        /// <returns>
        /// The server image with the image operation stored.
        /// </returns>
        public override ServerImage Blend(Color color, ImageBlendMethod method)
        {
            var operation = new ImageOperation<ServerImage>.ColorBlendOperation(color, method);
            this.StoreImageOperation(operation);

            return this;
        }

        /// <summary>
        /// Creates a crop operation of the source image cropped the supplied area.
        /// </summary>
        /// <param name="area">
        /// The area with which to crop the source image to.
        /// </param>
        /// <returns>
        /// The server image with the image operation stored.
        /// </returns>
        public override ServerImage Crop(Rectangle area)
        {
            var operation = new ImageOperation<ServerImage>.CropOperation(area);
            this.StoreImageOperation(operation);

            return this;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The store image operation.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        private void StoreImageOperation(ImageOperation<ServerImage> operation)
        {
            lock (this.operations)
            {
                this.operations.Add(operation);
            }
        }

        #endregion
    }
}