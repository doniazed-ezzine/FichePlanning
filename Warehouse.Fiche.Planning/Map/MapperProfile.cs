using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace Warehouse.Fiche.Planning.Map
{
    public class MapperProfile : Profile
    {


        public MapperProfile()
        {
            #region Mapping FichePlanning
            CreateMap<FichePlanning, FichePlanDTO>()
                .ForMember(r => r.NomPrenom, i => i.MapFrom(src => src.Utilisateur.NomPrenom))
                .ForMember(r => r.Matricule, i => i.MapFrom(src => src.Utilisateur.Matricule))
                .ForMember(r => r.Role, i => i.MapFrom(src => src.Utilisateur.Role))
                .ForMember(r => r.FkFonction, i => i.MapFrom(src => src.Utilisateur.FkFonction))
                .ForMember(r => r.Fonction, i => i.MapFrom(src => src.Utilisateur.Fonction.Label))
                .ForMember(r => r.Filiale, i => i.MapFrom(src => src.Filiale.Label))
                .ForMember(r => r.Code, i => i.MapFrom(src => src.Filiale.Code))
                .ForMember(r => r.Secteur, i => i.MapFrom(src => src.Filiale.Secteur))
                .ReverseMap();
            #endregion

            #region Mapping Periode
            CreateMap<Periode, PeriodeDTO>()
                .ForMember(r => r.NomPrenom, i => i.MapFrom(src => src.FichePlanning.Utilisateur.NomPrenom))
                .ForMember(r => r.Matricule, i => i.MapFrom(src => src.FichePlanning.Utilisateur.Matricule))
                .ForMember(r => r.FkUtilisateur, i => i.MapFrom(src => src.FichePlanning.Utilisateur.Id))
                .ForMember(r => r.Role, i => i.MapFrom(src => src.FichePlanning.Utilisateur.Role))
                .ForMember(r => r.FkFonction, i => i.MapFrom(src => src.FichePlanning.Utilisateur.FkFonction))
                .ForMember(r => r.Fonction, i => i.MapFrom(src => src.FichePlanning.Utilisateur.Fonction.Label))
                .ForMember(r => r.Filiale, i => i.MapFrom(src => src.FichePlanning.Filiale.Label))
                .ForMember(r => r.FkFiliale, i => i.MapFrom(src => src.FichePlanning.Filiale.Id))
                .ForMember(r => r.Code, i => i.MapFrom(src => src.FichePlanning.Filiale.Code))
                .ForMember(r => r.Secteur, i => i.MapFrom(src => src.FichePlanning.Filiale.Secteur))
                 .ForMember(r => r.Audite, i => i.MapFrom(src => src.FichePlanning.Audite))
                .ForMember(r => r.Evaluation, i => i.MapFrom(src => src.FichePlanning.Evaluation))
                .ForMember(r => r.Mois, i => i.MapFrom(src => src.DatePlanning.Month))
                .ForMember(r => r.Annee, i => i.MapFrom(src => src.DatePlanning.Year))
                .ReverseMap();
            #endregion

            #region Mapping Utilisateur
            CreateMap<Utilisateur, UtilisateurDTO>()
                .ForMember(r => r.Fonction, i => i.MapFrom(src => src.Fonction.Label))
                .ReverseMap();
            #endregion



        }

    }
}


