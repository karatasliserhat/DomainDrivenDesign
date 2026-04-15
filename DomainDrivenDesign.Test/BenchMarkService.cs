using BenchmarkDotNet.Attributes;

namespace DomainDrivenDesign.Test
{
    public class BenchMarkService
    {

        [Benchmark(Baseline = true)]
        public void Equals()
        {
            var testA1 = new Test1() { Id = Guid.NewGuid() };
            var testA2 = new Test1() { Id = testA1.Id };



            Console.WriteLine(testA1.Equals(testA2)); // True
        }

        [Benchmark]
        public void IEquatable()
        {
            var testB1 = new Test2() { Id= Guid.NewGuid() };
            var testB2 = new Test2() { Id= testB1.Id };
            Console.WriteLine(testB1.Equals(testB2)); // True

        }
        public class Test1
        {


            public Guid Id { get; set; }


            public override bool Equals(object? obj)
            {
                if (obj == null) return false;
                if (obj is not Test1 other) return false;
                if (GetType() != other.GetType()) return false;
                return Id == other.Id;
            }


        }

        public class Test2 : IEquatable<Test2>
        {
            public Guid Id { get; set; }

            public bool Equals(Test2? other)
            {
                if (other == null) return false;
                if (other is not Test2 other2) return false;
                if (GetType() != other.GetType()) return false;
                return Id == other.Id;
            }
        }

     

      
    }
}
