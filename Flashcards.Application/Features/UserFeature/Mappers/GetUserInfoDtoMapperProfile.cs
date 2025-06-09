﻿using AutoMapper;
using Flashcards.Application.Features.UserFeature.DTOs;
using Flashcards.Domain.Entities;

namespace Flashcards.Application.Features.UserFeature.Mappers
{
    public class GetUserInfoDtoMapperProfile : Profile
    {
        public GetUserInfoDtoMapperProfile()
        {
            CreateMap<User, GetUserInfoDto>();
        }
    }
}
