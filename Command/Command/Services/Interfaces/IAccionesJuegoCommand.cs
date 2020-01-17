namespace Command.Services.Interfaces
{
    public interface IAccionesJuegoCommand
    {
        string cComando { set; get; }
        void EjecutarAccion(string _cNombreJugador);
    }
}
