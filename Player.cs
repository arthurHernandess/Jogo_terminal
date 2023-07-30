using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Player
    {
		private string _nome;

		public string Nome
		{
			get 
			{
				return _nome; 
			}
			set 
			{
				try
				{
					_nome = value; 
				}
				catch (Exception)
				{
					throw new Exception("Nome deve ser um texto");
				}
			}
		}

		private int _vida;

		public int Vida
		{
			get { return _vida; }
			set 
			{
                try
                {
					_vida = value;
                }
                catch (Exception)
                {
                    throw new Exception("Vida deve ser um numero inteiro");
                }
			}
		}

		private int _moedas;

		public int Moedas
		{
			get { return _moedas; }
			set { _moedas = value; }
		}

		public Item item;

		public Player(string nm, int hp, int moedas, Item item)
		{
			this.Nome = nm;
			this.Vida = hp;
			this.Moedas = moedas;
			this.item = item;
		}
		public Player()
		{
            this.Nome = "Player1";
            this.Vida = 100;
            this.Moedas = 0;
			this.item = null;
        }
	}
}
