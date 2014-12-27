namespace BeyondSharp.Client.Display
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using OpenTK;
    using OpenTK.Input;

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
