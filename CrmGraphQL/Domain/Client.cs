using System;
using System.Collections.Generic;

namespace CrmGraphQL.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public User SalesRepresentative { get; set; }
        public Guid? SalesRepresentativeId { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
