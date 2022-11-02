namespace SecondHandCarBidProject.Common.DTOs
{
    public class BaseUserAddDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressInfoId { get; set; }
        public bool IsApproved { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool EmailVerified { get; set; }
        public bool isCorporate { get; set; }
        public bool KVKKChecked { get; set; }
        public short RoleTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
