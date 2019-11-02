using AutoMapper;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Business.Models.Domain;
using System;

namespace ReciclajeApi.Business.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Publicacion, PublicacionApiModel>();
            CreateMap<PublicacionApiModel, Publicacion>();
            CreateMap<TipoResiduo, TipoResiduoApiModel>().ForMember(dest => dest.IdTipoResiduo, opt => opt.MapFrom(x => x.IdTipo));
            CreateMap<CategoriaResiduo, CategoriaResiduoApiModel>();
            CreateMap<Usuario, UsuarioApiModel>();
            CreateMap<Direccion, DireccionApiModel>();
            CreateMap<int, EstadoApiModel>();
            CreateMap<int, UsuarioApiModel>();
            CreateMap<int, LocalidadApiModel>();
            CreateMap<int, ProvinciaApiModel>();
            CreateMap<Estado, EstadoApiModel>();
            CreateMap<Localidad, LocalidadApiModel>();
            CreateMap<Provincia, ProvinciaApiModel>();
            CreateMap<SignUp, SignUpApiModel>().ForMember(dest => dest.FotoDePerfil, opt => opt.Ignore());
            CreateMap<SignUpApiModel, SignUp>().ForMember(dest => dest.FotoDePerfil, opt => opt.Ignore());
            CreateMap<Material, MaterialApiModel>().ForMember(dest => dest.Imagen, opt => opt.MapFrom(x => Convert.ToBase64String(x.Imagen)));
            CreateMap<Perfil, PerfilApiModel>().ForMember(dest => dest.FotoDePerfil, opt => opt.MapFrom(x => Convert.ToBase64String(x.FotoDePerfil)));
        }
    }
}