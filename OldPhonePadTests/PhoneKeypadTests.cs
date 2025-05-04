using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldPhonePad;
using System;

namespace OldPhonePadTests
{
    [TestClass]
    public class PhoneKeypadTests
    {
        [TestMethod]
        public void OldPhonePad_SingleCharacter_ReturnsCorrectLetter()
        {
            string input = "2#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("A", result);
        }
        
        [TestMethod]
        public void OldPhonePad_MultipleConsecutivePresses_ReturnsCorrectLetter()
        {
            string input = "222#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("C", result);
        }
        
        [TestMethod]
        public void OldPhonePad_SpaceForPause_ReturnsCorrectString()
        {
            string input = "2 2#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("AA", result);
        }
        
        [TestMethod]
        public void OldPhonePad_Backspace_RemovesLastCharacter()
        {
            string input = "227*#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("A", result);
        }
        
        [TestMethod]
        public void OldPhonePad_MultipleBackspaces_RemovesMultipleCharacters()
        {
            string input = "2277**#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("A", result);
        }
        
        [TestMethod]
        public void OldPhonePad_ComplexExample_ReturnsCorrectString()
        {
            string input = "4433555 555666#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("HELLO", result);
        }
        
        [TestMethod]
        public void OldPhonePad_TuringExample_ReturnsCorrectString()
        {
            string input = "8 88777444666*664#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("TURING", result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OldPhonePad_MissingEndSymbol_ThrowsArgumentException()
        {
            string input = "123";
            PhoneKeypad.OldPhonePad(input);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OldPhonePad_EmptyInput_ThrowsArgumentException()
        {
            string input = "";
            PhoneKeypad.OldPhonePad(input);
        }
        
        [TestMethod]
        public void OldPhonePad_UnrecognizedCharacters_IgnoresThem()
        {
            string input = "234#";
            string result = PhoneKeypad.OldPhonePad(input);
            Assert.AreEqual("ADG", result);
        }
    }
}
