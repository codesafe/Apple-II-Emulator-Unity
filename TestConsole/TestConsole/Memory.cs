using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class Memory
{
    public byte[] memory = new byte[1024 * 64];

    public byte ReadByte(int addr)
	{
		return memory[addr];
	}

    public void WriteByte(int addr, byte value)
    {
        memory[addr] = value;
    }

    public ushort ReadWord(int addr)
    {
        byte m0 = memory[addr];
        byte m1 = memory[addr + 1];
        ushort w = (ushort)((m1 << 8) | m0);
        return w;
    }

    public void WriteWord(ushort value, int addr)
    {
        memory[addr] = (byte)(value >> 8);
        memory[addr + 1] = (byte)(value & 0xFF);
    }

//     ushort UpLoadProgram(byte* code, int codesize)
//     {
// 
//     }

    public void UpLoadProgram(int startPos, byte[] code, long codesize)
    {
        for (int i = 0; i < codesize; i++)
            memory[startPos + i] = code[i];
    }

}
