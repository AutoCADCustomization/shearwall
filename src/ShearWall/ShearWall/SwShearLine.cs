using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Exception = System.Exception;

namespace ShearWall
{
    class SwShearLine
    {
        #region private members
        private ObjectId _brObjectId;
        private ObjectId _btrObjectId;
        private string _name;
        private string _guid;
        private int _xVersion;
        private int _entityId;
        private string _blockId;
        private int _parentId;
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

        protected int EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }

        protected int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        protected string BlockId
        {
            get { return _blockId; }
            set { _blockId = value; }
        }

        #endregion

        #region constructor
        public SwShearLine()
        {
            
        }

        public SwShearLine(ObjectId brObjectId, OpenMode openMode, bool openErased)
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
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    BlockReference brObject = acTrans.GetObject(brObjectId, openMode, openErased) as BlockReference;
                    
                        

                    acTrans.Commit();
                }
                
                return ErrorStatus.OK;
            }
            catch (Autodesk.AutoCAD.Runtime.Exception aex)
            {
                return aex.ErrorStatus;
            }
            
        }

        public ErrorStatus ReadXdata(ObjectId brObjectId, OpenMode openMode, bool openErased)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            if (brObjectId == ObjectId.Null)
            {
                return ErrorStatus.NullObjectId;
            }
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    BlockReference brObject = acTrans.GetObject(brObjectId, openMode, openErased) as BlockReference;
                    if (brObjectId == null)
                    {
                        return ErrorStatus.NullObjectPointer;
                    }


                    acTrans.Commit();
                }

                return ErrorStatus.OK;
            }
            catch (Autodesk.AutoCAD.Runtime.Exception aex)
            {
                return aex.ErrorStatus;
            }

        }
        
        #endregion // methods
    }
}
