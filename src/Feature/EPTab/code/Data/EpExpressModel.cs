using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Feature.EPTab.Data.Interface;

namespace Sitecore.Feature.EPTab.Data
{
    public abstract class EpExpressModel : IEpExpressModel
    {
        public abstract string RenderToString(Guid contactId);
        public abstract string Heading { get; }
        public virtual bool UseDefaultWrapper => true;
        public abstract string TabLabel { get; }
    }
}