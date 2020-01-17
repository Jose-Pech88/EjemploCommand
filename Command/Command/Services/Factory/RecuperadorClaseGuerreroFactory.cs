using Command.Services.Factory.Interface;
using Command.Services.Interfaces;
using Command.Services.Strategy;

namespace Command.Services.Factory
{
    public class RecuperadorClaseGuerreroFactory : IRecuperadorClaseGuerreroFactory
    {
        public IAccionesReceiver CrearInstancia(string _cJugadorClase)
        {
            IAccionesReceiver AccionesReceiver = null;
            switch (_cJugadorClase)
            {
                case "1":
                    AccionesReceiver = new GuerreroClaseBajaStrategy();
                    break;
                case "2":
                    AccionesReceiver = new GuerreroClaseMediaStrategy();
                    break;
                case "3":
                    AccionesReceiver = new GuerreroClaseAltaStrategy();
                    break;
            }
            return AccionesReceiver;
        }
    }
}
