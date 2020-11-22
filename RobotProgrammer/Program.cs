using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RobotProgrammer
{
    public class Program
    {
        public List<Instruction> Instructions { get; }
        public string Port { get; set; }
        public string Step { get; set; }
        public string Wheel { get; set; }
        public string Axle { get; set; }

        public Program()
        {
            Instructions = new List<Instruction>();
        }

        public void AddInstruction(Instruction.Type instructionType)
        {
            Instructions.Add(new Instruction(instructionType));
        }

        public void Clear()
        {
            Instructions.Clear();
        }

        public string GenerateCode()
        {
            string template = File.ReadAllText(@"./template.nxc");
            string body = "", separator = " ";
            foreach (Instruction instruction in Instructions)
            {
                body += separator + instruction.GetSnippet();
                separator = "\n ";
            }
            template = template.Replace("%BODY%", body);
            template = template.Replace("%PORT%", Port);
            template = template.Replace("%STEP%", Step);
            template = template.Replace("%WHEEL%", Wheel);
            template = template.Replace("%AXLE%", Axle);
            return template;
        }
    }
}
