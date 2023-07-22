using Database.Repository;
using Domain.Command;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region FichePlanning
            services.AddTransient<IGenericRepository<FichePlanning>, GenericRepository<FichePlanning>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<FichePlanning>, string>, PutGenericHandler<FichePlanning>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<FichePlanning>, FichePlanning>, GetGenericHandler<FichePlanning>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<FichePlanning>, string>, AddGenericHandler<FichePlanning>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<FichePlanning>, string>, RemoveGenericHandler<FichePlanning>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<FichePlanning>, IEnumerable<FichePlanning>>, GetListGenericHandler<FichePlanning>>();
            #endregion
            #region Filiale
            services.AddTransient<IGenericRepository<Filiale>, GenericRepository<Filiale>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Filiale>, string>, PutGenericHandler<Filiale>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Filiale>, Filiale>, GetGenericHandler<Filiale>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Filiale>, string>, AddGenericHandler<Filiale>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Filiale>, string>, RemoveGenericHandler<Filiale>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Filiale>, IEnumerable<Filiale>>, GetListGenericHandler<Filiale>>();
            #endregion

            #region Fonction
            services.AddTransient<IGenericRepository<Fonction>, GenericRepository<Fonction>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Fonction>, string>, PutGenericHandler<Fonction>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Fonction>, Fonction>, GetGenericHandler<Fonction>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Fonction>, string>, AddGenericHandler<Fonction>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Fonction>, string>, RemoveGenericHandler<Fonction>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Fonction>, IEnumerable<Fonction>>, GetListGenericHandler<Fonction>>();
            #endregion

            #region Periode
            services.AddTransient<IGenericRepository<Periode>, GenericRepository<Periode>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Periode>, string>, PutGenericHandler<Periode>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Periode>, Periode>, GetGenericHandler<Periode>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Periode>, string>, AddGenericHandler<Periode>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Periode>, string>, RemoveGenericHandler<Periode>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Periode>, IEnumerable<Periode>>, GetListGenericHandler<Periode>>();
            #endregion
            #region Utilisateur
            services.AddTransient<IGenericRepository<Utilisateur>, GenericRepository<Utilisateur>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<Utilisateur>, string>, PutGenericHandler<Utilisateur>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<Utilisateur>, Utilisateur>, GetGenericHandler<Utilisateur>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<Utilisateur>, string>, AddGenericHandler<Utilisateur>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<Utilisateur>, string>, RemoveGenericHandler<Utilisateur>>();
            services.AddTransient<IRequestHandler<GetListGenericQuery<Utilisateur>, IEnumerable<Utilisateur>>, GetListGenericHandler<Utilisateur>>();
            #endregion


        }
    }
    }
