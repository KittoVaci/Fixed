namespace Cuni.Arithmetics.FixedPoint
{
  public class QType<T> where T : QType<T>
  {
    internal static int FractionalBits;
  }

  public sealed class Q8_24 : QType<Q8_24>
  {
    static Q8_24()
    {
      FractionalBits = 24;
    }
  }

  public sealed class Q16_16 : QType<Q16_16>
  {
    static Q16_16()
    {
      FractionalBits = 16;
    }
  }

  public sealed class Q24_8 : QType<Q24_8>
  {
    static Q24_8()
    {
      FractionalBits = 8;
    }
  }

  public struct Fixed<Q> where Q : QType<Q>
  {
    private struct FpValue
    {
      public int Value;

      public FpValue(int value) => Value = value;
    }

    private readonly int _value;

    static Fixed()
    {
      System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(Q).TypeHandle);
    }

    public Fixed(int integerValue) => _value = integerValue << QType<Q>.FractionalBits;

    private Fixed(FpValue fixedPointValue) => _value = fixedPointValue.Value;

    public Fixed<Q> Add(Fixed<Q> fixed2) => new Fixed<Q>(new FpValue(_value + fixed2._value));

    public Fixed<Q> Subtract(Fixed<Q> fixed2) => new Fixed<Q>(new FpValue(_value - fixed2._value));

    public Fixed<Q> Multiply(Fixed<Q> fixed2)
    {
      var result = _value * (long)fixed2._value;
      return new Fixed<Q>(new FpValue((int)(result >> QType<Q>.FractionalBits)));
    }

    public Fixed<Q> Divide(Fixed<Q> fixed2)
    {
      var result = (((long)_value) << QType<Q>.FractionalBits) / (long)fixed2._value;
      return new Fixed<Q>(new FpValue((int)result));
    }

    public static Fixed<Q> operator +(Fixed<Q> a, Fixed<Q> b)
    {
      var result = a.Add(b);
      return result;
    }
    public static Fixed<Q> operator -(Fixed<Q> a, Fixed<Q> b)
    {
      var result = a.Subtract(b);
      return result;
    }
    public static Fixed<Q> operator *(Fixed<Q> a, Fixed<Q> b)
    {
      var result = a.Multiply(b);
      return result;
    }
    public static Fixed<Q> operator /(Fixed<Q> a, Fixed<Q> b)
    {
      var result = a.Divide(b);
      return result;
    }

    public static explicit operator Fixed<Q>(Fixed<Q8_24> a)
    {
      return new Fixed<Q>(new FpValue(a._value >> (QType<Q8_24>.FractionalBits - QType<Q>.FractionalBits)));
    }

    public static explicit operator Fixed<Q>(Fixed<Q24_8> a)
    {
      return new Fixed<Q>(new FpValue(a._value << (QType<Q>.FractionalBits - QType<Q24_8>.FractionalBits)));
    }

    public static explicit operator Fixed<Q>(Fixed<Q16_16> a)
    {
      var shift = QType<Q16_16>.FractionalBits - QType<Q>.FractionalBits;
      if (shift > 0)
        return new Fixed<Q>(new FpValue(a._value >> shift));
      else
        return new Fixed<Q>(new FpValue(a._value << -shift));
    }

    public static implicit operator Fixed<Q>(int a)
    {
      return new Fixed<Q>(a);
    }

    public double ToDouble() => _value / (double)(1 << QType<Q>.FractionalBits);

    public override string ToString() => ToDouble().ToString();
  }
}
