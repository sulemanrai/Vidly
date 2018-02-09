using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            
            CreateMap<Movie, MovieDto>();

            CreateMap<Genre, MovieGenreTypeDto>();


        }

    }
}