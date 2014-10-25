using System;
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

        protected Sprite spCursor;
        protected Sprite spDragCursor;
        
        private ShearPanel.MouseOverType mouseOverType = ShearPanel.MouseOverType.PointerOverType;
        private bool draggingStart = false;
        private bool draggingStop = true;
        private Vector2f startDragPosition = new Vector2f();

        private bool isSelected = false;

        public MainScene(ShearWallDemo demoObject)
            : base(demoObject)
        {

        }

        public override void Initialize()
        {
            Texture texture = ResourceManager.Instance.GetTexture("cursor");
            spCursor = new Sprite(texture);
            texture = ResourceManager.Instance.GetTexture("dragcursor");
            spDragCursor = new Sprite(texture);
            spDragCursor.Origin = new Vector2f(12,0);
            this.RegisterEntity(ShearPanel.PanelType.NormalWall, new Vector2f(0, 0), new Vector2f(200f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.ShearWall, new Vector2f(200f, 0), new Vector2f(400f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.DoorWall, new Vector2f(400f, 0), new Vector2f(600f, 0), new RectangleShape());
            this.RegisterEntity(ShearPanel.PanelType.WindowWall, new Vector2f(600f, 0), new Vector2f(800.0f, 0), new RectangleShape());
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

        public override void HandleMouseButtonPressed(MouseButtonEventArgs e)
        {
            /*
            Vector2f pos = new Vector2f(Mouse.GetPosition(_demoObject.Window).X, Mouse.GetPosition(_demoObject.Window).Y);
            if ((e.Button == Mouse.Button.Left) && (CheckMouseOverType(pos) == ShearPanel.MouseOverType.DragOverType))
            {
                draggingStart = true;
                draggingStop = false;
                startDragPosition = pos;
            }
             */
            base.HandleMouseButtonPressed(e);
        }

        public override void HandleMouseButtonReleased(MouseButtonEventArgs e)
        {
            ShearPanel currentEntity = null;

            foreach (ShearPanel entity in entities)
            {
                entity.IsSelected = false;
            }
            foreach (ShearPanel entity in entities)
            {
                FloatRect rect = shapes[entity.Name].GetGlobalBounds();
                if (rect.Contains(e.X, e.Y))
                {
                    entity.IsSelected = true;
                    break;
                }
            }
            base.HandleMouseButtonReleased(e);
        }

        public override void HandleMouseMoved(MouseMoveEventArgs e)
        {
            /*
            if ((draggingStart == true) && (draggingStop == false))
            {
                Vector2f currentMouse = new Vector2f(e.X, e.Y);
                Vector2f deltaMouse = currentMouse - startDragPosition;
            }
             * */
            base.HandleMouseMoved(e);
        }

        public override void Update()
        {
            foreach(ShearPanel e in entities)
            {
                UpdateRectangleShapeFromEntity(e);
            }
            base.Update();
        }

        public override void Draw()
        {
            foreach (ShearPanel e in entities)
            {
                shapes[e.Name].Draw(_demoObject.Window, RenderStates.Default);
            }

            Vector2f pos = new Vector2f(Mouse.GetPosition(_demoObject.Window).X, Mouse.GetPosition(_demoObject.Window).Y);

            spDragCursor.Position = pos;
            spDragCursor.Draw(_demoObject.Window, RenderStates.Default);
            
            /*
            if ((draggingStart == true) && (draggingStop == false))
            {
                spDragCursor.Position = pos;
                spDragCursor.Draw(_demoObject.Window, RenderStates.Default);
            } else if ((draggingStart == false) && (draggingStop == true))
            {
                mouseOverType = CheckMouseOverType(pos);
                switch (mouseOverType)
                {
                    case ShearPanel.MouseOverType.PointerOverType:
                        spCursor.Position = pos;
                        spCursor.Draw(_demoObject.Window, RenderStates.Default);
                        break;
                    case ShearPanel.MouseOverType.DragOverType:
                        spDragCursor.Position = pos;
                        spDragCursor.Draw(_demoObject.Window, RenderStates.Default);
                        break;
                }
            }
             */
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
            shape.OutlineColor = new Color(Color.Black);
            shape.OutlineThickness = 1.0f;
            switch(e.Type)
            {
                case ShearPanel.PanelType.NormalWall:
                    shape.FillColor = new Color(Color.Yellow);
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
            if (e.IsSelected == true)
                shape.FillColor = new Color(Color.White);
        }

        private ShearPanel.MouseOverType CheckMouseOverType(Vector2f position)
        {
            ShearPanel currentEntity = null;
            
            foreach (ShearPanel e in entities)
            {
                FloatRect rect = shapes[e.Name].GetGlobalBounds();
                if (rect.Contains(position.X, position.Y))
                {
                    currentEntity = e;
                    break;
                }
            }
            if (currentEntity != null)
            {
                FloatRect rect = shapes[currentEntity.Name].GetGlobalBounds();
                if (Math.Abs(rect.Left - (position.X - 2)) <= 2.0)
                {
                    return ShearPanel.MouseOverType.DragOverType;
                }
            }
            return ShearPanel.MouseOverType.PointerOverType;
        }
    }
}
