namespace Models.Contact
{
    public class ContactModel : BaseModel
    {
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public string Type { get; set; }
    }
}
