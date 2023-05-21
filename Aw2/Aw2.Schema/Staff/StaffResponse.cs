using Aw2.Base;

namespace Aw2.Schema;

public class StaffResponse : BaseResponse
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
}
