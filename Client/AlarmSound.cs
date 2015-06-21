namespace Client
{
    using PublicClass;
    using System;
    using System.Data;
    using System.IO;

    public class AlarmSound
    {
        private string _alarmSoundFilePath = "";
        private static AlarmSound _alarmTypeSoundObj;

        public static AlarmSound GetInstance()
        {
            if (_alarmTypeSoundObj == null)
            {
                _alarmTypeSoundObj = new AlarmSound();
            }
            return _alarmTypeSoundObj;
        }

        public bool IsCustomAlarmSound(DataTable m_dtCarAlermList)
        {
            if (!Variable.sCustomAlarmSound.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                this._alarmSoundFilePath = string.Empty;
                return false;
            }
            long result = 0L;
            if ((m_dtCarAlermList != null) && (m_dtCarAlermList.Rows.Count > 0))
            {
                foreach (DataRow row in m_dtCarAlermList.Rows)
                {
                    if (long.TryParse(row["Status"].ToString(), out result) && ((result & 2L) != 0L))
                    {
                        this._alarmSoundFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Sound\UrgencyAlarm.WAV");
                        if (File.Exists(this._alarmSoundFilePath))
                        {
                            return true;
                        }
                    }
                }
            }
            this._alarmSoundFilePath = "";
            return false;
        }

        public string AlarmSoundFilePath
        {
            get
            {
                return this._alarmSoundFilePath;
            }
        }
    }
}

