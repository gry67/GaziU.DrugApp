using AutoMapper;
using GaziU.DrugApp.BL.Dtos;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.Dtos;

namespace GaziU.DrugApp
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<DrugDto, Drug>().ReverseMap(); 
            CreateMap<MedicineTypeDto, MedicineType>().ReverseMap();
            CreateMap<HastaDto, Hasta>().ReverseMap();
            CreateMap<HastaInsertDto, Hasta>().ReverseMap();
            CreateMap<HastaUpdateDto, Hasta>().ReverseMap();
            CreateMap<Drug, DrugViewDto>()
            .ForMember(dest => dest.MedicineType, opt => opt.MapFrom(src => src.MedicineType.Name))
            .ForMember(dest => dest.ActiveIngredient, opt => opt.MapFrom(src => src.ActiveIngredient.IngredientName));
        }
    }
}
