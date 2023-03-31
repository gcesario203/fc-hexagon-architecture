using System.ComponentModel.DataAnnotations.Schema;

namespace Adapters.Shared.Contracts
{
    public abstract class BaseEntityFrameworkModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}