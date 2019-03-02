using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.EPTab.Handlers
{
    public class EpExpressTabRenderer
    {
        public static string Render()
        {
            string contactId = System.Web.HttpContext.Current.Request.QueryString["cid"];
            string tabIdentifier = Sitecore.Context.Item["Placeholder Name"].Substring(3);
            var tab = EpContext.Tabs[tabIdentifier];
            if (tab.UseDefaultWrapper)
                return string.Format(Constants.DefaultWrapperPrefix, tab.Heading) + tab.RenderToString(Guid.Parse(contactId)) + Constants.DefaultWrapperSuffix;
            return tab.RenderToString(Guid.Parse(contactId));
        }
    }
}