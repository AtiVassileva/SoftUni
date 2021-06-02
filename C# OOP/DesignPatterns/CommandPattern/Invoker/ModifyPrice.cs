using System.Collections.Generic;
using CommandPattern.Contracts;

namespace CommandPattern.Invoker
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            this.commands = new List<ICommand>();
        }

        public void SetCommand(ICommand givenCommand) =>
            this.command = givenCommand;

        public void Invoke()
        {
            this.commands.Add(this.command);
            this.command.ExecuteAction();
        }
    }
}
