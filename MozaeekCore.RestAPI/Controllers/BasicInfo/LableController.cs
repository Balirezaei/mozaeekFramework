using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Core.ResponseMessages;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Controllers.BasicInfo
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly ILabelQueryFacade _labelQueryFacade;

        public LabelController(ICommandBus commandBus, ILabelQueryFacade labelQueryFacade)
        {
            this._commandBus = commandBus;
            _labelQueryFacade = labelQueryFacade;
        }


        [HttpGet("{id}")]
        public Task<LabelDto> GetById(long id)
        {
            return _labelQueryFacade.GetLabelById(id);
        }

        [HttpGet]
        public Task<PagedListResult<LabelGrid>> GetAllParent([FromQuery] LabelFilterContract pagingContract)
        {
            return _labelQueryFacade.GetAllParentLabels(pagingContract);
        }

        [HttpGet]
        public Task<PagedListResult<LabelGrid>> GetAllChildren(long id)
        {
            return _labelQueryFacade.GetAllLabelChildren(id);
        }

        [HttpGet("")]
        public Task<InitLabelDto> GetInitLabelDto()
        {
            return _labelQueryFacade.GetInitLabelDto();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLabelCommand command)
        {
            var commandResult = await _commandBus.DispatchAsync<CreateLabelCommand, CreateLabelCommandResult>(command);
            return CreatedAtAction(nameof(GetById), new { id = commandResult.Id }, commandResult.Id);
        }

        [HttpGet]
        public async Task<DeleteCommandResult> Delete(long id)
        {
            var commandResult = await _commandBus.DispatchAsync<DeleteLabelCommand, DeleteCommandResult>(new DeleteLabelCommand(id));
            return commandResult;
        }

        [HttpPost]
        public Task<UpdateLabelCommandResult> Update(UpdateLabelCommand cmd)
        {
            var commandResult = _commandBus.DispatchAsync<UpdateLabelCommand, UpdateLabelCommandResult>(cmd);
            return commandResult;
        }
    }
}
