
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Money_Finder.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        { }
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        private static string ConnectionString { get; set; }


        public DbSet<Offers> Offers { get; set; }
        public DbSet<Arrival> Arrival { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<CcpaOptOut> CcpaOptOut { get; set; }
        public DbSet<OfferWall> OfferWall { get; set; }
        
        public DbSet<SiteUnSubscribe> SiteUnSubscribe { get; set; }
        public DbSet<PopUp> PopUp { get; set; }
        public DbSet<TcpaOffers> TcpaOffers { get; set; }
        public DbSet<PathOffer> PathOffer { get; set; }
        public DbSet<DisclosureText> DisclosureText { get; set; }
        public DbSet<CoregOffer> CoregOffer { get; set; }
        public DbSet<DneDataBase> DneDataBase { get; set; }
        public DbSet<SmsDataBase> SmsDataBase { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        //public DbSet<transaction> transaction { get; set; }
        //public DbSet<evelflow> evelflow { get; set; }
        //public DbSet<everflowoffers> everflowoffers { get; set; }
        //public DbSet<advertisers> advertisers { get; set; }
        //public DbSet<account_manager> account_manager { get; set; }
        public DbSet<OfferStates> OfferStates { get; set; }
        public DbSet<userlocationcs> userlocationcs { get; set; }
        public DbSet<OfferCategory> OfferCategory { get; set; }
        public DbSet<QaOffer> QaOffer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            ///options.UseNpgsql("Server=postgresql-107540-0.cloudclusters.net;Port=19135;Database=moneyfinder;User Id=munir;Password=macodex@123");
            ///options.UseNpgsql("Server=localhost;Port=5432;Database=moneyfinder;User Id=postgres;Password=macodex@123;");

            // options.UseSqlServer("Data Source=.;Initial Catalog=moneyfinder;Integrated Security=True");
            ///options.UseSqlServer("Data Source=.;Initial Catalog=moneyfinder;Integrated Security=True");
            /// options.UseSqlServer("Data Source=A2NWPLSK14SQL-v01.shr.prod.iad2.secureserver.net;Initial Catalog=usmandb;User Id=Usman;Password =Lalamunir@20");
         


           
        }

        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
