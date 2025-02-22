using PrismAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Core.Interfaces;
public interface IRecursiveEntity<TId, TEntity> where TEntity : RecursiveEntityBase<TId, TEntity>, IRecursiveEntity<TId, TEntity>, new()
{
  public TId ParentId { get; set; }
  public TEntity Parent { get; set; }
  public List<TEntity> Children { get; set; }
  TEntity GetAncestor(TId n);
  TEntity GetDescendant(TId? child1, TId? child2);
  int GetLevel();
  Uri GetReparentedValue(TId? oldRoot, TId? newRoot);
  bool IsDescendantOf(TId? parent);
}
