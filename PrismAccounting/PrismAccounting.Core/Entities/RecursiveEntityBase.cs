using PrismAccounting.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrismAccounting.Core.Entities;
public abstract class RecursiveEntityBase<TEntity> : RecursiveEntityBase<DefaultId, TEntity>
  where TEntity : RecursiveEntityBase<DefaultId, TEntity>, IRecursiveEntity<DefaultId, TEntity>, new()
{
  protected RecursiveEntityBase()
  {
    //Id = Guid.NewGuid();
  }
  protected RecursiveEntityBase(String name = "root", TEntity parent = null) : base(name, parent)
  {
    // Id = Guid.NewGuid();
  }
}
public abstract class RecursiveEntityBase<TId, TEntity> : AuditableEntityBase<TId>, IRecursiveEntity<TId, TEntity>
  where TEntity : RecursiveEntityBase<TId, TEntity>, IRecursiveEntity<TId, TEntity>, new()
{
  protected RecursiveEntityBase()
  {

  }
  protected RecursiveEntityBase(string name = "root", TEntity parent = null)
  {
    ParentId = parent is null ? parent.Id : default;
    Name = name;
    Level = parent.Level + 1;
  }

  #region Class Peoperities
  public string Name { get; set; }
  public TId? ParentId { get; set; }
  public virtual TEntity? Parent { get; set; }
  public virtual List<TEntity>? Children { get; set; }
  public int Level { get; set; } = 0;
  public Int32 GetLevel => Level;
  public string HierarchicalId { get; set; } = "/";
  public string HierarchicalNames { get; set; } = "/";
  public bool IsRoot { get; set; } = false;
  public bool IsLeaf { get; set; } = false;
  /// <summary>
  ///   Gets or sets the index of this node in the
  ///   collection of children nodes of its parent.
  /// </summary>
  /// 
  public int Index { get; set; }
  #endregion


  #region Public Methods
  // TODO Methods
  public virtual TEntity AddChild(string name)
  {
    IsLeaf = false;
    if (Children == null) Children = new();
    var child = Create(name, (TEntity)this);
    child.Level = Level+1;
    child.IsLeaf = true;
    child.IsRoot = false;
    child.Index = Children.Max(e => e.Index)+1;
    Children.Add(child);
    return child;
  }
  public virtual TEntity AddSibling(string name)
  {
    return Parent.AddChild(name);
  }
  /// <summary>
  ///   Gets the next sibling of this node (the node
  ///   immediately next to it in its parent's collection).
  /// </summary>
  /// 
  public TEntity Next
  {
    get
    {
      if (Parent == null)
        return null;
      if (Index + 1 >= Parent.Children.Count)
        return null;
      return Parent.Children[Index + 1];
    }
  }

  /// <summary>
  ///   Gets the previous sibling of this node.
  /// </summary>
  /// 
  public TEntity Previous
  {
    get
    {
      if (Index == 0)
        return null;
      return Parent.Children[Index - 1];
    }
  }
  // public TEntity GetDirectAncestor(TId n)
  public TEntity GetAncestor()
  {
    return this.Parent;
  }

  // public SortedList<int, TEntity> GetAllAncestor(TId n)
  public List<TEntity> GetAllAncestors()
  {
    throw new NotImplementedException();
  }

  public List<TEntity> GetDescendants()
  {
    throw new NotImplementedException();
  }
  public List<TEntity> GetAllDescendants()
  {
    SortedList<int, TEntity> DescendantsIds = new SortedList<int, TEntity>();
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

  protected virtual void GenerateHierarchy()
  {
    if (ParentId != null && Parent != null)
    {
      HierarchicalId = $"{Parent.HierarchicalId}/{Parent.Id}";
      HierarchicalNames = $"{Parent.HierarchicalNames}/{Parent.Name}";
    }
    else
    {
      HierarchicalId = "/";
      HierarchicalNames = "/";
    }
  }


  ////? Gets the next sibling tree node.
  //public TEntity? Next() {
  //  int idx = Parent.Children.IndexOf((TEntity)this);
  //  if (Parent.Children.Count > idx + 1)
  //  {
  //    return Parent.Children[idx + 1];
  //  }
  //  return null;
  //}
  #endregion

  #region Private Methods
  private SortedList<int, TEntity> GetAllParents(TEntity entity, SortedList<int, TEntity> Parents, int lvl = 0)
  {
    if (entity.Parent == null) return Parents;
    Parents.Add(lvl, entity.Parent);
    return GetAllParents(entity.Parent, Parents, lvl++);
  }
  private List<TEntity> GetAllChildren(TEntity entity, List<TEntity> Children, int lvl = 0)
  {
    if (entity.Children == null || entity.Children?.Count == 0) return Children;
    foreach (var child in Children)
    {
      Children.Add(entity.Parent);
      GetAllChildren(entity.Parent, Children, lvl + 1);
    }
    return Children;
  }
  #endregion


  #region Static Methods
  public static TEntity CreateTree(string name)
  {
    TEntity node = new TEntity();
    node.Name = name;
      node.IsRoot = true;
      node.IsLeaf = false;
    node.GenerateHierarchy();
    return node;
  }
  public static TEntity Create(string name, TEntity? parent = null)
  {
    TEntity node = new TEntity();
    node.Name = name;
    if (parent is not null)
    {
      node.ParentId = parent.Id;
      node.Parent = parent;
      parent.IsLeaf = false;
      node.IsRoot = false;
      node.IsLeaf = true;
    }
    else
    {
      node.IsRoot = true;
      node.IsLeaf = false;
    }
    node.GenerateHierarchy();
    return node;
  }

  #endregion
}
