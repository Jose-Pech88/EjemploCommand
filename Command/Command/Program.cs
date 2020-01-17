using Command.Services;
using Command.Services.Factory;
using Command.Services.Factory.Interface;
using Command.Services.Interfaces;
using System;
using System.Threading;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InicializarAplicacion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        static void InicializarAplicacion()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            IRecuperadorMenuJugador RecuperadorMenuJugador = new RecuperadorMenuJugador();
            IAccionesReceiver Receiver = null;
            IRecuperadorClaseGuerreroFactory RecuperadorClaseGuerreroFactory = new RecuperadorClaseGuerreroFactory();
            string cMenuJugador = RecuperadorMenuJugador.RecuperarMenuJugador();
            string cMenuJugadorSeleccionado = string.Empty;
            string cNombreJugador = string.Empty;
            bool lMenuJugadorSeleccionado = false;            
            do
            {
                Console.WriteLine(cMenuJugador);
                cMenuJugadorSeleccionado = Console.ReadLine();
                if (cMenuJugadorSeleccionado == "S")
                    Environment.Exit(1);
                Receiver = RecuperadorClaseGuerreroFactory.CrearInstancia(cMenuJugadorSeleccionado);
                if (Receiver != null)
                    lMenuJugadorSeleccionado = true;
                else
                    Console.WriteLine("Comando no válido\r\n");
            }
            while (!lMenuJugadorSeleccionado);
            Console.Clear();
            Console.WriteLine("Capturar Nombre del Jugador");
            cNombreJugador = Console.ReadLine();
            AdministrarMenuAcciones(Receiver, cNombreJugador);

        }

        static void AdministrarMenuAcciones(IAccionesReceiver _receiver, string _cNombreJugador)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            IRecuperadorMenuAcciones RecuperadorMenuAcciones = new RecuperadorMenuAcciones();
            Console.ForegroundColor = ConsoleColor.Red;
            JugadorInvoker Invoker = new JugadorInvoker();
            AgregarComandosAInvokerBasicos(Invoker, _receiver);
            string cOpcion = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine(RecuperadorMenuAcciones.RecuperarMenuAcciones(Invoker.iTipoMenu, _cNombreJugador));
                cOpcion = Console.ReadLine();
                if (cOpcion != "S")
                {
                    IAccionesJuegoCommand EjecutarCommand = Invoker.BuscarCommand(cOpcion);
                    if (EjecutarCommand != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Invoker.EjecutarComando(EjecutarCommand, _cNombreJugador);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ReadKey();
                    }
                    else
                    {
                        AgregarNuevasAcciones(cOpcion, _receiver, Invoker);
                    }
                }
            }
            while (cOpcion != "S");

            if (cOpcion == "S")
                InicializarAplicacion();
        }

        static void AgregarNuevasAcciones(string _cOpcion, IAccionesReceiver _accionesReceiver, JugadorInvoker _jugadorInvoker)
        {
            switch (_cOpcion)
            {
                case "AI":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(">Instalando Rifle de Plasma...");
                    Thread.Sleep(1000);
                    IAccionesJuegoCommand AccionLanzarArma = new EjecutandoRifleCommand(_accionesReceiver);
                    AccionLanzarArma.cComando = "AA";
                    _jugadorInvoker.AgregarCommand(AccionLanzarArma);
                    if(_jugadorInvoker.iTipoMenu == 2)
                        _jugadorInvoker.iTipoMenu = 3;
                    else
                        _jugadorInvoker.iTipoMenu = 1;
                    Console.WriteLine(">>>Rifle de Plasma Instalada...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "BI":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(">Instalando Lanza Granada...");
                    Thread.Sleep(1000);
                    IAccionesJuegoCommand AccionBombardear = new LanzandoGranadaCommand(_accionesReceiver);
                    AccionBombardear.cComando = "BB";
                    _jugadorInvoker.AgregarCommand(AccionBombardear);
                    if (_jugadorInvoker.iTipoMenu == 1)
                        _jugadorInvoker.iTipoMenu = 3;
                    else
                        _jugadorInvoker.iTipoMenu = 2;
                    Console.WriteLine(">>>Lanza Granada Instalada...");
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.WriteLine("Comando no válido");
                    break;
            }
            Thread.Sleep(1000);
        }

        static void AgregarComandosAInvokerBasicos(JugadorInvoker _invoker, IAccionesReceiver accionesReceiver)
        {
            IAccionesJuegoCommand AccionesCaminar = new CaminandoCommand(accionesReceiver);
            AccionesCaminar.cComando = "A";            
            IAccionesJuegoCommand AccionSaltar = new SaltandoCommand(accionesReceiver);
            AccionSaltar.cComando = "B";
            IAccionesJuegoCommand AccionGolpear = new GolpeandoCommand(accionesReceiver);
            AccionGolpear.cComando = "C";
            IAccionesJuegoCommand AccionDisparar = new DisparandoArmaCommand(accionesReceiver);
            AccionDisparar.cComando = "D";
            _invoker.AgregarCommand(AccionesCaminar);            
            _invoker.AgregarCommand(AccionSaltar);
            _invoker.AgregarCommand(AccionGolpear);
            _invoker.AgregarCommand(AccionDisparar);
        }
    }
}