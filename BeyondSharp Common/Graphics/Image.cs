// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Image.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   A shared image that enables the server to modify an image and product a set of instructions to be carried out by the client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Graphics
{
    using System.Drawing;

    /// <summary>
    /// A shared image that enables the server to modify an image and product a set of instructions to be carried out by the client.
    /// </summary>
    /// <typeparam name="TImageType">
    /// The server or client image type.
    /// </typeparam>
    public abstract class Image<TImageType>
        where TImageType : Image<TImageType>
    {
        #region Public Methods and Operators

        /// <summary>
        /// Blends the current image with the supplied image using the specified blending method.
        /// </summary>
        /// <param name="image">
        /// The image to be blended into this one.
        /// </param>
        /// <param name="method">
        /// The blending method to be used.
        /// </param>
        /// <returns>
        /// An image representing the source image blended by the supplied image with the supplied method.
        /// </returns>
        public abstract TImageType Blend(TImageType image, ImageBlendMethod method);

        /// <summary>
        /// Blend the current image with the supplied color using the specified blending method.
        /// This is effectively blending the image by a solid-color image of the same-size using the supplied color.
        /// </summary>
        /// <param name="color">
        /// The color to be blended into this one.
        /// </param>
        /// <param name="method">
        /// The blending method to be used.
        /// </param>
        /// <returns>
        /// An image representing the source image blended by the supplied color with the supplied method.
        /// </returns>
        public abstract TImageType Blend(Color color, ImageBlendMethod method);

        /// <summary>
        /// Crops the image to the specified area.
        /// </summary>
        /// <param name="area">
        /// The area to crop this image to.
        /// </param>
        /// <returns>
        /// An image representing the source image cropped to the supplied area.
        /// </returns>
        public abstract TImageType Crop(Rectangle area);

        #endregion
    }
}