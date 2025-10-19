using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AdvancedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(4851), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5486), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5490), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5493), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5497) });

            migrationBuilder.InsertData(
                table: "CarouselSlides",
                columns: new[] { "Id", "AnimationType", "BackgroundColor", "ButtonClass", "ButtonText", "CategoryId", "CreatedAt", "CreatedBy", "CustomCssClass", "DeletedAt", "DeletedBy", "DisplayOrder", "Duration", "EndDate", "ImageAlt", "ImagePath", "IsActive", "LinkUrl", "Location", "MobileImagePath", "StartDate", "Subtitle", "TextAlign", "TextColor", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "fade", null, "btn-primary", "Kup Teraz", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6295), null, null, null, null, 1, 5000, null, "Nowa kolekcja wiosenna 2025", "1.jpg", true, "/damskie", "home", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(5701), "Odkryj najnowsze trendy w modzie damskiej i męskiej", "center", null, "Nowa Kolekcja Wiosna 2025", null, null },
                    { 2, "fade", null, "btn-primary", "Zobacz Ofertę", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6633), null, null, null, null, 2, 5000, null, "Wielka wyprzedaż do -50%", "2.jpg", true, "/meskie", "home", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6632), "Nie przegap okazji! Setki produktów w obniżonych cenach", "center", null, "Wyprzedaż do -50%", null, null },
                    { 3, "fade", null, "btn-primary", "Przeglądaj", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6636), null, null, null, null, 3, 5000, null, "Elegancka odzież na specjalne okazje", "3.jpg", true, "/odziez-wierzchnia", "home", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6636), "Koszule, sukienki i dodatki dla wymagających", "center", null, "Elegancja na Każdą Okazję", null, null },
                    { 4, "fade", null, "btn-primary", "Sprawdź", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6639), null, null, null, null, 4, 5000, null, "Darmowa dostawa powyżej 200 PLN", "4.jpg", true, "/akcesoria", "home", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6639), "Przy zamówieniach powyżej 200 PLN", "center", null, "Darmowa Dostawa", null, null },
                    { 5, "fade", null, "btn-primary", "Odkryj Więcej", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6643), null, null, null, null, 5, 5000, null, "Kolekcja zimowych kurtek", "5.jpg", true, "/odziez-wierzchnia", "home", null, new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6642), "Przygotuj się na zimę z naszą kolekcją kurtek", "center", null, "Stylowe Kurtki", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "IconCssClass", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(6412), "Odzież damska", "fas fa-female", "Damskie", "damskie" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "IconCssClass", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7153), "Odzież męska", "fas fa-male", "Męskie", "meskie" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "IconCssClass", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7160), "Kurtki i płaszcze", 3, "fas fa-wind", "Odzież Wierzchnia", null, "odziez-wierzchnia" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "IconCssClass", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7163), "Dodatki i akcesoria", 4, "fas fa-shopping-bag", "Akcesoria", null, "akcesoria" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7774), "Eleganckie sukienki damskie", 1, "Sukienki", "damskie-sukienki" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7782), "Modne spódnice", 2, "Spódnice", 1, "damskie-spodnice" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7785), "Eleganckie bluzki damskie", 3, "Bluzki", 1, "damskie-bluzki" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7788), "Spodnie damskie", 4, "Spodnie", 1, "damskie-spodnie" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "IconCssClass", "IsActive", "Name", "ParentCategoryId", "ShowInNavbar", "Slug" },
                values: new object[,]
                {
                    { 9, new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7790), "Eleganckie koszule męskie", 1, null, true, "Koszule", 2, true, "meskie-koszule" },
                    { 10, new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7793), "Spodnie męskie", 2, null, true, "Spodnie", 2, true, "meskie-spodnie" },
                    { 11, new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7796), "Koszulki męskie", 3, null, true, "T-Shirty", 2, true, "meskie-tshirty" },
                    { 12, new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7799), "Bluzy męskie", 4, null, true, "Bluzy", 2, true, "meskie-bluzy" }
                });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Name", "Price", "StripePriceId", "StripeProductId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(447), "Piękna, zwiewna sukienka idealna na letnie wieczory. Wykonana z wysokiej jakości materiału, zapewnia komfort i styl.", true, "Elegancka Sukienka Letnia", 189.99m, "price_sukienka_letnia_001", "prod_sukienka_letnia_001", null },
                    { 2, 6, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(879), "Klasyczna plisowana spódnica midi. Doskonała do biura i na specjalne okazje.", true, "Spódnica Midi Plisowana", 149.99m, "price_spodnica_midi_001", "prod_spodnica_midi_001", null },
                    { 3, 7, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(916), "Elegancka biała bluzka z delikatnymi wzorami. Idealna do spodni i spódnic.", true, "Bluzka Elegancka Biała", 99.99m, "price_bluzka_biala_001", "prod_bluzka_biala_001", null },
                    { 4, 8, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(919), "Klasyczne czarne spodnie damskie. Wygodne i eleganckie, pasują do każdej stylizacji.", true, "Spodnie Damskie Czarne", 129.99m, "price_spodnie_damskie_001", "prod_spodnie_damskie_001", null },
                    { 5, 7, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(923), "Kolorowa bluzka w kwiatowy wzór. Idealna na wiosnę i lato.", true, "Bluzka Kwiatowa Wzór", 89.99m, "price_bluzka_kwiatowa_001", "prod_bluzka_kwiatowa_001", null },
                    { 13, 3, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(949), "Lekka kurtka wiosenna dla kobiet. Wodoodporna i wygodna.", true, "Kurtka Wiosenna Damska", 299.99m, "price_kurtka_wiosenna_001", "prod_kurtka_wiosenna_001", null },
                    { 14, 3, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(953), "Elegancki wełniany płaszcz męski. Ciepły i stylowy na zimę.", true, "Płaszcz Męski Wełniany", 449.99m, "price_plaszcz_welniany_001", "prod_plaszcz_welniany_001", null },
                    { 15, 3, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(956), "Klasyczna kurtka skórzana. Ponadczasowy styl dla mężczyzn i kobiet.", true, "Kurtka Skórzana", 599.99m, "price_kurtka_skorzana_001", "prod_kurtka_skorzana_001", null }
                });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6576));

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 1, "Product 1 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8150), 1, "1.jpg", true, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 2, "Product 1 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8599), 2, "2.jpg", 1 },
                    { 3, "Product 1 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8604), 3, "3.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 4, "Product 2 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8609), 1, "1.jpg", true, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 5, "Product 2 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8613), 2, "2.jpg", 2 },
                    { 6, "Product 2 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8622), 3, "3.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 7, "Product 3 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8626), 1, "1.jpg", true, 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 8, "Product 3 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8630), 2, "2.jpg", 3 },
                    { 9, "Product 3 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8634), 3, "3.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 10, "Product 4 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8640), 1, "1.jpg", true, 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 11, "Product 4 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8644), 2, "2.jpg", 4 },
                    { 12, "Product 4 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8648), 3, "3.jpg", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 13, "Product 5 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8652), 1, "1.jpg", true, 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 14, "Product 5 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8657), 2, "2.jpg", 5 },
                    { 15, "Product 5 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8660), 3, "3.jpg", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 37, "Product 13 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8820), 1, "1.jpg", true, 13 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 38, "Product 13 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8824), 2, "2.jpg", 13 },
                    { 39, "Product 13 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8828), 3, "3.jpg", 13 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 40, "Product 14 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8832), 1, "1.jpg", true, 14 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 41, "Product 14 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8835), 2, "2.jpg", 14 },
                    { 42, "Product 14 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8839), 3, "3.jpg", 14 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 43, "Product 15 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8843), 1, "1.jpg", true, 15 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 44, "Product 15 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8847), 2, "2.jpg", 15 },
                    { 45, "Product 15 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8851), 3, "3.jpg", 15 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity", "StripePriceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3325), true, 189.99m, 1, "SUK-001-2-3", 2, 25, "price_suk_001_2_3", null },
                    { 2, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3706), true, 189.99m, 1, "SUK-001-2-4", 2, 25, "price_suk_001_2_4", null },
                    { 3, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3711), true, 189.99m, 1, "SUK-001-2-1", 2, 25, "price_suk_001_2_1", null },
                    { 4, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3715), true, 189.99m, 1, "SUK-001-3-3", 3, 25, "price_suk_001_3_3", null },
                    { 5, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3719), true, 189.99m, 1, "SUK-001-3-4", 3, 25, "price_suk_001_3_4", null },
                    { 6, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3733), true, 189.99m, 1, "SUK-001-3-1", 3, 25, "price_suk_001_3_1", null },
                    { 7, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3736), true, 189.99m, 1, "SUK-001-4-3", 4, 25, "price_suk_001_4_3", null },
                    { 8, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3740), true, 189.99m, 1, "SUK-001-4-4", 4, 25, "price_suk_001_4_4", null },
                    { 9, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3744), true, 189.99m, 1, "SUK-001-4-1", 4, 25, "price_suk_001_4_1", null },
                    { 10, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3749), true, 189.99m, 1, "SUK-001-5-3", 5, 25, "price_suk_001_5_3", null },
                    { 11, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3752), true, 189.99m, 1, "SUK-001-5-4", 5, 25, "price_suk_001_5_4", null },
                    { 12, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3756), true, 189.99m, 1, "SUK-001-5-1", 5, 25, "price_suk_001_5_1", null },
                    { 13, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3781), true, 149.99m, 2, "SPO-001-1-1", 1, 30, "price_spo_001_1_1", null },
                    { 14, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3786), true, 149.99m, 2, "SPO-001-1-2", 1, 30, "price_spo_001_1_2", null },
                    { 15, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3822), true, 149.99m, 2, "SPO-001-1-7", 1, 30, "price_spo_001_1_7", null },
                    { 16, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3826), true, 149.99m, 2, "SPO-001-2-1", 2, 30, "price_spo_001_2_1", null },
                    { 17, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3830), true, 149.99m, 2, "SPO-001-2-2", 2, 30, "price_spo_001_2_2", null },
                    { 18, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3835), true, 149.99m, 2, "SPO-001-2-7", 2, 30, "price_spo_001_2_7", null },
                    { 19, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3839), true, 149.99m, 2, "SPO-001-3-1", 3, 30, "price_spo_001_3_1", null },
                    { 20, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3843), true, 149.99m, 2, "SPO-001-3-2", 3, 30, "price_spo_001_3_2", null },
                    { 21, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3846), true, 149.99m, 2, "SPO-001-3-7", 3, 30, "price_spo_001_3_7", null },
                    { 22, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3850), true, 149.99m, 2, "SPO-001-4-1", 4, 30, "price_spo_001_4_1", null },
                    { 23, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3854), true, 149.99m, 2, "SPO-001-4-2", 4, 30, "price_spo_001_4_2", null },
                    { 24, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3858), true, 149.99m, 2, "SPO-001-4-7", 4, 30, "price_spo_001_4_7", null },
                    { 25, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3895), true, 99.99m, 3, "BLU-001-2-2", 2, 40, "price_blu_001_2_2", null },
                    { 26, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3899), true, 99.99m, 3, "BLU-001-3-2", 3, 40, "price_blu_001_3_2", null },
                    { 27, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3903), true, 99.99m, 3, "BLU-001-4-2", 4, 40, "price_blu_001_4_2", null },
                    { 28, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3907), true, 99.99m, 3, "BLU-001-5-2", 5, 40, "price_blu_001_5_2", null },
                    { 29, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3921), true, 129.99m, 4, "SPD-001-2-1", 2, 35, "price_spd_001_2_1", null },
                    { 30, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3925), true, 129.99m, 4, "SPD-001-2-8", 2, 35, "price_spd_001_2_8", null },
                    { 31, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3929), true, 129.99m, 4, "SPD-001-3-1", 3, 35, "price_spd_001_3_1", null },
                    { 32, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3933), true, 129.99m, 4, "SPD-001-3-8", 3, 35, "price_spd_001_3_8", null },
                    { 33, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3937), true, 129.99m, 4, "SPD-001-4-1", 4, 35, "price_spd_001_4_1", null },
                    { 34, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3942), true, 129.99m, 4, "SPD-001-4-8", 4, 35, "price_spd_001_4_8", null },
                    { 35, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3946), true, 129.99m, 4, "SPD-001-5-1", 5, 35, "price_spd_001_5_1", null },
                    { 36, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3950), true, 129.99m, 4, "SPD-001-5-8", 5, 35, "price_spd_001_5_8", null },
                    { 37, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3953), true, 129.99m, 4, "SPD-001-6-1", 6, 35, "price_spd_001_6_1", null },
                    { 38, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3957), true, 129.99m, 4, "SPD-001-6-8", 6, 35, "price_spd_001_6_8", null },
                    { 39, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3970), true, 89.99m, 5, "BLK-001-1-3", 1, 45, "price_blk_001_1_3", null },
                    { 40, 6, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3975), true, 89.99m, 5, "BLK-001-1-6", 1, 45, "price_blk_001_1_6", null },
                    { 41, 5, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3979), true, 89.99m, 5, "BLK-001-1-5", 1, 45, "price_blk_001_1_5", null },
                    { 42, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3983), true, 89.99m, 5, "BLK-001-2-3", 2, 45, "price_blk_001_2_3", null },
                    { 43, 6, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3986), true, 89.99m, 5, "BLK-001-2-6", 2, 45, "price_blk_001_2_6", null },
                    { 44, 5, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3990), true, 89.99m, 5, "BLK-001-2-5", 2, 45, "price_blk_001_2_5", null },
                    { 45, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4008), true, 89.99m, 5, "BLK-001-3-3", 3, 45, "price_blk_001_3_3", null },
                    { 46, 6, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4012), true, 89.99m, 5, "BLK-001-3-6", 3, 45, "price_blk_001_3_6", null },
                    { 47, 5, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4016), true, 89.99m, 5, "BLK-001-3-5", 3, 45, "price_blk_001_3_5", null },
                    { 48, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4020), true, 89.99m, 5, "BLK-001-4-3", 4, 45, "price_blk_001_4_3", null },
                    { 49, 6, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4023), true, 89.99m, 5, "BLK-001-4-6", 4, 45, "price_blk_001_4_6", null },
                    { 50, 5, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4027), true, 89.99m, 5, "BLK-001-4-5", 4, 45, "price_blk_001_4_5", null },
                    { 51, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4031), true, 89.99m, 5, "BLK-001-5-3", 5, 45, "price_blk_001_5_3", null },
                    { 52, 6, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4034), true, 89.99m, 5, "BLK-001-5-6", 5, 45, "price_blk_001_5_6", null },
                    { 53, 5, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4038), true, 89.99m, 5, "BLK-001-5-5", 5, 45, "price_blk_001_5_5", null },
                    { 113, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4330), true, 299.99m, 13, "KUR-001-2-3", 2, 20, "price_kur_001_2_3", null },
                    { 114, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4334), true, 299.99m, 13, "KUR-001-2-4", 2, 20, "price_kur_001_2_4", null },
                    { 115, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4338), true, 299.99m, 13, "KUR-001-2-1", 2, 20, "price_kur_001_2_1", null },
                    { 116, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4342), true, 299.99m, 13, "KUR-001-3-3", 3, 20, "price_kur_001_3_3", null },
                    { 117, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4345), true, 299.99m, 13, "KUR-001-3-4", 3, 20, "price_kur_001_3_4", null },
                    { 118, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4349), true, 299.99m, 13, "KUR-001-3-1", 3, 20, "price_kur_001_3_1", null },
                    { 119, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4353), true, 299.99m, 13, "KUR-001-4-3", 4, 20, "price_kur_001_4_3", null },
                    { 120, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4357), true, 299.99m, 13, "KUR-001-4-4", 4, 20, "price_kur_001_4_4", null },
                    { 121, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4360), true, 299.99m, 13, "KUR-001-4-1", 4, 20, "price_kur_001_4_1", null },
                    { 122, 3, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4364), true, 299.99m, 13, "KUR-001-5-3", 5, 20, "price_kur_001_5_3", null },
                    { 123, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4368), true, 299.99m, 13, "KUR-001-5-4", 5, 20, "price_kur_001_5_4", null },
                    { 124, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4371), true, 299.99m, 13, "KUR-001-5-1", 5, 20, "price_kur_001_5_1", null },
                    { 125, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4378), true, 449.99m, 14, "PLA-001-3-1", 3, 15, "price_pla_001_3_1", null },
                    { 126, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4382), true, 449.99m, 14, "PLA-001-3-8", 3, 15, "price_pla_001_3_8", null },
                    { 127, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4386), true, 449.99m, 14, "PLA-001-4-1", 4, 15, "price_pla_001_4_1", null },
                    { 128, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4390), true, 449.99m, 14, "PLA-001-4-8", 4, 15, "price_pla_001_4_8", null },
                    { 129, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4394), true, 449.99m, 14, "PLA-001-5-1", 5, 15, "price_pla_001_5_1", null },
                    { 130, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4400), true, 449.99m, 14, "PLA-001-5-8", 5, 15, "price_pla_001_5_8", null },
                    { 131, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4404), true, 449.99m, 14, "PLA-001-6-1", 6, 15, "price_pla_001_6_1", null },
                    { 132, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4407), true, 449.99m, 14, "PLA-001-6-8", 6, 15, "price_pla_001_6_8", null },
                    { 133, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4413), true, 599.99m, 15, "SKO-001-3", 3, 10, "price_sko_001_3", null },
                    { 134, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4417), true, 599.99m, 15, "SKO-001-4", 4, 10, "price_sko_001_4", null },
                    { 135, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4420), true, 599.99m, 15, "SKO-001-5", 5, 10, "price_sko_001_5", null },
                    { 136, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4423), true, 599.99m, 15, "SKO-001-6", 6, 10, "price_sko_001_6", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Name", "Price", "StripePriceId", "StripeProductId", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, 9, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(926), "Elegancka niebieska koszula męska. Idealna do garnituru i na oficjalne spotkania.", true, "Koszula Męska Niebieska", 159.99m, "price_koszula_niebieska_001", "prod_koszula_niebieska_001", null },
                    { 7, 10, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(930), "Klasyczne spodnie męskie typu chino. Wygodne i stylowe na co dzień.", true, "Spodnie Męskie Chino", 179.99m, "price_spodnie_chino_001", "prod_spodnie_chino_001", null },
                    { 8, 11, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(933), "Podstawowy biały t-shirt męski. Wysokiej jakości bawełna, idealny na co dzień.", true, "T-Shirt Męski Basic Biały", 59.99m, "price_tshirt_bialy_001", "prod_tshirt_bialy_001", null },
                    { 9, 11, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(936), "Podstawowy czarny t-shirt męski. Niezawodny element każdej szafy.", true, "T-Shirt Męski Basic Czarny", 59.99m, "price_tshirt_czarny_001", "prod_tshirt_czarny_001", null },
                    { 10, 12, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(939), "Ciepła i wygodna bluza męska z kapturem. Idealna na chłodniejsze dni.", true, "Bluza Męska z Kapturem", 139.99m, "price_bluza_kaptur_001", "prod_bluza_kaptur_001", null },
                    { 11, 9, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(943), "Klasyczna biała koszula męska. Must-have w każdej szafie.", true, "Koszula Męska Biała Classic", 149.99m, "price_koszula_biala_001", "prod_koszula_biala_001", null },
                    { 12, 10, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(946), "Klasyczne jeansy męskie w kolorze ciemnego denimu. Trwałe i stylowe.", true, "Spodnie Męskie Jeans", 199.99m, "price_jeans_meskie_001", "prod_jeans_meskie_001", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 16, "Product 6 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8664), 1, "1.jpg", true, 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 17, "Product 6 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8672), 2, "2.jpg", 6 },
                    { 18, "Product 6 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8677), 3, "3.jpg", 6 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 19, "Product 7 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8681), 1, "1.jpg", true, 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 20, "Product 7 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8684), 2, "2.jpg", 7 },
                    { 21, "Product 7 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8688), 3, "3.jpg", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 22, "Product 8 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8712), 1, "1.jpg", true, 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 23, "Product 8 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8716), 2, "2.jpg", 8 },
                    { 24, "Product 8 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8725), 3, "3.jpg", 8 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 25, "Product 9 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8729), 1, "1.jpg", true, 9 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 26, "Product 9 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8737), 2, "2.jpg", 9 },
                    { 27, "Product 9 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8742), 3, "3.jpg", 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 28, "Product 10 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8752), 1, "1.jpg", true, 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 29, "Product 10 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8756), 2, "2.jpg", 10 },
                    { 30, "Product 10 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8759), 3, "3.jpg", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 31, "Product 11 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8762), 1, "1.jpg", true, 11 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 32, "Product 11 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8766), 2, "2.jpg", 11 },
                    { 33, "Product 11 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8770), 3, "3.jpg", 11 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 34, "Product 12 Image 1", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8808), 1, "1.jpg", true, 12 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 35, "Product 12 Image 2", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8812), 2, "2.jpg", 12 },
                    { 36, "Product 12 Image 3", null, new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8815), 3, "3.jpg", 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity", "StripePriceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 54, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4050), true, 159.99m, 6, "KOS-001-3-4", 3, 30, "price_kos_001_3_4", null },
                    { 55, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4054), true, 159.99m, 6, "KOS-001-3-7", 3, 30, "price_kos_001_3_7", null },
                    { 56, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4058), true, 159.99m, 6, "KOS-001-4-4", 4, 30, "price_kos_001_4_4", null },
                    { 57, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4061), true, 159.99m, 6, "KOS-001-4-7", 4, 30, "price_kos_001_4_7", null },
                    { 58, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4065), true, 159.99m, 6, "KOS-001-5-4", 5, 30, "price_kos_001_5_4", null },
                    { 59, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4069), true, 159.99m, 6, "KOS-001-5-7", 5, 30, "price_kos_001_5_7", null },
                    { 60, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4073), true, 159.99m, 6, "KOS-001-6-4", 6, 30, "price_kos_001_6_4", null },
                    { 61, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4077), true, 159.99m, 6, "KOS-001-6-7", 6, 30, "price_kos_001_6_7", null },
                    { 62, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4100), true, 179.99m, 7, "CHI-001-2-1", 2, 28, "price_chi_001_2_1", null },
                    { 63, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4105), true, 179.99m, 7, "CHI-001-2-8", 2, 28, "price_chi_001_2_8", null },
                    { 64, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4108), true, 179.99m, 7, "CHI-001-2-7", 2, 28, "price_chi_001_2_7", null },
                    { 65, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4112), true, 179.99m, 7, "CHI-001-3-1", 3, 28, "price_chi_001_3_1", null },
                    { 66, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4118), true, 179.99m, 7, "CHI-001-3-8", 3, 28, "price_chi_001_3_8", null },
                    { 67, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4122), true, 179.99m, 7, "CHI-001-3-7", 3, 28, "price_chi_001_3_7", null },
                    { 68, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4126), true, 179.99m, 7, "CHI-001-4-1", 4, 28, "price_chi_001_4_1", null },
                    { 69, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4130), true, 179.99m, 7, "CHI-001-4-8", 4, 28, "price_chi_001_4_8", null },
                    { 70, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4133), true, 179.99m, 7, "CHI-001-4-7", 4, 28, "price_chi_001_4_7", null },
                    { 71, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4137), true, 179.99m, 7, "CHI-001-5-1", 5, 28, "price_chi_001_5_1", null },
                    { 72, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4141), true, 179.99m, 7, "CHI-001-5-8", 5, 28, "price_chi_001_5_8", null },
                    { 73, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4145), true, 179.99m, 7, "CHI-001-5-7", 5, 28, "price_chi_001_5_7", null },
                    { 74, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4149), true, 179.99m, 7, "CHI-001-6-1", 6, 28, "price_chi_001_6_1", null },
                    { 75, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4163), true, 179.99m, 7, "CHI-001-6-8", 6, 28, "price_chi_001_6_8", null },
                    { 76, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4167), true, 179.99m, 7, "CHI-001-6-7", 6, 28, "price_chi_001_6_7", null },
                    { 77, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4174), true, 59.99m, 8, "TSH-W-2", 2, 50, "price_tsh_w_2", null },
                    { 78, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4177), true, 59.99m, 8, "TSH-W-3", 3, 50, "price_tsh_w_3", null },
                    { 79, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4181), true, 59.99m, 8, "TSH-W-4", 4, 50, "price_tsh_w_4", null },
                    { 80, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4184), true, 59.99m, 8, "TSH-W-5", 5, 50, "price_tsh_w_5", null },
                    { 81, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4187), true, 59.99m, 8, "TSH-W-6", 6, 50, "price_tsh_w_6", null },
                    { 82, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4193), true, 59.99m, 9, "TSH-B-2", 2, 50, "price_tsh_b_2", null },
                    { 83, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4197), true, 59.99m, 9, "TSH-B-3", 3, 50, "price_tsh_b_3", null },
                    { 84, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4201), true, 59.99m, 9, "TSH-B-4", 4, 50, "price_tsh_b_4", null },
                    { 85, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4204), true, 59.99m, 9, "TSH-B-5", 5, 50, "price_tsh_b_5", null },
                    { 86, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4207), true, 59.99m, 9, "TSH-B-6", 6, 50, "price_tsh_b_6", null },
                    { 87, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4214), true, 139.99m, 10, "BLZ-001-3-1", 3, 32, "price_blz_001_3_1", null },
                    { 88, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4218), true, 139.99m, 10, "BLZ-001-3-8", 3, 32, "price_blz_001_3_8", null },
                    { 89, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4222), true, 139.99m, 10, "BLZ-001-3-7", 3, 32, "price_blz_001_3_7", null },
                    { 90, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4226), true, 139.99m, 10, "BLZ-001-4-1", 4, 32, "price_blz_001_4_1", null },
                    { 91, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4230), true, 139.99m, 10, "BLZ-001-4-8", 4, 32, "price_blz_001_4_8", null },
                    { 92, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4234), true, 139.99m, 10, "BLZ-001-4-7", 4, 32, "price_blz_001_4_7", null },
                    { 93, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4238), true, 139.99m, 10, "BLZ-001-5-1", 5, 32, "price_blz_001_5_1", null },
                    { 94, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4241), true, 139.99m, 10, "BLZ-001-5-8", 5, 32, "price_blz_001_5_8", null },
                    { 95, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4245), true, 139.99m, 10, "BLZ-001-5-7", 5, 32, "price_blz_001_5_7", null },
                    { 96, 1, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4249), true, 139.99m, 10, "BLZ-001-6-1", 6, 32, "price_blz_001_6_1", null },
                    { 97, 8, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4253), true, 139.99m, 10, "BLZ-001-6-8", 6, 32, "price_blz_001_6_8", null },
                    { 98, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4257), true, 139.99m, 10, "BLZ-001-6-7", 6, 32, "price_blz_001_6_7", null },
                    { 99, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4263), true, 149.99m, 11, "KSH-W-3", 3, 35, "price_ksh_w_3", null },
                    { 100, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4267), true, 149.99m, 11, "KSH-W-4", 4, 35, "price_ksh_w_4", null },
                    { 101, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4270), true, 149.99m, 11, "KSH-W-5", 5, 35, "price_ksh_w_5", null },
                    { 102, 2, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4273), true, 149.99m, 11, "KSH-W-6", 6, 35, "price_ksh_w_6", null },
                    { 103, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4280), true, 199.99m, 12, "JEA-001-2-4", 2, 28, "price_jea_001_2_4", null },
                    { 104, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4284), true, 199.99m, 12, "JEA-001-2-7", 2, 28, "price_jea_001_2_7", null },
                    { 105, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4288), true, 199.99m, 12, "JEA-001-3-4", 3, 28, "price_jea_001_3_4", null },
                    { 106, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4292), true, 199.99m, 12, "JEA-001-3-7", 3, 28, "price_jea_001_3_7", null },
                    { 107, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4296), true, 199.99m, 12, "JEA-001-4-4", 4, 28, "price_jea_001_4_4", null },
                    { 108, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4299), true, 199.99m, 12, "JEA-001-4-7", 4, 28, "price_jea_001_4_7", null },
                    { 109, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4303), true, 199.99m, 12, "JEA-001-5-4", 5, 28, "price_jea_001_5_4", null },
                    { 110, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4307), true, 199.99m, 12, "JEA-001-5-7", 5, 28, "price_jea_001_5_7", null },
                    { 111, 4, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4319), true, 199.99m, 12, "JEA-001-6-4", 6, 28, "price_jea_001_6_4", null },
                    { 112, 7, new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4323), true, 199.99m, 12, "JEA-001-6-7", 6, 28, "price_jea_001_6_7", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

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

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 261, DateTimeKind.Utc).AddTicks(7895), new DateTime(2025, 10, 15, 22, 26, 11, 261, DateTimeKind.Utc).AddTicks(9735) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(329), new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(330) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(334), new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(335) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(338), new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(342), new DateTime(2025, 10, 15, 22, 26, 11, 262, DateTimeKind.Utc).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "IconCssClass", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(7275), null, null, "Woman", "woman" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "IconCssClass", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(7751), null, null, "Man", "man" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "IconCssClass", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8209), null, 1, null, "T-Shirts", 1, "woman-tshirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "IconCssClass", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8216), null, 2, null, "Pants", 1, "woman-pants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8220), null, 3, "Dresses", "woman-dresses" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8223), null, 1, "T-Shirts", 2, "man-tshirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8226), null, 2, "Pants", 2, "man-pants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "Name", "ParentCategoryId", "Slug" },
                values: new object[] { new DateTime(2025, 10, 15, 22, 26, 11, 258, DateTimeKind.Utc).AddTicks(8229), null, 3, "Shirts", 2, "man-shirts" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 257, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 264, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 254, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 259, DateTimeKind.Utc).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 260, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 260, DateTimeKind.Utc).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 15, 22, 26, 11, 260, DateTimeKind.Utc).AddTicks(293));
        }
    }
}
