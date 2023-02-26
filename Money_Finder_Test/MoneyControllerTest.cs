using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Money_Finder.Controllers;
using Moq;
using System.Net;

namespace Money_Finder_Test
{
    public class MoneyControllerTest
    {

        [Fact]
        public async Task Offer_Link_Paramaeters_Check_Async()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Host = new HostString("localhost:5002");
            var session = new TestSession("UnitTest");
            httpContext.Session = session;
            var dummyIpAddress = IPAddress.Parse("192.0.2.1");
            httpContext.Request.HttpContext.Connection.RemoteIpAddress = dummyIpAddress;
            httpContext.Request.QueryString = new QueryString("?tid=test_tid&sourceone=test_source&First_name=test_first_name&Last_name=test_last_name&Address=test_address&email=test_email&zip=test_zip&phonea=test_phonea&phoneb=test_phoneb&phonec=test_phonec&City=test_city&Age=test_age&DOB=test_dob&Gender=test_gender&State=test_state");
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var controller = new MoneyController();
            controller.ControllerContext = controllerContext;

            // Act
            var result = await controller.short_formAsync() as ViewResult;

            // Assert
            Assert.NotNull(result);

            Assert.Equal("test_tid", result.ViewData["tid"]);
            Assert.Equal("test_first_name", result.ViewData["firstname"]);
            Assert.Equal("test_last_name", result.ViewData["lastname"]);
            Assert.Equal("test_address", result.ViewData["address"]);
            Assert.Equal("test_email", result.ViewData["email"]);
            Assert.Equal("test_zip", result.ViewData["zip"]);
            Assert.Equal("test_phonea", result.ViewData["phonea"]);
            Assert.Equal("test_phoneb", result.ViewData["phoneb"]);
            Assert.Equal("test_phonec", result.ViewData["phonec"]);
            Assert.Equal("test_state", result.ViewData["State"]);
            Assert.Equal("test_gender", result.ViewData["Gender"]);
            Assert.Equal("test_dob", result.ViewData["DOB"]);
            Assert.Equal("test_city", result.ViewData["City"]);
            Assert.Equal("test_age", result.ViewData["Age"]);
            Assert.Equal("test_source", result.ViewData["source_one"]);
        }

        [Fact]
        public async Task SubmitOffers_RedirectsToOffersPage()
        {

            // Arrange
            var httpContext = new DefaultHttpContext();

            var form = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "TRANSACTIONID", "123" },
                { "source_one", "test" },
                { "first_name", "John" },
                { "last_name", "Doe" },
                { "address", "123 Main St" },
                { "zip", "12345" },
                { "phone", "123456789123456789" },
                { "phonea", "123" },
                { "phoneb", "456" },
                { "phonec", "7890" },
                { "universal_leadid", "abc123" },
                { "email", "john.doe@example.com" },
                { "checkingaccount", "yes" },
                { "nsyesno", "yes" },
                { "device", "desktop" },
                { "lf", "form1" },
                { "age", "30" },
                { "city", "New York" },
                { "dob", "01/01/1990" },
                { "gender", "Male" },
                { "state", "NY" }
            };
            httpContext.Request.Form = new FormCollection(form);
            httpContext.Connection.RemoteIpAddress = IPAddress.Parse("127.0.0.1");
            httpContext.Connection.Id = Guid.NewGuid().ToString();
            httpContext.Request.Host = new HostString("localhost:5002");
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var controller = new MoneyController();
            controller.ControllerContext = controllerContext;

            // Act
            var result = await controller.submitoffers() as RedirectResult;

            // Assert
            Assert.NotNull(result.Url);
        }
    }
}