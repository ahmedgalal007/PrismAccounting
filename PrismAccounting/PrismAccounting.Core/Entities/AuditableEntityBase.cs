using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Core.Entities;
public class AuditableEntityBase: AuditableEntityBase<DefaultId>
{
}
public class AuditableEntityBase<TId> : EntityBase<TId>
{
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
