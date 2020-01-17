using Command.Services.Interfaces;

namespace Command.Services
{
    public class RecuperadorMenuJugador : IRecuperadorMenuJugador
    {
        public string RecuperarMenuJugador()
        {
            string cMenu = string.Empty;
            cMenu = "#####         Elija un jugador         ###\r\n";
            cMenu = string.Format("{0} 1.-Jugador clase baja \r\n", cMenu);
            cMenu = string.Format("{0} 2.-Jugador clase media \r\n", cMenu);
            cMenu = string.Format("{0} 3.-Jugador clase alta \r\n", cMenu);
            cMenu = string.Format("{0} S.-Salir \r\n", cMenu);
            return cMenu;
        }
    }
}
