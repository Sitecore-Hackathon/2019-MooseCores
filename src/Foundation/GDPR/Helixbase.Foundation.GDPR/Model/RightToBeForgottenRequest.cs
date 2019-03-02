using System;

namespace Helixbase.Foundation.RightToBeForgotten.Model
{
    public class ForgetRequest
    {
        public Guid ContactID { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
