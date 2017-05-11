using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Exception for case when schedule type not supported by timer implementation.
    /// </summary>
    [Serializable]
    public class ScheduleNotSupportedException : Exception
    {
        public ScheduleNotSupportedException() { }
        public ScheduleNotSupportedException(string message) : base(message) { }
        public ScheduleNotSupportedException(string message, Exception inner) : base(message, inner) { }
        protected ScheduleNotSupportedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }

    /// <summary>
    /// Determines the schedule type.
    /// </summary>
    [Flags]
    public enum SchedulePeriodType
    {
        /// <summary>
        /// The one shot schedule.
        /// </summary>
        OneShot = 1,

        /// <summary>
        /// The hour period.
        /// </summary>
        Hour = 2,

        /// <summary>
        /// The day period.
        /// </summary>
        Day = 4,

        /// <summary>
        /// The weekday period
        /// </summary>
        Weekday = 8,

        /// <summary>
        /// The week period.
        /// </summary>
        Week = 16,

        /// <summary>
        /// The month period.
        /// </summary>
        Month = 32,

        /// <summary>
        /// The year period.
        /// </summary>
        Year = 64
    }

    /// <summary>
    /// Determines whether specified schedule connected with particular time or not.
    /// </summary>
    public enum ScheduleTimeType
    {
        /// <summary>
        /// The schedule has start and end time.
        /// </summary>
        Timed,

        /// <summary>
        /// The schedule started at the midnight of specified day and ends at the midnight of the next day.
        /// </summary>
        WholeDayLong
    }

    /// <summary>
    /// Schedule for <see cref="ITimer"/>Timer</see> interface.
    /// </summary>
    public class TimerSchedule
    {
        /// <summary>
        /// Gets or sets the type of the schedule.
        /// </summary>
        /// <value>
        /// The type of the schedule.
        /// </value>
        public SchedulePeriodType ScheduleType { get; set; }

        /// <summary>
        /// Gets or sets the name of the schedule.
        /// </summary>
        /// <value>
        /// The name of the schedule.
        /// </value>
        public string ScheduleName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TimerSchedule"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TimerSchedule"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        //TODO: Write schedule logic for different cases.
    }
}
