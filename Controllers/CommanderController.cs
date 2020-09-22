using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DockerApi.Data;
using DockerApi.Dto;
using DockerApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommanderController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICommanderRepo _repository;

        private readonly IMapper _mapper;

        public CommanderController(ILogger<WeatherForecastController> logger, ICommanderRepo repository,IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Commands>> GetAllCommands()
        {
            var commandsItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandsItems));
        }

        //Get api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<Commands> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            
            var commandsModel = _mapper.Map<Commands>(commandCreateDto);
            _repository.CreateCommand(commandsModel);
            _repository.SaveChanges();

            var commondReadDto = _mapper.Map<CommandReadDto>(commandsModel);

            //return Ok(commondReadDto);

            return CreatedAtRoute(nameof(GetCommandById),new {Id = commandsModel.Id}, commondReadDto );
        }

        //PUT api/Cpmmnds/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateCommand(int id,CommandUpdateDto cmd)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(cmd,commandModelFromRepo);
            
            _repository.UpdateCommands(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch,ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch,commandModelFromRepo);

            _repository.UpdateCommands(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
