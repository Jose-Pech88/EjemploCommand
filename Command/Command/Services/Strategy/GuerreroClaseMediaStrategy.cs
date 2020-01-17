using Command.Services.Interfaces;
using System;

namespace Command.Services.Strategy
{
    public class GuerreroClaseMediaStrategy : IAccionesReceiver
    {
        public void ImprimirAccion(string _cNombreJugador, string _cEvento)
        {
            Console.WriteLine(string.Format("{0} {1} de 20",_cNombreJugador , _cEvento));
        }
    }
}
