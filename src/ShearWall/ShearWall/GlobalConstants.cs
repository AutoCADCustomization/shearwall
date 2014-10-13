using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShearWall
{
    public enum SubShearLineType
    {
        NormalWallLine = 1,
        ShearPanelLine = 2,
        DoorLine = 3,
        WindowLine = 4
    }

    public enum WallPanelType
    {
        NormalWall = 1,
        ShearPanel = 2,
        Door = 3,
        Window = 4
    }

    public static class GlobalConstants
    {
        public static string XDataKeySubShearLine
        {
            get { return "SW-SUBSHEARLINE"; }
        }

        public static string XDataKeyShearLine
        {
            get { return "SW-SHEARLINE"; }
        }

        public static string XDataKeyWallPanel
        {
            get { return "SW-WALLPANEL"; }
        }

        public static int XDataVersion
        {
            get { return 1; }
        }
    }
}
