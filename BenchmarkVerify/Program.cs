
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
        private StringJoinComparision join = new();
        string[] str = new string[] { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c","a", "b", "c",
            "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", 
            "a", "b", "c", "a", "b", "c" };

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
