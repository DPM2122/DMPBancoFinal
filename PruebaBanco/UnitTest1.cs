using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DMPBANCOFINAL;
using System.Collections.Generic;

namespace PruebaBanco
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaDatosCorrectos()
        { 
            double saldo = 11.99;
            double cantidad = 4.55;
            double esperado = 7.44;
            DMPBanco Prueba = new DMPBanco("Mr. Bryan Walton", saldo);
            // acción a probar
            Prueba.Debit(cantidad);
            // afirmación de la prueba (valor esperado Vs. Valor obtenido)
    
            Assert.AreEqual(esperado, Prueba.Saldo, 0.01,  "Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "La cantidad no puede ser mayor que el saldo")]
        public void PruebaCantidadErronea()
        {
            double saldo = 11.99;
            double cantidad = 15.55;
            DMPBanco Prueba = new DMPBanco("Mr. Bryan Walton", saldo);
            Prueba.Debit(cantidad);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "La cuenta está congelada")]
        public void PruebaCuentaCongelada()
        {
            double saldo = 11.99;
            double cantidad = 15.55;
            DMPBanco Prueba = new DMPBanco("Mr. Bryan Walton", saldo);
            Prueba.FreezeAccount();
            Prueba.Debit(cantidad);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "La cantidad es erronea")]
        public void CantidadErronea()
        {
            double saldo = 11.99;
            double cantidad = -15.55;
            DMPBanco Prueba = new DMPBanco("Mr. Bryan Walton", saldo);
            Prueba.Debit(cantidad);
        }


        [TestMethod]
        public void  PruebaContidadErronea()
        {
            double saldo = 11.99;
            double cantidad = -15.55;
            DMPBanco Prueba = new DMPBanco("Mr. Bryan Walton", saldo);
            try
            {
                Prueba.Debit(cantidad);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "La cantidad es errónea");
                return;
            }
            Assert.Fail("Deberia haber fallado");



        }
    }
}
