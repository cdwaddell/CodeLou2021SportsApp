using System;
using System.Collections.Generic;
using Xunit;

namespace SportApp.test
{

    public class GenericTests
    {
        public string DoSomething(string input)
        {
            return $"goodbye {input}";
        }

        [Fact]
        public void ActionDelegates()
        {
            var consoleOutputDictionary = new Dictionary<string, Func<string, string>>();
            consoleOutputDictionary.Add("1", input => $"hello {input}");
            consoleOutputDictionary.Add("2", DoSomething);
            var firstOutput = consoleOutputDictionary["1"]("Daniel");
            var secondOutput = consoleOutputDictionary["2"]("Daniel");

            Assert.Equal("hello Daniel", firstOutput);
            Assert.Equal("goodbye Daniel", secondOutput);
        }

        [Fact]
        public void TimespanTest(){
            var startDate = new DateTime(1980, 4, 11, 1, 0, 0);
            var endDate = new DateTime(2020, 1, 21, 13, 45, 23);
            
            var years = endDate.Year - startDate.Year;
            var months = endDate.Month - startDate.Month;
            var span = endDate - startDate;
            if (months < 0)
            {
                months += 12;
                years--; // add 1 year to months, and remove 1 year from years.
            }

            Assert.Equal(39, years);
            Assert.Equal(9, months);
        }
    }
}
