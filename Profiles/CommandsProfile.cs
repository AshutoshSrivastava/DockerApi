using AutoMapper;
using DockerApi.Dto;
using DockerApi.Models;

namespace DockerApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source ->Target
            CreateMap<Commands,CommandReadDto>();
            CreateMap<CommandCreateDto,Commands>();
            CreateMap<CommandUpdateDto,Commands>();

            CreateMap<Commands,CommandUpdateDto>();
        }
    }
}