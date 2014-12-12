namespace BeyondSharp.Common.Graphics
{
    using System.Drawing;

    public abstract class Image<ImageType>
        where ImageType : Image<ImageType>
    {
        /// <summary>
        ///     Blends the current image with the supplied image using the specified blending method.
        /// </summary>
        /// <param name="image">The image to be blended into this one.</param>
        /// <param name="method">The blending method to be used.</param>
        /// <returns>An image representing the source image blended by the supplied image with the supplied method.</returns>
        public abstract ImageType Blend(ImageType image, ImageBlendMethod method);

        /// <summary>
        ///     Blend the current image with the supplied color using the specified blending method.
        ///     This is effectively blending the image by a solid-color image of the same-size using the supplied color.
        /// </summary>
        /// <param name="color">The color to be blended into this one.</param>
        /// <param name="method">The blending method to be used.</param>
        /// <returns>An image representing the source image blended by the supplied color with the supplied method.</returns>
        public abstract ImageType Blend(Color color, ImageBlendMethod method);

        /// <summary>
        ///     Crops the image to the specified area.
        /// </summary>
        /// <param name="area">The area to crop this image to.</param>
        /// <returns>An image representing the source image cropped to the supplied area.</returns>
        public abstract ImageType Crop(Rectangle area);
    }
}