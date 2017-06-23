using System;

namespace ProcessRunner
{
    public class SetupProcessViewModel : BaseViewModel
    {
        public DateTime Start { get; protected set; }

        public DateTime End { get; protected set; }

        public virtual void ChangeStart(DateTime start)
        {
            Start = start;
            RaisePropertyChanged(nameof(Start));
        }

        public virtual void ChangeEnd(DateTime end)
        {
            End = end;
            RaisePropertyChanged(nameof(End));
        }

        public static SetupProcessViewModel Default()
        {
            var now = DateTime.Now;

            return new SetupProcessViewModel
            {
                Start = now,
                End = now.AddHours(1)
            };
        }
    }
}
