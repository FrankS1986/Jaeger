//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JaegerMeister.MvvmSample.Logic.Ui
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Jaeger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Jaeger()
        {
            this.tbl_Jagderfolge = new HashSet<tbl_Jagderfolge>();
            this.tbl_Postausgang = new HashSet<tbl_Postausgang>();
            this.tbl_Rueckmeldung = new HashSet<tbl_Rueckmeldung>();
        }
    
        public int Jäger_ID { get; set; }
        public string Anrede { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string Adresszusatz { get; set; }
        public string Postleitzahl { get; set; }
        public string Wohnort { get; set; }
        public string Funktion { get; set; }
        public string Telefonnummer1 { get; set; }
        public string Telefonnummer2 { get; set; }
        public string Telefonnummer3 { get; set; }
        public string Email { get; set; }
        public string Jagdhund { get; set; }
        public Nullable<System.DateTime> Geburtsdatum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Jagderfolge> tbl_Jagderfolge { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Postausgang> tbl_Postausgang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Rueckmeldung> tbl_Rueckmeldung { get; set; }
    }
}
