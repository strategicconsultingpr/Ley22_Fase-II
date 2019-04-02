using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassData
/// </summary>
namespace Ley22_WebApp_V2.Old_App_Code
{
    public struct DataParticipante
    {
        public int PK_Persona;
        public int Id_Participante;
        public string NR_SeguroSocial;
        public string Identificacion;
        public string Pasaporte;
        public string Licencia;
        public int IUP;
        public string Expediente;
        public string NB_Primero;
        public string NB_Segundo;
        public string AP_Primero;
        public string AP_Segundo;
        public DateTime FE_Nacimiento;
        public int FK_Sexo;
        public string SexoDescripcion;
        public int FK_GrupoEtnico;
        public string GrupoEtnicoDescripcion;
        public int FK_Veterano;
        public string Correo;
        public string Telefono1;
        public string Telefono2;
        public string TelefonoFamiliaraMasCercano;
        public string TelefonoCitas;
        public string DireccionLinea1;
        public string DireccionLinea2;
        public string Municipio;
        public string CodigoPostal;
    }

    public static class ConstTipoAlerta
    {
        public const int Success = 1;
        public const int Info = 2;
        public const int Warning = 3;
        public const int Danger = 4;

    }

    public struct Data_SA_Persona
    {
        public int PK_Persona;
        public string NR_SeguroSocial;
        public int FK_Sexo;
        public string NB_Primero;
        public string NB_Segundo;
        public string AP_Primero;
        public string AP_Segundo;
        public DateTime FE_Nacimiento;
        public int FK_Veterano;
        public int FK_GrupoEtnico;

    }
}

 