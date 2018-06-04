using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TrucoWin.Entidades.Enumeradores;

namespace TrucoWin.Entidades
{
    public class Barralho
    {
        List<Carta> listCartas = new List<Carta>();

        public Barralho()
        {
            CarregarBarralho();
        }

        private void CarregarBarralho()
        {
            foreach (ValorCarta item in Enum.GetValues(typeof(ValorCarta)))
            {
                foreach (Naipe naipe in Enum.GetValues(typeof(Naipe)))
                {
                    Carta carta = new Carta();
                    carta.Valor = (int)item;
                    carta.Naipe = naipe;
                    carta.Imagem = null;

                    listCartas.Add(carta);
                }
            }
        }

        public List<Carta> Embarralhar(NumJogadores numJogadores)
        {
            List<Carta> listCartasRodada = new List<Carta>();

            Random rdn = new Random((int)DateTime.Now.Ticks);

            int qtdCartas = numJogadores == NumJogadores.Dois ? 7 : 13;

            for (int i = 0; i < qtdCartas; i++)
            {
                var encontrou = false;

                while (!encontrou)
                {
                    var cartaSorteada = rdn.Next(0, listCartas.Count - 1);
                    var carta = listCartas[cartaSorteada];

                    if (listCartasRodada.Any(f => f.Valor == carta.Valor && f.Naipe == carta.Naipe) == false)
                    {
                        listCartasRodada.Add(carta);
                        encontrou = true;
                    }
                }
            }

            return listCartasRodada;
        }
    }
}
