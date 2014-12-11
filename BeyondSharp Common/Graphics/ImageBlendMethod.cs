// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageBlendMethod.cs" company="ShieldCoding">
//   No licenses are currently available, owned by Richard Brown-Lang.
// </copyright>
// <summary>
//   The image blend method.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BeyondSharp.Common.Graphics
{
    /// <summary>
    /// The image blend method.
    /// </summary>
    public enum ImageBlendMethod
    {
        /// <summary>
        /// The add.
        /// </summary>
        Add, 

        /// <summary>
        /// The subtract.
        /// </summary>
        Subtract, 

        /// <summary>
        /// The multiply.
        /// </summary>
        Multiply, 

        /// <summary>
        /// The overlay.
        /// </summary>
        Overlay, 

        /// <summary>
        /// The underlay.
        /// </summary>
        Underlay, 

        /// <summary>
        /// The and.
        /// </summary>
        And, 

        /// <summary>
        /// The or.
        /// </summary>
        Or
    }
}