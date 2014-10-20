using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace graphics_demo
{
    static class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShearWallDemo demo = new ShearWallDemo();
            demo.Run();
        }
    }
}
