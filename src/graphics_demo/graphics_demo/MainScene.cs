﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace graphics_demo
{
    public class MainScene : Scene
    {
        List<ShearPanel> entities = new List<ShearPanel>();
        Dictionary<string, RectangleShape> shapes = new Dictionary<string, RectangleShape>();

        bool reset = false;

        public MainScene(ShearWallDemo demoObject)
            : base(demoObject)
        {

        }

        public override void Initialize()
        {
            this.RegisterEntity(ShearPanel.PanelType.NormalWall, new Vector2f(0, 0), new Vector2f(200f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.NormalWall, new Vector2f(200f, 0), new Vector2f(400f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.NormalWall, new Vector2f(400f, 0), new Vector2f(600f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.NormalWall, new Vector2f(600f, 0), new Vector2f(800.0f, 0), new RectangleShape());
            base.Initialize();
        }

        public override void Reset()
        {
            foreach (ShearPanel e in entities)
            {
                e.ResetToStartingPosition();
            }            
        }

        public override void HandleInput(SFML.Window.KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                this._demoObject.Window.Close();
            base.HandleInput(e);
        }

        public override void HandleMouseMoved(MouseMoveEventArgs e)
        {
            base.HandleMouseMoved(e);
        }

        public override void HandleMouseButtonPressed(MouseButtonEventArgs e)
        {
            base.HandleMouseButtonPressed(e);
        }

        public override void HandleMouseButtonReleased(MouseButtonEventArgs e)
        {
            base.HandleMouseButtonReleased(e);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            foreach (ShearPanel e in entities)
            {
                shapes[e.Name].Draw(_demoObject.Window, RenderStates.Default);
            }
        }


        // Private methods
        private void RegisterEntity(ShearPanel.PanelType panelType, Vector2f start, Vector2f end, RectangleShape shape)
        {
            ShearPanel e = new ShearPanel(panelType, start, end);
            entities.Add(e);
            shapes.Add(e.Name, shape);
            UpdateRectangleShapeFromEntity(e);
        }

        private void UpdateRectangleShapeFromEntity(ShearPanel e)
        {
            RectangleShape shape = shapes[e.Name];

            shape.Size = new Vector2f(e.Length, 100.0f);
            shape.Position = e.Start;
            switch(e.Type)
            {
                case ShearPanel.PanelType.NormalWall:
                    shape.FillColor = new Color(Color.White);
                    break;
                case ShearPanel.PanelType.DoorWall:
                    shape.FillColor = new Color(Color.Green);
                    break;
                case ShearPanel.PanelType.WindowWall:
                    shape.FillColor = new Color(Color.Blue);
                    break;
                case ShearPanel.PanelType.ShearWall:
                    shape.FillColor = new Color(Color.Red);
                    break;
            }            
        }


        
    }
}