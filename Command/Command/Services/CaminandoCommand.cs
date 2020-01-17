using Command.Services.Interfaces;
using System;

namespace Command.Services
{
    public class CaminandoCommand : IAccionesJuegoCommand
    {
        private IAccionesReceiver Receiver;
        public string cComando { set; get; }
        public CaminandoCommand(IAccionesReceiver _receiver)
        {
            this.Receiver = _receiver ?? throw new ArgumentNullException(nameof(_receiver));
        }
        public void EjecutarAccion(string _cNombreJugador)
        {
            this.Receiver.ImprimirAccion(_cNombreJugador,"Caminando con velocidad");
        }
    }
}
