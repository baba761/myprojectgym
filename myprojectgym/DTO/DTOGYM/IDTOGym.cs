namespace myprojectgym.DTO.DTOGYM
{
    public interface IDTOGym
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string ContactInfo { get; set; }
        int CountryId { get; set; }
        string Email { get; set; }
        string Fax { get; set; }
        string GymName { get; set; }
        string Phone { get; set; }
        string PostalCode { get; set; }
        int StateId { get; set; }
    }
}