using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.EPTab.Data.Interface
{
    public interface IEpExpressModel
    {
        bool UseDefaultWrapper { get; }
        string Heading { get; }
        string TabLabel { get; }
        string RenderToString(Guid contactId);
    }
}