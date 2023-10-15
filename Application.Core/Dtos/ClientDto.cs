namespace Application.Core.Dtos
{
    public class ClientDto
    {
        public Guid RecordId { get; set; }
        public string ClientName { get; set; }
        public DateTime DateRegisterd { get; set; }
        public string Location { get; set; }
        public int NumberOfSystemUsers { get; set; }
    }
}
