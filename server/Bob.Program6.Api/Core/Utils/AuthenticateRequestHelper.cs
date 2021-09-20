using Bob.Program6.Api.Core.Model;
using System.Text.RegularExpressions;

namespace Bob.Program6.Api.Core.Utils
{
    public static class AuthenticateRequestHelper
    {
        public readonly static string Error = "Name/Password should only contain letters, numbers and spaces (min 3 max 15).";
        public static bool IsValid(this AuthenticateRequest val)
        {
            return IsTextOk(val.Name) && IsTextOk(val.Password);
        }

        private static bool IsTextOk(string val) {
            if (!IsNotNull(val)) {
                return false;
            }
            if (!IsContentOk(val))
            {
                return false;
            }
            if (!IsSizeOk(val))
            {
                return false;
            }
            return  true;
        }

	    private static bool IsSizeOk(string str) {
		    return 3 <= str.Length && str.Length <= 15;
	    }

        private static bool IsNotNull(string str) {
	        return str != null;
        }

        private static bool IsContentOk(string str) {
            var isOk = new Regex("^[A-Za-z0-9 ]+$");
	        return isOk.IsMatch(str);
        }
    }
}
