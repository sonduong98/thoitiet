namespace Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
