//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ley22_WebApp_V2.Old_App_Code
{
    using System;
    
    public partial class ListarCasosCriminalesActivos_Result
    {
        public int Id_CasoCriminal { get; set; }
        public int Id_Participante { get; set; }
        public string NumeroCasoCriminal { get; set; }
        public Nullable<System.DateTime> FechaOrden { get; set; }
        public Nullable<System.DateTime> FechaSentencia { get; set; }
        public string Alcohol { get; set; }
        public int FK_Tribunal { get; set; }
        public string NB_Juez { get; set; }
        public int Activa { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Id_UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
        public Nullable<int> Id_MotivoCierre { get; set; }
        public string ComentarioCierre { get; set; }
        public string Id_UsuarioCierre { get; set; }
        public Nullable<int> FK_Programa { get; set; }
        public Nullable<int> NumLicencia { get; set; }
        public Nullable<int> FK_EstadoCivil { get; set; }
        public string Email { get; set; }
        public string TelCelular { get; set; }
        public string TelHogar { get; set; }
        public string TelTrabajo { get; set; }
        public string DireccionLinea1 { get; set; }
        public string DireccionLinea2 { get; set; }
        public Nullable<int> FK_Pueblo { get; set; }
        public string CodigoPostal { get; set; }
        public string DireccionLinea1Postal { get; set; }
        public string DireccionLinea2Postal { get; set; }
        public Nullable<int> FK_PuebloPostal { get; set; }
        public string CodigoPostalPostal { get; set; }
        public Nullable<int> FK_PlanMedico { get; set; }
        public string CondicionSalud { get; set; }
        public string Impedimento { get; set; }
        public Nullable<int> FK_Grado { get; set; }
        public string LugarTrabajo { get; set; }
        public string Ocupacion { get; set; }
        public Nullable<byte> Veterano { get; set; }
        public Nullable<int> FK_DesempleoRazon { get; set; }
        public Nullable<int> CantidadFamilia { get; set; }
        public string NB_Pareja { get; set; }
        public string NB_Padre { get; set; }
        public string NB_Madre { get; set; }
    }
}