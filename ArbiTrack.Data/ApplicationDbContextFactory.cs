using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbiTrack.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public const string DefaultDbFileName = "ArbiTrack.db";
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var path = GetFullDatabasePath();

            optionsBuilder.UseSqlite($"Data Source={path}");

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.ImpossibleFutureApps.Any())
            {
                var _appDictionary = new Dictionary<string, string>
                {
                    { "43A059EF3F4B26A4801036890475640A28EF59250AC121A90087FD7706760FF9", "AI FitBuddy" },
                    { "00822CAA6A50B7565361313E4B99EE512D1B2CBF84E919AEB871D7CF9FF5F81C", "AntAI" },
                    { "9170B2A6D649CAD3D597E74CD6F062595F8D02E92A930F1C7E4F288853348CAF", "AntChain - Time-Proof Your Truth" },
                    { "628DC2BD71596808C4BC1EEA7E0B365CBA241E7250C25FE3F6EA99FC36C3A420", "ArbiTrack" },
                    { "423688FE8C18A697B4981F8BC5D077A44DECB5150CF23457EDDDAC01651C9603", "Ark" },
                    { "9447C33997BF54B7D6C757E0BC057374138BB6F8C9B5846C091D1C71C3CAF80E", "ArtistView(AV)" },
                    { "9E0F70F405FB98815694E223F2BAC0156BD18ACBE511183A5044892AC462B3D0", "Auto Wallet - Application Framework" },
                    { "486699A1B251EBE6518436CACC7AB3B6B0571B31A9D591ADA84483A4BA993144", "Autonomi Browser Extension" },
                    { "2FE2EB51BDCAF5DA7CF0A648759DC50EFBD67B528EB303F3ED3C18C85713CBFD", "Autonomi Community Token" },
                    { "F4FE70941D93B84757C3AEE7DD2B3C0FA676D910A35CE3D687BEC796B4D37E97", "Autonomi Transaction Reporter" },
                    { "FDC08A0D94763A3FE9DBC9564A3BE9271965C6E7440800DA06D1EE9D58F645FF", "AutonomiNet" },
                    { "C1637DA4F9787DFB6E9C3ACA6E73357A9DCE3F1BFC2BD96C2BA39AC54C3D0F7E", "AutVid" },
                    { "2FC34A9D91145F1A11339221CC0CA1B823CDFF3035AD99B2EAE9D926D55C7251", "CanMan" },
                    { "1F21EE5CF611227460A65D6D8C7371B37B7F9D25E7C4FC3A1C8AD1DEEDA5FD6C", "Colony" },
                    { "713F53A9197AC68EF258DE4A92C56DA953C696D0325F9C478A6014A675A13591", "Friends" },
                    { "CDA164DAA02503B49F2F959C067EF243E240E75AB671C8DAED230DA34B7648C1", "Historical Weather Data" },
                    { "8C03346F75EFFEDD1F1DD42060C6FE125179CB27BC7EB94DB2B3ACC547BC97BF", "IMIM" },
                    { "5FE6C74ECED5DAEEF34ED210B016F59A3908521F4C571C62A8F5D156BD8EE0D0", "Memories" },
                    { "CD762D8092903CA7DB27DBD356A49C335013A68BD26A907FA4AE10539C9716EB", "Mutant" },
                    { "AC1D8986F6B0B24F27AAC4D77F220E77EFCF706C3C0692C8E053082774B6AEC0", "MyLife" },
                    { "4A605FC2EAA7A887E73D64C3C530342471BA655BB2F9B3368D54529286957DAB", "Nest" },
                    { "73EC1B7668D49197A6D24257FA2526DF69F201028A40AD64AE43FA3AA976F3FA", "News Site" },
                    { "DD21333C34BBB9833D0CC1143212379C93054C675FF234F72FEE45894C28E637", "Perpetual" },
                    { "C0B064D9C75BF72275349412DF59B9FE1A0F4B91E7496C74FA68904C80CAEF5C", "Personal Soundtrack" },
                    { "5EA148F0A602F420CFEE794D6796C73CFD44993C8D90556199AEE353DB84B200", "Pirate Radio" },
                    { "6E8732D0839627255BCEE134ECE82A3424BCFEADC0511508613C1228786B3FEB", "Queeni AI Assistant" },
                    { "5EED32D6E916C28EC9936E8C81944DA0481BD227A44BC077AE1F0051B4AB744C", "REGRU" },
                    { "60105462D3D4BAF2327776856B70D56D95772FD2B256F5252181632F9DE22B95", "Ryyn" },
                    { "F2524FB02FF4BA42800FE4AA8F5333D40926D63B2A88B0047077A39286709814", "SafeStoreAPI" },
                    { "DF6A482E3955A240420071D990DBD2C4B92307BE2F87B7D3B6600691FFE8FC3F", "Screenshot Tool" },
                    { "F2F690FF3A9D0780B8CE88E0D794B016347A43C1029392622622DC4AB4BE714A", "SOMA" },
                    { "96281B6BA8DEDBB173C92DD85CB17B8D1F5FEF80CB57207C6CED67113B8D1C3F", "STASHBAG" },
                    { "6A47215BA66818E23FBFDC8B4CFCF35770C0B36B60D85842B4215815A7E74EFC", "Vessmere" },
                    { "4E3EB5B7545D7D8CB044D756E90A68CBFD4CAD472F18C2395C2D86511E84AC03", "w3b.site" }
                };
                foreach (var item in _appDictionary)
                {
                    context.ImpossibleFutureApps.Add(new Models.ImpossibleFutureAppModel()
                    {
                        Address = item.Key,
                        Name = item.Value,
                    });
                }

                await context.SaveChangesAsync();
            }
        }

        public static string GetFullDatabasePath()
        {
            return Path.Combine(GetDatabaseDirectoryPath(), GetDatabaseFileName());
        }

        public static string GetDatabaseDirectoryPath()
        {
            string databasePath;

#if ANDROID
            // Android specific
            databasePath = FileSystem.AppDataDirectory, databaseName);
#else
            // Default fallback (e.g. Windows design-time and WinUI)
            databasePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads",
                    "ArbiTrack"
                );
#endif
            if (!Directory.Exists(databasePath))
                Directory.CreateDirectory(databasePath);

            return databasePath;
        }

        public static string GetDatabaseFileName()
        {
            var dir = GetDatabaseDirectoryPath();
            var files = Directory.GetFiles(dir, $"*-{DefaultDbFileName}");
            if (files.Length > 0)
            {
                var result = Path.GetFileName(files.OrderByDescending(f => File.GetLastWriteTime(f)).First());
                return result;
            }

            return DefaultDbFileName;
        }
    }
}
