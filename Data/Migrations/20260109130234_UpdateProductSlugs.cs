using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductSlugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(2659) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3082), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3086), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3091) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3094), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 65, DateTimeKind.Utc).AddTicks(2194), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(9974), new DateTime(2026, 1, 9, 13, 2, 32, 65, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 95, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 95, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 93, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 1, 9, 13, 2, 32, 93, DateTimeKind.Utc).AddTicks(2358) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 80, DateTimeKind.Utc).AddTicks(122), new DateTime(2026, 1, 9, 13, 2, 32, 79, DateTimeKind.Utc).AddTicks(6163), new DateTime(2026, 7, 9, 13, 2, 32, 79, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 81, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AltText", "CreatedAt" },
                values: new object[] { "Majtki damskie bawełniane wysokie 5-pak - widok z przodu", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AltText", "CreatedAt" },
                values: new object[] { "Majtki damskie bawełniane wysokie 5-pak - szczegóły produktu", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6073) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane wysokie 6-pak - widok z przodu", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6080), 1, "products/briefs-6pack/image-1.jpg", true, 2 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane wysokie 6-pak - szczegóły produktu", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6086), 2, "products/briefs-6pack/image-2.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane wysokie 8-pak - widok z przodu, najlepsza wartość", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6093), 1, "products/briefs-8pack/image-1.jpg", true, 3 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane wysokie 8-pak - szczegóły produktu, oszczędności", new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6116), 2, "products/briefs-8pack/image-2.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "CreatedAt", "CultureCode", "Description", "MetaDescription", "MetaKeywords", "Name", "ProductId", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 9, 13, 2, 32, 88, DateTimeKind.Utc).AddTicks(7888), "pl-PL", "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 5 sztuk w zestawie. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "majtki damskie, bawełna, bielizna damska, majtki wysokie, 5-pak, Kokomija", "Majtki damskie bawełniane wysokie - 5 pak", 1, "majtki-damskie-bawelniane-wysokie-5-pak", new DateTime(2026, 1, 9, 13, 2, 32, 88, DateTimeKind.Utc).AddTicks(7892) },
                    { 2, new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1060), "en-US", "High quality women's cotton briefs in a set of 5. Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's high-waist cotton briefs 5-pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "women's briefs, cotton underwear, high-waist briefs, 5-pack, Kokomija", "Women's High-Waist Cotton Briefs - 5 Pack", 1, "womens-cotton-briefs-5-pack", new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1061) },
                    { 3, new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1065), "pl-PL", "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 6 sztuk w zestawie. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Oszczędź kupując więcej!", "majtki damskie, bawełna, bielizna damska, majtki wysokie, 6-pak, zestaw, Kokomija", "Majtki damskie bawełniane wysokie - 6 pak", 2, "majtki-damskie-bawelniane-wysokie-6-pak", new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1066) },
                    { 4, new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1069), "en-US", "High quality women's cotton briefs in a set of 6. Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's high-waist cotton briefs 6-pack. Comfortable, breathable and durable underwear. Save more when buying more!", "women's briefs, cotton underwear, high-waist briefs, 6-pack, value pack, Kokomija", "Women's High-Waist Cotton Briefs - 6 Pack", 2, "womens-cotton-briefs-6-pack", new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1070) },
                    { 5, new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1073), "pl-PL", "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 8 sztuk w zestawie - NAJLEPSZA WARTOŚĆ! Wygodne, przewiewne i trwałe. Dostawa w Polsce. Największe oszczędności!", "majtki damskie, bawełna, bielizna damska, majtki wysokie, 8-pak, najlepsza wartość, oszczędności, Kokomija", "Majtki damskie bawełniane wysokie - 8 pak", 3, "majtki-damskie-bawelniane-wysokie-8-pak", new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1073) },
                    { 6, new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1076), "en-US", "High quality women's cotton briefs in a set of 8. Comfortable, breathable and durable. Best value choice! Available in various colors and sizes.", "Buy women's high-waist cotton briefs 8-pack - BEST VALUE! Comfortable, breathable and durable underwear. Maximum savings!", "women's briefs, cotton underwear, high-waist briefs, 8-pack, best value, savings, Kokomija", "Women's High-Waist Cotton Briefs - 8 Pack", 3, "womens-cotton-briefs-8-pack", new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1077) }
                });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(113), "majtki-damskie-bawelniane-wysokie-5-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(663), "majtki-damskie-bawelniane-wysokie-6-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(668), "majtki-damskie-bawelniane-wysokie-8-pak" });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(829) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1371), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1377) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1386) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1286) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1724), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1725) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1732), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1734) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 70, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 61, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 61, DateTimeKind.Utc).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(100), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(992), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(997) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 778, DateTimeKind.Utc).AddTicks(9977), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1777), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(68), new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 780, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(9437), new DateTime(2026, 1, 8, 23, 40, 38, 780, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 796, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 796, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 795, DateTimeKind.Utc).AddTicks(7233), new DateTime(2026, 1, 8, 23, 40, 38, 795, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 1, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(5072), new DateTime(2026, 7, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 789, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AltText", "CreatedAt" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 1", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AltText", "CreatedAt" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 2", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 3", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1080), 3, "products/briefs-5pack/image-3.jpg", false, 1 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 4", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1084), 4, "products/briefs-5pack/image-4.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 5", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1088), 5, "products/briefs-5pack/image-5.jpg", false, 1 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AltText", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[] { "Majtki damskie bawełniane 5-pak - zdjęcie 6", new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1104), 6, "products/briefs-5pack/image-6.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 7, "Majtki damskie bawełniane 5-pak - zdjęcie 7", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1108), 7, "products/briefs-5pack/image-7.jpg", 1 },
                    { 8, "Majtki damskie bawełniane 5-pak - zdjęcie 8", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1112), 8, "products/briefs-5pack/image-8.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 9, "Majtki damskie bawełniane 6-pak - zdjęcie 1", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1119), 1, "products/briefs-6pack/image-1.jpg", true, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 10, "Majtki damskie bawełniane 6-pak - zdjęcie 2", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1125), 2, "products/briefs-6pack/image-2.jpg", 2 },
                    { 11, "Majtki damskie bawełniane 6-pak - zdjęcie 3", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1129), 3, "products/briefs-6pack/image-3.jpg", 2 },
                    { 12, "Majtki damskie bawełniane 6-pak - zdjęcie 4", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1137), 4, "products/briefs-6pack/image-4.jpg", 2 },
                    { 13, "Majtki damskie bawełniane 6-pak - zdjęcie 5", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1141), 5, "products/briefs-6pack/image-5.jpg", 2 },
                    { 14, "Majtki damskie bawełniane 6-pak - zdjęcie 6", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1144), 6, "products/briefs-6pack/image-6.jpg", 2 },
                    { 15, "Majtki damskie bawełniane 6-pak - zdjęcie 7", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1148), 7, "products/briefs-6pack/image-7.jpg", 2 },
                    { 16, "Majtki damskie bawełniane 6-pak - zdjęcie 8", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1151), 8, "products/briefs-6pack/image-8.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 17, "Majtki damskie bawełniane 8-pak - zdjęcie 1", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1157), 1, "products/briefs-8pack/image-1.jpg", true, 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 18, "Majtki damskie bawełniane 8-pak - zdjęcie 2", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1163), 2, "products/briefs-8pack/image-2.jpg", 3 },
                    { 19, "Majtki damskie bawełniane 8-pak - zdjęcie 3", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1168), 3, "products/briefs-8pack/image-3.jpg", 3 },
                    { 20, "Majtki damskie bawełniane 8-pak - zdjęcie 4", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1171), 4, "products/briefs-8pack/image-4.jpg", 3 },
                    { 21, "Majtki damskie bawełniane 8-pak - zdjęcie 5", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1175), 5, "products/briefs-8pack/image-5.jpg", 3 },
                    { 22, "Majtki damskie bawełniane 8-pak - zdjęcie 6", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1178), 6, "products/briefs-8pack/image-6.jpg", 3 },
                    { 23, "Majtki damskie bawełniane 8-pak - zdjęcie 7", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1183), 7, "products/briefs-8pack/image-7.jpg", 3 },
                    { 24, "Majtki damskie bawełniane 8-pak - zdjęcie 8", null, new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1186), 8, "products/briefs-8pack/image-8.jpg", 3 }
                });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(8926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9472), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9933), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9938), null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(1257), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2626), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2634), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2638), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2642), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(6578), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7193), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7203), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 777, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 777, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8204), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8205) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8209), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8210) });
        }
    }
}
