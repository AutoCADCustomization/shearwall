using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace graphics_demo
{
    class ShearPanel
    {
        public enum PanelType
        {
            NormalWall,
            ShearWall,
            DoorWall,
            WindowWall,
        }

        public enum MouseOverType
        {
            PointerOverType,
            DragOverType,
        }

        public ShearPanel()
        {
            _type = PanelType.NormalWall;
            _rect = new RectangleShape();
        }

        public ShearPanel(PanelType type, Vector2f start, Vector2f end)
        {
            _resetType = type;
            _resetStart = start;
            _resetEnd = end;

            _type = type;
            _start = start;
            _end = end;
            _rect = new RectangleShape();
            _isSelected = false;

            Name = Guid.NewGuid().ToString();
        }

        private Vector2f _start;
        private Vector2f _end;        
        private PanelType _type;        
        private RectangleShape _rect;

        private Vector2f _resetStart;
        private Vector2f _resetEnd;
        private PanelType _resetType;

        private bool _isSelected;

        public string Name;

        public Vector2f Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public Vector2f End
        {
            get { return _end; }
            set { _end = value; }
        }

        public float Length
        {
            get { return _end.X - _start.X; }            
        }

        public PanelType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public  bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        public void ResetToStartingPosition()
        {
            _type = _resetType;
            _start = _resetStart;
            _end = _resetEnd;
        }

    
    }
}
