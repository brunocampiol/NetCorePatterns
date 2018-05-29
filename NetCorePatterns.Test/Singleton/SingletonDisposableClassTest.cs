using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCorePatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCorePatterns.Test.Singleton
{
    [TestClass]
    public class SingletonDisposableClassTest
    {
        [TestMethod]
        public void SingletonDisposableClass_OneInstance_AreSame()
        {
            // Assamble
            SingletonDisposableClass first = SingletonDisposableClass.Instance;
            SingletonDisposableClass second = SingletonDisposableClass.Instance;

            // Act

            // Assert
            Assert.AreSame(first, second);
        }

        [TestMethod]
        public void SingletonDisposableClass_OneInstance_AreEqual()
        {
            // Assamble
            SingletonDisposableClass first = SingletonDisposableClass.Instance;
            SingletonDisposableClass second = SingletonDisposableClass.Instance;

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
