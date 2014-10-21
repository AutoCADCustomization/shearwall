using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace graphics_demo
{
    public class ShearWallDemo
    {
        private RenderWindow _window;
        public RenderWindow Window { get { return this._window; } }

        public ShearWallDemo()
        {
            _window = new RenderWindow(new VideoMode(1024, 768), "Shear Wall Demo!");
            _window.SetVisible(true);
            _window.SetVerticalSyncEnabled(true);

            // Set up event handlers
            _window.Closed += _window_Closed;
            _window.KeyPressed += _window_KeyPressed;
        }

        private void Initialize()
        {
        }

        public void Run()
        {
            // Build the startup menu scene
            StartScene s = new StartScene(this);
            s.Name = "start";
            s.BackgroundTexture = ResourceManager.Instance.GetTexture("start");
            SceneManager.Instance.AddScene(s);

            // Build the main game scene
            MainScene d = new MainScene(this);
            d.Name = "main";
            d.BackgroundTexture = ResourceManager.Instance.GetTexture("main");
            SceneManager.Instance.AddScene(d);

            // Start the game
            SceneManager.Instance.GotoScene("start");
        }


        private void Update()
        {
            
        }

        private void Render()
        {
            _window.Clear(Color.White);
            _window.Display();
        }





        void _window_KeyPressed(object sender, KeyEventArgs e)
        {
            SceneManager.Instance.CurrentScene.HandleInput(e);
        }

        void _window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

 


    }
}
