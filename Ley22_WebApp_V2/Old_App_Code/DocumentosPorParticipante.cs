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
    using System.Collections.Generic;
    
    public partial class DocumentosPorParticipante
    {
        public int Id_DocumentoPorParticipante { get; set; }
        public int Id_Documento { get; set; }
        public int Id_Participante { get; set; }
        public int Id_OrdenJudicial { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        public string PathNameDocumento { get; set; }
        public int Id_UsuarioRecibe { get; set; }
        public int Aprobado { get; set; }
        public Nullable<int> Id_UsuarioAprobacion { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> Id_Programa { get; set; }
    }
}
