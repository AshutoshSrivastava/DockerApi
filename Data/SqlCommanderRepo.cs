using System;
using System.Collections.Generic;
using System.Linq;
using DockerApi.Models;

namespace DockerApi.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommandContext _context;

        public SqlCommanderRepo(CommandContext context)
        {
            _context = context;
        }

        public Commands CreateCommand(Commands cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
            return cmd;
        }

        public IEnumerable<Commands> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Commands GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


        public void DeleteCommand(Commands cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Remove(cmd);
        }

        // void UpdateCommand(Commands cmd)
        // {
        //     if(cmd == null)
        //     {
        //         throw new ArgumentNullException(nameof(cmd));
        //     }
        //     _context.Commands.Update(cmd);
        // }

        void ICommanderRepo.UpdateCommands(Commands cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Update(cmd);
        }
    }
}