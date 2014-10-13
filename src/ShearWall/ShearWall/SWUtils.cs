using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace ShearWall
{
    class SwUtils
    {
    }

    public static class SwCoordSysUtils
    {
        public static ErrorStatus GetStartEndPoints(ObjectId objectId, ref Point3d start, ref Point3d end, Matrix3d mtx)
        {

        }

        public static ErrorStatus GetStartEndPoints(ObjectId objectId, ref Point3d start, ref Point3d end)
        {
            Matrix3d matrix = Matrix3d.Identity;
        }
    }
}
