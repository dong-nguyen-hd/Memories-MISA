using MISA.Core.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Extensions.Validation
{
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
