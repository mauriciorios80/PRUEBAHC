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
    
    public partial class TIPODOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPODOCUMENTO()
        {
            this.CLIENTES = new HashSet<CLIENTES>();
            this.MECANICOS = new HashSet<MECANICOS>();
        }
    
        public int TD_ID { get; set; }
        public string TD_DESCRIPCION { get; set; }
        public Nullable<System.DateTime> TD_ROW_CREATE { get; set; }
        public Nullable<System.DateTime> TD_ROW_MODIFY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENTES> CLIENTES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MECANICOS> MECANICOS { get; set; }
    }
}
