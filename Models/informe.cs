using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace webapi
{

    public class Informe {
        private Cadeteria cadeteria;
        private float enviosPromedioPorCadete;
        private int cantTotalEnvios;
        private float montoTotalGanado;
        public float EnviosPromedioPorCadete { get => enviosPromedioPorCadete; set => enviosPromedioPorCadete = value; }
        public int CantTotalEnvios { get => cantTotalEnvios; set => cantTotalEnvios = value; }
        public float MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }
        public Informe(Cadeteria cadeteria) {
            this.cadeteria = cadeteria;
        }
        private void AddCadeteData(int IdCadete)
        {
            cantTotalEnvios += cadeteria.EnviosRealizados(IdCadete);
            montoTotalGanado += cadeteria.MontoTotalCadete(IdCadete);
            return;
        }
        private void AddListadoData()
        {
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                AddCadeteData(cadete.Id);
            }
        }

        private void CalcularPromedio()
        {
            float cantidadCadetes = cadeteria.ListadoCadetes.Count;
            enviosPromedioPorCadete = cantTotalEnvios / cantidadCadetes;
            
        }
        public void MostrarInfCadete(int IdCadete)
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("Cadete:" + cadeteria.GetCadeteByID(IdCadete).Nombre);
            Console.WriteLine("Cantidad de envios completados:" + cadeteria.EnviosRealizados(IdCadete));
            Console.WriteLine("Ganancias:" + cadeteria.MontoTotalCadete(IdCadete));
            Console.WriteLine("Jornal:" + cadeteria.JornalACobrarCadete(IdCadete));
        }
        public void MostrarInfListCadetes()
        {
            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                MostrarInfCadete(cadete.Id);
            }
        }
        public void MostrarInfCadeteria()
        {
            Console.WriteLine("\n==============DATOS DE LA CADETERIA====================\n");
            Console.WriteLine("Cantidad de cadetes:" + cadeteria.ListadoCadetes.Count);
            Console.WriteLine("Cantidad Total de envios:" + cantTotalEnvios);
            Console.WriteLine("Monto total ganado:" + montoTotalGanado);
            Console.WriteLine("Envios promedio por cadete:" + enviosPromedioPorCadete);
        }

        public void MostrarInfCompleto()
        {
            cantTotalEnvios = 0;
            montoTotalGanado = 0;
            AddListadoData();
            CalcularPromedio();
            MostrarInfCadeteria();
            MostrarInfListCadetes();
        }
    }

}