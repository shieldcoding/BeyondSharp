// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageOperation.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The server stores changes to images as operations to be executed by the client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Graphics
{
    using System.Drawing;

    using Newtonsoft.Json;

    /// <summary>
    /// The server stores changes to images as operations to be executed by the client.
    /// </summary>
    /// <typeparam name="TImageType">
    /// The server or client image.
    /// </typeparam>
    public abstract class ImageOperation<TImageType>
        where TImageType : Image<TImageType>
    {
        #region Enums

        /// <summary>
        /// The image operation type.
        /// </summary>
        public enum ImageOperationType
        {
            /// <summary>
            /// The image blend.
            /// </summary>
            ImageBlend, 

            /// <summary>
            /// The color blend.
            /// </summary>
            ColorBlend, 

            /// <summary>
            /// The crop.
            /// </summary>
            Crop
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the operation type.
        /// </summary>
        [JsonProperty]
        public ImageOperationType OperationType { get; private set; }

        #endregion

        /// <summary>
        /// The color blend operation.
        /// </summary>
        public class ColorBlendOperation : ImageOperation<TImageType>
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ColorBlendOperation"/> class.
            /// </summary>
            /// <param name="color">
            /// The color.
            /// </param>
            /// <param name="method">
            /// The method.
            /// </param>
            public ColorBlendOperation(Color color, ImageBlendMethod method)
            {
                this.OperationType = ImageOperationType.ColorBlend;
                this.Color = color;
                this.Method = method;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the color.
            /// </summary>
            [JsonProperty]
            public Color Color { get; private set; }

            /// <summary>
            /// Gets the method.
            /// </summary>
            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }

            #endregion
        }

        /// <summary>
        /// The crop operation.
        /// </summary>
        public class CropOperation : ImageOperation<TImageType>
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="CropOperation"/> class.
            /// </summary>
            /// <param name="area">
            /// The area.
            /// </param>
            public CropOperation(Rectangle area)
            {
                this.OperationType = ImageOperationType.Crop;
                this.Area = area;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the area.
            /// </summary>
            [JsonProperty]
            public Rectangle Area { get; private set; }

            #endregion
        }

        /// <summary>
        /// The image blend operation.
        /// </summary>
        public class ImageBlendOperation : ImageOperation<TImageType>
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ImageBlendOperation"/> class.
            /// </summary>
            /// <param name="image">
            /// The image.
            /// </param>
            /// <param name="method">
            /// The method.
            /// </param>
            public ImageBlendOperation(TImageType image, ImageBlendMethod method)
            {
                this.OperationType = ImageOperationType.ImageBlend;
                this.Image = image;
                this.Method = method;
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets the image.
            /// </summary>
            [JsonProperty]
            public TImageType Image { get; private set; }

            /// <summary>
            /// Gets the method.
            /// </summary>
            [JsonProperty]
            public ImageBlendMethod Method { get; private set; }

            #endregion
        }
    }
}