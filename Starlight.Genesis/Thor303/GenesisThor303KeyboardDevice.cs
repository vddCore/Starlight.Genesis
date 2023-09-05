using System.Drawing;
using Hideous;

namespace Starlight.Genesis.Thor303
{
    public class GenesisThor303KeyboardDevice : Device
    {
        public GenesisThor303KeyboardDevice()
            : base(new(0x331A, 0x5018, MaxFeatureReportLength: 8))
        {
        }

        public void SendRaw(params byte[] command)
        {
            if (command.Length > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(command), "Max 7 bytes allowed.");
            }
            
            Set(new GenesisThor303Packet(0x0A)
                .AppendData(command));
        }

        public void Disable()
        {
            Set(new GenesisThor303Packet(0x0A)
                .AppendData(0x04, 0x01));
        }

        public void Enable()
        {
            Set(new GenesisThor303Packet(0x0A)
                .AppendData(0x03, 0x01));
        }

        public void SetKeyColor(Thor303Key key, Color color)
            => SetKeyColor((byte)key, color);

        public void SetKeyColor(byte keyIndex, Color color)
        {
            Set(new GenesisThor303Packet(0x0A)
                .AppendData(0x0C, 0x00)
                .AppendData(keyIndex)
                .AppendData(color.R, color.G, color.B, color.A));

            // [0x0C, 0x00, 0x89]: Flush key color registers.
            Set(new GenesisThor303Packet(0x0A)
                .AppendData(0x0C, 0x00, 0x89));
        }
    }
}