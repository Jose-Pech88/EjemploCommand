using Command.Services.Interfaces;
using System;

namespace Command.Services
{
    public class GolpeandoCommand : IAccionesJuegoCommand
    {
        private IAccionesReceiver Receiver;
        public string cComando { set; get; }
        public GolpeandoCommand(IAccionesReceiver _receiver)
        {
            this.Receiver = _receiver ?? throw new ArgumentNullException(nameof(_receiver));
        }

        public void EjecutarAccion(string _cNombreJugador)
        {
            this.Receiver.ImprimirAccion(_cNombreJugador ,"Golpeando con poder");
        }
    }
}
