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
    
    public partial class Programas_Region_Mapping
    {
        public int FK_Region { get; set; }
        public int FK_Programa { get; set; }
    
        public virtual Region Region { get; set; }
    }
}
