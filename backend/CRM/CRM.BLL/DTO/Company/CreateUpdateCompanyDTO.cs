namespace CRM.BLL.DTO.Company
{
    public class CreateUpdateCompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Industry { get; set; }
        public string? Website { get; set; }
    }
}
