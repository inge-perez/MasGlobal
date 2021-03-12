using Business;
using Business.Contracts;
using Business.DTOs;
using Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void VerifyFactory()
        {
            //Preparar
            string type = "HourlySalaryEmployee";
            //Prueba
             var result = Factory.Creator(type);
            //Verificar
            Assert.IsInstanceOfType(result, typeof(HourlySalaryEmployee));
        }
    }
    
}
