using System;
using System.Collections;
using System.Collections.Generic;

// two disk ][ drive units
public class FloppyDrive
{
	// the full disk image pathname
	public byte[] filename = new byte[400];
	// based on the image file attributes
	public bool readOnly;
	// nibblelized disk image
	public byte[] data = new byte[232960];
	// motor status
	public bool motorOn;
	// writes to file are not implemented
	public bool writeMode;
	// current track position
	public byte track;
	// ptr to nibble under head position
	public ushort nibble;

    public void Reset()
    {
        Array.Clear(filename, 0, 400);
        readOnly = false;

        Array.Clear(data, 0, 232960);
        motorOn = false;
        writeMode = false;
        track = 0;
        nibble = 0;
    }
};


public class Screen
{
    public int[] buffer = new int[Define.SCREENSIZE_X * Define.SCREENSIZE_Y];

    // RGBA
    private int GetColor(byte r, byte g, byte b, byte a)
    {
        int color = r << 24 | g << 24 | b <<8 | a;
        return color;
    }

    public void ClearScreen()
    {
        for (int y = 0; y < Define.SCREENSIZE_Y; y++)
            for (int x = 0; x < Define.SCREENSIZE_X; x++)
            {
                buffer[y * Define.SCREENSIZE_X + x] = GetColor(30, 30, 30, 255 );
            }
    }
}

public class Device
{
    public Cpu cpu = null;

    // DISK
    FloppyDrive[] disk = new FloppyDrive[2];
    byte updatedrive;

    bool [,] phases = new bool[2,4];
	bool [,] phasesB = new bool[2, 4];
    bool [,] phasesBB = new bool[2, 4];
    int [] pIdx = new int[2];
    int [] pIdxB = new int[2];
    int [] halfTrackPos = new int[2];
    byte dLatch;
    int currentDrive;

    /////////////////////////////////////////////////////////

    public bool resetMachine;
    bool colorMonitor;
    byte zoomscale;

    byte keyboard;

    /////////////////////////////////////////////////////////

    bool silence;
    int volume;
    bool speaker;
    long speakerLastTick;

    /////////////////////////////////////////////////////////

    bool textMode;
    bool mixedMode;
    bool hires_Mode;
    byte videoPage;
    ushort videoAddress;

    //_RECT pixelGR;

    int [,] LoResCache = new int [24, 40];
	int [,] HiResCache = new int[192, 40];
	byte [,] previousBit = new byte[192, 40];
	byte flashCycle;

    /////////////////////////////////////////////////////////


    // 패들정보
    float [] GCP = new float[2];
    float [] GCC = new float[2];
	int [] GCD = new int[2];
	int [] GCA = new int[2];
	byte GCActionSpeed;
	byte GCReleaseSpeed;
    long GCCrigger;

	/////////////////////////////////////////////////////////

	public void InsetFloppy()
    {
        disk[0].Reset();
        disk[1].Reset();
    }

    public void Create(Cpu cpu)
    {
        //font.Create();
        zoomscale = 3;

        this.cpu = cpu;

    }


    public void Reset()
    {
//         loaddumpmachine = false;
//         dumpMachine = false;
//         loadromfile = false;

        resetMachine = false;
        colorMonitor = true;
        keyboard = 0;

        //pixelGR = { 0, 0, 7, 4 };

        silence = false;
        speaker = false;
        speakerLastTick = 0;

        // DISK ][
        updatedrive = 0;
        currentDrive = 0;
        // I/O register
        dLatch = 0;

        for(int i=0; i<2; i++)
            for (int j = 0; j < 2; j++)
            {
                phases[i, j] = false;
                phasesB[i, j] = false;
                phasesBB[i, j] = false;
            }

        pIdx[0] = pIdx[1] = 0;
        pIdxB[0] = pIdxB[1] = 0;
        halfTrackPos[0] = halfTrackPos[1] = 0;

        ////////////////////////////////////////////////////////////////////////// GAMEPAD

        // 패들 초기화
        GCP[0] = 127.0f;
        GCP[1] = 127.0f;
        GCC[0] = 0;
        GCC[1] = 0;
        GCD[0] = 0;
        GCD[1] = 0;
        GCA[0] = 0;
        GCA[1] = 0;
        GCActionSpeed = 64;
        GCReleaseSpeed = 64;

        ////////////////////////////////////////////////////////////////////////// VIDEO

        textMode = true;
        mixedMode = false;
        videoPage = 1;
        hires_Mode = false;

        //videoAddress = videoPage * 0x0400;
        for (int i = 0; i < 24; i++)
            for (int j = 0; j < 40; j++)
            {
                LoResCache[i, j] = 0;
            }

        for (int i = 0; i < 192; i++)
            for (int j = 0; j < 40; j++)
            {
                HiResCache[i, j] = 0;
                previousBit[i, j] = 0;
            }

        flashCycle = 0;
    }

    byte SoftSwitch(Memory mem, ushort address, byte value, bool WRT)
    {
		switch (address)
		{
			// KEYBOARD
			case 0xC000:
				return (keyboard);
			// KBDSTROBE
			case 0xC010:
				keyboard &= 0x7F;
				return (keyboard);

			// TAPEOUT??
			case 0xC020:
				break;

			///////////////////////////////////////////////////////////////////////////////// Speaker

			case 0xC030: // SPEAKER
			//case 0xC033: 
				PlaySound();
				break;

			///////////////////////////////////////////////////////////////////////////////// Graphics

			case 0xC050:
				textMode = false;
				//printf("Text Mode Off\n");
				break;
			// Text
			case 0xC051:
				textMode = true;
				//printf("Text Mode On\n");
				break;

			// Mixed off
			case 0xC052:
				mixedMode = false;
				//printf("Mixed Mode Off\n");
				break;

			// Mixed on
			case 0xC053:
				mixedMode = true;
				//printf("Mixed Mode On\n");
				break;

			// Page 1
			case 0xC054:
				videoPage = 1;
				//printf("Video Page 1\n");
				break;
			// Page 2
			case 0xC055:
				videoPage = 2;
				//printf("Video Page 2\n");
				break;

			// HiRes off
			case 0xC056:
				hires_Mode = false;
				//printf("HIRES Mode Off\n");
				break;
			// HiRes on
			case 0xC057:
				hires_Mode = true;
				//printf("HIRES Mode On\n");
				break;

			/////////////////////////////////////////////////////////////////////////////////	Joy Paddle ?

			/*
				https://apple2.org.za/gswv/a2zine/faqs/csa2pfaq.html

				These are actually the first two game Pushbutton inputs (PB0
				and PB1) which are borrowed by the Open Apple and Closed Apple
				keys. Bit 7 is set (=1) in these locations if the game switch or
				corresponding key is pressed.

				PB2 =      $C063 ;game Pushbutton 2 (read)
				This input has an option to be connected to the shift key on
				the keyboard. (See info on the 'shift key mod'.)

				PADDLE0 =  $C064 ;bit 7 = status of pdl-0 timer (read)
				PADDLE1 =  $C065 ;bit 7 = status of pdl-1 timer (read)
				PADDLE2 =  $C066 ;bit 7 = status of pdl-2 timer (read)
				PADDLE3 =  $C067 ;bit 7 = status of pdl-3 timer (read)
				PDLTRIG =  $C070 ;trigger paddles
				Read this to start paddle countdown, then time the period until
				$C064-$C067 bit 7 becomes set to determine the paddle position.
				This takes up to three milliseconds if the paddle is at its maximum
				extreme (reading of 255 via the standard firmware routine).

				SETIOUDIS= $C07E ;enable DHIRES & disable $C058-5F (W)
				CLRIOUDIS= $C07E ;disable DHIRES & enable $C058-5F (W)

			*/
			// Push Button 0
			case 0xC061:
				{
// 					if (gamepad.pressbtn2)
// 						return 0x80;
// 					else
						return 0;
				}
			// Push Button 1
			case 0xC062:
				{
// 					if (gamepad.pressbtn1)
// 						return 0x80;
// 					else
						return 0;
				}

			// 		// Push Button 2
			// 		case 0xC063: 
			// 			return 0;

			// Paddle 0
			case 0xC064:
				{
					byte v = readPaddle(0);
					return (v);
				}

			// Paddle 1
			case 0xC065:
				{
					byte v = readPaddle(1);
					return (v);
				}

			// paddle timer RST
			case 0xC070:
				resetPaddles();
				break;

			/////////////////////////////////////////////////////////////////////////////////	DISK 2

			case 0xC0E0:
			case 0xC0E1:
			case 0xC0E2:
			case 0xC0E3:
			case 0xC0E4:
			case 0xC0E5:
			case 0xC0E6:
			case 0xC0E7:
				stepMotor(address);
				break; // MOVE DRIVE HEAD

			// MOTOR OFF
			case 0xCFFF:
			case 0xC0E8:
				disk[currentDrive].motorOn = false;
				//printf("--> DISK MOTOR OFF\n");
				break;

			// MOTOR ON
			case 0xC0E9:
				disk[currentDrive].motorOn = true;
				//printf("--> DISK MOTOR ON\n");
				break;

			// DRIVE 0
			case 0xC0EA:
				setDrv(0);
				break;
			// DRIVE 1
			case 0xC0EB:
				setDrv(1);
				break;

			// Shift Data Latch
			case 0xC0EC:
				{
					// writting
					if (disk[currentDrive].writeMode)
						disk[currentDrive].data[disk[currentDrive].track * 0x1A00 + disk[currentDrive].nibble] = dLatch;
					else
					{
						// reading
						dLatch = disk[currentDrive].data[disk[currentDrive].track * 0x1A00 + disk[currentDrive].nibble];
					}
					// turn floppy of 1 nibble
					disk[currentDrive].nibble = (ushort)((disk[currentDrive].nibble + 1) % 0x1A00);
				}
				return (dLatch);

			// Load Data Latch
			case 0xC0ED:
				dLatch = value;
				break;

			// latch for READ
			case 0xC0EE:
				disk[currentDrive].writeMode = false;
				return (byte)(disk[currentDrive].readOnly ? 0x80 : 0);                                 // check protection

			// latch for WRITE
			case 0xC0EF:
				disk[currentDrive].writeMode = true;
				break;

			///////////////////////////////////////////////////////////////////////////////// LANGUAGE CARD

			case 0xC080:
			case 0xC084:
				mem.LCBank2Enable = true;
				mem.LCReadable = true;
				mem.LCWritable = false;
				mem.LCPreWriteFlipflop = false;
				break;       // LC2RD

			case 0xC081:
			case 0xC085:
				mem.LCBank2Enable = true;
				mem.LCReadable = false;
				mem.LCWritable |= mem.LCPreWriteFlipflop;
				mem.LCPreWriteFlipflop = !WRT;
				break;       // LC2WR

			case 0xC082:
			case 0xC086:
				mem.LCBank2Enable = true;
				mem.LCReadable = false;
				mem.LCWritable = false;
				mem.LCPreWriteFlipflop = false;
				break;       // ROMONLY2

			case 0xC083:
			case 0xC087:
				mem.LCBank2Enable = true;
				mem.LCReadable = true;
				mem.LCWritable |= mem.LCPreWriteFlipflop;
				mem.LCPreWriteFlipflop = !WRT;
				break;       // LC2RW

			case 0xC088:
			case 0xC08C:
				mem.LCBank2Enable = false;
				mem.LCReadable = true;
				mem.LCWritable = false;
				mem.LCPreWriteFlipflop = false;
				break;       // LC1RD

			case 0xC089:
			case 0xC08D:
				mem.LCBank2Enable = false;
				mem.LCReadable = false;
				mem.LCWritable |= mem.LCPreWriteFlipflop;
				mem.LCPreWriteFlipflop = !WRT;
				break;       // LC1WR

			case 0xC08A:
			case 0xC08E:
				mem.LCBank2Enable = false;
				mem.LCReadable = false;
				mem.LCWritable = false;
				mem.LCPreWriteFlipflop = false;
				break;       // ROMONLY1

			case 0xC08B:
			case 0xC08F:
				mem.LCBank2Enable = false;
				mem.LCReadable = true;
				mem.LCWritable |= mem.LCPreWriteFlipflop;
				mem.LCPreWriteFlipflop = !WRT;
				break;       // LC1RW
		}

		return (byte)(cpu.tick % 256);
	}

    void PlaySound()
    {
        if (!silence)
        {
            speaker = !speaker;
            // 1023000Hz / 96000Hz = 10.65625
//             unsigned int length = (unsigned int)((cpu->tick - speakerLastTick) / 10.65625f);
// 
//             speakerLastTick = cpu->tick;
//             if (length > AUDIOBUFFERSIZE)
//                 length = AUDIOBUFFERSIZE;
// 
//             SDL_QueueAudio(audioDevice, audioBuffer[speaker], length | 1);
        }
    }

	byte readPaddle(int pdl)
    {
		return 0;
    }

    void resetPaddles()
    {
        GCC[0] = GCP[0] * GCP[0];
        GCC[1] = GCP[1] * GCP[1];
        //GCCrigger = cpu->tick;
    }


	//////////////////////////////////////////////////////////////////////////////////////////////////////

	void stepMotor(ushort address)
    {
        address &= 7;
        int phase = address >> 1;

        phasesBB[currentDrive, pIdxB[currentDrive]] = phasesB[currentDrive, pIdxB[currentDrive]];
        phasesB[currentDrive, pIdx[currentDrive]] = phases[currentDrive, pIdx[currentDrive]];
        pIdxB[currentDrive] = pIdx[currentDrive];
        pIdx[currentDrive] = phase;

        if (!((address & 1) > 0))
        {                                                         // head not moving (PHASE x OFF)
            phases[currentDrive,phase] = false;
            return;
        }

        if ((phasesBB[currentDrive,(phase + 1) & 3]) && (--halfTrackPos[currentDrive] < 0))      // head is moving in
            halfTrackPos[currentDrive] = 0;

        if ((phasesBB[currentDrive,(phase - 1) & 3]) && (++halfTrackPos[currentDrive] > 140))    // head is moving out
            halfTrackPos[currentDrive] = 140;

        phases[currentDrive,phase] = true;                                                 // update track#
        disk[currentDrive].track = (byte)( (halfTrackPos[currentDrive] + 1) / 2 );
    }

    void setDrv(int drv)
    {
        disk[drv].motorOn = disk[drv == 0 ? 1 : 0].motorOn || disk[drv].motorOn;
        disk[drv == 0 ? 1 : 0].motorOn = false;
        currentDrive = drv;
    }

	/////////////////////////////////////////////////////////////////////////////////////////////////////////

	void UpdateKeyBoard()
	{
#if false
		int key = GetKeyPressed();
		bool shift = IsKeyDown(KEY_LEFT_SHIFT) || IsKeyDown(KEY_RIGHT_SHIFT);

		switch (key)
		{
			case KEY_A: keyboard = 0xC1; break;
			case KEY_B: keyboard = 0xC2; break;
			case KEY_C: keyboard = 0xC3; break;
			case KEY_D: keyboard = 0xC4; break;
			case KEY_E: keyboard = 0xC5; break;
			case KEY_F: keyboard = 0xC6; break;
			case KEY_G: keyboard = 0xC7; break;
			case KEY_H: keyboard = 0xC8; break;
			case KEY_I: keyboard = 0xC9; break;
			case KEY_J: keyboard = 0xCA; break;
			case KEY_K: keyboard = 0xCB; break;
			case KEY_L: keyboard = 0xCC; break;
			case KEY_M: keyboard = 0xCD; break;
			case KEY_N: keyboard = 0xCE; break;
			case KEY_O: keyboard = 0xCF; break;
			case KEY_P: keyboard = 0xD0; break;
			case KEY_Q: keyboard = 0xD1; break;
			case KEY_R: keyboard = 0xD2; break;
			case KEY_S: keyboard = 0xD3; break;
			case KEY_T: keyboard = 0xD4; break;
			case KEY_U: keyboard = 0xD5; break;
			case KEY_V: keyboard = 0xD6; break;
			case KEY_W: keyboard = 0xD7; break;
			case KEY_X: keyboard = 0xD8; break;
			case KEY_Y: keyboard = 0xD9; break;
			case KEY_Z: keyboard = 0xDA; break;

			case KEY_ZERO: keyboard = shift ? 0xA9 : 0xB0; break;             // 0 )
			case KEY_ONE: keyboard = shift ? 0xA1 : 0xB1; break;             // 1 !
			case KEY_TWO: keyboard = shift ? 0xC0 : 0xB2; break;             // 2 @
			case KEY_THREE: keyboard = shift ? 0xA3 : 0xB3; break;             // 3 #
			case KEY_FOUR: keyboard = shift ? 0xA4 : 0xB4; break;             // 4 $
			case KEY_FIVE: keyboard = shift ? 0xA5 : 0xB5; break;             // 5 %
			case KEY_SIX: keyboard = shift ? 0xDE : 0xB6; break;             // 6 ^
			case KEY_SEVEN: keyboard = shift ? 0xA6 : 0xB7; break;             // 7 &
			case KEY_EIGHT: keyboard = shift ? 0xAA : 0xB8; break;             // 8 *
			case KEY_NINE: keyboard = shift ? 0xA8 : 0xB9; break;             // 9 (


			case KEY_LEFT_BRACKET: keyboard = shift ? 0x9B : 0xDB; break;   // [ {
			case KEY_BACKSLASH: keyboard = shift ? 0x9C : 0xDC; break;   // \ |
			case KEY_RIGHT_BRACKET: keyboard = shift ? 0x9D : 0xDD; break;   // ] }

			case KEY_APOSTROPHE: keyboard = shift ? 0xA2 : 0xA7; break;   // ' "
			case KEY_COMMA: keyboard = shift ? 0xBC : 0xAC; break;   // , <
			case KEY_PERIOD: keyboard = shift ? 0xBE : 0xAE; break;   // . >

			case KEY_MINUS: keyboard = shift ? 0xDF : 0xAD; break;  // - _
			case KEY_SLASH: keyboard = shift ? 0xBF : 0xAF; break;  // / ?
			case KEY_SEMICOLON: keyboard = shift ? 0xBA : 0xBB; break;  // ; :
			case KEY_EQUAL: keyboard = shift ? 0xAB : 0xBD; break;  // = +

			case KEY_BACKSPACE: keyboard = 0x88; break;             // BS
			case KEY_LEFT: keyboard = 0x88; break;             // BS
			case KEY_RIGHT: keyboard = 0x95; break;             // NAK
			case KEY_SPACE: keyboard = 0xA0; break;
			case KEY_ESCAPE: keyboard = 0x9B; break;             // ESC
			case KEY_ENTER: keyboard = 0x8D; break;             // CR

			// RESET
			case KEY_F1:
				resetMachine = true;
				break;

			// COLOR <--> GREEM
			case KEY_F2:
				colorMonitor = !colorMonitor;
				break;

			// ZOOM
			case KEY_F3:
				zoomscale = zoomscale + 1 > 3 ? 1 : zoomscale + 1;
				break;

			// MUTE Speaker
			case KEY_F4:
				silence = !silence;
				break;

			case KEY_F9:
				loadromfile = true;
				break;

			case KEY_F10:
				dumpMachine = true;
				break;

			case KEY_F11:
				loaddumpmachine = true;
				break;

		}
#endif
		/*
		* 키보드로 게임패드 에뮬 (게임패드랑 같이 못함)
			if (IsKeyPressed(KEY_LEFT))
			{
				GCD[0] = -1; GCA[0] = 1;
				gamepad.axis[0] = true;
				//printf("left\n");
			}
			else if (IsKeyUp(KEY_LEFT) && gamepad.axis[0])
			{
				GCD[0] = 1;  GCA[0] = 0;
				gamepad.axis[0] = false;
			}

			if (IsKeyPressed(KEY_RIGHT))
			{
				GCD[0] = 1;  GCA[0] = 1;
				gamepad.axis[1] = true;
				//printf("right\n");
			}
			else if (IsKeyUp(KEY_RIGHT) && gamepad.axis[1])
			{
				GCD[0] = -1; GCA[0] = 0;
				gamepad.axis[1] = false;
			}


			if (IsKeyPressed(KEY_UP))
			{
				GCD[1] = -1; GCA[1] = 1;
				gamepad.axis[2] = true;
			}
			else if (IsKeyUp(KEY_UP) && gamepad.axis[2])
			{
				GCD[1] = 1;  GCA[1] = 0;
				gamepad.axis[2] = false;
			}

			if (IsKeyPressed(KEY_DOWN))
			{
				GCD[1] = 1; GCA[1] = 1;
				gamepad.axis[3] = true;
			}
			else if (IsKeyUp(KEY_DOWN) && gamepad.axis[3])
			{
				GCD[1] = -1; GCA[1] = 0;
				gamepad.axis[3] = false;
			}
		*/

	}

	public void UpdateInput()
    {
        UpdateKeyBoard();
        //UpdateGamepad();
    }

    // 플로피 디스크 업데이트
    public bool UpdateFloppyDisk()
    {
        // Floppy motor가 off이거나 updatedrive이 0이되면 끝
        if (disk[currentDrive].motorOn == false || updatedrive++ == 0)
            return false;
        else
            return true;
    }

}