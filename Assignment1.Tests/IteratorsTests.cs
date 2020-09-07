using System;
using System.Collections.Generic;
using Xunit;

namespace BDSA2019.Assignment01.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Flatten_iterator_valid()
        {
            //Arrange
            IEnumerable<IEnumerable<int>> input = new List<List<int>>()
            {
                new List<int>() { 1, 2},
                new List<int>() { 3, 4},
                new List<int>() { 5, 6}
            };

            //Act
            var actual = Iterators.Flatten(input);

            //Assert
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5, 6 }, actual);
        }

        [Fact]
        public void Filter_Iterator_valid()
        {
            //Arrange
            int[] numbers = { 0, 1, 2, 3 };
            Predicate<int> predicate = x => x > 2;

            //Act
            var actual = Iterators.Filter(numbers, predicate);

            //Assert
            Assert.Equal(new List<int> { 3 }, actual);
        }
    }
}
