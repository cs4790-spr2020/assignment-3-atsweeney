using System;

namespace BlabberApp.Domain.Entities
{
    public class Blab : BaseEntity
    {
        //Properties
        public DateTime DTTM { get; set; }

        public string Message { get; set; }

        public string UserID { get; set; }


        //Cosntructor
        public Blab()
        {
            this.DTTM = DateTime.Now;
        }
    }
}