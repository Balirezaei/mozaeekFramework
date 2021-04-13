using System;
using System.Linq;
using System.Text;
using System.Web;

namespace MozaeekCore.IntegrationTest.TestUtil
{
    public static class ExMethod
    {
        public static string ToQueryString(this object obj)
        {

            var properties = from p in obj.GetType().GetProperties()
                where p.GetValue(obj, null) != null
                select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }
    }
}