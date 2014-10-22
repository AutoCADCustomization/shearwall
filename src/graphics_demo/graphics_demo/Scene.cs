using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace graphics_demo
{
    public class Scene
    {
        public string Name;
        protected ShearWallDemo _demoObject;

        private DateTime currentTime = System.DateTime.Now;
        private DateTime targetTime = System.DateTime.Now ;        

        public Scene(ShearWallDemo demoObject)
        {
            _demoObject = demoObject;
        }

        public virtual void Initialize()
        {
            // called when scene object is created
        }

        public virtual void Reset()
        {
            // called when scene object is reset
        }

        public void Run()
        {
            // main loop for the scene
            Stopwatch timer = Stopwatch.StartNew();
            TimeSpan dt = TimeSpan.FromSeconds(3);
            TimeSpan elapsedTime = TimeSpan.Zero;

            timer.Reset();
            elapsedTime = timer.Elapsed;

            while (_demoObject.Window.IsOpen())
            {
                currentTime = System.DateTime.Now;
                if (elapsedTime >= dt)
                {
                    _demoObject.Window.Clear(Color.Black);
                    this.DrawBackground();
                    this.Update();                    
                    this.Draw();
                    _demoObject.Window.Display();
                    this.AfterDraw();

                    timer.Reset();
                    elapsedTime = timer.Elapsed;
                }
                else
                {
                    _demoObject.Window.DispatchEvents();
                    elapsedTime += TimeSpan.FromSeconds(1.0 / 1000.0); //dt
                }
            }
        }

        public virtual void HandleInput(KeyEventArgs e)
        {
            // input handler for the scene
        }

        public virtual void HandleMouseMoved(MouseMoveEventArgs e)
        {
        }

        public virtual void HandleMouseButtonPressed(MouseButtonEventArgs e)
        { 
        }

        public virtual void HandleMouseButtonReleased(MouseButtonEventArgs e)
        {
        }

        public virtual void DrawBackground()
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            
        }

        public virtual void AfterDraw()
        {

        }
        
    }
}
