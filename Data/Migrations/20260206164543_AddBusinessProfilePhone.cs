using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessProfilePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "BusinessProfiles",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8275), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8921), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8922) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8925), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8928), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8932), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(6387), new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(4614), new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 826, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 826, DateTimeKind.Utc).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 825, DateTimeKind.Utc).AddTicks(6922), new DateTime(2026, 2, 6, 16, 45, 39, 825, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(8066), new DateTime(2026, 2, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(5856), new DateTime(2026, 8, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 790, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3309));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 794, DateTimeKind.Utc).AddTicks(9488), new DateTime(2026, 2, 6, 16, 45, 39, 794, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(3911), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6838), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3279));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(6519), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7184), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7191), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(8634), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9264), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9273) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9277), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 779, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 779, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(6843), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7799), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7800) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "BusinessProfiles");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4862), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(2707) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(2651), new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 334, DateTimeKind.Utc).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 334, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 333, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 2, 5, 18, 55, 22, 333, DateTimeKind.Utc).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(3086), new DateTime(2026, 2, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(1221) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 302, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 305, DateTimeKind.Utc).AddTicks(2918), new DateTime(2026, 2, 5, 18, 55, 22, 305, DateTimeKind.Utc).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(586), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(1478), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3245), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3266), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3287), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3287) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3300), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5989));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6040));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6044));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6171));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6314));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6332));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6356));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6399));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6476));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6489));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6503));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(2811), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3584), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3587), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3591), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3592) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3595), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(6418), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7059), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7063), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7101), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7105), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 290, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 298, DateTimeKind.Utc).AddTicks(7933), new DateTime(2026, 2, 5, 18, 55, 22, 298, DateTimeKind.Utc).AddTicks(9407) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(442), new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(447) });
        }
    }
}
