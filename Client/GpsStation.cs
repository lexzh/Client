using System;

namespace Client
{
    [Serializable]
    public class GpsStation
    {
        private int _id;

        private string _regiondot;

        private string _regionname;

        private int? _regiontype = new int?(0);

        private DateTime? _updatetime = new DateTime?(DateTime.Now);

        private int? _stationtype = new int?(0);

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string RegionDot
        {
            get
            {
                return this._regiondot;
            }
            set
            {
                this._regiondot = value;
            }
        }

        public string RegionName
        {
            get
            {
                return this._regionname;
            }
            set
            {
                this._regionname = value;
            }
        }

        public int? RegionType
        {
            get
            {
                return this._regiontype;
            }
            set
            {
                this._regiontype = value;
            }
        }

        public int? StationType
        {
            get
            {
                return this._stationtype;
            }
            set
            {
                this._stationtype = value;
            }
        }

        public DateTime? UpdateTime
        {
            get
            {
                return this._updatetime;
            }
            set
            {
                this._updatetime = value;
            }
        }

        public GpsStation()
        {
        }
    }
}