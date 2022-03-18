namespace com.fabioscagliola.Schedule
{
    /// <summary>
    /// The parameters of an activity that computes a Fibonacci number 
    /// </summary>
    public class FiboActivityParameters : ActivityParameters
    {
        /// <summary>
        /// The position of the Fibonacci number in the sequence 
        /// </summary>
        public uint Position { get; set; }

        /// <summary>
        /// The Fibonacci number 
        /// </summary>
        public uint Number { get; set; }

    }
}

