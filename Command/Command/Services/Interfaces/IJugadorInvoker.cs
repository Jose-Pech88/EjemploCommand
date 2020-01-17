namespace Command.Services.Interfaces
{
    public interface IJugadorInvoker
    {
        void EjecutarComando(IAccionesJuegoCommand _accionesJuego, string _cNombreJugador);
    }
}
