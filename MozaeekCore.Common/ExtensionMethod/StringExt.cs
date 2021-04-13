namespace MozaeekCore.Common.ExtensionMethod
{
    public static class StringExt
    {
        public static bool IsNullOrEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Recheck(this string str)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Contains("ك"))
            {
                str = str.Replace("ك", "ک");
            }
            if (str.Contains("ي"))
            {
                str = str.Replace("ي", "ی");
            }
            if (str.Contains("ة"))
            {
                str = str.Replace("ة", "ه");
            }

            str = str.Trim().TrimEnd();
            
            return str;
        }
    }
}