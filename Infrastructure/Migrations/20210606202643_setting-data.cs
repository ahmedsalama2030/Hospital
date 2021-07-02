using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class settingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GeneralSettings",
                columns: new[] { "Id", "AboutUs", "AboutUsAr", "AboutUsDescription", "AboutUsDescriptionAr", "Address", "AddressAr", "AdminSiteName", "AdminSiteNameAr", "CreatedDate", "Email", "FacebookPath", "History", "HistoryAr", "JobTimeDetails", "LastEditDate", "LinkedInPath", "ManegerHead", "ManegerHeadAr", "ManegerName", "ManegerNameAr", "ManegerPhotoPath", "ManegerWord", "ManegerWordAr", "MapPath", "Message", "MessageAr", "PhoneNumberSecond", "PhoneNumberThird", "PhoneNumbermain", "SiteLogoPath", "SiteName", "SiteNameAr", "TwitterPath", "Value", "ValueAr", "VideoPath", "Vision", "VisionAr", "YoutubePath" },
                values: new object[] { new Guid("c22694b8-42a2-4115-9631-1c2d1e2ac5f7"), "In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.", "في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله", "In the medical complex, we focus on the quality of doctors and the best and latest services, so do not worry about any disease that affects you. Just visit us and you will see that an integrated professional team of distinguished doctors in all specialties will take care of you and heal you, God willing.", "في المجمع الطبي  نركز على جودة الاطباء وافضل الخدمات واحدثها، لذالك لا تقلق من اي مرض يصيبك فقط قم بزيارتنا وسترى بان فريق عمل متكامل محترف من الاطباء المتميزين في كل الاختصاصات سيقومون برعايتك وشفائك بأذن الله", "egypt,cairo", "القاهرة,مصر", "name site admin", "إسم الموقع ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.salama.ali.ramadan@gmail.com", null, null, null, "9:00 AM - 2:30 PM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Doctor", null, "Ahmed salama ali ramdain", null, "/img/manager.png", null, null, null, null, null, null, null, "01027409328", "/img/log0.png", "site name", "أسم الموقع", null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b22694b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "ConcurrencyStamp",
                value: "133a7026-fa61-404c-92c6-29ee587a94b4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b22698b1-42a2-4115-9634-1c2d1e2ac5f8"),
                column: "ConcurrencyStamp",
                value: "7455750e-3a25-441c-ace7-a49eb5568da0");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c22694b8-42a2-4115-9631-1c2d1e2ac5f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "574cac4e-c6c2-4e4a-8f12-c1cecd157b5a", "AQAAAAEAACcQAAAAEMeuVdD1eBOnTpajVqRD4stRnlg0Y7Alb8tNeL71WlgApNNFnpb6DRBtL/VEJ7faiw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GeneralSettings",
                keyColumn: "Id",
                keyValue: new Guid("c22694b8-42a2-4115-9631-1c2d1e2ac5f7"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b22694b8-42a2-4115-9631-1c2d1e2ac5f7"),
                column: "ConcurrencyStamp",
                value: "70d1ed5e-1e7d-4b3a-98ad-c6ff6def363e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b22698b1-42a2-4115-9634-1c2d1e2ac5f8"),
                column: "ConcurrencyStamp",
                value: "26b7f116-d687-4ef3-8828-5a3d82daa6ad");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c22694b8-42a2-4115-9631-1c2d1e2ac5f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c6d173c-238d-4577-8667-f6af5f497fb5", "AQAAAAEAACcQAAAAECHFuZY140a+UkLosi5JNJzF0uwrmSJkvHEeEVAFYeAP2p8uXgNmpVgSo7saRIPqng==" });
        }
    }
}
