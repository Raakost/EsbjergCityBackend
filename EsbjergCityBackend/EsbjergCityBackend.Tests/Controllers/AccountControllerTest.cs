using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsbjergCityBackend.Controllers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace EsbjergCityBackend.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void RegisterTest()
        {


        }
        [TestMethod]
        public void LoginTest()
        {
            //string url = "http://localhost:6681/token";
            ////var client = new WebClient();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = url;
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            //}
            //client.Headers.Add("Authorization", "Bearer " + accessToken);

            //var response = await client.GetStringAsync(url);
        }
        [TestMethod]
        public void FailedLoginTest()
        {
            //string url = "http://localhost:6681/token";
            //WebClient client = new WebClient();
            //String userName = "u@u.dk";
            //String passWord = "TestPass1!";

            //client.Credentials = new NetworkCredential(userName, passWord);

            //string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            //client.Headers[HttpRequestHeader.Authorization] = "Bearer " + credentials;

            //var result = client.DownloadString(url);

            //Console.WriteLine(result);
        }
        [TestMethod]
        public void DeleteLoginTest()
        {
        }
    }
}
