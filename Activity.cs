namespace com.fabioscagliola.Schedule
{
    public abstract class Activity
    {
        public int Period { get; set; }

    }

    public abstract class Activity<T> : Activity where T : ActivityParameters
    {
        public abstract void Do(ref T activityParameters);

    }
}

