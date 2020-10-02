using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.IO;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            while (true)
            {
                var command = this.reader.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var cmdArgs = command.Split(' ', '<', '>')
                    .ToArray();

                var soldierType = cmdArgs[0];
                var id = int.Parse(cmdArgs[1]);
                var firstName = cmdArgs[2];
                var lastName = cmdArgs[3];

                ISoldier currentSoldier = null;

                if (soldierType == "Private")
                {
                    var salary = decimal.Parse(cmdArgs[4]);

                    currentSoldier = AddPrivate(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    currentSoldier = AddLieutenantGeneral(cmdArgs, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    var salary = decimal.Parse(cmdArgs[4]);
                    var corps = cmdArgs[5];

                    try
                    {
                        var engineer = AddEngineer(id, firstName, lastName, salary, corps, cmdArgs);
                        currentSoldier = engineer;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    var salary = decimal.Parse(cmdArgs[4]);
                    var corps = cmdArgs[5];

                    try
                    {
                        var commando = AddCommando(id, firstName, lastName, salary, corps, cmdArgs);

                        currentSoldier = commando;
                    }
                    catch (InvalidCorpsException ime)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    currentSoldier = AddSpy(cmdArgs, id, firstName, lastName);
                }

                if (currentSoldier != null)
                {
                    this.soldiers.Add(currentSoldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier AddSpy(string[] cmdArgs, int id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(cmdArgs[4]);
            var currentSoldier = new Spy(id, firstName, lastName, codeNumber);
            return currentSoldier;
        }

        private static Commando AddCommando(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArgs)
        {
            var commando = new Commando(id, firstName, lastName, salary, corps);
            var missionArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    var codeName = missionArgs[i];
                    var missionState = missionArgs[i + 1];

                    var mission = new Mission(codeName, missionState);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateException ime)
                {
                    continue;
                }
            }

            return commando;
        }

        private static Engineer AddEngineer(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArgs)
        {
            var engineer = new Engineer(id, firstName, lastName, salary, corps);
            var repairArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                var partName = repairArgs[i];
                var hours = int.Parse(repairArgs[i + 1]);

                var repair = new Repair(partName, hours);

                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ISoldier AddLieutenantGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            var currentSalary = decimal.Parse(cmdArgs[4]);
            var general = new LieutenantGeneral(id, firstName, lastName, currentSalary);

            foreach (var pid in cmdArgs.Skip(5))
            {
                var soldierToAdd =
                    this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(soldierToAdd);
            }

            return general;
        }

        private static Private AddPrivate(int id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }
    }
}
