namespace WebTest.Data.Users
{
    public class UserEntity
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public BloodType BloodType { get; set; }
        public bool Rh { get; set; }
    }
    public enum Role
    {
        Client,
        Admin,
        SuperAdmin
    }
    public enum BloodType
    {
        O,
        A,
        B,
        AB
    }
}
