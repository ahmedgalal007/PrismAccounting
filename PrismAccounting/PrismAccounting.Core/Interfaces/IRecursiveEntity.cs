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
  public int Index { get; set; }
  int GetLevel { get; }
  TEntity Next { get; }
  TEntity Previous { get; }

  // TODO Methods
  TEntity AddChild(string name);
  TEntity AddSibling(string name);
  // TEntity GetDirectAncestor(TId n);
  TEntity GetAncestor();
  // SortedList<int, TEntity> GetAllAncestor(TId n);
  List<TEntity> GetAllAncestors();
  List<TEntity> GetDescendants();
  List<TEntity> GetAllDescendants();

  Uri GetReparentedValue(TId? oldRoot, TId? newRoot);
  bool IsDescendantOf(TId? parent);

}
