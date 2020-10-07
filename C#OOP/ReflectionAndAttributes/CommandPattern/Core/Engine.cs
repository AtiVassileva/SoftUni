using System;
using CommandPattern.Core.Contracts;
using CommandPattern.IO;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;
        private readonly IReader _reader;
        private readonly IWriter _writer;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this._commandInterpreter = commandInterpreter;
            _reader = new ConsoleReader();
            _writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                var cmdArgs = Console.ReadLine();

                try
                {
                    var result = _commandInterpreter.Read(cmdArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
