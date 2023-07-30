using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Item
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private int _valor;

		public int Valor
		{
			get { return _valor; }
			set { _valor = value; }
		}

		public Item(string nm, int valor)
		{
			this.Nome = nm;
			this.Valor = valor;
		}
	}
}
