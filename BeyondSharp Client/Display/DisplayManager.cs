#region Usings

using System;
using OpenTK;

#endregion

namespace BeyondSharp.Client.Display
{
    public class DisplayManager : GameWindow
    {
        public void Initialize()
        {
            Width = ClientProgram.Configuration.Graphics.Width;
            Height = ClientProgram.Configuration.Graphics.Height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            ClientProgram.Configuration.Graphics.Width = Width;
            ClientProgram.Configuration.Graphics.Height = Height;
        }
    }
}