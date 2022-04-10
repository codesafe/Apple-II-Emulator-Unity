using System.Collections;
using System.Collections.Generic;


static class Define
{


    public const ushort SCREENTEXT_X = 40;
    public const ushort SCREENTEXT_Y = 24;
    public const ushort SCREENSIZE_X = 280;
    public const ushort SCREENSIZE_Y = 192;

    public const ushort STACK_ADDRESS = 0x0100;


    ///////////////////////////////////////////////////////////////////////////////////////

    // Memory
    public const ushort RAMSIZE = 0xC000;
    public const ushort ROMSIZE = 0x3000;
    public const ushort ROMSTART = 0xD000;
    public const ushort SL6START = 0xC600;      // 
    public const ushort SL6SIZE = 0x0100;

    public const ushort LGCSTART = 0xD000;
    public const ushort LGCSIZE = 0x3000;
    public const ushort BK2START = 0xD000;
    public const ushort BK2SIZE = 0x1000;

    ///////////////////////////////////////////////////////////////////////////////////////

    // CPU

    public const byte FLAG_CARRY = 0b0000_0001;
    public const byte FLAG_ZERO = 0b0000_0010;
    public const byte FLAG_INTERRUPT_DISABLE = 0b0000_0100;
    public const byte FLAG_DECIMAL_MODE = 0b0000_1000;
    public const byte FLAG_BREAK = 0b0001_0000;
    public const byte FLAG_UNUSED = 0b0010_0000;
    public const byte FLAG_OVERFLOW = 0b0100_0000;
    public const byte FLAG_NEGATIVE = 0b1000_0000;

    // LDA (LoaD Accumulator)
    public const byte LDA_IM = 0xA9;
    public const byte LDA_ZP = 0xA5;
    public const byte LDA_ZPX = 0xB5;
    public const byte LDA_ABS = 0xAD;
    public const byte LDA_ABSX = 0xBD;
    public const byte LDA_ABSY = 0xB9;
    public const byte LDA_INDX = 0xA1;
    public const byte LDA_INDY = 0xB1;

    // LDX (LoaD X register)
    public const byte LDX_IM = 0xA2;
    public const byte LDX_ZP = 0xA6;
    public const byte LDX_ZPY = 0xB6;
    public const byte LDX_ABS = 0xAE;
    public const byte LDX_ABSY = 0xBE;

    // LDY (LoaD Y register)
    public const byte LDY_IM = 0xA0;
    public const byte LDY_ZP = 0xA4;
    public const byte LDY_ZPX = 0xB4;
    public const byte LDY_ABS = 0xAC;
    public const byte LDY_ABSX = 0xBC;

    // No Operation
    public const byte NOP = 0xEA;

    // JSR (Jump to Subroutine)
    public const byte JSR = 0x20;
    public const byte JMP_ABS = 0x4C;
    public const byte JMP_IND = 0x6C;
    // Return from Subroutine
    public const byte RTS = 0x60;


    // STA - Store Accumulator
    public const byte STA_ZP = 0x85;
    public const byte STA_ZPX = 0x95;
    public const byte STA_ABS = 0x8D;
    public const byte STA_ABSX = 0x9D;
    public const byte STA_ABSY = 0x99;
    public const byte STA_INDX = 0x81;
    public const byte STA_INDY = 0x91;

    // STX - Store X Register
    public const byte STX_ZP = 0x86;
    public const byte STX_ZPY = 0x96;
    public const byte STX_ABS = 0x8E;

    // STY - Store Y Register
    public const byte STY_ZP = 0x84;
    public const byte STY_ZPX = 0x94;
    public const byte STY_ABS = 0x8C;


    // Stack Operation
    public const byte TSX = 0xBA;       // Transfer Stack Pointer to X
    public const byte TXS = 0x9A;       // Transfer X to Stack Pointer
    public const byte PHA = 0X48;       // Push Accumulator
    public const byte PLA = 0x68;       // Pull Accumulator
    public const byte PLP = 0x28;       // Pull Processor Status
    public const byte PHP = 0x08;       // Pushes a copy of the status flags on to the stack.

    // Logical Operation
    public const byte AND_IM = 0x29;
    public const byte AND_ZP = 0x25;
    public const byte AND_ZPX = 0x35;
    public const byte AND_ABS = 0x2D;
    public const byte AND_ABSX = 0x3D;
    public const byte AND_ABSY = 0x39;
    public const byte AND_INDX = 0x21;
    public const byte AND_INDY = 0x31;

    public const byte ORA_IM = 0x09;
    public const byte ORA_ZP = 0x05;
    public const byte ORA_ZPX = 0x15;
    public const byte ORA_ABS = 0x0D;
    public const byte ORA_ABSX = 0x1D;
    public const byte ORA_ABSY = 0x19;
    public const byte ORA_INDX = 0x01;
    public const byte ORA_INDY = 0x11;

    public const byte EOR_IM = 0x49;
    public const byte EOR_ZP = 0x45;
    public const byte EOR_ZPX = 0x55;
    public const byte EOR_ABS = 0x4D;
    public const byte EOR_ABSX = 0x5D;
    public const byte EOR_ABSY = 0x59;
    public const byte EOR_INDX = 0x41;
    public const byte EOR_INDY = 0x51;

    // Bit Test
    public const byte BIT_ZP = 0x24;
    public const byte BIT_ABS = 0x2C;


    // Register Transfer
    public const byte TAX = 0xAA;
    public const byte TAY = 0xA8;
    public const byte TXA = 0x8A;
    public const byte TYA = 0x98;

    // increase / decrease
    public const byte INX = 0xE8;
    public const byte INY = 0xC8;
    public const byte DEX = 0xCA;
    public const byte DEY = 0x88;
    public const byte INC_ZP = 0xE6;
    public const byte INC_ZPX = 0xF6;
    public const byte INC_ABS = 0xEE;
    public const byte INC_ABSX = 0xFE;
    public const byte DEC_ZP = 0xC6;
    public const byte DEC_ZPX = 0xD6;
    public const byte DEC_ABS = 0xCE;
    public const byte DEC_ABSX = 0xDE;

    // Arithmetic
    public const byte ADC_IM = 0x69;
    public const byte ADC_ZP = 0x65;
    public const byte ADC_ZPX = 0x75;
    public const byte ADC_ABS = 0x6D;
    public const byte ADC_ABSX = 0x7D;
    public const byte ADC_ABSY = 0x79;
    public const byte ADC_INDX = 0x61;
    public const byte ADC_INDY = 0x71;

    public const byte SBC_IM = 0xE9;
    public const byte SBC_ZP = 0xE5;
    public const byte SBC_ZPX = 0xF5;
    public const byte SBC_ABS = 0xED;
    public const byte SBC_ABSX = 0xFD;
    public const byte SBC_ABSY = 0xF9;
    public const byte SBC_INDX = 0xE1;
    public const byte SBC_INDY = 0xF1;

    public const byte CMP_IM = 0xC9;
    public const byte CMP_ZP = 0xC5;
    public const byte CMP_ZPX = 0xD5;
    public const byte CMP_ABS = 0xCD;
    public const byte CMP_ABSX = 0xDD;
    public const byte CMP_ABSY = 0xD9;
    public const byte CMP_INDX = 0xC1;
    public const byte CMP_INDY = 0xD1;

    public const byte CPX_IM = 0xE0;
    public const byte CPX_ZP = 0xE4;
    public const byte CPX_ABS = 0xEC;

    public const byte CPY_IM = 0XC0;
    public const byte CPY_ZP = 0XC4;
    public const byte CPY_ABS = 0XCC;


    // Shifts
    public const byte ASL = 0x0A;
    public const byte ASL_ZP = 0x06;
    public const byte ASL_ZPX = 0x16;
    public const byte ASL_ABS = 0x0E;
    public const byte ASL_ABSX = 0x1E;

    public const byte LSR = 0x4A;
    public const byte LSR_ZP = 0x46;
    public const byte LSR_ZPX = 0x56;
    public const byte LSR_ABS = 0x4E;
    public const byte LSR_ABSX = 0x5E;

    public const byte ROL = 0x2A;
    public const byte ROL_ZP = 0x26;
    public const byte ROL_ZPX = 0x36;
    public const byte ROL_ABS = 0x2E;
    public const byte ROL_ABSX = 0x3E;

    public const byte ROR = 0x6A;
    public const byte ROR_ZP = 0x66;
    public const byte ROR_ZPX = 0x76;
    public const byte ROR_ABS = 0x6E;
    public const byte ROR_ABSX = 0x7E;

    // Force Interrupt
    public const byte BRK = 0x00;
    public const byte RTI = 0x40;

    // Branches
    public const byte BCC = 0x90;
    public const byte BCS = 0xB0;
    public const byte BEQ = 0xF0;
    public const byte BMI = 0x30;
    public const byte BNE = 0xD0;
    public const byte BPL = 0x10;
    public const byte BVC = 0x50;
    public const byte BVS = 0x70;

    // Status Flag Changes
    public const byte CLC = 0x18;
    public const byte CLD = 0xD8;
    public const byte CLI = 0x58;
    public const byte CLV = 0xB8;
    public const byte SEC = 0x38;
    public const byte SED = 0xF8;
    public const byte SEI = 0x78;

}


public class Cpu
{

    // REGISTER
    public byte A;
    public byte X;
    public byte Y;

    // Processor Status : Flag
    public byte     PS;
    public byte     SP;     // Stack Pointer
    public ushort   PC;     // program control


	ulong tick = 0;


	public void SetFlag(byte flag, bool set)
    {
        if (set)
            PS |= flag;
        else
            PS &= (byte)~flag;
    }

    public bool GetFlag(byte flag)
    {
        return (PS & flag) > 0 ? true : false;
    }


    public void SetZeroNegative(byte Register)
    {
        SetFlag(Define.FLAG_ZERO, Register == 0);
        //Flag.Z = (Register == 0);

        SetFlag(Define.FLAG_NEGATIVE, (Register & Define.FLAG_NEGATIVE) > 0 ? true : false);
        //Flag.N = (Register & Define.FLAG_NEGATIVE) > 0;
    }

    public void SetCarryFlag(ushort value)
    {
        //Flag.C = (value & 0xFF00) > 0;
        SetFlag(Define.FLAG_CARRY, (value & 0xFF00) > 0);
    }

//     public void SetCarryFlagNegative(ushort value)
//     {
//         Flag.C = (value < 0x100);
//     }

    public void SetOverflow(byte oldv0, byte v0, byte v1)
    {
        byte v_1 = (byte)((oldv0 ^ v1) & Define.FLAG_NEGATIVE);

        bool sign0 = !(v_1 > 0 ? true : false);   // 계산전 부호
        bool sign1 = ((v0 ^ v1) & Define.FLAG_NEGATIVE) > 0 ? true : false;       // 계산후 부호

        // Overflow는 같은 부호를 더했는데 다른 부호가 나오면 Overflow이다
        SetFlag(Define.FLAG_OVERFLOW, (sign0 != sign1));
        //Flag.V = (sign0 != sign1);
        //Flag.V = sign0 && sign1;
    }

    byte Fetch(Memory mem, ref int cycle)
    {
        byte c = mem.ReadByte(PC++);
        cycle--;
        return c;
    }

    ushort FetchWord(Memory mem, ref int cycle)
    {
        byte c0 = mem.ReadByte(PC++);
        byte c1 = mem.ReadByte(PC++);

        // 엔디안에 따라 c0 <--> c1해야 할수도 있다
        ushort w = (ushort)((c1 << 8) | c0);
        cycle -= 2;
        return w;
    }


    // 메모리에서 읽는데 cycle소모 x / PC무관 할때 (Zero page같은것)
    byte ReadByte(Memory mem, ushort addr, ref int cycle)
    {
        byte c = mem.ReadByte(addr);
        cycle--;
        return c;
    }

    ushort ReadWord(Memory mem, ushort addr, ref int cycle)
    {
        ushort c = mem.ReadWord(addr);
        cycle -= 2;
        return c;
    }

    void WriteByte(Memory mem, byte value, int addr, ref int cycle)
    {
        mem.WriteByte(addr, value);
        cycle--;
    }

    void Writeushort(Memory mem, ushort value, int addr, ref int cycle)
    {
        mem.WriteWord(value, addr);
        cycle -= 2;
    }

    ushort GetStackAddress()
    {
        ushort sp = (ushort)(Define.STACK_ADDRESS + SP);
        return sp;
    }

    // Byte를 Stack에 Push
    void PushStackByte(Memory mem, byte value, ref int cycle)
    {
        WriteByte(mem, value, GetStackAddress(), ref cycle);
        SP--;
        cycle--;
    }

    // ushort를 Stack에 Push
    void PushStackWord(Memory mem, ushort value, ref int cycle)
    {
        // Hi byte 먼저
        WriteByte(mem, (byte)(value >> 8), GetStackAddress(), ref cycle);
        SP--;
        // Lo byte 나중에
        WriteByte(mem, (byte)(value & 0xFF), GetStackAddress(), ref cycle);
        SP--;
    }

    // 스택에서 1 byte POP
    byte PopStackByte(Memory mem, ref int cycle)
    {
        SP++;
        byte popbyte = ReadByte(mem, GetStackAddress(), ref cycle);
        cycle--;
        return popbyte;
    }

    // Stack에서 ushort pop
    ushort PopStackWord(Memory mem, ref int cycle)
    {
        SP++;
        byte lo = ReadByte(mem, GetStackAddress(), ref cycle);
        SP++;
        byte hi = ReadByte(mem, GetStackAddress(), ref cycle);
        ushort popushort = (ushort)(lo | (hi << 8));
        cycle--;

        return popushort;
    }


    int Run(Memory mem, ref int cycle)
    {
        int CyclesRequested = cycle;
		int prevcycle = cycle;

		while (cycle > 0)
        {
            ushort prevPC = PC;
            // 여기에서 cycle 하나 소모
            byte inst = Fetch(mem, ref cycle);
            //lastInst = inst;

//             if (enableLog)
//             {
//                 printf("A:[%2X] X:[%2X] Y:[%2X] PC:[%4X] ", A, X, Y, prevPC);
//                 printf("INST : [%2X] / C:[%d] Z:[%d] I:[%d] D:[%d] B:[%d] U:[%d] V:[%d] N:[%d]\n", inst,
//                     Flag.C, Flag.Z, Flag.I, Flag.D, Flag.B, Flag.Unused, Flag.V, Flag.N);
//             }

            switch (inst)
            {
                case Define.LDA_IM: // 2 cycle
                    {
                        A = Fetch(mem, ref cycle);
                        SetZeroNegative(A);
                    }
                    break;

                case Define.LDA_ZP: // 3 cycle
                    {
                        ushort addr = addr_mode_ZP(mem, ref cycle);
                        A = ReadByte(mem, addr, ref cycle);
                        SetZeroNegative(A);
                    }
                    break;

                case Define.LDA_ZPX: // 4 cycle
                    {
                        ushort addr = addr_mode_ZPX(mem, ref cycle);
                        A = ReadByte(mem, addr, ref cycle);
                        SetZeroNegative(A);
                    }
                    break;

				// 절대 주소 지정을 사용하는 명령어는 대상 위치를 식별하기 위해 전체 16 비트 주소를 포함합니다.
				case Define.LDA_ABS: // 4 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						A = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.LDA_ABSX:// 4 cycle / 페이지 넘어가면 1 cycle 추가
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						A = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.LDA_ABSY:  // 4 cycle / 페이지 넘어가면 1 cycle 추가
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						A = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);

					}
					break;

				case Define.LDA_INDX:  // 6 cycle
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						A = ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				case Define.LDA_INDY: // 5 ~ 6 cycle
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						A = ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				// LDX
				case Define.LDX_IM:    // 2cycle
					{
						//LoadToRegister(mem, cycle, X);
						X = Fetch(mem, ref cycle);
						SetZeroNegative(X);
					}
					break;

				case Define.LDX_ZP:    // 3cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						X = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(X);
					}
					break;

				case Define.LDX_ZPY:   // 4cycle
					{
						ushort addr = addr_mode_ZPY(mem, ref cycle);
						X = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(X);
					}
					break;

				case Define.LDX_ABS:   // 4cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						X = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(X);

					}
					break;

				case Define.LDX_ABSY:  // 4 ~ 5 cycle
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						X = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(X);

					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				case Define.LDY_IM: // 2 cycle
					{
						Y = Fetch(mem, ref cycle);
						SetZeroNegative(Y);
					}
					break;

				case Define.LDY_ZP: // 3 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						Y = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(Y);
					}
					break;

				case Define.LDY_ZPX: // 4 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						Y = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(Y);
					}
					break;

				case Define.LDY_ABS: // 4 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						Y = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(Y);
					}
					break;

				case Define.LDY_ABSX: // 4~5 ref cycle
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						Y = ReadByte(mem, addr, ref cycle);
						SetZeroNegative(Y);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				case Define.STA_ZP:    // 3 cycle
					{
						// ZeroPage에 A레지스터 내용 쓰기
						ushort addr = addr_mode_ZP(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_ZPX:   // 4 cycle
					{
						// ZP + X에 A레지스터 내용쓰기
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_ABS:   // 4 cycle
					{
						// ushort address에 A레지스터 내용 쓰기
						ushort addr = addr_mode_ABS(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_ABSX:  // 5 cycle
					{
						// ushort address + X에 A레지스터 내용 쓰기
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_ABSY:  // 5 cycle
					{
						// WORD address + Y에 A레지스터 내용 쓰기
						ushort addr = addr_mode_ABSY_NoPage(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_INDX:  // 6 cycle
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				case Define.STA_INDY:  // 6 cycle
					{
						// ZeroPage에서 WORD address얻고 address + Y에 가르키는곳에 A레지스터 내용쓰기 
						BYTE zp = Fetch(mem, ref cycle);
						ushort addr = ReadWord(mem, zp, ref cycle);
						addr += Y;
						cycle--;
						WriteByte(mem, A, addr, ref cycle);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				case Define.STX_ZP:    // 3 cycle
					{
						// ZeroPage에 X레지스터 내용 쓰기
						ushort addr = addr_mode_ZP(mem, ref cycle);
						WriteByte(mem, X, addr, ref cycle);
					}
					break;

				case Define.STX_ZPY:   // 4 cycle
					{
						// ZP + Y에 X레지스터 내용쓰기
						ushort addr = addr_mode_ZPY(mem, ref cycle);
						WriteByte(mem, X, addr, ref cycle);
					}
					break;

				case Define.STX_ABS:   // 4 cycle
					{
						// WORD address에 X레지스터 내용 쓰기
						ushort addr = addr_mode_ABS(mem, ref cycle);
						WriteByte(mem, X, addr, ref cycle);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				case Define.STY_ZP:    // 3 cycle
					{
						// ZeroPage에 X레지스터 내용 쓰기
						ushort addr = addr_mode_ZP(mem, ref cycle);
						WriteByte(mem, Y, addr, ref cycle);

					}
					break;

				case Define.STY_ZPX:   // 4 cycle
					{
						// ZP + X에 Y레지스터 내용쓰기
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						WriteByte(mem, Y, addr, ref cycle);
					}
					break;

				case Define.STY_ABS:   // 4 cycle
					{
						// WORD address에 Y레지스터 내용 쓰기
						ushort addr = addr_mode_ABS(mem, ref cycle);
						WriteByte(mem, Y, addr, ref cycle);
					}
					break;



				////////////////////////////////////////////////////////////////////////////// JUMP

				case Define.JSR: // 6 cycle
					{
						byte lo = ReadByte(mem, PC, ref cycle);
						PC++;
						ushort address = (ushort)(lo | (ReadByte(mem, PC, ref cycle) << 8));

						PushStackWord(mem, PC, ref cycle);
						PC = address;
						cycle--;
					}
					break;

				case Define.JMP_ABS:   // 3 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						PC = addr;
					}
					break;

				case Define.JMP_IND:   // 5 cycle
					{
						ushort addr = FetchWord(mem, ref cycle);
						addr = ReadWord(mem, addr, ref cycle);
						PC = addr;
					}
					break;

				case Define.RTS:   // 6 cycle
					{
						ushort addr = PopStackWord(mem, ref cycle);
						PC = (ushort)(addr + 1);
						cycle -= 2;
					}
					break;

				//////////////////////////////////////////////////////////////////////////////	STACK

				// Transfer (Stack Pointer) to X
				case Define.TSX:   // 2 cycle
					{
						// 스택포인터를 X 레지스터로
						X = SP;
						cycle--;
						// Z / N flag
						SetZeroNegative(X);
					}
					break;

				// Transfer X to (Stack Pointer)
				case Define.TXS:   // 2 cycle
					{
						// X레지스터를 SP로
						SP = X;
						cycle--;
					}
					break;

				// Pushes a copy of the accumulator on to the stack.
				case Define.PHA:   // 3 cycle
					{
						// A 레지스터를 스택에 Push
						PushStackByte(mem, A, ref cycle);
					}
					break;

				// Pulls an 8 bit value from the stack and into the accumulator. 
				// The zero and negative flags are set as appropriate.
				case Define.PLA:   // 4 cycle
					{
						// 스택에서 8비트를 pull --> A로
						A = PopStackByte(mem, ref cycle);
						cycle--;
						// Z / N flag
						SetZeroNegative(A);
					}
					break;

				// Pulls an 8 bit value from the stack and into the processor flags. 
				// The flags will take on new states as determined by the value pulled.
				case Define.PLP:   // 4 cycle
					{
						// pop 8 bit를 --> PS (Flag) : 플레그들은 Pop된 값에의하여 새로운 플레그 상태를 갖음
						PS = (byte)(PopStackByte(mem, ref cycle) | Define.FLAG_UNUSED);
					}
					break;

				// Pushes a copy of the status flags on to the stack.
				case Define.PHP:   // 3 cycle
					{
						// PS -> Stack에 Push
						byte _PS = (byte)(PS | Define.FLAG_BREAK);
						PushStackByte(mem, _PS, ref cycle);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				case Define.AND_IM:    // 2 cycle
					{
						A &= Fetch(mem, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_ZP:    // 3 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_ZPX:   // 4 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_ABS:   // 4cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_ABSX:  // 4 cycle / 페이지 넘어가면 1 cycle 추가
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_ABSY:  // 4 cycle / 페이지 넘어가면 1 cycle 추가
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.AND_INDX:  // 6 cycle
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				case Define.AND_INDY:  // 5 cycle / 페이지 넘어가면 1 cycle 추가
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						A &= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;


				case Define.ORA_IM:
					{
						A |= Fetch(mem, cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_ABSX:
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_ABSY:
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.ORA_INDX:
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				case Define.ORA_INDY:
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						A |= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;


				case Define.EOR_IM:
					{
						A ^= Fetch(mem, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_ABSX:
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_ABSY:
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);
						SetZeroNegative(A);
					}
					break;

				case Define.EOR_INDX:
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				case Define.EOR_INDY:
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						A ^= ReadByte(mem, addr, ref cycle);

						SetZeroNegative(A);
					}
					break;

				// Bit Test Zero page
				case Define.BIT_ZP:
					{
						// Zp에서 읽은 값과 A를 & 테스트 하고 플레그들을 셋팅 / Set if the result if the AND is zero
						// N 플레그는 7bit, Set to bit 7 of the memory value
						// V 플레그는 6Bit , Set to bit 6 of the memory value
						ushort addr = addr_mode_ZP(mem, ref cycle);
						byte R = ReadByte(mem, addr, ref cycle);

						Flag.Z = !(A & R);
						Flag.N = (R & FLAG_NEGATIVE) != 0;
						Flag.V = (R & FLAG_OVERFLOW) != 0;
					}
					break;

				case Define.BIT_ABS:
					{
						// Zp에서 읽은 값과 A를 & 테스트 하고 플레그들을 셋팅
						// N 플레그는 7bit / V 플레그는 6Bit
						ushort addr = addr_mode_ABS(mem, ref cycle);
						byte R = ReadByte(mem, addr, ref cycle);

						Flag.Z = !(A & R);
						Flag.N = (R & FLAG_NEGATIVE) != 0;
						Flag.V = (R & FLAG_OVERFLOW) != 0;

					}
					break;

				////////////////////////////////////////////////////////////////////////////// Register Transfer

				case Define.TAX:
					{
						// Transfer Accumulator to X
						X = A;
						cycle--;
						SetZeroNegative(X);
					}
					break;

				case Define.TAY:
					{
						//Transfer Accumulator to Y
						Y = A;
						cycle--;
						SetZeroNegative(Y);
					}
					break;

				case Define.TXA:
					{
						// Transfer X to Accumulator
						A = X;
						cycle--;
						SetZeroNegative(A);
					}
					break;

				case Define.TYA:
					{
						// Transfer Y to Accumulator
						A = Y;
						cycle--;
						SetZeroNegative(A);
					}
					break;


				////////////////////////////////////////////////////////////////////////////// increase / decrease

				case Define.INX:   // 2 cycle
					{
						// Increment X Register / X,Z,N = X+1
						X++;
						cycle--;
						Flag.Z = (X == 0);
						Flag.N = (X & FLAG_NEGATIVE) != 0;
					}
					break;

				case Define.INY:   // 2 cycle
					{
						// Increment Y Register / Y,Z,N = Y+1
						Y++;
						cycle--;
						Flag.Z = (Y == 0);
						Flag.N = (Y & FLAG_NEGATIVE) != 0;
					}
					break;
				case Define.DEX:   // 2 cycle
					{
						// Decrease X Register / X,Z,N = X+1
						X--;
						cycle--;
						Flag.Z = (X == 0);
						Flag.N = (X & FLAG_NEGATIVE) != 0;

					}
					break;

				case Define.DEY:   // 2 cycle
					{
						// Decrement Y Register / Y,Z,N = Y+1
						Y--;
						cycle--;
						Flag.Z = (Y == 0);
						Flag.N = (Y & FLAG_NEGATIVE) != 0;

					}
					break;

				case Define.INC_ZP:
					{
						// Increment Memory by One / M + 1 -> M
						ushort addr = addr_mode_ZP(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v++;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;
				case Define.INC_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v++;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;
				case Define.INC_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v++;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;
				case Define.INC_ABSX:
					{
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v++;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;
				case Define.DEC_ZP:// 5 cycle
					{
						// Decrement Memory by One / M - 1 -> M
						ushort addr = addr_mode_ZP(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v--;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);

					}
					break;
				case Define.DEC_ZPX: // 6 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v--;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;
				case Define.DEC_ABS:   // 6 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v--;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;

				case Define.DEC_ABSX:  // 7 cycle
					{
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						v--;
						cycle--;
						WriteByte(mem, v, addr, ref cycle);
						SetZeroNegative(v);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////	Arithmetic

				// Add with Carry
				// This instruction adds the contents of a memory location to the accumulator together with 
				// the carry bit.If overflow occurs the carry bit is set, this enables multiple byte addition to be performed.
				case Define.ADC_IM:    // 2 cycle
					{
						// A + M + C -> A, C
						byte v = Fetch(mem, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_ZP:    // 3 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_ZPX:   // 4 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_ABS:   // 4 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						byte v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_ABSX:  // 4~5 cycle
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_ABSY:  // 4~5 cycle
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_INDX:  // 6 cycle
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				case Define.ADC_INDY:  // 5~6 cycle
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ADC(v);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				// SBC - Subtract with Carry
				// A, Z, C, N = A - M - (1 - C)
				case Define.SBC_IM:    // 2 cycle
					{
						BYTE v = Fetch(mem, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_ZP:    // 3 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_ABSX:
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_ABSY:
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_INDX:
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				case Define.SBC_INDY:
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_SBC(v);
					}
					break;

				////////////////////////////////////////////////////////////////////////////// Compare

				// Z,C,N = A-M
				// This instruction compares the contents of the accumulator with another memory held 
				// valueand sets the zeroand carry flags as appropriate.
				case Define.CMP_IM:
					{
						BYTE v = Fetch(mem, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_ABSX:
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_ABSY:
					{
						ushort addr = addr_mode_ABSY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				case Define.CMP_INDX:
					{
						ushort addr = addr_mode_INDX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}

					break;

				case Define.CMP_INDY:
					{
						ushort addr = addr_mode_INDY(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CMP(v);
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				// Compare X Register
				// Z, C, N = X - M
				// This instruction compares the contents of the X register with another memory
				// held value and sets the zero and carry flags as appropriate.
				case Define.CPX_IM:
					{
						BYTE v = Fetch(mem, ref cycle);
						Execute_CPX(v);
					}
					break;

				case Define.CPX_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CPX(v);
					}
					break;

				case Define.CPX_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CPX(v);
					}
					break;

				case Define.CPY_IM:
					{
						BYTE v = Fetch(mem, ref cycle);
						Execute_CPY(v);
					}
					break;

				case Define.CPY_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CPY(v);
					}
					break;

				case Define.CPY_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_CPY(v);
					}
					break;

				////////////////////////////////////////////////////////////////////////////// SHIFT

				// Arithmetic Shift Left
				case Define.ASL: // 2 cycle
					{
						// A,Z,C,N = M*2 or M,Z,C,N = M*2
						// Carry Bit 계산을 먼저해야한다. Shift할 값자체가 -(NEG)인 경우 왼쪽 shift는 Carry를 일으키기 때문
						Execute_ASL(A, ref cycle);
					}
					break;

				case Define.ASL_ZP: // 5 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ASL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;

				case Define.ASL_ZPX: // 6 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ASL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;

				case Define.ASL_ABS: // 6 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ASL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);

					}
					break;

				case Define.ASL_ABSX: // 7 cycle
					{
						ushort addr = addr_mode_ABSX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ASL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);

					}
					break;

				// Logical Shift Right : A,C,Z,N = A/2 or M,C,Z,N = M/2
				// Each of the bits in A or M is shift one place to the right. 
				// The bit that was in bit 0 is shifted into the carry flag. Bit 7 is set to zero.
				// Carry Flag :	Set to contents of old bit 0
				case Define.LSR:   // 2 cycle
					{
						Execute_LSR(A, ref cycle);
					}
					break;
				case Define.LSR_ZP:    // 5 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_LSR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.LSR_ZPX:   // 6 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_LSR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.LSR_ABS:   // 6 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_LSR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.LSR_ABSX:  // 7 cycle
					{
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_LSR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;

				// Move each of the bits in either A or M one place to the left. 
				// Bit 0 is filled with the current value of the carry flag whilst 
				// the old bit 7 becomes the new carry flag value.
				case Define.ROL:   // 2 cycle
					{
						Execute_ROL(A, ref cycle);
					}
					break;
				case Define.ROL_ZP:    // 5 cycle
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROL_ZPX:   // 6 cycle
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROL_ABS:   // 6 cycle
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROL_ABSX:  // 7 cycle
					{
						// 여기는 ABS No page
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROL(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;

				// Rotate Right
				// Move each of the bits in either A or M one place to the right.
				// Bit 7 is filled with the current value of the carry flag whilst 
				// the old bit 0 becomes the new carry flag value.
				case Define.ROR:
					{
						Execute_ROR(A, ref cycle);
					}
					break;
				case Define.ROR_ZP:
					{
						ushort addr = addr_mode_ZP(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROR_ZPX:
					{
						ushort addr = addr_mode_ZPX(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROR_ABS:
					{
						ushort addr = addr_mode_ABS(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;
				case Define.ROR_ABSX:
					{
						ushort addr = addr_mode_ABSX_NoPage(mem, ref cycle);
						BYTE v = ReadByte(mem, addr, ref cycle);
						Execute_ROR(v, ref cycle);
						WriteByte(mem, v, addr, ref cycle);
					}
					break;


				////////////////////////////////////////////////////////////////////////////// Branches

				// Branch if carry flag clear
				// If the carry flag is clear then add the relative displacement to the program 
				// counter to cause a branch to a new location.
				case Define.BCC:
					{
						Execute_BRANCH(Flag.C, false, mem, ref cycle);
					}
					break;

				// Branch if Carry Set
				// If the carry flag is set then add the relative displacement to the program 
				// counter to cause a branch to a new location.
				// BCC 반대
				case Define.BCS: // 2 ~ 4 cycle
					{
						Execute_BRANCH(Flag.C, true, mem, ref cycle);
					}
					break;

				// Branch if Equal
				// If the zero flag is set then add the relative displacement to the program counter 
				// to cause a branch to a new location.
				// 2 (+1 if branch succeeds +2 if to a new page)
				case Define.BEQ:   // 2 cycle + Zero이면 1 cycle추가 + Page넘어가면 1 cycle 추가
					{
						Execute_BRANCH(Flag.Z, true, mem, ref cycle);
					}
					break;

				// If the zero flag is clear then add the relative displacement 
				// to the program counter to cause a branch to a new location.
				// BEQ랑 반대
				case Define.BNE:
					{
						Execute_BRANCH(Flag.Z, false, mem, ref cycle);
					}
					break;

				// Branch if negative flag set
				case Define.BMI:
					{
						Execute_BRANCH(Flag.N, true, mem, ref cycle);
					}
					break;

				// Branch if negative flag clear
				case Define.BPL:
					{
						Execute_BRANCH(Flag.N, false, mem, ref cycle);
					}
					break;

				// Branch if overflow flag clear
				case Define.BVC:
					{
						Execute_BRANCH(Flag.V, false, mem, ref cycle);
					}
					break;

				// Branch if overflow flag set
				case Define.BVS:
					{
						Execute_BRANCH(Flag.V, true, mem, ref cycle);
					}
					break;

				////////////////////////////////////////////////////////////////////////////// Status Flag Changes

				// Clear carry flag
				case Define.CLC:   // 2 cycle
					{
						Flag.C = 0;
						cycle--;
					}
					break;

				// Clear Decimal Mode
				case Define.CLD:   // 2 cycle
					{
						Flag.D = 0;
						cycle--;
					}
					break;

				// Clear Interrupt Disable
				case Define.CLI:   // 2 cycle
					{
						Flag.I = 0;
						cycle--;
					}
					break;

				// Clear Overflow Flag
				case Define.CLV:   // 2 cycle
					{
						Flag.V = 0;
						cycle--;
					}
					break;

				// Set carry flag
				case Define.SEC:   // 2 cycle
					{
						Flag.C = 1;
						cycle--;
					}
					break;

				// Set decimal mode flag
				case Define.SED:   // 2 cycle
					{
						Flag.D = 1;
						cycle--;
					}
					break;

				// Set interrupt disable flag
				case Define.SEI:   // 2 cycle
					{
						Flag.I = 1;
						cycle--;
					}
					break;

				//////////////////////////////////////////////////////////////////////////////

				// BRK 명령은 인터럽트 요청의 생성을 강제한다.
				// 프로그램 카운터 및 프로세서 상태가 스택에서 푸시된 다음 $ FFFE/F의 IRQ 인터럽트 벡터가 
				// PC에로드되고 상태의 중단 플래그가 1로 설정됩니다.
				case Define.BRK:   // 7 cycle
					{
#if USEOLD
				// PC Push
				// BRK는 PC를 +1하지 않고 +2한다고 함. 그래서 PC+1 push
				// https://www.c64-wiki.com/wiki/BRK
				PushStackWord(mem, PC+1, cycle);

				// SP Push
				BYTE _PS = PS | FLAG_BREAK | FLAG_UNUSED;
				PushStackByte(mem, _PS, cycle);

				WORD interruptVector = ReadWord(mem, 0xFFFE, cycle);
				PC = interruptVector;
				Flag.B = 1;
				Flag.I = 1;
#else
						PC++;
						WriteByte(mem, ((PC) >> 8) & 0xFF, 0x100 + SP, ref cycle);
						SP--;
						WriteByte(mem, PC & 0xFF, 0x100 + SP, ref cycle);
						SP--;
						WriteByte(mem, PS | FLAG_BREAK, 0x100 + SP, ref cycle);
						SP--;
						Flag.I = 1;
						Flag.D = 0;
						PC = ReadByte(mem, 0xFFFE, ref cycle) | ReadByte(mem, 0xFFFF, ref cycle) << 8;
#endif
						printf("BREAK!! : %x\n", PC);
					}
					break;

				// Return from Interrupt
				// RTI 명령은 인터럽트 처리 루틴의 끝에서 사용됩니다.
				// 프로그램 카운터 뒤에 오는 스택에서 프로세서 플래그를 가져옵니다.
				case Define.RTI:   // 6 cycle
					{
						//BYTE PS = PopStackByte(mem, cycle);
						//PC = PopStackWord(mem, cycle);

						SP++;
						PS = ReadByte(mem, 0x100 + SP, ref cycle);
						SP++;
						PC = ReadByte(mem, 0x100 + SP, ref cycle);
						SP++;
						PC |= ReadByte(mem, 0x100 + SP, ref cycle) << 8;
						cycle -= 5;
					}
					break;

				case Define.Define.Define.NOP:
					cycle--;
					break;

				//////////////////////////////////////////////////////////////////////////////

				default:
					//printf("Unknown instruction : %x\n", inst);
					//throw -1;
					break;
			}

			tick += (ulong)(prevcycle - cycle);

		}

		return CyclesRequested - cycle;
	}


    ////////////////////////////////////////////////////////////////////////////// memory addressing mode

    // ZeroPage
    ushort addr_mode_ZP(Memory mem, ref int cycle)
    {
        byte address = Fetch(mem, ref cycle);
        return address;
    }

    // Zero page + X
    ushort addr_mode_ZPX(Memory mem, ref int cycle)
    {
        byte address = (byte)(Fetch(mem, ref cycle) + X);
        cycle--;
        return address;
    }

    // Zero page + X
    ushort addr_mode_ZPY(Memory mem, ref int cycle)
    {
        byte address = (byte)(Fetch(mem, ref cycle) + Y);
        cycle--;
        return address;
    }

    // ABS
    ushort addr_mode_ABS(Memory mem, ref int cycle)
    {
        ushort address = FetchWord(mem, ref cycle);
        return address;
    }

    // ABS + X
    ushort addr_mode_ABSX(Memory mem, ref int cycle)
    {
	    byte lo = Fetch(mem, ref cycle);
	    byte hi = Fetch(mem, ref cycle);
	    ushort t = (ushort)(lo + X);
	    if ( (t & 0xFF00) > 0) 
            cycle--;

	    ushort address = (ushort)((lo | (hi << 8)) + X);
	    return address;

    }

    // ABS + X : Page 넘어가는것 무시(그냥 하드웨어가 이렇게 생김)
    ushort addr_mode_ABSX_NoPage(Memory mem, ref int cycle)
    {
        ushort address = FetchWord(mem, ref cycle);
        address += X;
        cycle--;
        return address;
    }

    // ABS + Y
    ushort addr_mode_ABSY(Memory mem, ref int cycle)
    {
        byte lo = Fetch(mem, ref cycle);
        byte hi = Fetch(mem, ref cycle);

        ushort t = (ushort)(lo + Y);
        if (t > 0xFF) cycle--;
        ushort address = (ushort)((lo | (hi << 8)) + Y);
        return address;
    }

    ushort addr_mode_ABSY_NoPage(Memory mem, ref int cycle)
    {
        ushort address = FetchWord(mem, ref cycle);
        address += Y;
        cycle--;
        return address;
    }

    ushort addr_mode_INDX(Memory mem, ref int cycle)
    {
        byte t = Fetch(mem, ref cycle);
        byte inx = (byte)(t + X);
        cycle--;
        ushort address = ReadWord(mem, inx, ref cycle);
        return address;
    }


    ushort addr_mode_INDY(Memory mem, ref int cycle)
    {

	    // zero page에서 ushort 읽고 Y레지스터와 더한 주소의 1바이트를 A에 로드
	    // 읽을 주소가 page를 넘으면 1사이클 감소
	    byte addr = Fetch(mem, ref cycle);
	    byte lo = ReadByte(mem, addr, ref cycle);
	    byte hi = ReadByte(mem, (ushort)(addr + 1), ref cycle);

	    ushort t = (ushort)(lo + Y);
	    if (t > 0xFF) cycle--;	// page 넘어감

	    ushort index_addr = (ushort)(((hi << 8) | lo) + Y);
	    return index_addr;
    }


	///////////////////////////////////////////////////////////////////////////

	void Execute_ADC(byte v)
	{
#if !USEOLD
		byte oldA = A;
		ushort Result = A + v + Flag.C;
		// Decimal mode
		if (Flag.D)
			Result += ((((Result + 0x66) ^ A ^ v) >> 3) & 0x22) * 3;
		A = (Result & 0xFF);
		SetZeroNegative(A);
		SetCarryFlag(Result);
		SetOverflow(oldA, A, v);
#else
	// Decimal mode 무시하면 Lode runner에서 점수 Hex로 나옴

	WORD result = A + v + Flag.C;
	Flag.V = ((result ^ A) & (result ^ v) & 0x0080) != 0;
	if (Flag.D)
		result += ((((result + 0x66) ^ A ^ v) >> 3) & 0x22) * 3;
	Flag.C = result > 0xFF;
	A = result & 0xFF;
	SetZeroNegative(A);
#endif
	}

	void Execute_SBC(byte v)
	{
#if !USEOLD
		Execute_ADC(~v);
#else
	v ^= 0xFF;
	if (Flag.D)
		v -= 0x0066;
	WORD result = A + v + (Flag.C);
	Flag.V = ((result ^ A) & (result ^ v) & 0x0080) != 0;
	if (Flag.D)
		result += ((((result + 0x66) ^ A ^ v) >> 3) & 0x22) * 3;
	Flag.C = result > 0xFF;
	A = result & 0xFF;
	SetZeroNegative(A);
#endif
	}

	void Execute_CMP(byte v)
	{
		ushort t = A - v;
		// 	Flag.N = (t & FLAG_NEGATIVE) > 0;	// Set if bit 7 of the result is set
		// 	Flag.Z = A == v;					// Set if A = M
		// 	Flag.C = A >= v;					// Set if A >= M

		Flag.Z = ((A - v) & 0xFF) == 0;
		Flag.N = ((A - v) & FLAG_NEGATIVE) != 0;
		Flag.C = (A >= v) != 0;
	}

	void Execute_CPX(BYTE v)
	{
		WORD t = X - v;
		// 	Flag.N = (t & FLAG_NEGATIVE) > 0;	// Set if bit 7 of the result is set
		// 	Flag.Z = X == v;					// Set if X = M
		// 	Flag.C = X >= v;					// Set if X >= M

		Flag.Z = ((X - v) & 0xFF) == 0;
		Flag.N = ((X - v) & FLAG_NEGATIVE) != 0;
		Flag.C = (X >= v) != 0;
	}

	void Execute_CPY(BYTE v)
	{
		WORD t = Y - v;
		// 	Flag.N = (t & FLAG_NEGATIVE) > 0;	// Set if bit 7 of the result is set
		// 	Flag.Z = Y == v;					// Set if Y = M
		// 	Flag.C = Y >= v;					// Set if Y >= M

		Flag.Z = ((Y - v) & 0xFF) == 0;
		Flag.N = ((Y - v) & FLAG_NEGATIVE) != 0;
		Flag.C = (Y >= v) != 0;
	}

	void CPU::Execute_ASL(BYTE &v, int &cycle)
	{
		Flag.C = (v & FLAG_NEGATIVE) > 0;
		v = v << 1;
		cycle--;
		SetZeroNegative(v);
	}

	void CPU::Execute_LSR(BYTE& v, int& cycle)
	{
		Flag.C = (v & 0x01);
		v = v >> 1;
		cycle--;
		SetZeroNegative(v);
	}

	/*
				   +------------------------------+
				   |         M or A               |
				   |   +-+-+-+-+-+-+-+-+    +-+   |
	  Operation:   +-< |7|6|5|4|3|2|1|0| <- |C| <-+         N Z C I D V
					   +-+-+-+-+-+-+-+-+    +-+             / / / _ _ _
	*/
	void CPU::Execute_ROL(BYTE& v, int& cycle)
	{
		// 이전의 carry flag값을 Shift후의 0bit에 채워준다
		BYTE oldcarry = Flag.C ? 0x01 : 0x00;
		Flag.C = (v & FLAG_NEGATIVE) > 0;
		v <<= 1;
		v |= oldcarry;
		cycle--;
		SetZeroNegative(v);
	}

	/*
				   +------------------------------+
				   |                              |
				   |   +-+    +-+-+-+-+-+-+-+-+   |
	  Operation:   +-> |C| -> |7|6|5|4|3|2|1|0| >-+         N Z C I D V
					   +-+    +-+-+-+-+-+-+-+-+             / / / _ _ _
	*/
	void CPU::Execute_ROR(BYTE& v, int& cycle)
	{
		// 최하비트가 1인가? -> 다음 캐리비트로 설정
		BYTE oldcarry = (v & FLAG_CARRY) > 0;
		v = v >> 1;
		// 이전 Carry가 1이면 NEGATIVE 채움
		v |= (Flag.C ? FLAG_NEGATIVE : 0);
		cycle--;
		Flag.C = oldcarry;
		SetZeroNegative(v);
	}


	void CPU::Execute_BRANCH(bool v, bool condition, Memory &mem, int &cycle)
	{
		SBYTE offset = (SBYTE)Fetch(mem, cycle);
		if (v == condition)
		{
#if !USEOLD
			// Page를 넘어가면 Cycle 증가
			BYTE lo = PC & 0x00FF;
			WORD t = lo + (SBYTE)offset;
			if (t > 0xFF) cycle--;

			PC += (SBYTE)offset;
			cycle--;
#else
		if (offset & FLAG_NEGATIVE)
			offset |= 0xFF00;  // jump backward
		if (((PC & 0xFF) + offset) & 0xFF00)  // page crossing
			cycle--;
		PC += offset;
		cycle--;
#endif
		}
	}



}
