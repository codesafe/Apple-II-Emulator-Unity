using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static public byte[] ram = new byte[1024 * 64];

//         static void UpLoadProgram(int startPos, byte[] code, long codesize)
//         {
//             for (int i = 0; i < codesize; i++)
//                 ram[startPos + i] = code[i];
//         }

        static void Main(string[] args)
        {
            Memory mem = new Memory();
            Cpu cpu = new Cpu();
            cpu.Reset();

            byte[] readData = null;
            long dataLength = 0;

            using (BinaryReader br = new BinaryReader(File.Open("../../6502_functional_test.bin", FileMode.Open)))
            {
                dataLength = br.BaseStream.Length;
                readData = new byte[br.BaseStream.Length];
                readData = br.ReadBytes((int)br.BaseStream.Length);

//                 for (int i = 0; i < readData.Length; i++)
//                     Console.WriteLine("readData{0}:{1:x2}", i, readData[i]);
            }

            long codesize = dataLength;
            mem.UpLoadProgram(0x0000, readData, codesize);

            cpu.PC = 0x400;
            long count = 0;
            int cycle = 1;
            while (true)
            {
                cpu.Run(mem, ref cycle);
                if (cpu.PC == 0x3469)
                    break;
                // 		if (count > 100000)
                // 			break;
                count++;
                cycle = 1;
            }

        }
    }
}
