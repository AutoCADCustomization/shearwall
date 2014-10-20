using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace graphics_demo
{
    class ShearPanel : Drawable
    {
        public enum PanelType
        {
            NormalWall,
            ShearWall,
            DoorWall,
            WindowWall,
        }

        public ShearPanel()
        {
            _type = PanelType.NormalWall;
        }

        public ShearPanel(PanelType type, Vector2f start, Vector2f end)
        {
            _type = type;
            _base = start;
            _end = end;
        }

        private Vector2f _base;
        private Vector2f _end;
        private double _length;
        private PanelType _type;
        private Color _color;

        protected Vector2f Base
        {
            get { return _base; }
            set { _base = value; }
        }

        protected Vector2f End
        {
            get { return _end; }
            set { _end = value; }
        }

        protected double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        protected PanelType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public void Draw (RenderTarget target, RenderStates states)
        {
            
        }
    
    }
}
