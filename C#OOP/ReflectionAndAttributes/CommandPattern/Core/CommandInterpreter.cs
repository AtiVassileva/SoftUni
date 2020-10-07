using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    /// <summary>
    /// Holds all the reflection we should do
    /// in order to execute the command
    /// </summary>
    
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";

        private const string InvalidCommandExceptionMessage
            = "Invalid command type!";

        /// <summary>
        /// Parses input and executes the correct command
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        
        public string Read(string args)
        {
            var tokens = args.
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var commandName = tokens[0] + CommandPostfix;
            var commandArguments = tokens.Skip(1).ToArray();

            // Get assembly in order to get types

            var assembly = Assembly.GetCallingAssembly();


            // Get concrete command type in order to produce
            // instance of concrete command

            var currentType = assembly.GetTypes()
                .FirstOrDefault
                    (t => t.Name.ToLower() == commandName.ToLower());

            if (currentType == null)
            {
                throw new ArgumentException(InvalidCommandExceptionMessage);
            }

            // Get concrete instance in order to invoke Execute()

            var commandInstance = (ICommand)
                Activator.CreateInstance(currentType);

            var result = commandInstance.Execute(commandArguments);

            return result;
        }
    }
}
