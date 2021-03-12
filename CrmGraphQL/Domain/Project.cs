using System;

namespace CrmGraphQL.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User SalesRepresentative { get; set; }
        public Guid SalesRepresentativeId { get; set; }
        public Guid ClientId { get; set; }
        public string InternalId { get; set; }
        public string ExternalId { get; set; }
    }
}
