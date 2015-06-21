using System;
namespace Client.Plugin
{
	public interface IPlugin
	{
		void Load(IClient client);
		void UnLoad();
	}
}
