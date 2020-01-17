using Command.Services.Interfaces;
using System;

namespace Command.Services
{
    public class LanzandoGranadaCommand : IAccionesJuegoCommand
    {
        private IAccionesReceiver Receiver;
        public string cComando { set; get; }
        public LanzandoGranadaCommand(IAccionesReceiver _receiver)
        {
            this.Receiver = _receiver ?? throw new ArgumentNullException(nameof(_receiver));
        }

        public void EjecutarAccion(string _cNombreJugador)
        {
            this.Receiver.ImprimirAccion(_cNombreJugador, "Ejecutando Lanza Granada con poder destructivo");
        }
    }
}
