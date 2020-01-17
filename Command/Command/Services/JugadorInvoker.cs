using Command.Services.Interfaces;
using Command.Services.Strategy;
using System.Collections.Generic;
using System.Linq;

namespace Command.Services
{
    public class JugadorInvoker : IJugadorInvoker
    {
        public int iTipoMenu { set; get; }
        private List<IAccionesJuegoCommand> lstAccionesJuegoCommand=new List<IAccionesJuegoCommand>();
        public JugadorInvoker()
        {
            this.iTipoMenu = 0;           
        }

        public void AgregarCommand(IAccionesJuegoCommand _accionesJuegoCommand)
        {
            if (_accionesJuegoCommand != null)
            {
                if (!lstAccionesJuegoCommand.Any() || lstAccionesJuegoCommand.Any(x => x.cComando != _accionesJuegoCommand.cComando))
                {
                    lstAccionesJuegoCommand.Add(_accionesJuegoCommand);
                }
            }
        }

        public void EjecutarComando(IAccionesJuegoCommand _accionesJuego, string _cNombreJugador)
        {
            _accionesJuego.EjecutarAccion(_cNombreJugador);
        }

        public IAccionesJuegoCommand BuscarCommand(string cKey)
        {
            IAccionesJuegoCommand AccionesJuegoCommand = null;
            if(lstAccionesJuegoCommand.Any(x=>x.cComando==cKey))
            {
                AccionesJuegoCommand = lstAccionesJuegoCommand.Where(x => x.cComando == cKey).FirstOrDefault();
            }
            return AccionesJuegoCommand;
        }
    }
}
