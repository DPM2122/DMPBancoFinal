using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMPBANCOFINAL
{
    /// <summary>
    /// Bank Account demo class.
    /// </summary>
    public class DMPBanco
    {
        private string mNombre;
        private double mSaldo;
        private bool mCongelada = false;
        private DMPBanco()
        {
        }
        public DMPBanco(string Nombre, double Saldo)
        {
            mNombre = Nombre;
            mSaldo = Saldo;
        }
        public string Nombre
        {
            get { return mNombre; }
        }
        public double Saldo
        {
            get { return mSaldo; }
        }
        public const string CantidadMayorQueSaldo = "La cant no puede ser > que el saldo";
        public const string CantidadMenorCero = "La cant no puede ser menor que 0";
        public void Debit(double cantidad)
        {
          
            if (mCongelada)
            {
                throw new Exception("Account frozen");
            }
            if (cantidad > mSaldo)
            {
                throw new ArgumentOutOfRangeException("cantidad", cantidad, CantidadMayorQueSaldo);
            }
            if (cantidad < 0)
            {
                throw new ArgumentOutOfRangeException("cantidad", cantidad, CantidadMenorCero);
            }

            mSaldo -= cantidad; // código intencionadamente incorrecto
        }
        public void Credit(double cantidad)
        {
            if (mCongelada)
                throw new Exception("Account frozen");
            if (cantidad < 0)
                throw new ArgumentOutOfRangeException("cantidad");
            mSaldo += cantidad;
        }

        public void FreezeAccount()
        {
            mCongelada = true;
        }

        public void UnfreezeAccount()
        {
            mCongelada = false;
        }

        public static void Main()
        {
            DMPBanco ba = new DMPBanco("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Saldo);
        }
    }
}
