using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace Fixed.Benchmark
{
  [ClrJob(baseline: true)]
  public class Benchmark
  {
    public static void Main(string[] args)
    {
      BenchmarkRunner.Run<Benchmark>();
    }
    [Benchmark]
    public void TripleAdd_q8_24()
    {
      var result = Data.q8_24 + 8;
      result = Data.q8_24 + 12;
      result = Data.q8_24 + 7;
    }
    [Benchmark]
    public void TripleMultiply_q16_16()
    {
      var result = Data.q16_16 * 4;
      result = result * 3;
      result = result * 2;
    }
    [Benchmark]
    public void TripleDivide_q24_8()
    {
      var result = Data.q24_8 / 2;
      result = Data.q24_8 / 4;
      result = Data.q24_8 / 3;
    }
    [Benchmark]
    public void GauseEliminationQ16_16()
    {
      Gause<Q16_16>.Eliminate(Data.q16_Matrix);
    }
  }
  public static class Data
  {
    public static Fixed<Q8_24> q8_24 = new Fixed<Q8_24>(8);
    public static Fixed<Q16_16> q16_16 = new Fixed<Q16_16>(16);
    public static Fixed<Q24_8> q24_8 = new Fixed<Q24_8>(24);

    public static Fixed<Q8_24>[,] q8_Matrix =
    {
      {q8_24 + 2, q8_24, q8_24 * 2},
      {q8_24, q8_24 + 4, q8_24},
      {q8_24 * 3, q8_24, q8_24 + 6}
    };
    public static Fixed<Q16_16>[,] q16_Matrix =
    {
      {q16_16 + 2, q16_16, q16_16 * 2},
      {q16_16, q16_16 + 4, q16_16},
      {q16_16 * 3, q16_16, q16_16 + 6}
    };
    public static Fixed<Q24_8>[,] q24_Matrix =
    {
      {q24_8 + 2, q24_8, q24_8 * 2},
      {q24_8, q24_8 + 4, q24_8},
      {q24_8 * 3, q24_8, q24_8 + 6}
    };
  }
  public static class Gause<Q> where Q : QType<Q>
  {
    private static Fixed<Q>[,] Matrix;
    private static void addRowToRow(int row1, int row2, bool negative)
    {
      for (int i = 0; i < Matrix.GetLength(1); i++)
      {
        if (negative) Matrix[row2, i] -= Matrix[row1, i];
        else Matrix[row2, i] += Matrix[row1, i];
      }
    }
    private static void multiplyRow(int row, Fixed<Q> multiplier)
    {
      for (int i = 0; i < Matrix.GetLength(1); i++)
        Matrix[row, i] *= multiplier;
    }
    private static void switchRows(int row1, int row2)
    {
      for (int i = 0; i < Matrix.GetLength(1); i++)
      {
        var helper = Matrix[row1, i];
        Matrix[row1, i] = Matrix[row2, i];
        Matrix[row2, i] = helper;
      }
    }
    public static void Eliminate(Fixed<Q>[,] matrix)
    {
      Matrix = matrix;
      for (int j = 0; j < Matrix.GetLength(1); j++)
      {
        for (int i = 1 + j; i < Matrix.GetLength(0); i++)
        {
          var multiplier = Matrix[j, j];
          multiplyRow(j, Matrix[i, j]);
          multiplyRow(i, multiplier);
          addRowToRow(j, i, true);
          multiplyRow(j, 1 / multiplier);
        }
      }
    }
  }
}
