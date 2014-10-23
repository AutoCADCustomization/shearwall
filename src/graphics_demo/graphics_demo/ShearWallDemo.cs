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
            _window.SetMouseCursorVisible(false);

            // Set up event handlers
            _window.Closed += _window_Closed;
            _window.KeyPressed += _window_KeyPressed;
            _window.MouseMoved += _window_MouseMoved;
            _window.MouseButtonPressed += _window_MouseButtonPressed;
            _window.MouseButtonReleased += _window_MouseButtonReleased;
        }

        private void Initialize()
        {
            ResourceManager.Instance.LoadTextureFromFile("cursor", @"resources\cursor.png");
            ResourceManager.Instance.LoadTextureFromFile("dragcursor", @"resources\dragcursor.png");
        }

        public void Run()
        {
            this.Initialize();
            MainScene m = new MainScene(this);
            m.Name = "main";            
            SceneManager.Instance.AddScene(m);            
            SceneManager.Instance.GotoScene("main");
        }

        void _window_KeyPressed(object sender, KeyEventArgs e)
        {
            SceneManager.Instance.CurrentScene.HandleInput(e);
        }

        void _window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

        void _window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            SceneManager.Instance.CurrentScene.HandleMouseMoved(e);
        }

        void _window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            SceneManager.Instance.CurrentScene.HandleMouseButtonPressed(e);
        }

        void _window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            SceneManager.Instance.CurrentScene.HandleMouseButtonReleased(e);
        }
    }
}
