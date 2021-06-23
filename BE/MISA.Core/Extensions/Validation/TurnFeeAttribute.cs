using MISA.Core.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Extensions.Validation
{
    /// <summary>
    /// Lớp tuỳ biến ValidationAttribute: xác định xem giá trị của TurnFee nhập vào có hợp lệ
    /// CreatedBy: NDDONG (14/06/2021)
    /// </summary>
    public class TurnFeeAttribute : ValidationAttribute
    {
        #region Property
        public string Message { get; set; } = string.Format("Giá trị Turn Fee không hợp lệ.");
        #endregion
        #region Constructor
        public TurnFeeAttribute():base()
        {
        }
        public TurnFeeAttribute(string errorMessage)
        {
            this.Message = errorMessage;
        }
        #endregion

        #region Method
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (Enum.IsDefined(typeof(eTurnFee), value))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(Message);
            }
            catch (Exception)
            {
                return new ValidationResult(Message);
            }
        }
        #endregion
    }
}
