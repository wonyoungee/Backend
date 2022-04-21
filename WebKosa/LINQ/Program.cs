using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Person>()
            {
                new Person() { Name = "홍길동", Age =20 },
                new Person() { Name ="김유신", Age=30 },
                new Person() { Name ="이순신", Age = 52},
                new Person() { Name ="유관순", Age = 40},
                new Person(){ Name ="아무개", Age=32},
                new Person(){ Name ="이병철", Age=15},
                new Person(){ Name ="정주영", Age = 22}
            };

            // 나이가 20살 이상인 사람
            //var firstobj = list.FirstOrDefault(p => p.Age >= 20);   // LINQ 명령어
            //var singleobj = list.SingleOrDefault(p => p.Age >=20);    // 만족하는 데이터 여러건 >> 예외발생!
            //Console.WriteLine(firstobj.Name);

            var firstobj = list.FirstOrDefault(p => p.Age == 20);   // LINQ 명령어
            Console.WriteLine(firstobj.Name);
            var singleobj = list.SingleOrDefault(p => p.Age ==20);  // 무조건 데이터 하나 or 디폴트
            Console.WriteLine(singleobj.Name);
        }
    }
}
