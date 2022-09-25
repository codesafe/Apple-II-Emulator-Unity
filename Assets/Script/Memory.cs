using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory
{
    // LC -> Language Card
    public bool LCWritable;
    public bool LCReadable;
    public bool LCBank2Enable;         // bank 2 enabled
    public bool LCPreWriteFlipflop;    // pre-write flip flop

    public byte[] ram = new byte[Define.RAMSIZE];  // 48K of ram $000-$BFFF
    public byte[] rom = new byte[Define.ROMSIZE];  // 12K of rom $D000-$FFFF
    public byte[] lgc = new byte[Define.LGCSIZE];  // Language Card 12K in $D000-$FFFF
    public byte[] bk2 = new byte[Define.BK2SIZE];  // bank 2 of Language Card 4K in $D000-$DFFF
    public byte[] sl6 = new byte[Define.SL6SIZE];  // P5A disk ][ PROM in slot 6

    public Memory()
    {
        Reset();
    }

    public void Reset()
    {
        LCWritable = true;
        LCReadable = false;
        LCBank2Enable = true;
        LCPreWriteFlipflop = false;

        Array.Clear(ram, 0, Define.RAMSIZE);
        Array.Clear(rom, 0, Define.ROMSIZE);
        Array.Clear(lgc, 0, Define.LGCSIZE);
        Array.Clear(bk2, 0, Define.BK2SIZE);
        Array.Clear(sl6, 0, Define.SL6SIZE);
    }

    public void ResetRam()
    {
        Array.Clear(ram, 0, Define.RAMSIZE);
    }

    public byte ReadByte(ushort address)
    {
        // RAM
        if (address < Define.RAMSIZE)
            return ram[address];

        if (address >= Define.ROMSTART)
        {
            // ROM
            if (!LCReadable)
                return rom[address - Define.ROMSTART];

            // BK2
            if (LCBank2Enable && (address < 0xE000))
                return bk2[address - Define.BK2START];

            // LC
            return lgc[address - Define.LGCSTART];
        }

        if ((address & 0xFF00) == Define.SL6START)
            return sl6[address - Define.SL6START];  // disk][

//         if ((address & 0xF000) == 0xC000)
//             return (device->SoftSwitch(this, address, 0, false));

        return 0;
    }

    public void WriteByte(int address, byte value)
    {
        if (address < Define.RAMSIZE)
        {
            ram[address] = value;
            return;
        }

        if (LCWritable && (address >= Define.ROMSTART))
        {
            if (LCBank2Enable && (address < 0xE000))
            {
                bk2[address - Define.BK2START] = value;                                          // BK2
                return;
            }
            lgc[address - Define.LGCSTART] = value;
            return;
        }

        if ((address & 0xF000) == 0xC000)
        {
//            device->SoftSwitch(this, address, value, true);
            return;
        }
    }

    public ushort ReadWord(ushort addr)
    {
        byte m0 = ReadByte(addr);
        byte m1 = ReadByte((ushort)(addr + 1));
        ushort w = (ushort)((m1 << 8) | m0);
        return w;
    }

    public void WriteWord(ushort value, int addr)
    {
        WriteByte(addr, (byte)(value >> 8));
        WriteByte(addr + 1, (byte)(value & 0xFF));
    }

}
