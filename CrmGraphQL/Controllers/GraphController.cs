using CrmGraphQL.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmGraphQL.Controllers
{
    [Produces("application/json")]
    [Route("graphql")]
    public class GraphController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;

        public GraphController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] QueryDTO dto)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = dto.query;
                //_.Inputs = query.Variables?.ToInputs();

            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
}
