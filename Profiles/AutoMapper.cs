using AutoMapper;
using PostParcelsAPI.Dtos;
using PostParcelsAPI.Models;

namespace PostParcelsAPI.Profiles
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<CreatePostDto, Post>();
            CreateMap<CreateParcelDto, Parcel>();
            CreateMap<UpdateParcelDto, Parcel>().ReverseMap();
        }
    }
}
