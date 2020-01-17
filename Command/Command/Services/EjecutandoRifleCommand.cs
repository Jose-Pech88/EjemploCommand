using Command.Services.Interfaces;
using System;

namespace Command.Services
{
    public class EjecutandoRifleCommand : IAccionesJuegoCommand
    {
        private IAccionesReceiver Receiver;
        public string cComando { set; get; }
        public EjecutandoRifleCommand(IAccionesReceiver _receiver)
        {
            this.Receiver = _receiver ?? throw new ArgumentNullException(nameof(_receiver));
        }

        public void EjecutarAccion(string _cNombreJugador)
        {
            this.Receiver.ImprimirAccion(_cNombreJugador , "Ejecutando Rifle de Plasma con poder");
        }
    }
}
