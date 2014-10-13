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
    class SwSubShearLine
    {
        #region private members
        private ObjectId _entityObjectId;
        private string _guid;
        private string _parentGuid;
        private int _xVersion;

        private Point3d _base;
        private Point3d _end;
        private double _length;
        #endregion




        #region public properties


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

        protected ObjectId EntityObjectId
        {
            get { return _entityObjectId; }
            set { _entityObjectId = value; }
        }

        protected string ParentGuid
        {
            get { return _parentGuid; }
            set { _parentGuid = value; }
        }

        protected Point3d Base
        {
            get { return _base; }
            set { _base = value; }
        }

        protected Point3d End
        {
            get { return _end; }
            set { _end = value; }
        }

        protected double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        #endregion

        #region constructor
        public SwSubShearLine()
        {
            this.ParentGuid = "";
            this.Guid = this.GenerateGUID();
            this.EntityObjectId = ObjectId.Null;
            this.XVersion = GlobalConstants.XDataVersion;
        }

        public SwSubShearLine(ObjectId entityObjectId) : this()
        {
            this.EntityObjectId = entityObjectId;
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

        public ErrorStatus PutXData(ObjectId entityObjectId)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            if (entityObjectId == ObjectId.Null)
            {
                return ErrorStatus.NullObjectId;
            }
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    Entity entity = acTrans.GetObject(entityObjectId, OpenMode.ForRead, false) as Entity;
                    if (entity.ObjectId.IsNull)
                    {
                        return ErrorStatus.NullObjectPointer;
                    }

                    RegAppTable regAppTable = (RegAppTable)acTrans.GetObject(acCurDb.RegAppTableId, OpenMode.ForRead);
                    if (!regAppTable.Has(GlobalConstants.XDataKeySubShearLine))
                    {
                        using (RegAppTableRecord regAppRecord = new RegAppTableRecord())
                        {
                            regAppRecord.Name = GlobalConstants.XDataKeySubShearLine;
                            regAppTable.UpgradeOpen();
                            regAppTable.Add(regAppRecord);
                            regAppTable.DowngradeOpen();
                            acTrans.AddNewlyCreatedDBObject(regAppRecord, true);
                        }
                    }

                    ResultBuffer resBuf = new ResultBuffer(
                        new TypedValue((int)DxfCode.ExtendedDataRegAppName, GlobalConstants.XDataKeySubShearLine),
                        new TypedValue((int)DxfCode.ExtendedDataAsciiString, Guid),
                        new TypedValue((int)DxfCode.ExtendedDataAsciiString, ParentGuid),
                        new TypedValue((int)DxfCode.ExtendedDataInteger32, XVersion)
                        );

                    entity.UpgradeOpen();
                    entity.XData = resBuf;
                    entity.DowngradeOpen();
                    acTrans.Commit();
                }

                return ErrorStatus.OK;
            }
            catch (Autodesk.AutoCAD.Runtime.Exception aex)
            {
                return aex.ErrorStatus;
            }
        }

        public ErrorStatus ReadXdata(ObjectId entityObjectId)
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            if (entityObjectId == ObjectId.Null)
            {
                return ErrorStatus.NullObjectId;
            }
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    Entity  entity = acTrans.GetObject(entityObjectId, OpenMode.ForRead, false) as Entity;
                    if (entity.ObjectId.IsNull)
                    {
                        return ErrorStatus.NullObjectPointer;
                    }

                    ResultBuffer resBuf = entity.GetXDataForApplication(GlobalConstants.XDataKeySubShearLine);
                    if (resBuf != null)
                    {
                        TypedValue[] xDataOut = resBuf.AsArray();
                        string key = "";
                        string guid = "";
                        string parentGuid = "";
                        int xversion = 0;
                        
                        
                        for (int i = 0; i < xDataOut.Length; i++)
                        {
                            TypedValue tv = xDataOut[i];
                            switch (i)
                            {
                                case 0:
                                    key = (string) tv.Value;
                                    break;
                                case 1:
                                    guid = (string) tv.Value;
                                    break;
                                case 2:
                                    parentGuid = (string) tv.Value;
                                    break;
                                case 3:
                                    xversion = (int) tv.Value;
                                    break;
                            }
                        }
                        this.Guid = guid;
                        this.ParentGuid = parentGuid;
                        this.XVersion = xversion;
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

        private string GenerateGUID()
        {
            this.Guid = System.Guid.NewGuid().ToString();
            return this.Guid;
        }
        
        private ErrorStatus GetGeometryData()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            if (this.EntityObjectId == ObjectId.Null)
            {
                return ErrorStatus.NullObjectId;
            }
            try
            {
                using (Transaction acTrans = acCurDb.TransactionManager.StartOpenCloseTransaction())
                {
                    Line  line = acTrans.GetObject(this.EntityObjectId, OpenMode.ForRead, false) as Line;
                    if (line.ObjectId.IsNull)
                    {
                        return ErrorStatus.NullObjectPointer;
                    }
                    this.Base = line.StartPoint;
                    this.End = line.EndPoint;
                    this.Length = this.Base.DistanceTo(this.End);

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
