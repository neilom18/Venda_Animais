using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Venda_Animais
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-br", true);
            Animal animal = new Animal();
            animal.ListarAnimais("base.csv");
            animal.TabelarPreco("gado.csv");
            animal.AdicionarPreco();
            animal.Relatorio();
        }
    }
}
