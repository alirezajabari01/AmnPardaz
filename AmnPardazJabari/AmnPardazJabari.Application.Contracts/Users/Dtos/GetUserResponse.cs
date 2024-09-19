using AmnPardazJabari.Domain.CustomMapping;
using AmnPardazJabari.Domain.Enums;
using AmnPardazJabari.Domain.Users;
using AutoMapper;

namespace AmnPardazJabari.Application.Contracts.Users.Dtos;

public class GetUserResponse : IHaveCustomMapping
{
    public string UserName { get; set; }
    public Guid Id { get; set; }
    public RoleId RoleId { get; set; }
    public void CreateMappings(Profile profile)
    {
        profile.CreateMap<User, GetUserResponse>()
            .ForMember(s => s.UserName, op =>
                op.MapFrom(v => v.UserName.Value));
    }
}