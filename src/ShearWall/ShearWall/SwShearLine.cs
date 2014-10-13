using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Exception = System.Exception;

namespace ShearWall
{
    class SwShearLine
    {
        #region private members

        private ObjectIdCollection _objectIdCollection;
        private ObjectId _entityObjectId;
        private string _guid;
        private string _parentGuid;
        private int _xVersion;

        private Point3d _base;
        private Point3d _end;
        private double _length;
        #endregion

        #region constructor
        public SwShearLine()
        {
            
        }
        #endregion

        #region properties
        #endregion

        #region methods
        public ErrorStatus CreateShearLineGroup()
        {
            if (_objectIdCollection == null || _objectIdCollection.Count == 0)
            {
                return ErrorStatus.NullIterator;
            }


            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    acTrans.Commit();
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception aex)
            {
                return aex.ErrorStatus;
            }
        }
        #endregion
    }
}
