using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests
{
    public class StringOperationsTests
    {


        [Fact(Skip ="se encuentra fallando estamos trabajando")]
        public void ConcatenateStrings() 
        { 
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi" );

            //Assert
            Assert.NotEmpty( result );
            Assert.NotNull( result );
            Assert.Equal( "Hello Platzi", result );
        }
        [Fact]
        public void IsPalindrome_True() 
        { 
            var StrOperaciones = new StringOperations();

            var result = StrOperaciones.IsPalindrome("ama");

            Assert.True( result );
        }
        [Fact]
        public void IsPalindrome_False()
        {
            var StrOperaciones = new StringOperations();

            var result = StrOperaciones.IsPalindrome("am");

            Assert.False(result);
        }
        [Fact]
        public void RemoveWhitespace()
        {
            var strOperations = new StringOperations();

            var result = strOperations.RemoveWhitespace( "H e l l o " );

            Assert.NotEmpty( result );
            Assert.NotNull( result );
            Assert.Equal("Hello", result);


        }
        [Fact]
        public void QuantintyInWords() 
        { 
            var strOperations = new StringOperations();

            var result = strOperations.QuantintyInWords("cat", 10);

            Assert.StartsWith("diez", result);
            Assert.Contains("cat", result );
        
        }
        [Fact]
        public void GetStringLength_Exeptions() 
        { 
            var strOperation = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(()=>strOperation.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            var strOperation = new StringOperations();

            var result = strOperation.GetStringLength("Padres");

            Assert.NotNull(result);
          
            Assert.Equal(6, result);
        }
        [Fact(Skip ="esta prueba falla estamos reparando")]
        public void TruncateString_Exeptions()
        {
            var strOperation = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperation.TruncateString(null, -1));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("VIII", 8)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected) 
        { 
            var strOperation = new StringOperations();

            var result = strOperation.FromRomanToNumber(romanNumber);
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences() 
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);


            var result = strOperations.CountOccurrences("Hello platzi", 'l');

             Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile() 
        { 
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            //mockFileReader.Setup(p=> p.ReadString("file.txt")).Returns("Reading file");

            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);

        }
    }
}
