//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REPUESTOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REPUESTOS()
        {
            this.FACTURAS_DETALLE = new HashSet<FACTURAS_DETALLE>();
        }
    
        public int REP_ID { get; set; }
        public string REP_DESCRIPCION { get; set; }
        public decimal REP_PRECIO { get; set; }
        public Nullable<System.DateTime> REP_ROW_CREATE { get; set; }
        public Nullable<System.DateTime> REP_ROW_MODIFY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURAS_DETALLE> FACTURAS_DETALLE { get; set; }
    }
}