using MyLoginApp.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyLoginApp.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            try
            {
                // Ensure you have the correct URL for your API
                string url = "http://292.268.1.107.8099/api/UserInfores/LoginUser/" + username + "/" + password;

                // Create an instance of HttpClient
                using (var client = new HttpClient())
                {
                    // Send a GET request to the specified URL
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the JSON response into a UserInfo object
                        UserInfo userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
                        return userInfo;
                    }
                    else
                    {
                        // Handle the case when the response is not successful
                        // For example, you may log the error or return null
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                return null;
            }
        }
    }
}









