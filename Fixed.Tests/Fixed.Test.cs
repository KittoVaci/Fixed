using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuni.Arithmetics.FixedPoint;

namespace Fixed.Tests
{
  [TestClass]
  public class Fixed_Q24_8
  {
    private Fixed<Q24_8> a = new Fixed<Q24_8>(24);
    private Fixed<Q24_8> b = new Fixed<Q24_8>(42);
    private Fixed<Q24_8> max = new Fixed<Q24_8>(1 << 23);
    private Fixed<Q24_8> negb = new Fixed<Q24_8>(-42);

    [TestMethod]
    public void SimpleConversionToQ16_16_Test()
    {
      //Act
      var result = (Fixed<Q16_16>)a;

      //Assert
      Assert.AreEqual((24).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void BoundConversionToQ16_16_Test()
    {
      //Act
      var result = (Fixed<Q16_16>)max;

      //Assert
      Assert.AreEqual((0).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void SimpleConversionToQ8_24_Test()
    {
      //Act
      var result = (Fixed<Q8_24>)a;

      //Assert
      Assert.AreEqual((24).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void BoundConversionToQ8_24_Test()
    {
      //Act
      var result = (Fixed<Q8_24>)max;

      //Assert
      Assert.AreEqual((0).ToString(), result.ToString()); //result test
    }


    [TestMethod]
    public void Add_additionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Add_additionOfSimpleNumbers_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Add_additionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Add_additionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Multiply_multiplicationOfnumbers_SideTestOfToString(a, b);
    }
    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Multiply_multiplicationOfnumbersOperator_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString(a, negb);
    }
    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString(a, negb);
    }

    [TestMethod]
    public void Divide_divisionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Divide_divisionOfSimpleNumbers_SideTestOfToString(a, b);
    }
    [TestMethod]
    public void Divide_divisionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q24_8>.Divide_divisionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }
  }



  [TestClass]
  public class Fixed_Q16_16
  {
    private Fixed<Q16_16> a = new Fixed<Q16_16>(24);
    private Fixed<Q16_16> b = new Fixed<Q16_16>(42);
    private Fixed<Q16_16> max = new Fixed<Q16_16>(32767);
    private Fixed<Q16_16> negb = new Fixed<Q16_16>(-42);


    [TestMethod]
    public void SimpleConversionToQ24_8_Test()
    {
      //Act
      var result = (Fixed<Q24_8>)a;

      //Assert
      Assert.AreEqual((24).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void BoundConversionToQ24_8_Test()
    {
      //Act
      var result = (Fixed<Q24_8>)max;

      //Assert
      Assert.AreEqual((32767).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void Add_additionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Add_additionOfSimpleNumbers_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Multiply_multiplicationOfnumbers_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString(a, negb);
    }
    [TestMethod]
    public void Divide_divisionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Divide_divisionOfSimpleNumbers_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Add_additionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Add_additionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Multiply_multiplicationOfnumbersOperator_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString(a, negb);
    }
    [TestMethod]
    public void Divide_divisionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q16_16>.Divide_divisionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }
  }


  [TestClass]
  public class Fixed_Q8_24
  {
    private Fixed<Q8_24> a = new Fixed<Q8_24>(24);
    private Fixed<Q8_24> b = new Fixed<Q8_24>(42);
    private Fixed<Q8_24> negb = new Fixed<Q8_24>(-42);

    [TestMethod]
    public void Add_additionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Add_additionOfSimpleNumbers_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_SideTestOfToString()
    {
      //Act
      var result = a.Multiply(b);

      //Assert
      Assert.AreEqual((unchecked((sbyte)(24 * 42))).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString()
    {
      var result = a.Multiply(negb);

      //Assert
      Assert.AreEqual((unchecked((sbyte)(24 * -42))).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void Divide_divisionOfSimpleNumbers_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Divide_divisionOfSimpleNumbers_SideTestOfToString(a, b);
    }


    [TestMethod]
    public void Add_additionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Add_additionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString(a, b);
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_SideTestOfToString()
    {
      //Act
      var result = a * b;

      //Assert
      Assert.AreEqual((unchecked((sbyte)(24 * 42))).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString()
    {
      var result = a * negb;

      //Assert
      Assert.AreEqual((unchecked((sbyte)(24 * -42))).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public void Divide_divisionOfSimpleNumbersOperator_SideTestOfToString()
    {
      TestsHelper<Q8_24>.Divide_divisionOfSimpleNumbersOperator_SideTestOfToString(a, b);
    }
  }





  public static class TestsHelper<Q> where Q : QType<Q>
  {
    [TestMethod]
    public static void Add_additionOfSimpleNumbers_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a.Add(b);

      //Assert
      Assert.AreEqual("66", result.ToString()); //result test
    }
    [TestMethod]
    public static void Add_additionOfSimpleNumbersOperator_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a + b;

      //Assert
      Assert.AreEqual("66", result.ToString()); //result test
    }

    [TestMethod]
    public static void Subtract_subtractionOfSimpleNumbers_resultIsNegaative_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a.Subtract(b);

      //Assert
      Assert.AreEqual((24 - 42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Subtract_subtractionOfSimpleNumbersOperator_resultIsNegaative_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a - b;

      //Assert
      Assert.AreEqual((24 - 42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Multiply_multiplicationOfnumbers_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a.Multiply(b);

      //Assert
      Assert.AreEqual((24 * 42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Multiply_multiplicationOfnumbersOperator_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a * b;

      //Assert
      Assert.AreEqual((24 * 42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Multiply_multiplicationOfnumbers_negativeResult_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a.Multiply(b);

      //Assert
      Assert.AreEqual((24 * -42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Multiply_multiplicationOfnumbersOperator_negativeResult_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = a * b;

      //Assert
      Assert.AreEqual((24 * -42).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Divide_divisionOfSimpleNumbers_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = b.Divide(a);

      //Assert
      Assert.AreEqual((42.0 / 24.0).ToString(), result.ToString()); //result test
    }

    [TestMethod]
    public static void Divide_divisionOfSimpleNumbersOperator_SideTestOfToString(Fixed<Q> a, Fixed<Q> b)
    {
      //Act
      var result = b / a;

      //Assert
      Assert.AreEqual((42.0 / 24.0).ToString(), result.ToString()); //result test
    }
  }
}
