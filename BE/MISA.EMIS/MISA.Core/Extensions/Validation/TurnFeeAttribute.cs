using MISA.Core.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Extensions.Validation
{
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
