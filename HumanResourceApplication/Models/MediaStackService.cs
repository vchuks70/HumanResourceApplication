using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HumanResourceApplication.Models
{
    public class MediaStackService:IMediaStackService
    {
        static readonly HttpClient client = new HttpClient();
        public static IList<MediaData> MediaData { get; set; } = new List<MediaData>();

        public MediaStackService(IOptions<AppSettings> appSettings)
        {
            
            _appSettings = appSettings.Value;
        }

        
        private readonly AppSettings _appSettings;
        public async Task<IList<MediaData>> GetData()
        {
            
            try
            {
               
                HttpResponseMessage response = await client.GetAsync($"http://api.mediastack.com/v1/news?access_key={_appSettings.ApiKey}");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<MediaStackResponse>(responseBody);
                MediaData = data.Data;
                return MediaData;
               
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
