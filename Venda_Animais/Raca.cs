using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Venda_Animais
{
    public class Raca
    {
        protected List<Raca> _raca;

        public string Nome { get;protected set; }
        public decimal Preco { get;protected set;}
        public IReadOnlyList<Raca> ListaRaca { get => _raca; }

        public void TabelarPreco(string arquivoCSV)
        {
            var patToFile = Path.Combine(Directory.GetCurrentDirectory(), arquivoCSV);
            var list = File.ReadAllLines(patToFile);
            list = list[1..];
            for (int i = 0; i < list.Count(); i++)
            {
                list[i] = list[i].Replace('.', ',');
            }
            _raca = list.Select(a => a.Split(';'))
                .Select(c => new Raca()
                {
                    Nome = c[0],
                    Preco = decimal.Parse(c[1]),
                }).ToList();
        }
    }

}
