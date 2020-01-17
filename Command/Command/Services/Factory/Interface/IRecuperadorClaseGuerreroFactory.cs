using Command.Services.Interfaces;

namespace Command.Services.Factory.Interface
{
    public interface IRecuperadorClaseGuerreroFactory
    {
        IAccionesReceiver CrearInstancia(string _cJugadorClase);
    }
}
