using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrucoWin.Entidades
{
    public class Enumeradores
    {
        public enum Naipe
        {
            Paus = 4,
            Copas = 3,
            Espadas = 2,
            Ouros = 1
        }

        public enum ValorCarta
        {
            Quatro = 4,
            Cinco = 5,
            Seis = 6,
            Sete = 7,
            Dama = 8,
            Valete = 9,
            Reis = 10,
            As = 11,
            Dois = 12,
            Tres = 13
        }

        public enum NumJogadores
        {
            Dois,
            Quatro
        }
    }
}
