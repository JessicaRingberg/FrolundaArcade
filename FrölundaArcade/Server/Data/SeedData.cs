using Microsoft.AspNetCore.Identity;
namespace FrölundaArcade.Server.Data;

public class SeedData
{
    private static async Task SeedUsersAndRoles(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var admin = new AppUser
        {
            Address = new Address { City = "Göteborg", Street = "Frölundagatan 10", Zipcode = "43352" },
            PhoneNumber = "0701405293",
            Email = "admin@gmail.com",
            UserName = "admin@gmail.com"
        };

        var customer = new AppUser
        {
            Address = new Address { City = "Göteborg", Street = "Frölundagatan 1", Zipcode = "43352" },
            PhoneNumber = "0701405293",
            Email = "customer@gmail.com",
            UserName = "customer@gmail.com"
        };
        await userManager.CreateAsync(admin, "Password123.");
        await userManager.CreateAsync(customer, "Password123.");
        var adminRole = new IdentityRole(Constants.Admin);

        await roleManager.CreateAsync(adminRole);
        await userManager.AddToRoleAsync(admin, adminRole.Name);
    }

    public static async Task SeedDatabase(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.Migrate();

        if (context.Users.Any()) return;

        await SeedUsersAndRoles(userManager, roleManager);
        var categoryAction = new Category { Name = "Action" };
        var categoryOpenWorld = new Category { Name = "Open World" };
        var categoryIndie = new Category { Name = "Indie" };
        var categorySport = new Category { Name = "Sport" };
        var categoryAccessory = new Category { Name = "Tillbehör" };


        context.Games.AddRange(
            new Game
            {
                Name = "Elden Ring",
                Price = 699,
                AgeLimit = 18,
                Category = categoryAction,
                Description =
                    "I The Fire Ring förvisas The Tarnished från The Lands Between. Den titulära Elden-ringen har förstörts, och du måste nu bygga om The Tarnished, ge dig ut på en resa i en förfallen värld, på jakt efter uråldriga runor som kan återskapa Elden-ringen och bli The Elden Lord.",
                TechnicalSpec = "MINIMUM: <br/>**OS:** Windows 10 <br/>**Processor:** INTEL CORE I5 - 8400 eller AMD RYZEN 3 3300X <br/>**Minne:** 12 GB RAM <br/>**Grafik:** NVIDIA GEFORCE GTX 1060 3 GB eller AMD RADEON RX 580 4 GB <br/>**DirectX:** Version 12 <br/>**Lagring:** 60 GB ledigt utrymme <br/>**Ljudkort:** Windows Compatible Audio Device",
                Reviews = new[] { new Review { Rating = 5, Text = "Someone said it was pretty good" },
                new Review { Rating = 3, Text = "Someone said it was great" }},
                Quantity = 5,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.playground.ru%2Fe%2FjdiPejRc_VfyKyXNKHX9UQ.jpeg%3F600-600&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fassets2.rockpapershotgun.com%2Felden-ring-trailer-summon.jpg%2FBROK%2Fresize%2F1920%253E%2Fformat%2Fjpg%2Fquality%2F80%2Felden-ring-trailer-summon.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.m20URtLtAmN1E1g_XxVIogHaEK%26pid%3DApi&f=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP._b0J1HQx9WSM-giq8pDOjQHaEH%26pid%3DApi&f=1" }
            },
            new Game
            {
                Name = "Far Cry 6",
                Price = 499,
                AgeLimit = 18,
                Quantity = 1,
                Category = categoryOpenWorld,
                Description =
                    "Gå med i revolutionen och tryck tillbaka mot den förtryckande regimen av diktatorn Antón Castillo och hans tonårsson Diego, som väcktes till liv av Hollywoodstjärnorna Giancarlo Esposito och Anthony Gonzalez.",
                TechnicalSpec = "MINIMUM: <br/>**OS:** Windows 10 <br/>**Processor:** INTEL CORE I5 - 2400 @3.1 GHz eller AMD FX-6300 @3.5 GHz eller likvärdigt <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GEFORCE GTX 670 eller AMD R9 270 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 40 GB ledigt utrymme",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwanuxi-storage.sgp1.cdn.digitaloceanspaces.com%2F2020%2F07%2FFar-cry-6-Box-Art.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.wallpapersden.com%2Fimage%2Fdownload%2Ffar-cry-6-poster_bGdlbWuUmZqaraWkpJRmaWVlrW5lZQ.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgamingbolt.com%2Fwp-content%2Fuploads%2F2020%2F07%2Ffar-cry-6-image-2.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.wccftech.com%2Fwp-content%2Fuploads%2F2021%2F05%2FFC6_Keyart-scaled.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Horizon Forbidden West",
                Price = 649,
                AgeLimit = 16,
                Quantity = 2,
                Category = categoryOpenWorld,
                Description =
                    "Följ med Aloy när hon trotsar det förbjudna västern – en majestätisk men farlig gräns som döljer mystiska nya hot. Utforska avlägsna länder, slåss mot större och mer imponerande maskiner och möt häpnadsväckande nya stammar när du återvänder till den långa framtida, postapokalyptiska världen Horizon.",
                TechnicalSpec = "MINIMUM: <br/>**OS:** Windows 10 <br/>**Processor:** INTEL CORE I5 - 8400 eller AMD RYZEN 3 3300X <br/>**Minne:** 12 GB RAM <br/>**Grafik:** NVIDIA GEFORCE GTX 1060 3 GB eller AMD RADEON RX 580 4 GB <br/>**DirectX:** Version 12 <br/>**Lagring:** 60 GB ledigt utrymme <br/>**Ljudkort:** Windows Compatible Audio Device",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.steamgriddb.com%2Fgrid%2F1c5e99c472d0de3b040558c210ef83b0.png&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fassets2.rockpapershotgun.com%2Fhorizon-forbidden-west-header.jpg%2FBROK%2Fresize%2F1920x1920%253E%2Fformat%2Fjpg%2Fquality%2F80%2Fhorizon-forbidden-west-header.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.jeYGWChmTwOmt6dT1a2hlgHaD5%26pid%3DApi&f=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.5AofGF7Ar_1eqL6Hq9K2gwHaDt%26pid%3DApi&f=1" }
            },
            new Game
            {
                Name = "God of War",
                Price = 299,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "En svår och obekant väg väntar när du utforskar ett häpnadsväckande återberättande av en klassisk berättelse. Följ med Kratos när han äventyrar genom en djup och reflektiv resa av växande, våld och önskan att bli en bättre man för sin son. I en värld full av monster, drakar och gudar vilar ansvaret på dina axlar - och när ditt liv är fyllt av blod och kaos, hur kan du förhindra tidigare misstag för att skydda din framtid?",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i5 - 2500k(4 core 3.3 GHz) eller AMD Ryzen 3 1200(4 core 3.1 GHz) <br/>**Minne:** 8 GB RAM <br/>**0Grafik:** NVIDIA GTX 960(4 GB) or AMD R9 290X(4 GB) <br/>**DirectX:** Version 11 <br/>**Lagring:** 70 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** DirectX feature level 11_1 required",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.giantbomb.com%2Fa%2Fuploads%2Foriginal%2F33%2F338034%2F3287019-3786480319-Z7hV9.png&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fassets.vg247.com%2Fcurrent%2F2018%2F06%2Fgod_of_war_game_plus-9.jpg&f=1&nofb=1", "https://cdn.gamer-network.net/2018/usgamer/God-of-War-2018-Shot-05.jpg", "https://external-preview.redd.it/QNg3fcZxrbEu8_hYdZWD04Ig2gW0npR71AHxIqX_oxs.jpg?auto=webp&s=8bb4a24cebdb5b867c9c5409959e78257172d376" }
            },
           new Game
           {
               Name = "Lost Ark",
               Price = 399,
               AgeLimit = 18,
               Quantity = 5,
               Category = categoryAction,
               Description =
                    "Ge dig ut på en odyssé för Den förlorade arken i en stor, livlig värld: utforska nya länder, leta efter förlorade skatter och testa dig själv i spännande actionstrider. Definiera din stridsstil med din klass och avancerade klass och anpassa dina färdigheter, vapen och utrustning för att få din kraft att bära när du kämpar mot horder av fiender, kolossala bossar och mörka krafter som söker arkens kraft i detta actionfyllda free-to-play-RPG.",
               TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
               Reviews = null,
               ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fassets.rpgsite.net%2Fimages%2Fimages%2F000%2F071%2F711%2Foriginal%2FLost-Ark_Box.jpg&f=1&nofb=1",
               ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.downloaduj.pl%2Fwp-content%2Fuploads%2F2017%2F03%2FObraz-1-Lost-Ark.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fnotorgames.ru%2Fwp-content%2Fuploads%2F2020%2F10%2F3-50.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.greetments-life.de%2Fassets%2Fimages%2Fusr_uploads%2F1630582742_5c66da98-6f32-4112-842f-f7dedbe666a9.jpg&f=1&nofb=1" }
           },
            new Game
            {
                Name = "Red Dead Redemption 2",
                Price = 699,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Amerika, 1899. Arthur Morgan och Van der Linde - gänget är brottslingar på rymmen.Med federala agenter och nationens bästa prisjägare i hälarna måste gänget råna, stjäla och kämpa sig fram genom centrala Nordamerikas kuperade terräng för att överleva. Interna grupperingar hotar att splittra gänget, och Arthur tvingas välja mellan sina principer och lojaliteten gentemot gänget som uppfostrat honom.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 7 - Service Pack 1 <br/>**Processor:** Intel core i5-2500K / AMD FX-6300<br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 700 2GB <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 150 GB ledigt utrymme <br/>**Ljudkort:** Direct X Compatible",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2F736x%2Faf%2Fcf%2F0a%2Fafcf0adb4c7c2c32438b63b0e55b5211.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.everyeye.it%2Fimg-screenshot%2Fred-dead-redemption-2-v1-566599.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.gratistodo.com%2Fwp-content%2Fuploads%2F2018%2F09%2FFondos-Red-Dead-Redemption-2-wallpapers-4.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.pushsquare.com%2Fnews%2F2018%2F02%2Fnew_red_dead_redemption_2_screenshots_look_downright_superb%2Fattachment%2F2%2Foriginal.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Cyberpunk 2077",
                Price = 699,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Cyberpunk 2077 är ett actionrollspel som utspelar sig i megametropolen Night City, där man spelar en cyberpunk-legosoldat som dras in i en kamp på liv och död. Upplevelsen har förbättrats och expanderats med gratis extrainnehåll. Skapa en karaktär som passar din spelstil och ta dig an jobb, fila på ditt rykte och lås upp uppgraderingar. Dina relationer och beslut formar berättelser och världen runtomkring dig. Här skrivs legender – hur kommer din att sluta?",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel Core i5-3570K eller AMD FX-8310<br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 970 eller AMD Radeon RX 470<br/>**DirectX:** Version 12 <br/>**Lagring:** 70 GB ledigt utrymme <br/>",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.gameexpres.cz%2Fdownload%2Fproducts%2FCYBERPUNK2077_PUZZ_POSTER_Female1.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.tapeciarnia.pl%2Ftapety%2Fnormalne%2Ftapeta-kadr-z-gry-cyberpunk-2077.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.somagnews.com%2Fwp-content%2Fuploads%2F2020%2F02%2F39-2-scaled-e1581965108226.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcriticalhits.com.br%2Fwp-content%2Fuploads%2F2020%2F12%2FCyberpunk2077_Shopping_RGB_EN-scaled-1.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "DOOM Eternal",
                Price = 399,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Helvetets arméer har invaderat jorden. Spela som Slayer i en episk enspelarkampanj för att besegra demoner i flera olika dimensioner och stoppa mänskligheten från att utplånas. Det Enda De Fruktar... Är Dig. Upplev den ultimata kombinationen av fart och kraft i DOOM Eternal – nästa steg i slagfärdiga förstapersonsstrider.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i5 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 80 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcollectors-junkies.com%2Fwp-content%2Fuploads%2F2020%2F03%2FDoom-Eternal-2020.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.anaitgames.com%2Fimages%2Fuploads%2F2020%2F03%2Fanalisis-doom-eternal-2.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.cdon.com%2Fmedia-dynamic%2Fimages%2Fproduct%2Fgame%2Fpc%2Fimage2%2Fdoom_eternal_deluxe_edition-48510827-xtra2.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.wccftech.com%2Fwp-content%2Fuploads%2F2020%2F01%2FDOOM_Eternal-scaled.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Cuphead",
                Price = 199,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Cuphead är ett klassiskt run and gun-actionspel med fokus på bosstrider. Grafiken och ljudet är inspirerat av tecknade serier från 1930-talet, och återskapade med samma tekniker: handritade animationer, bakgrunder i vattenfärg och originalinspelningar med jazztema. Spela som Cuphead eller Mugman(en spelare eller lokalt på delad skärm) medan du tar genom märkliga världar, skaffar nya vapen, lär dig kraftfulla supermanövrar och upptäcker dolda hemligheter medan du försöker återbetala din skuld till djävulen!",
                TechnicalSpec = "MINIMUM: <br/>**OS:** Windows 7<br/>**Processor:** Intel Core2 Duo E8400 <br/>**Minne:** 3 GB RAM <br/>**Grafik:** GeForce 9600 GT eller AMD HD 3870 <br/>**DirectX:** Version 11 <br/>**Lagring:** 4 GB ledigt utrymme ",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpreview.redd.it%2Fwdxq6nrb6ou31.jpg%3Fauto%3Dwebp%26s%3Db404300eecfe019a7473fc54e3e3e733be7e669c&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pcgamesn.com%2Fwp-content%2Fuploads%2Flegacy%2Fcuphead_gameplay.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ficdn2.digitaltrends.com%2Fimage%2Fcuphead_boss_rankings_guide_18-1920x1080.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.gamersyde.com%2Fimage_stream-36759-3012_0002.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "LEGO® Star Wars™: The Skywalker Saga",
                Price = 699,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Galaxen är din i LEGO® Star Wars™: The Skywalker Saga. Upplev minnesvärda ögonblick och massor av action från alla nio filmer i Skywalker-sagan med LEGO:s karakteristiska humor.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel Core i5-2400 eller AMD Ryzen 3 1200 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 750 Ti eller Radeon HD 7850 <br/>**DirectX:** Version 11 <br/>**Lagring:** 40 GB ledigt utrymme",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmedia.senscritique.com%2Fmedia%2F000019692001%2Fsource_big%2FLEGO_Star_Wars_La_Saga_Skywalker.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi2.wp.com%2Fsirusgaming.com%2Fwp-content%2Fuploads%2F2020%2F08%2Flego-star-wars-the-skywalker-saga-02.jpg%3Ffit%3D1200%252C675%26ssl%3D1&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic1.srcdn.com%2Fwordpress%2Fwp-content%2Fuploads%2F2019%2F12%2FLego-Star-Wars-Skywalker-Saga-Trailer.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.1337.games%2Fapp%2Fuploads%2F2020%2F08%2FLEGO-Star-Wars-The-Skywalker-Saga_2020_08-27-20_001-scaled-940x529.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Grand Theft Auto V",
                Price = 399,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "En ung gatutjuv, en före detta bankrånare och en livsfarlig psykopat blir inblandade i en härva med den undre världen, amerikanska regeringen och underhållningsindustrin. Enda sättet att överleva är genom ett antal farliga stötar i en skoningslös stad där de inte kan lita på någon, minst av allt varandra.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pcgamesarchive.com%2Fwp-content%2Fuploads%2F2020%2F04%2FGrand-Theft-Auto-V.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fsoftcamel.com%2Fwp-content%2Fuploads%2F2019%2F03%2FGrand-Theft-Auto-V-2.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimg.washingtonpost.com%2Frw%2F2010-2019%2FWashingtonPost%2F2011%2F06%2F27%2FNational-Enterprise%2FImages%2FSTGTA23-1.jpg%3Fuuid%3Dd2g7OKDFEeCxG385yZuJEA&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.boutique-pcland.fr%2Fwp-content%2Fuploads%2F2016%2F05%2Facheter-cl%25C3%25A9-Grand-Theft-Auto-V-vue2.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Stardew Valley",
                Price = 149,
                AgeLimit = 12,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Du har ärvt din farfars gamla gårdsplan i Stardew Valley. Beväpnad med hand-me-down verktyg och några mynt, du ger dig ut för att börja ditt nya liv. Kan du lära dig att leva av marken och förvandla dessa övervuxna fält till ett blomstrande hem? Det blir inte lätt. Ända sedan Joja Corporation kom till stan har de gamla livsstilarna nästan försvunnit. Samhällscentret, som en gång var stadens mest levande nav för aktivitet, ligger nu i spillror. Men dalen verkar full av möjligheter. Med lite hängivenhet kanske du bara är den som återställer Stardew Valley till storhet!",
                TechnicalSpec = "MINIMUM:<br/>**OS:** Windows Vista eller senare <br/>**Processor:** 2Ghz <br/>**Minne:** 2 GB RAM <br/>**Grafik:** 256 mb video memory, shader model 3.0+ <br/>**DirectX:** Version 10 <br/>**Lagring:** 500 MB ledigt utrymme",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fgamerwalkthroughs.com%2Fwp-content%2Fuploads%2F2016%2F03%2FStardew-Valley-Walkthrough.png&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2F4gnews.pt%2Fwp-content%2Fuploads%2F2019%2F02%2FStardewValley.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fnexusgames.to%2Fwp-content%2Fuploads%2F2020%2F07%2FStardew-Valley-Free-Download-By-Nexusgames.to-6-1250x950.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpowergamingnetwork.com%2Fwp-content%2Fuploads%2F2019%2F02%2Fstardew-valley-mobile-press.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Golf With Your Friends",
                Price = 189,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Varför ha vänner om inte för att spela Golf With Your Friends? Inget är utom räckhåll på de här banorna med fartfylld, spännande minigolf för upp till 12 spelare!",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstore-images.s-microsoft.com%2Fimage%2Fapps.26910.13908316754263937.5c54bde2-f9c8-4fbc-a7d0-4f022b0e27ed.2f31913e-0a1e-439f-b737-c77749597226%3Fw%3D400%26h%3D600&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.nintendo-insider.com%2Fwp-content%2Fuploads%2F2020%2F05%2Fgolf_with_your_friends_review_header.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.purexbox.com%2Fscreenshots%2F106917%2Flarge.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimage.winudf.com%2Fv2%2Fimage%2FY29tLk1hdGhpYXNHYW1lcy5Hb2xmV2l0aEZyaWVuZHNfc2NyZWVuXzBfMTUxODk1MDI1NF8wMTc%2Fscreen-0.jpg%3Fh%3D800%26fakeurl%3D1%26type%3D.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Fishing Planet",
                Price = 99,
                AgeLimit = 3,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Fishing Planet är en unik och mycket realistisk online förstapersons fiskesimulator utvecklad av ivriga fiskeentusiaster för sportfiskare för att ge dig full spänning av faktisk mete! Välj dina lockar, gör dina troféfångster, upptäck nya möjligheter och vässa dina riktiga metefärdigheter var som helst, när som helst med dina vänner!",
                TechnicalSpec = "MINIMUM: <br/>**OS:**OS Version - Windows 7, 8, 10 x64<br/>**Processor:** Dual-Core 2.4 Ghz<br/>**Minne:** 4 GB RAM <br/>**Grafik:** Graphics Card Intel HD4600 <br/>**DirectX:** Version 11 <br/>**Lagring:** 12 GB ledigt utrymme",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.mobygames.com%2Fimages%2Fcovers%2Fl%2F576785-fishing-planet-windows-apps-front-cover.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FHHz-l2dErpc%2Fmaxresdefault.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FiuRifkEfokA%2Fmaxresdefault.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2F2images.cgames.de%2Fimages%2Fgsgp%2F4%2Ffishing-planet_6004441.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "TEKKEN 7",
                Price = 399,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Kärlek, hämnd, stolthet. Alla har ett skäl att slåss. Värderingar är det som definierar oss och gör oss mänskliga, oavsett våra styrkor och svagheter. Det finns inga felaktiga motiv, bara de vägar vi väljer att ta.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2F2.bp.blogspot.com%2F-jTlTYUpCfzc%2FWoUkRr4dxUI%2FAAAAAAAABRY%2F3kcNNev3CTEg1adWFerp8Cd6BfD_k_tTQCLcBGAs%2Fs1600%2FTEKKEN-7-Free-Download-Full-Version-PC-Game-Setup.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/389730/ss_0030a7c969ad251a3cf6a194309911c99cc994b5.1920x1080.jpg?t=1638999755", "https://cdn.cloudflare.steamstatic.com/steam/apps/389730/ss_40faa5ba39563cb899f1ab2ddd2afbf8b451d52f.1920x1080.jpg?t=1638999755", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fkingofcracks.com%2Fwp-content%2Fuploads%2F2016%2F07%2FTekken-7-download-free-e1469612638962.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "FIFA 22",
                Price = 599,
                AgeLimit = 3,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Spela med över 17 000 spelare och fler än 700 lag på över 90 arenor. Lagen är hämtade från över 30 ligor runt om i världen.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.highsnobiety.com%2Fthumbor%2FjcHnmNSVuAGBGtfeiBwO0C3OrR4%3D%2F1200x1500%2Fstatic.highsnobiety.com%2Fwp-content%2Fuploads%2F2021%2F07%2F09185700%2Fkylian-mbappe-fifa-22-cover-athlete-01.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1506830/ss_487947e6eb5e8ca8f71e8bfea77753c95eca1b25.1920x1080.jpg?t=1644868577", "https://cdn.cloudflare.steamstatic.com/steam/apps/1506830/ss_ab3f290ac0667490be79a1f3231cb563b1effeb4.1920x1080.jpg?t=1644868577", "https://cdn.cloudflare.steamstatic.com/steam/apps/1506830/ss_2cdf78a2091db6adb7ec405f4c5438fd621266a9.600x338.jpg?t=1644868577" }
            },
            new Game
            {
                Name = "ARK: Survival Evolved",
                Price = 249,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Som en man eller kvinna strandsatt naken, fryser och svälter på stranden av en mystisk ö som heter ARK, måste du jaga, skörda resurser, hantverksartiklar, odla grödor, forskningsteknik och bygga skydd för att motstå elementen. Använd din list och resurser för att döda eller tämja & föda leviathan dinosaurier och andra urtid varelser roaming landet, och samarbeta med eller byte på hundratals andra spelare för att överleva, dominera... och fly!",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgamingbeasts.com%2Fwp-content%2Fuploads%2F2021%2F07%2FArk-Survival-Evolved-icon.jpeg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/346110/ss_ffd48da603fa700d10738ae4ee44ce2b9113cb64.1920x1080.jpg?t=1649288168", "https://cdn.cloudflare.steamstatic.com/steam/apps/346110/ss_1a7f5508e5384a759ccc83fa484db04513213698.1920x1080.jpg?t=1649288168", "https://cdn.cloudflare.steamstatic.com/steam/apps/346110/ss_46778c08a1a5ac5bdbaf8a5bf844fa666f66a14b.1920x1080.jpg?t=1649288168" }
            },
            new Game
            {
                Name = "No Man's Sky",
                Price = 499,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Inspirerad av äventyret och fantasin som vi älskar från klassisk science-fiction, presenterar No Man's Sky dig en galax att utforska, fylld med unika planeter och livsformer och konstant fara och action. I No Man's Sky är varje stjärna ljuset från en avlägsen sol, var och en omgiven av planeter fyllda med liv, och du kan gå till vilken du vill. Flyga smidigt från rymden till planetariska ytor, utan laddningsskärmar och inga gränser. I detta oändliga procedurgenererade universum kommer du att upptäcka platser och varelser som inga andra spelare har sett förut - och kanske aldrig kommer att göra det igen.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2F1.bp.blogspot.com%2F-Ig3A_5KYBvk%2FYJGQmy7nTJI%2FAAAAAAAABqw%2FecBZiUvhPocu7OrNkiUGyR4lBlQIMI6iACNcBGAsYHQ%2Fw1200-h630-p-k-no-nu%2FNo%252BMan%252527s%252BSky%252B%252528PC%252529%252BDublado%252BDownload%252BTorrent.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimg.generation-nt.com%2F0001638810.jpg&f=1&nofb=1", "https://cdn.cloudflare.steamstatic.com/steam/apps/275850/ss_999f20e5012b4d515449175c4f9c16006903e63a.1920x1080.jpg?t=1646415170", "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Ftorrent3.ru%2Fuploads%2Fposts%2F2015-10%2F1443894937_no-mans-sky-2.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Golf It!",
                Price = 99,
                AgeLimit = 3,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Golf It! är ett minigolfspel för flera spelare med fokus på en dynamisk, rolig och kreativ flerspelarupplevelse. En av de mest spännande funktionerna är en multiplayer editor, där du kan bygga och spela anpassade kartor tillsammans med dina vänner.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.newgamesbox.net%2Fwp-content%2Fuploads%2F2017%2F11%2FGolf-It-Free-Download-Full-Version-PC-Game-Setup.jpg&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgamefabrique.com%2Fstorage%2Fscreenshots%2Fpc%2Fgolf-it-04.png&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgameplaymania.com%2Fwp-content%2Fuploads%2Fthumbs%2Fembed%2FG%2Fgolf-it-free-online-with-maps-1.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fsteamcdn-a.akamaihd.net%2Fsteam%2Fapps%2F571740%2Fss_7c422cd0b500640b2798aa6c6ff29bd690159f90.1920x1080.jpg%3Ft%3D1560439586&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Franchise Hockey Manager 6",
                Price = 149,
                AgeLimit = 3,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Välj en av dussintals ligor runt om i världen och välj ett lag som ska vägleda till ära, inklusive en chans till det ultimata priset: FHM 8 är licensierad av NHL®, så att du kan ta tyglarna i din favoritserie för att erövra Stanley Cup®. Ta kontroll över ett landslag och försök till internationell överlägsenhet. Välj ett historiskt spel där du kan börja under vilket år som helst i NHL:s® historia ända tillbaka till början av 1917. Eller om du vill skapa din egen anpassade liga kan du också göra det!",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn-products.eneba.com%2Fresized-products%2F2Q1BLCa3DbSDpNHMJqy8_P8DfffwrPlGG_9fzMjhtGg_350x200_1x-0.jpeg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1739000/ss_fe468cebb0590746d88ddda9d9de3b9e81bdb366.1920x1080.jpg?t=1639018556", "https://cdn.cloudflare.steamstatic.com/steam/apps/1739000/ss_1d6a81f5847559a06a10d4cff6aec1fb30ed7d55.1920x1080.jpg?t=1639018556", "https://cdn.cloudflare.steamstatic.com/steam/apps/1739000/ss_fd7e6059476cd3c7b8c516585de7864ab55efb41.1920x1080.jpg?t=1639018556" }
            },
            new Game
            {
                Name = "Potion Craft: Alchemist Simulator",
                Price = 99,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Löv, blommor, bär, rötter, frukter, mineraler och en mängd svampar är redo för din mortel. Precis som espresso spelar slipningens finess roll!",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fgpstatic.com%2Facache%2F52%2F84%2F1%2Fus%2Fpackshot-bc55b3fbb1bdf3155c7e3cd8964e35d9.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1210320/ss_66746a1c6b2bbe9797461f490d092f87d4a9789c.1920x1080.jpg?t=1641691513", "https://cdn.cloudflare.steamstatic.com/steam/apps/1210320/ss_426f3f0be56e0bab488f9c6209a00ff8dffafb7a.1920x1080.jpg?t=1641691513", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.indiemag.fr%2Fsites%2Fdefault%2Ffiles%2Fjeux%2Fp%2Fpotion-craft-alchemist-simulator%2Fgalerie%2Fgalerie-potion-craft-alchemist-simulator_3.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "WWE 2K22",
                Price = 399,
                AgeLimit = 16,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Låt dig ryckas ned från läktarna och slå till hårt med fullständig kontroll över WWE:s universum. Släpp lös dykningar, sparkar och avslutningar med de största och mest realistiska superstjärnorna och legenderna från WWE: The Rock, Sasha Banks, Goldberg, Steve Austin, Brock Lesnar och många fler.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmedia.senscritique.com%2Fmedia%2F000020054571%2Fsource_big%2FWWE_2K22.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1255630/ss_b499852032d21871d2a3b02fdb09a68f346d5749.1920x1080.jpg?t=1649696875", "https://cdn.cloudflare.steamstatic.com/steam/apps/1255630/ss_1e60d769065a3dcd3345f3da4ec71d2b9781727e.1920x1080.jpg?t=1649696875", "https://cdn.cloudflare.steamstatic.com/steam/apps/1255630/ss_2abf0f8c12c5816c1f7409474cfbd7c06ef2a6b5.1920x1080.jpg?t=1649696875" }
            },
            new Game
            {
                Name = "TBA: Vampire Survivors",
                Price = 699,
                AgeLimit = 12,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Vakna som en försvagad vampyr efter århundraden av sömn. Jaga efter blod i närliggande bosättningar för att återfå din styrka medan du gömmer dig från den brännande solen för att överleva. Återuppbygg ditt slott och omvandla människor till dina lojala tjänare i ett försök att uppfostra ditt vampyrimperium. Skapa allierade online, avvärja heliga soldater och föra krig mot andra spelare i en värld av konflikter. Blir du nästa Dracula?",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.playground.ru%2Fe%2ForvNMgrjFk1CIRdm6cfT2g.jpeg%3F600-600&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1604030/ss_fe1492115942529ce8e147cfecd79799dc89846d.1920x1080.jpg?t=1649333464", "https://cdn.cloudflare.steamstatic.com/steam/apps/1604030/ss_e6f08f8e5259a687d8377845c70d7fca3ca5e3a9.1920x1080.jpg?t=1649333464", "https://cdn.cloudflare.steamstatic.com/steam/apps/1604030/ss_94b242cf382a438fb01be728df9add12893485c7.1920x1080.jpg?t=1649333464" }
            },
            new Game
            {
                Name = "Forza Horizon 5",
                Price = 599,
                AgeLimit = 7,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Det ultimata Horizon-äventyret väntar! Ge dig ut på otroliga bilturer genom ett öppet Mexiko som ständigt utvecklas, med gränslös och rolig körning i hundratals av världens bästa bilar. Ge dig ut på otroliga bilturer genom ett öppet Mexiko som ständigt utvecklas, med gränslös och rolig körning i hundratals av världens bästa bilar.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstore-images.s-microsoft.com%2Fimage%2Fapps.45612.14506879174941978.6da511ff-4f08-4e95-a2af-c7d9c42de4c4.139199d5-dde7-42bb-9979-cf8d03c0d883&f=1&nofb=1",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.nme.com%2Fwp-content%2Fuploads%2F2021%2F06%2Fforza-horizon-5.jpg&f=1&nofb=1", "https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/ss_78e4f63e05d50e59b9966ba8da9a53dbf84fd8f4.1920x1080.jpg?t=1649340064", "https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/ss_0bc32360d32b21abdf889422385cd753862dd73e.1920x1080.jpg?t=1649340064" }
            },
            new Game
            {
                Name = "Assassin's Creed Odyssey",
                Price = 699,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Från utstött till levande legend ger du dig ut på en odyssé för att förstå hemligheter från ditt förflutna och ändra ödet för antikens Grekland. Dina beslut påverkar hur din odyssé artar sig. Upplev olika slut tack vare det nya dialogsystemet och de val du gör. Anpassa din utrustning, ditt skepp och dina specialförmågor för att bli legendarisk.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fvignette.wikia.nocookie.net%2Fassassinscreed%2Fimages%2Ff%2Ff5%2FAssassin%27s_Creed_Odyssey.jpg%2Frevision%2Flatest%3Fcb%3D20180611213716&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/812140/ss_23039e3003448ee760030faf5e3bf8637f8d4063.1920x1080.jpg?t=1646425720", "https://cdn.cloudflare.steamstatic.com/steam/apps/812140/ss_71f5c2052a6bfb94486e929db3d6b92c06696843.1920x1080.jpg?t=1646425720", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.cgmagonline.com%2Fwp-content%2Fuploads%2F2018%2F10%2Fassassins-creed-odyssey-ps4-review.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "MXGP 2021",
                Price = 499,
                AgeLimit = 3,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "Ta på dig hjälmen, sätt dig på cykeln och kör så det ryker för att bli en äkta MXGP-mästare. Skapa ett eget stall eller gå med i ett officiellt och börja från MX2-kategorin i det nya karriärläget.Dina resultat påverkar hur karriären utvecklar sig och vilka stall- och sponsorkontrakt du blir erbjuden.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi6.imageban.ru%2Fout%2F2021%2F12%2F02%2F136c76a6a521b039729e21fb44736b50.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1610470/ss_743aaab5ecb6e6690bd469dc8133410b23fe535e.1920x1080.jpg?t=1638261773", "https://cdn.cloudflare.steamstatic.com/steam/apps/1610470/ss_59702b4ce0fce7675a172362120f53115a10c674.1920x1080.jpg?t=1638261773", "https://cdn.cloudflare.steamstatic.com/steam/apps/1610470/ss_358b0014b5cceb352ea6cb6b02e607e0c1993de5.1920x1080.jpg?t=1638261773" }
            },
            new Game
            {
                Name = "GRID Legends",
                Price = 499,
                AgeLimit = 3,
                Quantity = 5,
                Category = categorySport,
                Description =
                    "GRID Legends levererar spännande motorsport och intensiv action runt om i världen. Skapa dina drömevenemang, hoppa in i pågående flerspelartävlingar, var en del av dramat i en uppslukande virtuell berättelse och omfamna känslan av spektakulär, actionfylld racing.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpicfiles.alphacoders.com%2F465%2F465235.jpeg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1307710/ss_b6a2bbc0a0c3e378a3689b4eff1017da971c724a.1920x1080.jpg?t=1646752436", "https://cdn.cloudflare.steamstatic.com/steam/apps/1307710/ss_f9ff1a4932bbc71c1b7391439819da9bff878edd.1920x1080.jpg?t=1646752436", "https://cdn.cloudflare.steamstatic.com/steam/apps/1307710/ss_971c383c0cb43cbeffe35ccbbc652110748a001f.1920x1080.jpg?t=1646752436" }
            },
            new Game
            {
                Name = "Sea of Thieves",
                Price = 399,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Sea of Thieves erbjuder den viktiga piratupplevelsen, från segling och kamp till att utforska och plundra – allt du behöver för att leva piratlivet och bli en legend i din egen rätt. Utan fasta roller har du fullständig frihet att närma dig världen och andra spelare, hur du än väljer. Oavsett om du voyaging som en grupp eller seglar solo, kommer du säkert att stöta på andra besättningar i detta delade världsäventyr - men kommer de att vara vänner eller fiender, och hur kommer du att svara?",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallpapercave.com%2Fwp%2Fwp2457616.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1172620/ss_9359dcef3e29ad4c5efaa1ae79acf4b249dcd813.1920x1080.jpg?t=1649322580", "https://cdn.cloudflare.steamstatic.com/steam/apps/1172620/ss_e4267560f7538553dfdde693e42930220ffc2f71.1920x1080.jpg?t=1649322580", "https://cdn.cloudflare.steamstatic.com/steam/apps/1172620/ss_732c89a38a3a29bdd0867d3e5d818987e7a7828b.1920x1080.jpg?t=1649322580" }
            },
            new Game
            {
                Name = "Raft",
                Price = 199,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Ensam eller med vänner är ditt uppdrag att överleva ett episkt oceaniskt äventyr över ett farligt hav! Samla skräp för att överleva, utöka din flotte och var försiktig med farorna med havet! Fångad på en liten flotte med inget annat än en krok av gammal plast, vaknar spelarna på en stor, blått hav helt ensamt och utan land i sikte! Med torr hals och tom mage, överlevnad kommer inte att bli lätt!",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pcgamesarchive.com%2Fwp-content%2Fuploads%2F2020%2F11%2FRaft-Cover.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/648800/ss_594b5fab052123e5f96088df3ec3c9b7cec62e88.1920x1080.jpg?t=1642416570", "https://cdn.cloudflare.steamstatic.com/steam/apps/648800/ss_fddb32f91f59dc076b60eebf6d013fc9a636e0e1.1920x1080.jpg?t=1642416570", "https://cdn.cloudflare.steamstatic.com/steam/apps/648800/ss_c22b2ff5ba5609f74e61b5feaa5b7a1d7fd1dbd3.1920x1080.jpg?t=1642416570" }
            },
            new Game
            {
                Name = "Destiny 2",
                Price = 5,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Kasta dig in i Destiny 2 för att utforska solsystemets mysterier och uppleva de responsiva eldstriderna i första person. Lås upp kraftfulla elementarförmågor och samla unik utrustning för att anpassa din Guardians utseende och spelstil. Upplev Destiny 2:s filmiska handling, ta dig an utmanande samarbetsuppdrag och olika PvP-lägen, tillsammans eller med vänner. Ladda ner det gratis idag och skriv din legend bland stjärnorna.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/05/Destiny_2_%28artwork%29.jpg",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_a9642404e586be28f856e8f02d038828f691a5ba.1920x1080.jpg?t=1648758636", "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_c142f5078ace9f5e2eb2c80aa3bf768e156b4ee9.1920x1080.jpg?t=1648758636", "https://cdn.cloudflare.steamstatic.com/steam/apps/1085660/ss_7fcc82f468fcf8278c7ffa95cebf949bfc6845fc.1920x1080.jpg?t=1648758636" }
            },
            new Game
            {
                Name = "HITMAN 3",
                Price = 599,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Agent 47 blir tvungen att ta hjälp av sin sedan länge försvunna vän Lucas Grey för att eliminera Providences medhjälpare – men duon tvingas anpassa sig ju längre jakten fortgår. Efteråt kommer varken Agent 47 eller resten av världen att vara sig lik igen.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4b/Hitman_3_Packart.jpg",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1659040/ss_f7c70cb3f2b325664c90e0fc57612aadef140e1a.1920x1080.jpg?t=1645711397", "https://cdn.cloudflare.steamstatic.com/steam/apps/1659040/ss_e731480df2f3f8a5de50f8851095dfe382cb89cf.1920x1080.jpg?t=1645711397", "https://cdn.cloudflare.steamstatic.com/steam/apps/1659040/ss_1703d0e23fc0d3392518e3db6873f1e974e3eb1b.1920x1080.jpg?t=1645711397" }
            },
            new Game
            {
                Name = "New World",
                Price = 399,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryOpenWorld,
                Description =
                    "Utforska en spännande, öppen värld MMO fylld med fara och möjligheter där du kommer att skapa ett nytt öde för dig själv som en äventyrare skeppsbrott på den övernaturliga ön Aeternum. Oändliga möjligheter att slåss, foder och smedja väntar dig bland öns vildmark och ruiner. Kanalisera övernaturliga krafter eller använd dödliga vapen i ett klasslöst stridssystem i realtid och slåss ensam, med ett litet team eller i massarméer för PvE- och PvP-strider – valen är alla dina.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://www.beyondpixels.at/wp-content/uploads/2018/08/New-World-Key-Art.jpg",
                ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.vox-cdn.com%2Fthumbor%2FPRleHyDr2_WqZzGVHwwRE8sbzR0%3D%2F0x0%3A1463x696%2F1200x675%2Ffilters%3Afocal(615x231%3A849x465)%2Fcdn.vox-cdn.com%2Fuploads%2Fchorus_image%2Fimage%2F63019458%2F_CoJMAa85oPKgYrE9qwQ4HUEtj_Qk6zFOUY2JPAQWsoeJxFPc.0.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.idgesg.net%2Fimages%2Farticle%2F2019%2F02%2Fwolf-encounter-100787637-orig.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallpapercave.com%2Fwp%2Fwp6369286.jpg&f=1&nofb=1" }
            },
            new Game
            {
                Name = "Total War: WARHAMMER III",
                Price = 599,
                AgeLimit = 18,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Det sista bruset från en döende gud bryter gränsen mellan världar och öppnar en portal till kaosets rike. Från denna malström framträder de fyra ruinösa krafterna – Khorne, Nurgle, Tzeentch och Slaanesh – och sprider mörker och förtvivlan. Kislevs stränga krigare och grand cathays väldiga imperium står vid tröskeln, när en hämndlysten DemonPrins lovar att förgöra dem som korrumperade honom. Den kommande konflikten kommer att uppsluka alla. Kommer du att erövra dina demoner? Eller befalla dem?",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwallpapercave.com%2Fwp%2Fwp8532667.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1142710/ss_096cc26ed1c7a96e8e4fb7c2df71472c1b8b951a.1920x1080.jpg?t=1646396556", "https://cdn.cloudflare.steamstatic.com/steam/apps/1142710/ss_f2876f3cb6f313d8f1271596b259fc47a69d4c15.1920x1080.jpg?t=1646396556", "https://cdn.cloudflare.steamstatic.com/steam/apps/1142710/ss_b92530cc6fc9c4cb0f066eb42983bf7ca17b478b.1920x1080.jpg?t=1646396556" }
            },
            new Game
            {
                Name = "Octodad: Dadliest Catch",
                Price = 149,
                AgeLimit = 7,
                Quantity = 5,
                Category = categoryIndie,
                Description =
                    "Octodad: Dadliest Catch är ett spel om förstörelse, bedrägeri och faderskap. Spelaren kontrollerar Octodad, en dapper bläckfisk maskerad som en människa, när han går om sitt liv. Octodads existens är en ständig kamp, eftersom han måste behärska vardagliga uppgifter med sina otympliga benfria tentakler samtidigt som han håller sin bläckfiskiska natur hemlig för sin mänskliga familj.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2F1.bp.blogspot.com%2F-DQ6iNXayRDE%2FUwGYco2QgbI%2FAAAAAAAAAWE%2FYejHJHtzKQU%2Fs1600%2FOctodad%2BDadliest%2BCatch%2Bcover.jpg&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/224480/ss_806025844b18b7e83d5950d4b611244377a39ec9.1920x1080.jpg?t=1579035625", "https://cdn.cloudflare.steamstatic.com/steam/apps/224480/ss_9481932c0688b1fab46ad511357278db96c9a207.1920x1080.jpg?t=1579035625", "https://cdn.cloudflare.steamstatic.com/steam/apps/224480/ss_b582aec5e2608ffc3380fc8ffaabfcf09304840c.1920x1080.jpg?t=1579035625" }
            },
            new Game
            {
                Name = "Apex Legends",
                Price = 1,
                AgeLimit = 16,
                Quantity = 5,
                Category = categoryAction,
                Description =
                    "Bemästra ett ständigt växande karaktärsgalleri, strategiskt lagspel och spännande innovationer som går bortom Battle Royale – allt i en hård värld där allt är tillåtet. Välkommen till nästa nivå inom Hero Shooter.",
                TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                Reviews = null,
                ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmedia.senscritique.com%2Fmedia%2F000019374150%2Fsource_big%2FApex_Legends.png&f=1&nofb=1",
                ImageUrls = { "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_4a1054d35e662fcd2a195ff0e134b44bd5ba808f.1920x1080.jpg?t=1646676032", "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_d34e4980b8b72fcc4e5909177c119fc84e7280dd.1920x1080.jpg?t=1646676032", "https://cdn.cloudflare.steamstatic.com/steam/apps/1172470/ss_42c60e2380e53119dba291d7d608725163fd5f1a.1920x1080.jpg?t=1646676032" }
            },
             new Game
             {
                 Name = "Planet Zoo",
                 Price = 199,
                 AgeLimit = 3,
                 Quantity = 5,
                 Category = categoryOpenWorld,
                 Description =
                    "Bygg en värld för vilda djur i Planet Zoo. Från utvecklarna av Planet Coaster och Zoo Tycoon kommer den ultimata zoo-simmen, med autentiska levande djur som tänker, känner och utforskar världen du skapar runt dem. Upplev en globe-trotting-kampanj eller låt fantasin flöda i sandlådelägets frihet. Skapa unika livsmiljöer och vidsträckta landskap, fatta stora beslut och meningsfulla val och vårda dina djur när du bygger och förvaltar världens vildaste djurparker.",
                 TechnicalSpec = "MINIMUM: <br/>Kräver en 64 - bitars processor samt operativsystem <br/>**OS:** Windows 10 64 - bit <br/>**Processor:** Intel i3 eller AMD Ryzen 3 <br/>**Minne:** 8 GB RAM <br/>**Grafik:** NVIDIA GeForce GTX 460/ AMD HD6850 <br/>**DirectX:** Version 9.0c <br/>**Lagring:** 50 GB ledigt utrymme <br/>**Ytterligare anmärkningar:** Internetuppkoppling",
                 Reviews = null,
                 ImageUrl = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Ffull-games.org%2Fwp-content%2Fuploads%2F2019%2F10%2Fcover_Planet-Zoo.jpg&f=1&nofb=1",
                 ImageUrls = { "https://cdn.akamai.steamstatic.com/steam/apps/703080/ss_275f9a046ba89aa45944a940b4a5c1baaf50c81e.1920x1080.jpg?t=1649758176", "https://cdn.akamai.steamstatic.com/steam/apps/703080/ss_6a247086e998d16983a109f2ab9567b16ddd6ec1.1920x1080.jpg?t=1649758176", "https://cdn.akamai.steamstatic.com/steam/apps/703080/ss_70bff3dd9973ecba56512c358207659f58b844c9.1920x1080.jpg?t=1649758176" }
             },
             //Accessories
             new Game
             {
                 Name = "T-shirt God of War",
                 Price = 199,
                 AgeLimit = null,
                 Quantity = 20,
                 Category = categoryAccessory,
                 Description =
                    "Svart T-shirt med God of War - Prince of Chaos tema. 100% bomull, storlek L motsvarar Europeisk storlek 52",
                 TechnicalSpec = "Storlek L (52 EU) <br/>73,5 cm från krage till botten <br/>53 cm bröstvidd <br/>Material Bomull",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D18000100261378/MERCH801088/t-shirt-god-of-war-prince-of-chaos-svart-l--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D18000100261378/MERCH801088/t-shirt-god-of-war-prince-of-chaos-svart-l--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Musmatta SteelSeries",
                 Price = 179,
                 AgeLimit = null,
                 Quantity = 10,
                 Category = categoryAccessory,
                 Description =
                    "SteelSeries QcK Edge musmatta bjuder på exakt precision och pixelperfekt kontroll tack vare en mikrovävd yta och non-slip gummiklädd bas.",
                 TechnicalSpec = "**Storlek:**<br/> 32 x 27 x 0.2 cm",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002187135/15472/steelseries-qck-edge-musmatta-m--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002187134/15472/steelseries-qck-edge-musmatta-m--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002187132/15472/steelseries-qck-edge-musmatta-m--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002187089/15472/steelseries-qck-edge-musmatta-m--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Razer tangentbord",
                 Price = 666,
                 AgeLimit = null,
                 Quantity = 7,
                 Category = categoryAccessory,
                 Description =
                    "Ge dig in i matchen med Razer Ornata V2 tangentbord för gaming - ett vapen konfigurerat för dina spel. Det har hybridtangenter av Mecha-membran, helt anpassningsbara tangenter, flashiga Razer Chroma RGB-lampor och en rad multimedia-snabbtangenter.",
                 TechnicalSpec =
                 "**Anslutning:**<br/>Sladdbunden <br/>**RGB-belysning:**<br/>Ja<br/> **Färg:**<br/>Svart",
                 Reviews = new[] { new Review { Rating = 1, Text = "Never heard of this keyboard" } },
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002730590/203699/razer-ornata-v2-tangentbord-for-gaming--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002508224/203699/razer-ornata-v2-tangentbord-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002508238/203699/razer-ornata-v2-tangentbord-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002508273/203699/razer-ornata-v2-tangentbord-for-gaming--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Thrustmaster joystick",
                 Price = 599,
                 AgeLimit = null,
                 Quantity = 20,
                 Category = categoryAccessory,
                 Description =
                    "Flyg genom molnen med oslagbar realism tack vare Thrustmaster T.16000M FCS joystick. Utbytbar design gör att den passar till både höger- och vänsterhänta människor.",
                 TechnicalSpec = "**Anslutning:**<br/>USB <br/>**Kompatibel (plattform):**<br/>PC<br/> **Modellnamn:**<br/>Thrustmaster T.16000M FCS",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D18000100274433/THRT16000MPC/thrustmaster-t16000m-fcs-joystick--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D18000100274458/THRT16000MPC/thrustmaster-t16000m-fcs-joystick--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D18000100271432/THRT16000MPC/thrustmaster-t16000m-fcs-joystick--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002166525/THRT16000MPC/thrustmaster-t16000m-fcs-joystick--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Razer headset",
                 Price = 777,
                 AgeLimit = null,
                 Quantity = 1,
                 Category = categoryAccessory,
                 Description =
                    "Ta dig till toppen i e-sportvärlden med Razer Blackshark V2 headset för gaming. Det erbjuder 50 mm stora Triforce-membran som ger enastående ljudkvalitet, en avtagbar HyperClear-kardioidmikrofon och rumslig THX-ljudteknik.",
                 TechnicalSpec = "**Anslutning:**<br/>Kabel <br/>**Färg:**<br/>Svart<br/> **Mikrofon:**<br/>Ja <br/>**Typ av hörlurar:**<br/>On-ear",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002524081/218075/razer-blackshark-v2-headset-for-gaming--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002524039/218075/razer-blackshark-v2-headset-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002524040/218075/razer-blackshark-v2-headset-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002524080/218075/razer-blackshark-v2-headset-for-gaming--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Corsair gamingmus",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 2,
                 Category = categoryAccessory,
                 Description =
                    "Corsair M65 RGB Elite gamingmus är det ultimata vapnet i FPS-spel. Utöver optimal precision får du en optisk sensor med 18k upplösning och dedikerad sniper-knapp. Du kan justera vikt och RGB-belysning efter behov.",
                 TechnicalSpec = "**Anslutning:**<br/>Sladdbunden <br/>**Färg:**<br/>Svart<br/> **RGB-belysning:**<br/>Ja <br/>**Anpassad till:**<br/>Gaming<br/>**Mekaniska brytare:**<br/>Ja<br/>**Mus för höger/vänster-hänta:**<br/>Höger",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002227774/26660/corsair-m65-rgb-elite-gamingmus-svart--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002227775/26660/corsair-m65-rgb-elite-gamingmus-svart--pdp_zoom-3000.", "https://www.elgiganten.se/image/dv_web_D180001002227779/26660/corsair-m65-rgb-elite-gamingmus-svart--pdp_zoom-3000.", "https://www.elgiganten.se/image/dv_web_D180001002227776/26660/corsair-m65-rgb-elite-gamingmus-svart--pdp_zoom-3000." }
             },
             new Game
             {
                 Name = "Logitech tangentbord",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 20,
                 Category = categoryAccessory,
                 Description =
                    "Med gaming-tangentbordet Logitech Logitech G413 får du hög hastighet och exakta kommandon i spelandet. Tack vare ultrasnabba Romer-G-mekaniska switchar får du bättre respons vid tävlingar när varje millisekund räknas. Cool röd bakgrundsbelysning.",
                 TechnicalSpec = "**Anslutning:**<br/>Sladdbunden <br/>**Färg:**<br/>Svart<br/> **RGB-belysning:**<br/>Nej <br/>**Bakbelyst-tangentbord:**<br/>Ja<br/>**Mekaniska brytare:**<br/>Ja<br/>**Modellnamn:**<br/>Logitech G413 Carbon 920-008307<br/>**Tangentbordslayout:**<br/>Nordisk (QWERTY)",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002318457/LTG413RED/logitech-g413-tangentbord-gaming-svartrod--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001001243078/LTG413RED/logitech-g413-tangentbord-gaming-svartrod--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001001243080/LTG413RED/logitech-g413-tangentbord-gaming-svartrod--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002786016/LTG413RED/logitech-g413-tangentbord-gaming-svartrod--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Razer mus för gaming",
                 Price = 377,
                 AgeLimit = null,
                 Quantity = 40,
                 Category = categoryAccessory,
                 Description =
                    "Razer Deathadder V2 mus för gaming klarar av alla fiender med sin avancerade optiska sensor, justerbara känslighet, otroligt responsiva switchar, programmerbara knappar och ergonomiska design.",
                 TechnicalSpec = "**Anslutning:**<br/>Sladdbunden <br/>**Färg:**<br/>Svart<br/> **RGB-belysning:**<br/>Ja <br/>**Modellnamn:**<br/>Razer 399117-EK<br/>**Mekaniska brytare:**<br/>Nej<br/>**Serie:**<br/>Deathadder",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002431148/161538/razer-deathadder-v2-mus-for-gaming--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002431153/161538/razer-deathadder-v2-mus-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002432085/161538/razer-deathadder-v2-mus-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002432084/161538/razer-deathadder-v2-mus-for-gaming--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Plantronics headset",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 10,
                 Category = categoryAccessory,
                 Description =
                    "Plantronics RIG 500 Pro gamingheadset ger en utmärkt ljudkvalitet till din speluppsättning. Det har Dolby Atmos och även 50 mm högtalarelement. För högljudda och klara kommandon i ditt lag har detta headset en avtagbar brusreducerande mikrofon. Dess snygga exoskelett är inte bara coolt utan har även en lätt vikt så du kan spela under långa perioder utan att nacken eller huvudet ansträngs. Med detta headset kan inget stoppa dig när du tar dig till toppen av topplistorna.",
                 TechnicalSpec = "**Anslutning:**<br/>Kabel <br/>**Färg:**<br/>Grå<br/> **Typa av hörlurar:**<br/>On-ear <br/>**Modellnamn:**<br/>Plantronics 214455-99<br/>**Serie:**<br/>Rig 500",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002536212/159543/plantronics-rig-500-pro-gamingheadset--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002419806/159543/plantronics-rig-500-pro-gamingheadset--pdp_zoom-3000.jpg", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fos1.meinecloud.io%2Fb10030%2Fmedia%2Fimage%2F08%2Feb%2F6b%2F11399210159-tmp5b9913db803bfDco8xK8XFzUgV.jpg&f=1&nofb=1", "https://ksd-images.lt/display/aikido/store/e2e41632fba9d9ca604e683af7e968b0.jpg?h=2000&w=2000" }
             },
             new Game
             {
                 Name = "Router",
                 Quantity = 30,
                 Price = 699,
                 AgeLimit = null,
                 Category = categoryAccessory,
                 Description =
                    "TP-Link AX10 Dual-band WiFi router har riklig bandbredd och avancerade teknologier som ger dig snabb online-anslutning som klarar av alla dina uppgifter. Routern stödjer nästa generations WiFi 6 ax-standard som ger dig oöverträfflig hastighet och minimalt med fördröjningar, så att du kan få sömlösa spelupplevelser och arbeta ostört.",
                 TechnicalSpec = "**Modellnamn:**<br/>TP-Link Archer router <br/>**Nätverkshastighet:**<br/>1151-1900 Mbps<br/> **Antal LAN-portar:**<br/>4-5 <br/>**Wi-Fi generation:**<br/>Wi-Fi 6 (802.11ax)<br/>**Kompatibel med MESH:**<br/>Nej",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002672539/150307/tp-link-ax10-dual-band-wifi-6-router--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002492572/150307/tp-link-ax10-dual-band-wifi-6-router--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002492561/150307/tp-link-ax10-dual-band-wifi-6-router--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002492469/150307/tp-link-ax10-dual-band-wifi-6-router--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Corsair musmatta",
                 Price = 189,
                 AgeLimit = null,
                 Quantity = 30,
                 Category = categoryAccessory,
                 Description =
                    "Corsair MM150 musmatta för gaming hjälper dig genom dina tuffaste matcher med en supertunn, 35x26 cm stor, slitstark yta i polykarbonat och halkskydd.",
                 TechnicalSpec = "**Färg:**<br/>Svart, Grå<br/>**Mått:**<br/>35 x 26 cm",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002802214/251755/corsair-mm150-musmatta-for-gaming--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002616433/251755/corsair-mm150-musmatta-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002616444/251755/corsair-mm150-musmatta-for-gaming--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002616435/251755/corsair-mm150-musmatta-for-gaming--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Gamingstol REA!",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 30,
                 Category = categoryAccessory,
                 Description =
                    "Arozzi Verona Signature Soft Fabric gamingstol visar hur elegans, komfort och ergonomi kan gå hand i hand. Den har en mjuk tygyta som andas, och förbättrat skum i ryggstöd och säte.",
                 TechnicalSpec = "**Färg:**<br/>Grå, Blå<br/>**Modellnamn:**<br/>Arozzi VERONA-SIG-SFB-BL",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002534497/225042/arozzi-verona-signature-soft-fabric-gamingstol-gra-med-bla-logo--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002534499/225042/arozzi-verona-signature-soft-fabric-gamingstol-gra-med-bla-logo--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002534514/225042/arozzi-verona-signature-soft-fabric-gamingstol-gra-med-bla-logo--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002534505/225042/arozzi-verona-signature-soft-fabric-gamingstol-gra-med-bla-logo--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Grafikkort (10GB) REA!",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 30,
                 Category = categoryAccessory,
                 Description =
                 "EVGA GeForce RTX 3080 FTW3 ULTRA GAMING LHR grafikkort använder nästa generations strålspårning och tensorkärnor samt streamande multiprocessorer för att leverera fantastisk prestanda och extremt verklighetstrogen bild.",
                 TechnicalSpec = "**Grafikkortstillverkare:**<br/>EVGA<br/>**Serie:**<br/>GeForce RTX 30 Series<br/>**Minne (typ):**<br/>GDDR6X",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002829243/353851/evga-geforce-rtx-3080-ftw3-ultra-gaming-lhr-grafikkort-10gb--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002829250/353851/evga-geforce-rtx-3080-ftw3-ultra-gaming-lhr-grafikkort-10gb--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002829246/353851/evga-geforce-rtx-3080-ftw3-ultra-gaming-lhr-grafikkort-10gb--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002829240/353851/evga-geforce-rtx-3080-ftw3-ultra-gaming-lhr-grafikkort-10gb--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Datorfläkt REA!",
                 Price = 699,
                 AgeLimit = null,
                 Quantity = 30,
                 Category = categoryAccessory,
                 Description =
                    "Nya generationen av välkända NZXT Kraken X familjen är här och kommer med uppdaterad pump och en större samt ljusstarkare RGB infinity mirror på pumphuvudet som även går att rotera 360 grader så loggan alltid hamnar åt rätt håll. Styrs som tidigare modeller med CAM programvaran men har nu även uppdaterats med en HUE 2 kontakt för ännu fler ljuseffekter. (kräver en HUE 2 hub) Kommer med hela 6 års garanti.",
                 TechnicalSpec = "**Rotationshastighet (RPM):**<br/>2000 rpm<br/>**Fläkt diameter:**<br/>120<br/>**Produkttyp:**<br/>Vattenkylning",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002472323/192213/nzxt-kraken-x73-360mm--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002472602/192213/nzxt-kraken-x73-360mm--pdp_zoom-3000.jpg", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.falconcomputers.co.uk%2Fmedia%2Fproduct%2F86648%2F0%2F0%2Fnzxt-rl-krx73-01-kraken-x73-360mm-aio-liquid-cooled-cpu-cooler.jpg.jpg&f=1&nofb=1", "https://www.elgiganten.se/image/dv_web_D180001002472334/192213/nzxt-kraken-x73-360mm--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Razer öronsnäckor",
                 Price = 599,
                 Quantity = 30,
                 AgeLimit = null,
                 Category = categoryAccessory,
                 Description =
                    "Razer Hammerhead true wireless öronsnäckor är små men kraftfulla nog för att tillgodose alla dina gamingbehov. Koppla bara ihop dem med önskad Bluetooth-aktiverad enhet och njut av upp till fyra timmars oavbrutet spelande.",
                 TechnicalSpec = "**Färg:**<br/>Svart<br/>**IP-klassificering:**<br/>IPX4 Striltätt<br/>**Anslutning:**<br/>Helt trådlös",
                 Reviews = null,
                 ImageUrl = "https://www.elgiganten.se/image/dv_web_D180001002360393/129441/razer-hammerhead-true-wireless-oronsnackor--pdp_zoom-3000.jpg",
                 ImageUrls = { "https://www.elgiganten.se/image/dv_web_D180001002360375/129441/razer-hammerhead-true-wireless-oronsnackor--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002360356/129441/razer-hammerhead-true-wireless-oronsnackor--pdp_zoom-3000.jpg", "https://www.elgiganten.se/image/dv_web_D180001002360356/129441/razer-hammerhead-true-wireless-oronsnackor--pdp_zoom-3000.jpg" }
             },
             new Game
             {
                 Name = "Gamingskrivbord",
                 Price = 699,
                 Quantity = 10,
                 AgeLimit = null,
                 Category = categoryAccessory,
                 Description =
                    "Söker du det perfekta prisvärda skrivbordet för din spelutrustning? Du kan verkligen inte välja fel med Svive Vega! Det här skrivbordet är perfekt för en enskild bildskärmsmontering i rum där utrymme är prioritet. Den R-formade bendesignen förhindrar att skrivbordet vacklar och metallramen hjälper till att bära vikten, vilket gör Svive Vega-spelskrivbordet mycket robust och stabilt.",
                 TechnicalSpec = "**Färg:**<br/>Svart<br/>**Justerbara fötter:**<br/>Ja<br/>**Tillverkare:**<br/>Svive",
                 Reviews = null,
                 ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.pricerunner.se%2Fproduct%2F1200x630%2F3000747948%2FSvive-Vega-Dark-RGB-Gaming-Desk-Black.jpg&f=1&nofb=1",
                 ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.komplett.dk%2Fimg%2Fp%2F2400%2F1161524_2.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.komplett.no%2Fimg%2Fp%2F800%2F1161523_5.jpg&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.komplett.no%2Fimg%2Fp%2F2400%2F1161523_3.jpg&f=1&nofb=1" }
             },
             new Game
             {
                 Name = "Racing Wheel (REA)",
                 Price = 599,
                 Quantity = 25,
                 AgeLimit = null,
                 Category = categoryAccessory,
                 Description =
                    "Konstruerad för den perfekta körupplevelsen med dubbelmotorisk kraftåterkoppling, paddelväxlare i rostfritt stål och handsydda läderhjul. Justerbara golvpedaler gör att du kan accelerera, bromsa och växla med känslan av en riktig bil.",
                 TechnicalSpec = "**Färg:**<br/>Svart<br/>**Kompatibel med:**<br/>PC samt Xbox One<br/>**Anslutning:**<br/>Kabelanslutning",
                 Reviews = null,
                 ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.dove.co.nz%2Fimages%2Fproducts%2F12407-53141110-large.jpg&f=1&nofb=1",
                 ImageUrls = { "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.7A6Xfw44KP7gXMfKlxRpxAHaHa%26pid%3DApi&f=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0265%2F9755%2F6317%2Fproducts%2Flogitech-gaming-logitech-g920-driving-force-racing-wheel-for-xbox-one-and-pc-28667215642792_1024x1024.jpg%3Fv%3D1619430331&f=1&nofb=1", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F1181%2F5664%2Fproducts%2Flogitech_g920_driving_force_racing_wheel_1024x1024.jpg%3Fv%3D1591178283&f=1&nofb=1" }
             }
        );

        await context.SaveChangesAsync();
    }
}