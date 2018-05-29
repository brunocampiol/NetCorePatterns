using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCorePatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePatterns.Test.Singleton
{
    [TestClass]
    public class SingletonSealedDisposableClassTest
    {
        [TestMethod]
        public void SingletonSealedDisposableClass_OneInstance_AreSame()
        {
            // Assamble
            SingletonSealedDisposableClass first = SingletonSealedDisposableClass.Instance;
            SingletonSealedDisposableClass second = SingletonSealedDisposableClass.Instance;

            // Act

            // Assert
            Assert.AreSame(first, second);
        }

        [TestMethod]
        public void SingletonSealedDisposableClass_OneInstance_AreEqual()
        {
            // Assamble
            SingletonSealedDisposableClass first = SingletonSealedDisposableClass.Instance;
            SingletonSealedDisposableClass second = SingletonSealedDisposableClass.Instance;

            // Act
            first.SomeValue++;

            // Assert
            Assert.AreEqual(first.SomeValue, second.SomeValue);

            // Act
            second.SomeValue++;

            // Assert
            Assert.AreEqual(first.SomeValue, second.SomeValue);

            // They should be always same
            Assert.AreSame(first, second);
        }
    }
}
