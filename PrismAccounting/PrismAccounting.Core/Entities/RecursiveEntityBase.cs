using PrismAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Core.Entities;
public class RecursiveEntityBase<TEntity>: RecursiveEntityBase<DefaultId, TEntity>
  where TEntity : RecursiveEntityBase<DefaultId, TEntity>, IRecursiveEntity<DefaultId, TEntity>, new()
{
}
public abstract class RecursiveEntityBase<TId, TEntity> : AuditableEntityBase<TId>, IRecursiveEntity<TId, TEntity>
  where TEntity: RecursiveEntityBase<TId, TEntity>, IRecursiveEntity<TId, TEntity>, new()
{
  public TId ParentId { get ; set; }
  public TEntity Parent { get; set; }
  public List<TEntity> Children { get; set; }

  public TEntity GetAncestor(TId n)
  {
    return this.Parent;
  }

  public TEntity GetDescendant(TId? child1, TId? child2)
  {
    throw new NotImplementedException();
  }

  public Int32 GetLevel()
  {
    throw new NotImplementedException();
  }

  public Uri GetReparentedValue(TId? oldRoot, TId? newRoot)
  {
    throw new NotImplementedException();
  }

  public Boolean IsDescendantOf(TId? parent)
  {
    throw new NotImplementedException();
  }
}
