using Remoting;
using ParamLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Client;

namespace Client
{
    public class GpsStationDAL
    {
        public GpsStationDAL()
        {
        }

        public int Add(GpsStation model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("insert into GpsStation(");
            stringBuilder.Append("RegionDot,RegionName,RegionType,StationType)");
            stringBuilder.Append(" values (");
            stringBuilder.Append("@RegionDot,@RegionName,@RegionType,@StationType)");
            stringBuilder.Append(";select @@IDENTITY");
            string str = stringBuilder.ToString();
            List<SqlParam> sqlParams = new List<SqlParam>();
            SqlParam sqlParam = new SqlParam()
            {
                name = "RegionDot",
                @value = model.RegionDot
            };
            sqlParams.Add(sqlParam);
            SqlParam sqlParam1 = new SqlParam()
            {
                name = "RegionName",
                @value = model.RegionName
            };
            sqlParams.Add(sqlParam1);
            SqlParam sqlParam2 = new SqlParam()
            {
                name = "RegionType",
                @value = model.RegionType
            };
            sqlParams.Add(sqlParam2);
            SqlParam sqlParam3 = new SqlParam()
            {
                name = "StationType",
                @value = model.StationType
            };
            sqlParams.Add(sqlParam3);
            DataTable dataTable = RemotingClient.ExecParamSqlByCompress(str, sqlParams);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public GpsStation DataRowToModel(DataRow row)
        {
            GpsStation gpsStation = new GpsStation();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    gpsStation.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RegionDot"] != null)
                {
                    gpsStation.RegionDot = row["RegionDot"].ToString();
                }
                if (row["RegionName"] != null)
                {
                    gpsStation.RegionName = row["RegionName"].ToString();
                }
                if (row["RegionType"] != null && row["RegionType"].ToString() != "")
                {
                    gpsStation.RegionType = new int?(int.Parse(row["RegionType"].ToString()));
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    gpsStation.UpdateTime = new DateTime?(DateTime.Parse(row["UpdateTime"].ToString()));
                }
                if (row["StationType"] != null && row["StationType"].ToString() != "")
                {
                    gpsStation.StationType = new int?(int.Parse(row["StationType"].ToString()));
                }
            }
            return gpsStation;
        }

        public bool Delete(int ID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("delete from GpsStation ");
            stringBuilder.Append(" where ID=@ID");
            string str = stringBuilder.ToString();
            List<SqlParam> sqlParams = new List<SqlParam>();
            SqlParam sqlParam = new SqlParam()
            {
                name = "ID",
                @value = ID
            };
            sqlParams.Add(sqlParam);
            if (RemotingClient.ExecParamNoQuery(str, sqlParams).ResultCode == (long)0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteList(string IDlist)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("delete from GpsStation ");
            stringBuilder.Append(string.Concat(" where ID in (", IDlist, ")  "));
            if (RemotingClient.ExecNoQuery(stringBuilder.ToString()).ResultCode == (long)0)
            {
                return true;
            }
            return false;
        }

        public bool Exists(int ID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select count(1) from GpsStation");
            stringBuilder.Append(string.Concat(" where ID=", ID));
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Exists(string strwhere)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from GpsStation");
            stringBuilder.Append(string.Concat(" where ", strwhere));
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool Exists(GpsStation model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from GpsStation");
            if (model.ID == 0)
            {
                stringBuilder.Append(string.Concat(" where RegionDot like '", model.RegionDot, "'"));
                stringBuilder.Append(string.Concat(" and RegionName='", model.RegionName, "'"));
                stringBuilder.Append(string.Concat(" and RegionType='", model.RegionType, "'"));
                stringBuilder.Append(string.Concat(" and StationType='", model.StationType, "'"));
            }
            else
            {
                int d = model.ID;
                stringBuilder.Append(string.Concat(" where ID=", model.ID));
                stringBuilder.Append(string.Concat(" and RegionDot like '", model.RegionDot, "'"));
                stringBuilder.Append(string.Concat(" and RegionName='", model.RegionName, "'"));
                stringBuilder.Append(string.Concat(" and RegionType='", model.RegionType, "'"));
                stringBuilder.Append(string.Concat(" and StationType='", model.StationType, "'"));
            }
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable GetList(string strWhere, string orderby)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ID,RegionDot,RegionName,RegionType,UpdateTime,StationType ");
            stringBuilder.Append(" FROM GpsStation ");
            if (strWhere.Trim() != "")
            {
                stringBuilder.Append(string.Concat(" where ", strWhere));
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                stringBuilder.Append(string.Concat(" order by ", orderby));
            }
            return RemotingClient.ExecSql(stringBuilder.ToString());
        }

        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ");
            if (Top > 0)
            {
                stringBuilder.Append(string.Concat(" top ", Top.ToString()));
            }
            stringBuilder.Append(" ID,RegionDot,RegionName,RegionType,UpdateTime,StationType ");
            stringBuilder.Append(" FROM GpsStation ");
            if (strWhere.Trim() != "")
            {
                stringBuilder.Append(string.Concat(" where ", strWhere));
            }
            if (!string.IsNullOrEmpty(filedOrder))
            {
                stringBuilder.Append(string.Concat(" order by ", filedOrder));
            }
            return RemotingClient.ExecSql(stringBuilder.ToString());
        }

        public GpsStation GetModel(int ID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select  top 1 ID,RegionDot,RegionName,RegionType,UpdateTime,StationType from GpsStation ");
            stringBuilder.Append(string.Concat(" where ID=", ID));
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }
            return this.DataRowToModel(dataTable.Rows[0]);
        }

        public GpsStation GetModel(string codition)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select  top 1 ID,RegionDot,RegionName,RegionType,UpdateTime,StationType from GpsStation ");
            stringBuilder.Append(string.Concat(" where ", codition));
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                return null;
            }
            return this.DataRowToModel(dataTable.Rows[0]);
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select count(1) FROM GpsStation ");
            if (strWhere.Trim() != "")
            {
                stringBuilder.Append(string.Concat(" where ", strWhere));
            }
            DataTable dataTable = RemotingClient.ExecSql(stringBuilder.ToString());
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                return 0;
            }
            return Convert.ToInt32(dataTable.Rows[0][0]);
        }

        public bool Update(GpsStation model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("update GpsStation set ");
            stringBuilder.Append("RegionDot=@RegionDot,");
            stringBuilder.Append("RegionName=@RegionName,");
            stringBuilder.Append("RegionType=@RegionType,");
            stringBuilder.Append("UpdateTime=@UpdateTime,");
            stringBuilder.Append("StationType=@StationType");
            stringBuilder.Append(" where ID=@ID");
            string str = stringBuilder.ToString();
            List<SqlParam> sqlParams = new List<SqlParam>();
            SqlParam sqlParam = new SqlParam()
            {
                name = "RegionDot",
                @value = model.RegionDot
            };
            sqlParams.Add(sqlParam);
            SqlParam sqlParam1 = new SqlParam()
            {
                name = "RegionName",
                @value = model.RegionName
            };
            sqlParams.Add(sqlParam1);
            SqlParam sqlParam2 = new SqlParam()
            {
                name = "RegionType",
                @value = model.RegionType
            };
            sqlParams.Add(sqlParam2);
            SqlParam sqlParam3 = new SqlParam()
            {
                name = "UpdateTime",
                @value = model.UpdateTime
            };
            sqlParams.Add(sqlParam3);
            SqlParam sqlParam4 = new SqlParam()
            {
                name = "StationType",
                @value = model.StationType
            };
            sqlParams.Add(sqlParam4);
            SqlParam sqlParam5 = new SqlParam()
            {
                name = "ID",
                @value = model.ID
            };
            sqlParams.Add(sqlParam5);
            if (RemotingClient.ExecParamNoQuery(str, sqlParams).ResultCode == (long)0)
            {
                return true;
            }
            return false;
        }
    }
}