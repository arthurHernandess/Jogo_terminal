using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Bau
    {
        #region Propriedades
        private bool _trancado;
        public bool Trancado 
        {
            get { return _trancado; }
            set 
            {
                if (!value || value)
                    _trancado = value;
                else
                    throw new Exception("deu erado :(");
            }
        }

        private bool _aberto;
        public bool Aberto
        {
            get { return _aberto; }
            set
            {
                if (!value || value)
                    _aberto= value;
                else
                    throw new Exception("deu erado :(");
            }
        }

        private int _valorMoedas;
        public int ValorMoedas
        {
            get { return _valorMoedas;}
            set {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    try
                    {
                        if(value <= 200)
                        {
                            _valorMoedas = value;
                        }
                        else
                        {
                            throw new Exception("Valor da moeda deve ser até 200");
                        }
                    }
                    catch 
                    {
                        throw new Exception("Valor de moedas deve ser numérico!!");
                    }
                }
                else
                    throw new Exception("Insira o valor das moedas");
            }
        }
        #endregion

        public Bau (bool trancado, bool aberto, int moedas)
        {
            this.Trancado = trancado;
            this.Aberto = aberto;
            this.ValorMoedas = moedas;
        }

        #region Metodos
        public void destrancar(Player p, string n_bau)
        {
            if (Aberto)
            {
                Console.WriteLine("Baú já está aberto");
                return;
            }

            if(Trancado)
            {
                if(p.item != null)
                {
                    if (p.item.Nome == "Chave do bau " +n_bau)
                    {
                        Trancado = false;
                        Aberto = false;
                        Console.WriteLine("Baú foi destrancado");
                    }
                    else
                    {
                        Console.WriteLine("Você não possui chave para destrancar esse baú");
                    }
                }
                else
                {
                    Console.WriteLine("Você não possui chave para destrancar esse baú");
                }
            }
            else
            {
                Console.WriteLine("Baú não está trancado");
            }
        }

        public int abrir()
        {
            if(!Aberto)
            {
                if (!Trancado)
                {
                    Aberto = true;
                    return ValorMoedas;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }
        #endregion
    }
}
