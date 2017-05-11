using System;
using System.Collections.Generic;

namespace VKS.MHS.Elements
{
    /// <summary>
    /// Event arguments for schedule state changed event.
    /// </summary>
    public class ScheduleStateChangedEventArgs: TimerStateChangedEventArgs
    {
        /// <summary>
        /// Gets or sets the schedule identifier that fired this event.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        public Guid ScheduleId { get; protected set; }

        /// <summary>
        /// Gets or sets the schedule that fired this event. 
        /// </summary>
        /// <value>
        /// The schedule that fired event.
        /// </value>
        public TimerSchedule Schedule { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating previous state of schedule.
        /// This value could differ from <see cref="PreviousTimerState"/> value in case when 
        /// schedules overlapping each other.
        /// </summary>
        /// <value>
        ///   <c>true</c> if previously schedule was on; otherwise, <c>false</c>.
        /// </value>
        public bool PreviousState { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating new state of schedule.
        /// This value could differ from <see cref="NewTimerState"/> value in case when 
        /// schedules overlapping each other.
        /// </summary>
        /// <value>
        ///   <c>true</c> if schedule will be active; otherwise, <c>false</c>.
        /// </value>
        public bool NewState { get; protected set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleStateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="AScheduleId">A fired schedule identifier.</param>
        /// <param name="ASchedule">A fired schedule.</param>
        /// <param name="APrevState">A previous state of schedule.</param>
        /// <param name="ANewState">A new state of schedule.</param>
        /// <param name="APrevTimerState">A previous timer state.</param>
        /// <param name="ANewTimerState">A new timer state.</param>
        /// <exception cref="ArgumentException">Thrown when Schedule Id is not specified.</exception>
        /// <exception cref="ArgumentNullException">Thrown when ASchedule is not specified.</exception>
        public ScheduleStateChangedEventArgs(Guid AScheduleId, TimerSchedule ASchedule, 
            bool APrevState, bool ANewState, TimerState APrevTimerState, TimerState ANewTimerState):
            base(APrevTimerState, ANewTimerState)
        {
            if (AScheduleId == Guid.Empty)
                throw new ArgumentException("Schedule Id is not specified.", nameof(AScheduleId));
            if (ASchedule == null)
                throw new ArgumentNullException(nameof(ASchedule));

            ScheduleId = AScheduleId;
            Schedule = ASchedule;
            PreviousState = APrevState;
            NewState = ANewState;
        }
    }

    /// <summary>
    /// Event arguments for timer state changed event.
    /// </summary>
    public class TimerStateChangedEventArgs: EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating previous timer state.
        /// This value could differ from <see cref="PreviousState"/> value in case when 
        /// schedules overlapping each other.
        /// </summary>
        public TimerState PreviousTimerState { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating new timer state.
        /// This value could differ from <see cref="NewState"/> value in case when 
        /// schedules overlapping each other.
        /// </summary>
        public TimerState NewTimerState { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerStateChangedEventArgs"/> class.
        /// </summary>
        /// <param name="APrevState">A previous timer state.</param>
        /// <param name="ANewState">A new timer state.</param>
        public TimerStateChangedEventArgs(TimerState APrevState, TimerState ANewState)
        {
            PreviousTimerState = APrevState;
            NewTimerState = ANewState;
        }
    }

    /// <summary>
    /// Determines possible timer operating states.
    /// </summary>
    public enum TimerState
    {

        /// <summary>
        /// The automatic mode, timer is "On": based on schedules.
        /// </summary>
        AutoOn,

        /// <summary>
        /// The automatic mode, timer is "Off": based on schedules.
        /// </summary>
        AutoOff,

        /// <summary>
        /// The timer is always "On": schedules are ignored.
        /// </summary>
        OverrideOn,

        /// <summary>
        /// The timer is always "Off": schedules are ignored.
        /// </summary>
        OverrideOff
    }

    /// <summary>
    /// Delegate for ScheduleStateChanged event for <see cref="ITimer"/> interface.
    /// </summary>
    /// <param name="ASender">A sender of event.</param>
    /// <param name="AEventArgs">The <see cref="TimerStateChangedEventArgs"/> instance containing the event data.</param>
    public delegate void ScheduleStateChangedEventDelegate(ITimer ASender, ScheduleStateChangedEventArgs AEventArgs);

    /// <summary>
    /// Delegate for TimerStateChanged event for <see cref="ITimer"/> interface.
    /// </summary>
    /// <param name="ASender">A sender of event.</param>
    /// <param name="AEventArgs">The <see cref="TimerStateChangedEventArgs"/> instance containing the event data.</param>
    public delegate void TimerStateChangedEventDelegate(ITimer ASender, TimerStateChangedEventArgs AEventArgs);


	/// <summary>
	/// Generic interface of timers. This interface based
	/// on <see cref="ISensor&lt;TData&gt;"/> interface in case
	/// of external RTC circuits.
	/// </summary>
	public interface ITimer: ISensor<TimerData>
	{
        /// <summary>
        /// Gets the schedule capabilities.
        /// </summary>
        /// <value>
        /// The schedule capabilities.
        /// </value>
        SchedulePeriodType ScheduleCapabilities { get; }
        
        /// <summary>
        /// Gets the existing schedules.
        /// </summary>
        /// <returns>A read-only dictionary with "id" -> "schedule" pairs for all existing schedules for timer.</returns>
        IReadOnlyDictionary<Guid, TimerSchedule> GetSchedules();

        /// <summary>
        /// Creates the schedule within timer.
        /// </summary>
        /// <param name="ASchedule">A schedule description to create.</param>
        /// <returns>The identifier of created schedule.</returns>
        /// <exception cref="ScheduleNotSupportedException">Thrown when specified schedule not 
        /// supported by timer.</exception>
        Guid CreateSchedule(TimerSchedule ASchedule);

        /// <summary>
        /// Reads the detailed schedule from timer storage.
        /// </summary>
        /// <param name="AScheduleId">A schedule identifier.</param>
        /// <returns>Detailed schedule instance.</returns>
        TimerSchedule ReadSchedule(Guid AScheduleId);

        /// <summary>
        /// Updates the schedule for timer.
        /// </summary>
        /// <param name="AScheduleId">A schedule identifier to update.</param>
        /// <param name="ANewSchedule">A new schedule.</param>
        void UpdateSchedule(Guid AScheduleId, TimerSchedule ANewSchedule);

        /// <summary>
        /// Toggles the schedule of timer.
        /// </summary>
        /// <param name="AScheduleId">A schedule identifier to toggle.</param>
        /// <returns>A new state of schedule.</returns>
        bool ToggleSchedule(Guid AScheduleId);

        /// <summary>
        /// Deletes the schedule.
        /// </summary>
        /// <param name="AScheduleId">A schedule identifier to delete.</param>
        void DeleteSchedule(Guid AScheduleId);

        /// <summary>
        /// Gets the state of the timer.
        /// </summary>
        /// <value>
        /// The state of the timer.
        /// </value>
        TimerState TimerState { get; }

        /// <summary>
        /// Enables the Override mode. Timer state will be changed to <c>OverrideOn</c> or <c>OverrideOff</c> states based on
        /// value of <paramref name="ATargetState"/> argument. To disable Override mode call <see cref="OverrideStateOff()"/>
        /// method.
        /// </summary>
        /// <param name="ATargetState">if set to <c>true</c> then timer will be activated against all schedules. If this 
        /// parameter set to <c>false</c> then timer will be deactivated against all schedules.</param>
        void OverrideStateOn(bool ATargetState);

        /// <summary>
        /// Disables the Override mode.
        /// </summary>
        void OverrideStateOff();

        /// <summary>
        /// Occurs when schedule state changed within timer. This event could be used for monitoring
        /// states of schedules within timer (i.e. for UI).
        /// </summary>
        /// <remarks>
        /// This event shouldn't be confused to <see cref="TimerStateChanged"/> event. The main
        /// difference is that this event ignores Override mode for timer (if supported): this event
        /// fired when schedule is activated or deactivated. The real state of timer passed within
        /// event arguments.
        /// </remarks>
        event ScheduleStateChangedEventDelegate ScheduleStateChanged;

        /// <summary>
        /// Occurs when timer state changed. This event should be used for monitoring timer state.
        /// </summary>
        /// <remarks>
        /// This event shouldn't be confused to <see cref="ScheduleStateChanged"/> event. The main
        /// difference is that this event respects Override mode for timer (if supported): this event
        /// fired when Override mode is enabled and won't fired unless Override mode is disabled disregarding
        /// all schedule activations.
        /// </remarks>
        event TimerStateChangedEventDelegate TimerStateChanged;

    }
}
