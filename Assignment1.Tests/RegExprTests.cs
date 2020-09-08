using System.Linq;
using Xunit;

namespace Assignment1
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_valid()
        {
            //Arrange
            string[] lines = {"hejsa du", "Hvad laver du"};

            //Act
            var actual = RegExpr.SplitLine(lines).Count();

            //Assert
            Assert.Equal(5, actual);
        }

        [Fact]
        public void SplitLine_valid2()
        {
            //Arrange
            string[] lines = {"Jeg hedder Simone", "Vi er 2 i gruppen"};

            //Act
            var actual = RegExpr.SplitLine(lines).Count();

            //Assert
            Assert.Equal(8, actual);
        }

        [Fact]
        public void SplitLine_invalid()
        {
            //Arrange
            string[] lines = {""};

            //Act
            var actual = RegExpr.SplitLine(lines).Count();

            //Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Resolutions_valid()
        {
            //Arrange
            var strings = "4098x4987";

            //Act
            var actual = RegExpr.Resolutions(strings).ElementAt(0);

            //Assert
            Assert.Equal((4098, 4987), actual);
        }

        [Fact]
        public void Resolutions_valid2()
        {
            //Arrange
            var strings = "2x123456";

            //Act
            var actual = RegExpr.Resolutions(strings).ElementAt(0);

            //Assert
            Assert.Equal((2, 123456), actual);
        }

        [Fact]
        public void InnerText_valid()
        {
            //Arrange
            var html = "<k>Der er 2 i gruppen</k>";
            var tag = "<k>";

            //Act
            var actual = RegExpr.InnerText(html, tag).ElementAt(0);

            //Assert
            Assert.Equal("Der er 2 i gruppen", actual);
        }

        [Fact]
        public void InnerText_valid2()
        {
            //Arrange
            var html = "<k> Der er (cirka) 170 på linjen </k>";
            var tag = "<k>";

            //Act
            var actual = RegExpr.InnerText(html, tag).ElementAt(0);

            //Assert
            Assert.Equal(" Der er (cirka) 170 på linjen ", actual);
        }

        [Fact]
        public void InnerText_NestedTags_valid()
        {
            //Arrange
            var html = "<k> Der er (cirka) 170 på linjen <p> ITU </p> </k>";
            var tag = "<k>";

            //Act
            var actual = RegExpr.InnerText(html, tag).ElementAt(0);

            //Assert
            Assert.Equal(" Der er (cirka) 170 på linjen ITU", actual);
        }
    }
}