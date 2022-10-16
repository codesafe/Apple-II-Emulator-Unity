using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Machine : MonoBehaviour
{
    [SerializeField] RawImage screen;
    [SerializeField] Transform fddIcon;

    [SerializeField] GameObject kbd;
    [SerializeField] GameObject joypad;
    [SerializeField] Joystick joystick;
    [SerializeField] BTN[] btn;

    public Memory mem = new Memory();
    public Device device = new Device();
    public Cpu cpu = new Cpu();

    bool appstarted = false;
    bool btn0 = false;
    bool btn1 = false;

    AudioClip _clip;
    AudioSource audiosource;

    int count = 0;
    int length;
    int sampling_rate;
    float[] temp_sample;

    void Start()
    {
        CreateSound();

        btn[0].SetMachine(this);
        btn[1].SetMachine(this);

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

    void CreateSound()
    {
        audiosource = GetComponent<AudioSource>();

//         AudioClip myClip = AudioClip.Create("Sound", samplerate, 1, samplerate, true, OnAudioRead, OnAudioSetPosition);
//         audiosource.clip = myClip;
//         audiosource.Play();


//         float fq = 440;
//         sampling_rate = 44100;
//         _clip = CreateClip(fq.ToString(), sampling_rate, fq);
// 
//         audiosource.clip = _clip;
//         //audiosource.loop = true;
//         audiosource.Play();

    }

    private AudioClip CreateClip(string clipName, int samplerate, float frequency)
    { 
        var clip = AudioClip.Create(clipName, samplerate, 1, samplerate, true);
        //(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, PCMReaderCallback pcmreadercallback);
        var size = clip.frequency * (int)Mathf.Ceil(clip.length);
        float[] data = new float[size];

        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * count / samplerate);
            count++;
        }

        clip.SetData(data, 0);
        return clip;
    }

    void LoadRom()
    {
        Array.Copy(Rom.appleIIrom, mem.rom, 12288);
        Array.Copy(Rom.diskII, mem.sl6, 256);

        //device.InsertFloppy("DOS3.3", 0);
        device.InsertFloppy("LodeRunner", 0);
        
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

        float x = joystick.Horizontal;
        float y = joystick.Vertical;

//         if( x != 0 || y != 0 )
//             Debug.Log($" XY : {x} / {y}");

        device.UpdateInput( x, y, btn0, btn1);

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

        //float rot = device.GetFddRot();
        //fddIcon.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        if( appstarted )
        {
            int p = 17050;
            Run(ref p);
            RefreshDisplay();
        }

    }

//     void FixedUpdate()
//     {
//         if (appstarted)
//         {
//             //int p = 17050;
//             int p = (1023000 / 60);	// 1.023MHz
//             Run(ref p);
//         }
//     }

    public void OnClickChangeKBD()
    {
        if( kbd.activeSelf )
        {
            kbd.SetActive(false);
            joypad.SetActive(true);
            //device.SetJoyPad(true);
        }
        else
        {
            kbd.SetActive(true);
            joypad.SetActive(false);
            //device.SetJoyPad(false);
        }
    }

    public void OnPushBtn(string p)
    {
        //Debug.Log($"Push : {p}");

        if( p == "0")
            btn0 = true;
        if (p == "1")
            btn1 = true;

    }

    public void OnReleaseBtn(string p)
    {
        //Debug.Log($"Release : {p}");

        if (p == "0")
            btn0 = false;
        if (p == "1")
            btn1 = false;
    }


    ///////////////////////////////////////////////////////////////////////////////// SOUND

    int position = 0;
    int samplerate = 44100;
    float frequency = 440;

    void OnAudioFilterRead(float[] data, int channels)
    {
        int count = 0;
        short[] b = device.GetSoundBuffer();
        while (count < data.Length)
        {
            //data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            data[count] = (float)(b[count] * frequency / samplerate);
            position++;
            count++;
        }
    }


/*
    void OnAudioRead(float[] data)
    {
        int count = 0;
        while (count < data.Length)
        {
            data[count] = Mathf.Sin(2 * Mathf.PI * frequency * position / samplerate);
            position++;
            count++;
        }
    }

    void OnAudioSetPosition(int newPosition)
    {
        position = newPosition;
    }
*/

}
