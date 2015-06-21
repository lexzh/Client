using System;
namespace Client.Plugin
{
	public class GpsResponse
	{
		public string ErrorMsg
		{
			get;
			set;
		}
		public string OrderIDParam
		{
			get;
			set;
		}
		public long ResultCode
		{
			get;
			set;
		}
		public GpsResponse()
		{
		}
		public GpsResponse(long lResultCode)
		{
			this.ResultCode = lResultCode;
			if (!"0".Equals(this.ResultCode))
			{
				this.ErrorMsg = "操作失败！\r\n详情请查看日志。";
			}
		}
	}
}
