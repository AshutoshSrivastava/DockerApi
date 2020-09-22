using System.Collections.Generic;
using DockerApi.Models;

namespace DockerApi.Data{
    public class MockCommanderRepo : ICommanderRepo
    {
        public Commands CreateCommand(Commands cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Commands cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Commands> GetAllCommands()
        {
            var Commands = new List<Commands>
            {
                 new Commands{Id=0,HowTo="Boil an egg",Line="Boil water",Platform="Kettle & Pan"},
                 new Commands{Id=1,HowTo="Cut a Bread",Line="Get a knife",Platform="Knife and Chopping Board"},
                 new Commands{Id=2,HowTo="Make a Tea",Line="Boil water and put tea leafs into it",Platform="Kettle"}
            };
            return Commands;

        }

        public Commands GetCommandById(int id)
        {
            return new Commands{Id=id,HowTo="Boil an egg",Line="Boil water",Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Commands UpdateCommand(Commands cmd)
        {
            //throw new System.NotImplementedException();
            return null;
        }

        void ICommanderRepo.UpdateCommands(Commands cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}