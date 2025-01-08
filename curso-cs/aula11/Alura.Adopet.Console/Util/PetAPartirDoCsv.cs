using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCsv
    {
        public static Pet ConverteDoTexto(this string linha)
        {
            string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio");

            bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
            if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

            bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
            if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

            int[] enums = Array.ConvertAll(Enum.GetValues<TipoPet>(), value => (int)value);
            if (!enums.Contains(tipoPet)) throw new ArgumentException("Tipo do pet inválido!");

            return new Pet(petId, propriedades[1], (TipoPet)tipoPet);
        }
    }
}
