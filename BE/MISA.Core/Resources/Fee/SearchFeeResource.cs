using MISA.Core.Extensions;
using System;

namespace MISA.Core.Resources.Fee
{
    /// <summary>
    /// Lớp DTO: Đối tượng tìm kiếm, lọc
    /// </summary>
    /// CreatedBy: NDDONG (14/06/2021)
    public class SearchFeeResource : QueryResource
    {
        #region Property
        private string _feeName;
        public string FeeName { get => _feeName; set => _feeName = value.RemoveSpaceCharacter(); }

        public Guid? FeeGroupId { get; set; }

        public Guid? FeeRangeId { get; set; }

        public byte? TurnFeeId { get; set; }
        public int? AmountOfFee { get; set; }

        public bool Follow { get; set; }
        #endregion

        #region Constructor
        public SearchFeeResource(int page, int pageSize) : base(page, pageSize)
        {

        }
        #endregion
    }
}
