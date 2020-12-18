using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelLayer.Business;
using ModelLayer.Data;
namespace TestModelLayer
{
    public class Program
    {

        static void Main(string[] args)
        {

            Dbal myDbal = new Dbal("Escp_Game", "root", "", "localhost");

            Client myCLient = new Client();

            DaoClient theDaoClient = new DaoClient(myDbal);
            Console.WriteLine(theDaoClient.SelectById(1));

            DaoVille theDaoVille = new DaoVille(myDbal);
            Ville myVille = new Ville(1, "Paris");
            theDaoVille.Insert(myVille);


            Console.ReadLine();
        }
    }
}

