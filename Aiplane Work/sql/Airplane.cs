//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aiplane_Work.sql
{
    using System;
    using System.Collections.Generic;
    
    public partial class Airplane
    {
        public int ID { get; set; }
        public Nullable<int> IDPilot { get; set; }
        public string DeparturePoint { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> DepartureTime { get; set; }
        public Nullable<int> TicketPrice { get; set; }
    
        public virtual Pilot Pilot { get; set; }
    }
}