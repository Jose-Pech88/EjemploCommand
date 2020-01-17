using Command.Services.Interfaces;

namespace Command.Services
{
    public class RecuperadorMenuAcciones : IRecuperadorMenuAcciones
    {
        public string RecuperarMenuAcciones(int _iTipoMenu, string _cNombreJugador)
        {
            string cMenuAcciones = string.Empty;
            cMenuAcciones = CrearMenu(_iTipoMenu, _cNombreJugador);
            return cMenuAcciones;
        }
        private string CrearMenu(int _iTipoMenu, string _cNombreJugador)
        {
            string cMenu = string.Empty;
            cMenu = string.Format("####       Menu Jugador {0}      ###\r\n", _cNombreJugador);
            cMenu = string.Format("{0}Elija una opción:\r\n", cMenu);
            cMenu = string.Format("{0}A: Caminar\r\n", cMenu);          
            cMenu = string.Format("{0}B: Saltar\r\n", cMenu);
            cMenu = string.Format("{0}C: Golpear\r\n", cMenu);
            cMenu = string.Format("{0}D: Disparar Pistola\r\n", cMenu);
            cMenu = string.Format("{0}{1}", cMenu, AgregarOpciones(_iTipoMenu));
            cMenu = string.Format("{0}S: Salir", cMenu);
            return cMenu;
        }

        private string AgregarOpciones(int iTipoMenu)
        {
            string cMenu = string.Empty;
            switch (iTipoMenu)
            {
                case 0:
                    cMenu = "AI: Conseguir Rifle de Plasma\r\n";
                    cMenu = string.Format("{0}BI: Conseguir Lanza Granadas\r\n", cMenu);
                    break;
                case 1:
                    cMenu = "AA: Ejecutar Rifle de Plasma\r\n";
                    cMenu = string.Format("{0}BI: Conseguir Lanza Granadas\r\n", cMenu);
                    break;
                case 2:
                    cMenu = "AI: Conseguir Rifle de Plasma\r\n";
                    cMenu = string.Format("{0}BB: Ejecutar Lanza Granadas\r\n", cMenu);
                    break;
                case 3:
                    cMenu = "AA: Ejecutar Rifle de Plasma\r\n";
                    cMenu = string.Format("{0}BB: Ejecutar Lanza Granadas\r\n", cMenu);
                    break;
            }
            return cMenu;
        }
    }
}
