using Hideous;

namespace Starlight.Genesis.Thor303
{
    public class GenesisThor303Packet : FeaturePacket
    {
        public GenesisThor303Packet(byte reportId) 
            : base(reportId, 8)
        {
        }
    }
}