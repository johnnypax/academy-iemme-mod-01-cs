using Lez03_07_InfoHidingIncapsulamento.Classes;

namespace Lez03_07_InfoHidingIncapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Automobile peugeot = new Automobile();
            //peugeot.marca = "Peugeot";

            //Automobile bmw = new Automobile();
            //bmw.marca = "BMW";
            //bmw.cilindrata = 2400;

            //Automobile? tesla = null;

            //Moto honda = new Moto()
            //{
            //    modello = "XADV",
            //    cilindrata = -750
            //};

            //Moto honda = new Moto();
            //honda.setCilindrata(750);

            //Console.WriteLine(honda.getCilindrata());

            //Monopattino xiao = new Monopattino();
            //xiao.Marca = "Xiaomi";
            ////xiao.VelMax = 60.0f;          //NO
            //xiao.NumPersone = 3;

            //Console.WriteLine(xiao.Marca);
            //Console.WriteLine(xiao.VelMax);
            //Console.WriteLine(xiao.NumPersone);

            Bicicletta nukeproof = new Bicicletta();
            nukeproof.HasCampanello = true;

            Bicicletta commencal = new Bicicletta("Commençal", "Allmountain", false);

        }
    }
}