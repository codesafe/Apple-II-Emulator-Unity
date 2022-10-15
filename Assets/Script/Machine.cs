using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    [SerializeField] RawImage screen;

    public Memory mem = new Memory();
    public Device device = new Device();
    public Cpu cpu = new Cpu();

    bool appstarted = false;

    void Start()
    {
        mem.Reset();
        mem.SetDevice(device);
        device.Reset();
        device.InsetFloppy();

        mem.WriteByte(0x3F4, 0);
        cpu.Reset(mem);

        mem.WriteByte(0x4D, 0xAA);   // Joust crashes if this memory location equals zero
        mem.WriteByte(0xD0, 0xAA);   // Planetoids won't work if this memory location equals zero

        device.Create(cpu, mem);
        screen.texture = device.display.mainTexture;

        Booting();

        appstarted = true;
    }

    void LoadRom()
    {
        Array.Copy(Rom.appleIIrom, mem.rom, 12288);
        Array.Copy(Rom.diskII, mem.sl6, 256);

        device.InsertFloppy("DOS3.3", 0);
        //device.InsertFloppy("LodeRunner", 0);
        
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

            int c = 100000;
            cpu.Run(mem, ref c);
        }
    }

    int frame = 0;
    void RefreshDisplay()
    {
        device.Render(frame);

        if (frame++ > Define.TARGET_FRAME)
            frame = 0;
    }

    void Update()
    {
        if( appstarted )
            RefreshDisplay();
    }

    void FixedUpdate()
    {
        if (appstarted)
        {
            int p = 17050;
            Run(ref p);
        }
    }
}
