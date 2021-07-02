using AutoMapper;
using Core.Dtos.Contact_us;
using Core.Dtos_User;
using Core.Dtos_User.AboutUs;
using Core.Dtos_User.Appointment;
using Core.Dtos_User.common_question;
using Core.Dtos_User.ContactUs;
using Core.Dtos_User.Department;
using Core.Dtos_User.Doctor;
using Core.Dtos_User.Home;
using Core.Dtos_User.hospital;
using Core.Dtos_User.News;
using Core.Dtos_User.Sliders;
using Core.Entities;
 using System;
using System.Linq;

namespace Infrastructure.Helper.AutoMapper
{
    public partial class AutoMapperProfiles
    {
        public class Users : Profile
        {
            public Users()
            {

                // general contact
                CreateMap<GeneralSetting, GeneraDetail>();
                CreateMap<GeneralSetting, ContactUsDto>();
                CreateMap<GeneralSetting, AboutUsDetailDto>();
                CreateMap<GeneralSetting, HomeDetailDto>();
                CreateMap<GeneralSetting, HeaderFooterDetailsDto>();
              // question
                CreateMap<CommonQuestion, CommonQuestionListDto>();
                // department
                CreateMap<Department, DepartmentDetailDto>();
                CreateMap<Department, DepartmentListDtoUser>();
                CreateMap<Department, deparmentMiniDto>().ReverseMap();

                // doctor
                CreateMap<Doctor, DoctorDtoListGet>();
                //hospital
                CreateMap<Hospital, HospitalGetlDto>();
                // news 
                 
                CreateMap<News, NewsUserListDto>().ForMember(dest => dest.Path, 
                    op => { op.MapFrom(src => src.NewsImages.FirstOrDefault(a => a.isMain == true).Path); });
                
                CreateMap<AppointmentGetDto, Appointment>()
                    .ForMember(a => a.CreatedDate, op => op.MapFrom(s => DateTime.Now)).
                  ForMember(a => a.LastEditDate, op => op.MapFrom(s => DateTime.Now));
                // slider
                CreateMap<Slider, SliderDto>();

                // contact us
                CreateMap<ContactusRegisterDto, ContactUs>();

 
            }
        }
    }
}