using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venda_Animais
{
    public  static class Extensao
    {
        public static string AnimalToString(this Animal animal)
        {
            return animal.Nome.ToUpper() + " Peso: " + animal.Peso + " arrobas " +"Preço: " + animal.Preco;
        }
    }
}
