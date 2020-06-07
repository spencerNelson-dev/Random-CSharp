using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg.", Line = "Boil water", Platform = "Pot" },
                new Command { Id = 1, HowTo = "Cut Bread", Line = "Get a knife", Platform = "Knife" },
                new Command { Id = 2, HowTo = "Make cup of tea", Line = "Don't do it", Platform = "Cup" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg.", Line = "Boil water", Platform = "Pot" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
