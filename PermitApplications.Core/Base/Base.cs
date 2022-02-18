using System.ComponentModel.DataAnnotations.Schema;

namespace PermitApplications.Core.BaseModel.Base
{
    public class Base : IBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
