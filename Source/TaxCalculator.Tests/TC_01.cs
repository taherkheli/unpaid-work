using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TaxCalculator.Tests
{
  [TestClass]
  public class TC_01
  {
    private Kommune _sut;

    [DataTestMethod]
    [DataRow(2016, 1, 1, 0.1)]
    [DataRow(2016, 5, 2, 0.4)]
    [DataRow(2016, 7, 10, 0.2)]
    [DataRow(2016, 3, 16, 0.2)]
    public void TestMethod1(int y, int m, int d, double expected)
    {
      var taxRules = new List<TaxRule> {
        new TaxRule(new DateTime(2016, 01, 01), new DateTime(2016, 12, 31), RuleType.Yearly, 0.2),
        new TaxRule(new DateTime(2016, 05, 01), new DateTime(2016, 5, 31), RuleType.Monthly, 0.4),
        new TaxRule(new DateTime(2016, 01, 01), new DateTime(2016, 01, 01), RuleType.Daily, 0.1),
        new TaxRule(new DateTime(2016, 12, 25), new DateTime(2016, 12, 25), RuleType.Daily, 0.1)
      };

      _sut = new Kommune("Copenhagen", taxRules);

      var actual = _sut.Calculate(new DateTime(y, m, d)); 

      Assert.AreEqual(expected, actual, "OK");
    }
  }
}
