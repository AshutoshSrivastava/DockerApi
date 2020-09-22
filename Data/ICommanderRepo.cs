using System.Collections.Generic;
using DockerApi.Models;

namespace DockerApi.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Commands> GetAllCommands();
        Commands GetCommandById(int id);
        Commands CreateCommand(Commands cmd);
        void UpdateCommands(Commands cmd);
        void DeleteCommand(Commands cmd);
    }
}