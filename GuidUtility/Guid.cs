using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GuidUtility
{
    public struct Guid
    {
        // ReSharper disable once ClassNeverInstantiated.Local
        private class NativeMethod
        {
            [DllImport("rpcrt4.dll", SetLastError = true)]
            public static extern int UuidCreateSequential(out System.Guid guid);
        }

        public static System.Guid SequentialGuid()
        {
            const int rpcSOk = 0;

            var result = NativeMethod.UuidCreateSequential(out var guid);

            return result == rpcSOk ? guid : System.Guid.NewGuid();
        }

        public static List<System.Guid> ToGuid(IEnumerable<string> @this)
        {
            var result = new List<System.Guid>();
            if (@this == null) return result;
            foreach (var item in @this)
            {
                if (System.Guid.TryParse(item, out var parsedGuid))
                {
                    result.Add(parsedGuid);
                }
            }

            return result;
        }

        public static System.Guid ToGuid(string @this)
        {
            return System.Guid.TryParse(@this, out var guid) ? guid : System.Guid.Empty;
        }
    }
}
