using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BeyondSharp.Client.Game
{
    public class GameManager : GameWindow
    {
        internal bool Initialize()
        {
            Width = ClientProgram.Configuration.Graphics.Width;
            Height = ClientProgram.Configuration.Graphics.Height;

            return true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            
            ClientProgram.Configuration.Graphics.Width = Width;
            ClientProgram.Configuration.Graphics.Height = Height;
            ClientProgram.Configuration.Graphics.VSync = VSync;

            switch(WindowState)
            {
                case WindowState.Fullscreen:
                    ClientProgram.Configuration.Graphics.Fullscreen = true;
                    break;
                default:
                    ClientProgram.Configuration.Graphics.Fullscreen = false;
                    break;
            }
        }
    }
}
