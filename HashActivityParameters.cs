namespace com.fabioscagliola.Schedule
{
    /// <summary>
    /// The parameters of an activity that computes the MD5 hash of a string 
    /// </summary>
    public class HashActivityParameters : ActivityParameters
    {
        /// <summary>
        /// The iinput string 
        /// </summary>
        public string InputString { get; set; }

        /// <summary>
        /// The output MD5 hash 
        /// </summary>
        public string Hash { get; set; }

    }
}

