namespace CrmGraphQL.Persistence
{
    public class Repository
    {
        protected readonly CrmDbContext dbContext;

        public Repository(CrmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
