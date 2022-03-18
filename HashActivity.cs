using com.fabioscagliola.Core.Data;
using System.Security.Cryptography;
using System.Text;

namespace com.fabioscagliola.Schedule
{
    /// <summary>
    /// An activity that computes the MD5 hash of a string 
    /// </summary>
    public class HashActivity : Activity<HashActivityParameters>
    {
        public override void Do(ref HashActivityParameters activityParameters)
        {
            MD5 md5 = MD5.Create();
            byte[] computedHash = md5.ComputeHash(Encoding.UTF8.GetBytes(activityParameters.InputString));
            activityParameters.Hash = computedHash.ToHexString();
        }

    }
}

