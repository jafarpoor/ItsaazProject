namespace Domain.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertTime { get; set; }
        public bool IsActive { get; set; }
    }
}
