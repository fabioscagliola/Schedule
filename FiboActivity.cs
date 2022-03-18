namespace com.fabioscagliola.Schedule
{
    /// <summary>
    /// An activity that computes a Fibonacci number 
    /// </summary>
    class FiboActivity : Activity<FiboActivityParameters>
    {
        public override void Do(ref FiboActivityParameters activityParameters)
        {
            uint f(uint n) => n > 1 ? f(n - 1) + f(n - 2) : n;  // Please note the recursive lambda :P 
            activityParameters.Number = f(activityParameters.Position);
        }

    }
}

