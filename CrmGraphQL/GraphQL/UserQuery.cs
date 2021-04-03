using CrmGraphQL.Domain;
using GraphQL.Types;

namespace CrmGraphQL.GraphQL
{
    public class UserQuery : ObjectGraphType
    {
        private readonly IUserRepository _userRepo;

        public UserQuery(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public FieldType GetUsers()
        {
            return FieldAsync<ListGraphType<UserType>>("users",
                resolve: async _ =>
                {
                    return await _userRepo.ListAsync();
                });
        }
    }
}
