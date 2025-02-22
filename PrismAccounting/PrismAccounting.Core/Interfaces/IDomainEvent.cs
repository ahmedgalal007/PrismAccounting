using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Core.Interfaces;
public interface IDomainEvent
{
  public string Name { get; set; }
  public DateTime Created { get; set; }
}
