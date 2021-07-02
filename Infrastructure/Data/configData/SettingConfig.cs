using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.configData
{
    public class SettingConfig : IEntityTypeConfiguration<GeneralSetting>
    {
        private Guid Id = Guid.Parse("C22694B8-42A2-4115-9631-1C2D1E2AC5F7");

        public void Configure(EntityTypeBuilder<GeneralSetting> builder)
        {
            var setting = new GeneralSetting()
            {
                Id = Id,
                CreatedDate = new DateTime(),
                LastEditDate = new DateTime(),

                SiteName = "site name",
                SiteNameAr = "أسم الموقع",
                AdminSiteName = "name site admin",
                AdminSiteNameAr = "إسم الموقع ",
                AboutUsAr = "في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله",
                AboutUs = "In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.",
                AboutUsDescriptionAr = "في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله",
                AboutUsDescription = "In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.",
                Address = "egypt,cairo",
                AddressAr = "القاهرة,مصر",
                JobTimeDetails = "9:00 AM - 2:30 PM",
                Email = "ahmed.salama.ali.ramadan@gmail.com",
                ManegerHead = "Doctor",
                ManegerName = "Ahmed salama ali ramdain",
                ManegerPhotoPath = "/img/manager.png",
                SiteLogoPath = "/img/log0.png",
                PhoneNumbermain = "01027409328"
            };
            builder.HasData(setting);
         }
    }
}
