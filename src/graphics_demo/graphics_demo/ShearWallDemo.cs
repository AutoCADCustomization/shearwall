using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace graphics_demo
{
    class ShearWallDemo
    {
        public ShearWallDemo()
        {
            window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            player = new CircleShape();
            Init();
        }

        public void Init()
        {
            player.Radius = 40.0f;
            player.Position = new Vector2f(100.0f, 100.0f);
            player.FillColor = new Color(Color.Cyan);
            window.Closed += new EventHandler(this.OnClosed);
        }

        public void Run()
        {
            while (window.IsOpen())
            {
                ProcessEvents();
                Update();
                Render();
            }
        }

        private void ProcessEvents()
        {
            window.DispatchEvents();
        }

        private void Update()
        {
            
        }

        private void Render()
        {
            window.Clear(Color.White);
            window.Draw(player);
            window.Display();
        }

        private RenderWindow window;
        private CircleShape player;
        private bool isMovingUp;
        private bool isMovingDown;
        private bool isMovingLeft;
        private bool isMovingRight;


        protected virtual void OnClosed(Object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        protected void handlePlayerInput(Keyboard.Key key, bool isPressed)
        {
            if (key == Keyboard.Key.W)
                isMovingUp = isPressed;
            else if (key == Keyboard.Key.S)
                isMovingDown = isPressed;
            else if (key == Keyboard.Key.A)
                isMovingLeft = isPressed;
            else if (key == Keyboard.Key.D)
                isMovingRight = isPressed;
        }


    }
}
