using Command.Services.Interfaces;
using System;

namespace Command.Services
{
    public class SaltandoCommand : IAccionesJuegoCommand
    {
        private IAccionesReceiver Receiver;
        public string cComando { set; get; }
        public SaltandoCommand(IAccionesReceiver _receiver)
        {
            this.Receiver = _receiver ?? throw new ArgumentNullException(nameof(_receiver));
        }
        public void EjecutarAccion(string _cNombreJugador)
        {
            this.Receiver.ImprimirAccion(_cNombreJugador ,"Saltando a una altura");
        }
    }
}
