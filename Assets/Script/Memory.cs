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


}
