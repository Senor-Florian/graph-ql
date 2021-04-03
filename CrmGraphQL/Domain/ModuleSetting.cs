using System;

namespace CrmGraphQL.Domain
{
    public class ModuleSetting
    {
        public Guid Id { get; set; }
        public bool ShowProjectInternalId { get; set; }
        public bool CanSalesRepresentativeEditProjectExternalId { get; set; }
    }
}
