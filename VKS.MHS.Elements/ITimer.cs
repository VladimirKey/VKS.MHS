using System;
namespace VKS.MHS.Elements
{
	/// <summary>
	/// Generic interface of timers. This interface based
	/// on <see cref="ISensor&lt;TData&gt;"/> interface in case
	/// of external RTC circuits.
	/// </summary>
	public interface ITimer: ISensor<TimerData>
	{
		//TODO: Add schedule logic here.
	}
}
