using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TrucoWin.Entidades.Enumeradores;

namespace TrucoWin.Entidades
{
    public class Mesa
    {
        private Barralho barralho = new Barralho();

        public NumJogadores NumJogadores { get; set; }

        private List<Jogador> listJogador1 = new List<Jogador>();

        public List<Jogador> ListJogador1
        {
            get { return listJogador1; }
            set { listJogador1 = value; }
        }


        private List<Jogador> listJogador2 = new List<Jogador>();

        public List<Jogador> ListJogador2
        {
            get { return listJogador2; }
            set { listJogador2 = value; }
        }

        public Jogador MaoDeJogo { get; set; }

        public Carta Vira { get; set; }

        private List<CartaJogador> listCartaJogador = new List<CartaJogador>();

        public List<CartaJogador> ListCartaJogador
        {
            get { return listCartaJogador; }
        }

        public void NovaRodada()
        {
            this.Vira = null;

            if (this.NumJogadores == NumJogadores.Dois)
            {
                if (this.MaoDeJogo == null)
                {
                    this.MaoDeJogo = this.ListJogador1.First();
                }
                else
                {
                    this.MaoDeJogo = this.ListJogador1.Any(f => f.Id == MaoDeJogo.Id) ? this.ListJogador2.First() : this.ListJogador1.First();
                }
            }
            else
            {
                if (this.MaoDeJogo == null)
                {
                    this.MaoDeJogo = this.ListJogador1.First();
                }
                else
                {

                }
            }

            Cartear();
        }

        private void Cartear()
        {
            var listCartaJogada = barralho.Embarralhar(this.NumJogadores);

            this.Vira = listCartaJogada.Last();
            listCartaJogada.Remove(listCartaJogada.Last());

            var listJogadorPrimeirasCartas = this.ListJogador1.Any(f => f.Id == MaoDeJogo.Id) ? this.ListJogador1 : this.ListJogador2;
            for (int i = 0; i < listJogadorPrimeirasCartas.Count; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    CartaJogador cartaJogador = new CartaJogador();
                    cartaJogador.Carta = listCartaJogada.First();
                    cartaJogador.Jogador = listJogadorPrimeirasCartas[i];
                    listCartaJogador.Add(cartaJogador);

                    listCartaJogada.Remove(listCartaJogada.First());
                }
            }

            var listJogadorOutrasCartas = this.ListJogador1.Any(f => f.Id == MaoDeJogo.Id) ? this.ListJogador2 : this.ListJogador1;
            for (int i = 0; i < listJogadorOutrasCartas.Count; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    CartaJogador cartaJogador = new CartaJogador();
                    cartaJogador.Carta = listCartaJogada.First();
                    cartaJogador.Jogador = listJogadorOutrasCartas[i];
                    listCartaJogador.Add(cartaJogador);

                    listCartaJogada.Remove(listCartaJogada.First());
                }
            }
        }
    }
}
