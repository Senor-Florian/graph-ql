using System;

namespace CrmGraphQL.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ClientId { get; set; }
    }
}
