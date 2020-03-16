using System;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.Domain.Entities
{
    public class BaseEntity : iBaseEntity 
    {
        //Attributes
        private string _SysId;


        //Properties
        public string SysId 
        {
            get 
            {
                return this._SysId;
            }
        }

        public DateTime CreatedDTTM { get; set; }

        public DateTime ModifiedDTTM { get; set; }


        //Constructor
        public BaseEntity()
        {
            this._SysId = Guid.NewGuid().ToString();
            this.CreatedDTTM = DateTime.Now;
            this.ModifiedDTTM = DateTime.Now;
        }


        //Methods
        public bool Equals(string AnotherID)
        {
            return this._SysId.Equals(AnotherID);
        }
    }
}