using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace ShearWall
{
    class SwWallPanel
    {
        #region private members

        private ObjectId _brObjectId;
        private ObjectId _btrObjectId;
        private string _name;
        private string _guid;
        private int _xVersion;

        #endregion

        #region public properties
        protected string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected string Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        protected int XVersion
        {
            get { return _xVersion; }
            set { _xVersion = value; }
        }

        protected ObjectId BrObjectId
        {
            get { return _brObjectId; }
            set { _brObjectId = value; }
        }

        protected ObjectId BtrObjectId
        {
            get { return _btrObjectId; }
            set { _btrObjectId = value; }
        }

        #endregion

        #region constructor
        public SwWallPanel()
        {
            
        }

        public SwWallPanel(ObjectId brObjectId, OpenMode openMode, bool openErased)
        {

        }

        #endregion

        #region methods
        public ErrorStatus OpenObject(ObjectId brObjectId, OpenMode openMode, bool openErased)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            if (brObjectId == ObjectId.Null)
            {
                return ErrorStatus.NullObjectId;
            }
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                BlockReference brObject = acTrans.GetObject(brObjectId, openMode, openErased) as BlockReference;
             
                  // Dispose of the transaction
              }
            return ErrorStatus.OK;
        }
        
        
        #endregion // methods
    }
}
