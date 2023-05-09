using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mastermind
{
    public  class Juego: INotifyPropertyChanged
        {
           
            private int[] valores = new int[4];

            private int aciertos;
            private int oportunidades;


            public int Oportunidades
            {
                get { return oportunidades; }
                set { oportunidades = value; }
            }

            public int Aciertos
            {
                get { return aciertos; }
                set { aciertos = value; }
            }

            public event PropertyChangedEventHandler? PropertyChanged;

            public bool JuegoIniciado { get; set; } = false;

            public string Resultado { get; set; }
            public void Iniciar()
            {
                Random r = new Random();
                for (int i = 0; i < 4; i++)
                {
                    valores[i] = r.Next(0, 10);
                }
                oportunidades = 10;
                aciertos = 0;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }

            public void Verificar(int[] numeros)
            {
                for (int i = 0; i<valores.Length; i++)
                {
                    if (numeros[i] == valores[i])
                    {
                        aciertos++;
                    }
                }
                if (aciertos==4)
                {
                    Resultado = "Felicidades :D";
                    JuegoIniciado = false;
                }
                else if (oportunidades==0)
                {
                    Resultado = "Perdiste :(";
                    JuegoIniciado = false;
                }
            }
            public ICommand IniciarComando { get; set; }
            public ICommand VerificarComando { get; set; }

            public Juego()
            {
                IniciarComando = new RelayCommand(Iniciar);
                VerificarComando = new RelayCommand<int[]>(Verificar);

            }
        }
    }
}
}
