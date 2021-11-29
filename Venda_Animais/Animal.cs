using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Venda_Animais
{
    public class Animal : Raca
    {

        private List<Animal> _lista = new List<Animal>();
        public decimal Peso { get; private set; }
        public int Id { get; private set; }
        public decimal Fator { get; private set; }
        public IReadOnlyList<Animal> Lista { get => _lista; }
        public void ListarAnimais(string arquivoCSV)
        {
            var patToFile = Path.Combine(Directory.GetCurrentDirectory(), arquivoCSV);
            var list = File.ReadAllLines(patToFile);
            list = list[1..];
            for (int i = 0; i < list.Count(); i++)
            {
                list[i] = list[i].Replace('.', ',');
            }
            _lista = list.Select(a => a.Split(';'))
                .Select(c => new Animal()
                {
                    Id = Convert.ToInt32(c[0]),
                    Nome = c[1],
                    Peso = decimal.Parse(c[2]),
                    Fator = decimal.Parse(c[3]),
                })
                .ToList();
        }
        public void AdicionarPreco()
        {
            for (int i = 0; i < _lista.Count; i++)
            {
                for (int j = 0; j < _raca.Count; j++)
                {
                    if (_lista[i].Nome == _raca[j].Nome)
                    {
                        _lista[i].Preco = _raca[j].Preco * _lista[i].Peso * _lista[i].Fator;
                    }
                }
            }
        }
        public Animal MaiorPreco(string raca)
        {
            decimal maior = 0;
            Animal maiorPreco = null;
            foreach (var boi in _lista)
            {
                if(boi.Nome == raca)
                {
                    if (boi.Preco >= maior)
                    {
                        maior = boi.Preco;
                        maiorPreco = boi;
                    }
                }
            }
            return maiorPreco;
        }
        public void Relatorio()
        {
            for (int i = 0; i < _raca.Count; i++)
            {
                string path = Directory.GetCurrentDirectory() + @"\" + _raca[i].Nome + ".txt";
                try
                {
                    var fs = new FileStream(path, FileMode.Create);
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("Data: " + DateTime.Now);
                        writer.WriteLine("O preço do arroba: " + _raca[i].Preco);
                        var animalMaisCaro = MaiorPreco(_raca[i].Nome);
                        writer.WriteLine("Animal mais caro -> " + animalMaisCaro.Nome + " de peso: "
                            + animalMaisCaro.Peso + " vale: " + animalMaisCaro.Preco);
                        var c = _lista.Where(x => x.Nome == _raca[i].Nome).OrderByDescending(x => x.Preco).ToList();
                        foreach (var x in c)
                        {
                            writer.WriteLine(x.AnimalToString());
                        }
                    }
                }
                catch (IOException) { }
            }
        }
    }

}
