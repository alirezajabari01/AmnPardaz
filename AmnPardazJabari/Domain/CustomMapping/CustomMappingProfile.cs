using AutoMapper;

namespace AmnPardazJabari.Domain.CustomMapping;

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile(IEnumerable<IHaveCustomMapping> haveCustomMappings)
    {
        foreach (var item in haveCustomMappings)
            item.CreateMappings(this);
    }
}
