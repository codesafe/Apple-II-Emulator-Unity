using System.Collections;
using System.Collections.Generic;


static class Define
{

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
    public ushort   PC;		// program control


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

    public void SetCarryFlagNegative(ushort value)
    {
        Flag.C = (value < 0x100);
    }

    public void SetOverflow(byte oldv0, byte v0, byte v1)
    {
        bool sign0 = !((oldv0 ^ v1) & Define.FLAG_NEGATIVE) > 0 ? true : false;   // 계산전 부호
        bool sign1 = ((v0 ^ v1) & Define.FLAG_NEGATIVE) > 0 ? true : false;       // 계산후 부호

        // Overflow는 같은 부호를 더했는데 다른 부호가 나오면 Overflow이다
        SetFlag(Define.FLAG_OVERFLOW, (sign0 != sign1));
        //Flag.V = (sign0 != sign1);
        //Flag.V = sign0 && sign1;
    }

}
