using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MISA.Core.Resources
{
    public sealed class DeleteResource
    {
        [MaxLength(100)]
        [Display(Name = "List Delete")]
        public List<Guid> ListDelete { get; set; }
    }

    public sealed class DetailDelete
    {
        public Guid Id { get; set; }
        public string Error { get; set; }

        public DetailDelete(Guid id, string error)
        {
            this.Id = id;
            this.Error = error;
        }
    }
}
