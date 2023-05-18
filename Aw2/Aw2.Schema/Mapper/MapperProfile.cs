using AutoMapper;
using Aw2.Data.Domains;

namespace Aw2.Schema;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Staff, StaffResponse>();
        CreateMap<StaffRequest, Staff>();
    }
}
