using Moq;
using PrismAccounting.Core.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Xunit;

namespace PrismAccounting.Core.Tests.Entities
{
  public class RecursiveEntity1Tests
  {
    private MockRepository mockRepository;



    public RecursiveEntity1Tests()
    {
      this.mockRepository = new MockRepository(MockBehavior.Strict);

    }

    private RecursiveEntity1 CreateRecursiveEntity1()
    {
      return new RecursiveEntity1();
    }
    private RecursiveEntity1 CetTree()
    {
      var root = RecursiveEntity1.CreateTree("root");

      var lvl11 = root.AddChild("lvl11");
      var lvl12 = root.AddChild("lvl12");
      var lvl211 = lvl11.AddChild("lvl211");
      var lvl212 = lvl11.AddChild("lvl212");
      var lvl221 = lvl12.AddChild("lvl221");
      var lvl222 = lvl12.AddChild("lvl222");

      return root;
    }
    private RecursiveEntity1 CreateRecursiveEntity1( string name, RecursiveEntity1 parent)
    {
      return new RecursiveEntity1(name, parent);
    }

    [Fact]
    public void ItSouldREturnNameOfThirdGeneration()
    {
      // Arrange
      var root = this.CetTree();
      var child = root.Children[0].Children[0];

      // Act

      // Assert
      Assert.True(false);
      this.mockRepository.VerifyAll();
    }
  }



  public class RecursiveEntity1 : RecursiveEntityBase<RecursiveEntity1>
  {
    public RecursiveEntity1() : base()
    {

    }
    public RecursiveEntity1(String name, RecursiveEntity1 parent) : base(name, parent)
    {
    }
  }
}
