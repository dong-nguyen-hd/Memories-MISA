using MISA.Core.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Extensions.Validation
{
    /// <summary>
    /// Lớp tuỳ biến ValidationAttribute: xác định xem giá trị của Quality nhập vào có hợp lệ
    /// CreatedBy: NDDONG (14/06/2021)
    /// </summary>
    class QualityAttribute : ValidationAttribute
    {
        #region Property
        public string Message { get; set; } = string.Format("Giá trị Quality không hợp lệ.");
        #endregion
        #region Constructor
        public QualityAttribute() : base()
        {
        }
        public QualityAttribute(string errorMessage)
        {
            this.Message = errorMessage;
        }
        #endregion

        #region Method
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {   
                if(value is null)
                    return ValidationResult.Success;

                if (Enum.IsDefined(typeof(eQuality), value))
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
