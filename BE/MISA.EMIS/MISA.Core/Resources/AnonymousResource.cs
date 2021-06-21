using MISA.Core.Extensions;

namespace MISA.Core.Resources
{
    public abstract class AnonymousResource
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public AnonymousResource(byte id, string name)
        {
            this.Id = id;
            this.Name = name.RemoveSpaceCharacter();
        }
    }

    public class QualityResource : AnonymousResource
    {
        public QualityResource(byte id, string name) : base(id, name)
        {
        }
    }

    public class TurnFeeResource : AnonymousResource
    {
        public TurnFeeResource(byte id, string name) : base(id, name)
        {
        }
    }
}
