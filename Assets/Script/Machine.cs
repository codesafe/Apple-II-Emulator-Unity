using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    Memory mem = new Memory();
    Device device = new Device();
    Cpu cpu = new Cpu();

    void Start()
    {
        mem.Reset();
        device.InsetFloppy();

        mem.WriteByte(0x3F4, 0);
        cpu.Reset(mem);

        mem.WriteByte(0x4D, 0xAA);   // Joust crashes if this memory location equals zero
        mem.WriteByte(0xD0, 0xAA);   // Planetoids won't work if this memory location equals zero

        device.Create(cpu);
        Booting();
    }

    void LoadRom()
    {
        Array.Copy(Rom.appleIIrom, mem.rom, 12288);
        Array.Copy(Rom.diskII, mem.sl6, 256);
    }

    bool Booting()
    {
        LoadRom();
        cpu.Reset(mem);

        return true;
    }


    void Reset()
    {
        mem.Reset();
        cpu.Reboot(mem);
        device.Reset();

        // unset the Power-UP byte
        mem.WriteByte(0x3F4, 0);
        // dirty hack, fix soon... if I understand why
        mem.WriteByte(0x4D, 0xAA);   // Joust crashes if this memory location equals zero
        mem.WriteByte(0xD0, 0xAA);   // Planetoids won't work if this memory location equals zero

        Booting();
    }

    void Run(ref int cycle)
    {
        if (device.resetMachine)
        {
            Reset();
            return;
        }

        device.UpdateInput();
        cpu.Run(mem, ref cycle);

        while (true)
        {
            if (device.UpdateFloppyDisk() == false)
                break;

            int c = 10000;
            cpu.Run(mem, ref c);
        }
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        int p = 17050;
        Run(ref p);
    }
}
