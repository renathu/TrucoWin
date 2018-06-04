using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrucoWin.Entidades;

namespace TrucoWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mesa mesa = new Mesa();
            mesa.NumJogadores = Enumeradores.NumJogadores.Dois;

            Jogador jogador1 = new Jogador();
            jogador1.Id = 1;
            jogador1.Nome = "Renato";

            Jogador jogador2 = new Jogador();
            jogador2.Id = 2;
            jogador2.Nome = "Maria";

            if (mesa.NumJogadores == Enumeradores.NumJogadores.Dois)
            {
                mesa.ListJogador1.Add(jogador1);
                mesa.ListJogador2.Add(jogador2);
            }
            mesa.MaoDeJogo = jogador2;

            mesa.NovaRodada();
        }
    }
}
