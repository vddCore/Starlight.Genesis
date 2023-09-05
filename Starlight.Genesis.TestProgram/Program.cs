using System.Drawing;
using Starlight.Genesis.Thor303;

var thor303 = new GenesisThor303KeyboardDevice();
thor303.SendRaw(0x0A, 0x13, 0x0F, 0x04, 0x07);
Console.WriteLine();

// thor303.Set(new GenesisThor303Packet(0x0A)
//     .AppendData(0x04, 0x01));