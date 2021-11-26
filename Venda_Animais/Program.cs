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
        }
        public class Animal
        {
            private List<Animal> _lista = new List<Animal>();
            public decimal Peso { get;private set; }
            public int Id { get; private set; }
            public string Raca { get; private set; }
            public decimal Fator { get; private set; }
            public IReadOnlyList<Animal> Lista { get => _lista; }
            public void ListarAnimais(string arquivoCSV)
            {
                var patToFile = Path.Combine(Directory.GetCurrentDirectory(),arquivoCSV);
                var list = File.ReadAllLines(patToFile);
                list = list[1..];
                for(int i = 0; i < list.Count(); i++)
                {
                    list[i] = list[i].Replace('.', ',');
                }
                _lista = list.Select(a => a.Split(';'))
                    .Select(c => new Animal()
                    {
                        Id = Convert.ToInt32(c[0]),
                        Raca = c[1],
                        Peso = decimal.Parse(c[2]),
                        Fator = decimal.Parse(c[3]),
                    })
                    .ToList();
            }
        }
    }
}
