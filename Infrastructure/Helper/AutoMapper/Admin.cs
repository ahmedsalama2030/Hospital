using AutoMapper;
using Core.Common;
using Core.Dtos.Auth;
using Core.Dtos.clinics;
using Core.Dtos.CommonQuestion;
using Core.Dtos.Department;
using Core.Dtos.Doctor;
using Core.Dtos.hospital;
using Core.Dtos.News;
using Core.Dtos.settings;
 using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Helper.AutoMapper
{
    public partial class AutoMapperProfiles
    {
        public class Admin : Profile
        {
            public Admin()
            {
                CreateMap<News, NewsDtoGet>().ReverseMap();
                CreateMap<NewsDtoPost, News>();
                CreateMap<NewsImage, NewsImageGet>().ReverseMap(); ;
                // images news
                CreateMap<ImagesPath, NewsImage>();
                CreateMap<ImagesPath, NewsImageGet>();
                // clinics 
                CreateMap<ClinicSchedul, ClinicSchedulDtoGet>().ReverseMap();
                // hospitals
                CreateMap<Hospital, HospitalDtoGet>().ReverseMap();
                CreateMap<Hospital, HospitalSelectListDto>();

                // common question
                CreateMap<CommonQuestion, CommonQuestionDtoGet>().ReverseMap();
                // departments
                 CreateMap<Department, DepartmentDtoGet>().ReverseMap();
                CreateMap<DepartmentImages, DepartmentImagesDtoGet>().ReverseMap();
                 CreateMap<ImagesPath, DepartmentImages>();

                // Doctors
                CreateMap<Doctor, DoctorDtoList>();
                 CreateMap<DoctorDtoPost, Doctor>().ReverseMap();

                // generalSettings
                 
                 CreateMap<GeneralSetting, GeneralSettingsDtoGet>().ReverseMap();
                // users
                CreateMap<User, UserListDto>().ReverseMap() ;
                CreateMap<UserEditDto, User>().ReverseMap();
                CreateMap<UserEditDto, User>().ReverseMap();
                CreateMap<UserRegisterDto, User>().ReverseMap();
                // roles
                CreateMap<Role, RolesUserDto>().ReverseMap();


            }
        }
    }
}