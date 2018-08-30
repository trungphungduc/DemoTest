using System;

namespace DataAccess
{
    public class BaseModel
    {
        public Int64 Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public String UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public String UserUpdated { get; set; }
    }
}
