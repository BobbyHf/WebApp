using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BHIP.Model;

namespace BHIP.Model
{
    public static class ContextPerRequest
    {
        public static TrustEntities CurrentUser
        {
            get
            {
                if (!HttpContext.Current.Items.Contains("myContext"))
                {
                    HttpContext.Current.Items.Add("myContext", new TrustEntities());
                }
                return HttpContext.Current.Items["myContext"] as TrustEntities;
            }
        }


        public static BHIPEntities CurrentData
        {
            get
            {
                if (!HttpContext.Current.Items.Contains("myShellContext"))
                {
                    HttpContext.Current.Items.Add("myShellContext", new BHIPEntities());
                }
                return HttpContext.Current.Items["myShellContext"] as BHIPEntities;
            }
        }
    }
}
