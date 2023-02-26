using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Money_Finder.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    AdminLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemRoll = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkypeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TryCount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.AdminLoginId);
                });

            migrationBuilder.CreateTable(
                name: "CcpaOptOut",
                columns: table => new
                {
                    CcpaOptOutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcpaOptOut", x => x.CcpaOptOutId);
                });

            migrationBuilder.CreateTable(
                name: "CoregOffer",
                columns: table => new
                {
                    CoregOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffliateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Switch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCapDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoregOffer", x => x.CoregOfferId);
                });

            migrationBuilder.CreateTable(
                name: "DisclosureText",
                columns: table => new
                {
                    DisclosureTextId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Second = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Third = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fourth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisclosureText", x => x.DisclosureTextId);
                });

            migrationBuilder.CreateTable(
                name: "DneDataBase",
                columns: table => new
                {
                    DneDataBaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DneDataBase", x => x.DneDataBaseId);
                });

            migrationBuilder.CreateTable(
                name: "OfferCategory",
                columns: table => new
                {
                    OfferCategoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategory", x => x.OfferCategoryid);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OffersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OffersId);
                });

            migrationBuilder.CreateTable(
                name: "OfferStates",
                columns: table => new
                {
                    OfferStatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    States = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferStates", x => x.OfferStatesId);
                });

            migrationBuilder.CreateTable(
                name: "OfferWall",
                columns: table => new
                {
                    OfferWallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffliateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCapDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferWall", x => x.OfferWallId);
                });

            migrationBuilder.CreateTable(
                name: "PathOffer",
                columns: table => new
                {
                    PathOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EverflowOfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewWindowLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkipLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCapDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffliateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathOffer", x => x.PathOfferId);
                });

            migrationBuilder.CreateTable(
                name: "PopUp",
                columns: table => new
                {
                    PopUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffliateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCapDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Switch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopUp", x => x.PopUpId);
                });

            migrationBuilder.CreateTable(
                name: "QaOffer",
                columns: table => new
                {
                    QaOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QaOffer", x => x.QaOfferId);
                });

            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    RegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeadId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckingAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetSpend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Forms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.RegisterId);
                });

            migrationBuilder.CreateTable(
                name: "SiteUnSubscribe",
                columns: table => new
                {
                    SiteUnSubscribeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUnSubscribe", x => x.SiteUnSubscribeId);
                });

            migrationBuilder.CreateTable(
                name: "SmsDataBase",
                columns: table => new
                {
                    SmsDataBaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Optin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptOut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsDataBase", x => x.SmsDataBaseId);
                });

            migrationBuilder.CreateTable(
                name: "TcpaOffers",
                columns: table => new
                {
                    TcpaOffersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BulletPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TcpaOffers", x => x.TcpaOffersId);
                });

            migrationBuilder.CreateTable(
                name: "userlocationcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlocationcs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "CcpaOptOut");

            migrationBuilder.DropTable(
                name: "CoregOffer");

            migrationBuilder.DropTable(
                name: "DisclosureText");

            migrationBuilder.DropTable(
                name: "DneDataBase");

            migrationBuilder.DropTable(
                name: "OfferCategory");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "OfferStates");

            migrationBuilder.DropTable(
                name: "OfferWall");

            migrationBuilder.DropTable(
                name: "PathOffer");

            migrationBuilder.DropTable(
                name: "PopUp");

            migrationBuilder.DropTable(
                name: "QaOffer");

            migrationBuilder.DropTable(
                name: "Register");

            migrationBuilder.DropTable(
                name: "SiteUnSubscribe");

            migrationBuilder.DropTable(
                name: "SmsDataBase");

            migrationBuilder.DropTable(
                name: "TcpaOffers");

            migrationBuilder.DropTable(
                name: "userlocationcs");
        }
    }
}
