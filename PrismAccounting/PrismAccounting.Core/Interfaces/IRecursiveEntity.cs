using PrismAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismAccounting.Core.Interfaces;
public interface IRecursiveEntity<TId, TEntity> where TEntity : RecursiveEntityBase<TId, TEntity>, IRecursiveEntity<TId, TEntity>, new()
{
  public string Name { get; set; }
  public TId ParentId { get; set; }
  public TEntity Parent { get; set; }
  public List<TEntity> Children { get; set; }

  public int Level { get; set; }
  public string HierarchicalId { get; set; }
  public string HierarchicalNames { get; set; }
  public bool IsRoot { get; set; }
  public bool IsLeaf { get; set; }

  // TODO Methods
  TEntity AddChild(string name);
  TEntity AddSibling(string name);
  // TEntity GetDirectAncestor(TId n);
  TEntity GetDirectAncestor();
  // SortedList<int, TEntity> GetAllAncestor(TId n);
  SortedList<int, TEntity> GetAllAncestor();
  List<TEntity> GetDirectDescendants(TId? child1, TId? child2);
  SortedList<int, TEntity> GetAllDescendant(TId? child1, TId? child2);
  int GetLevel();
  Uri GetReparentedValue(TId? oldRoot, TId? newRoot);
  bool IsDescendantOf(TId? parent);
  TEntity Next();
}
