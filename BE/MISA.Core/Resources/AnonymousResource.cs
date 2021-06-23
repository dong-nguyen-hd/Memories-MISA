using MISA.Core.Extensions;

namespace MISA.Core.Resources
{
    /// <summary>
    /// Lớp DTO: dùng kế thừa cho Quality và TurnFee
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
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

    /// <summary>
    /// Lớp DTO: dùng cho Quality
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public class QualityResource : AnonymousResource
    {
        public QualityResource(byte id, string name) : base(id, name)
        {
        }
    }

    /// <summary>
    /// Lớp DTO: dùng cho TurnFee
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public class TurnFeeResource : AnonymousResource
    {
        public TurnFeeResource(byte id, string name) : base(id, name)
        {
        }
    }
}
