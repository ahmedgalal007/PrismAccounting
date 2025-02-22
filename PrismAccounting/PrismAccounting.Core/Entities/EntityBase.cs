using System;
using PrismAccounting.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrismAccounting.Core.Entities;
public class EntityBase : EntityBase<DefaultId>
{
}

public class EntityBase<TId>
{
    public TId Id { get; set; }
  [NotMapped]
    public List<IDomainEvent> Events { get; set; }
}

