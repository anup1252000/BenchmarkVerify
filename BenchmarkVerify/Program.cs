
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace BenchmarkVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BootStrapper>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RPlotExporter]
    public class BootStrapper
    {
        private readonly StringJoinComparision join = new();
        private string[] str = Array.Empty<string>();
        private readonly string[] seed = new[] { "a", "b", "c" };

        [Params(0, 1, 3, 30, 300)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            str = new string[Size];
            for (int i = 0; i < Size; i++)
            {
                str[i] = seed[i % seed.Length];
            }
        }

        [Benchmark]
        public void NormalJoin()
        {
            join.NormalJoin(str);
        }

        [Benchmark]
        public void ConcatJoin()
        {
            join.ConcatString(str);
        }

        [Benchmark]
        public void SBJoin()
        {
            join.StringBuilderVerify(str);
        }
    }

    public class StringJoinComparision
    {
        public string NormalJoin(string[] str)
        {
            string temp = string.Empty;
            temp += String.Join(',', str);
            return temp;
        }

        public string ConcatString(string[] str)
        {
            return String.Concat(str);
        }

        public string StringBuilderVerify(string[] str)
        {
            StringBuilder sb = new();
            sb.AppendJoin(",", str);
            return sb.ToString();
        }
    }
}
