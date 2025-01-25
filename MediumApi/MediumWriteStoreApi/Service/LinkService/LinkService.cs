using MediumWriteStoreApi.DTO.LinkDTO;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;
using static System.Net.WebRequestMethods;
using HtmlAgilityPack;
using static System.Net.Mime.MediaTypeNames;

namespace MediumWriteStoreApi.Service.LinkService
{
    public class LinkService : ILinkService
    {
        private readonly IConfiguration _configuration;
        private readonly string YoutubeApiKey;
        private readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = true
        });

        public LinkService(IConfiguration configuration) 
        {
            _configuration = configuration;
            YoutubeApiKey = _configuration.GetValue<string>("YoutubeApiKey")!;
        }
        public async Task<EmbededInfoResponseDTO> GetEmbededInfoFromLink(string url)
        {

            EmbededInfoResponseDTO result = new EmbededInfoResponseDTO();

            HtmlDocument web = new HtmlDocument();

            var responce = await _httpClient.GetAsync("https://cors-anywhere.herokuapp.com/"+ url);

            if (responce.IsSuccessStatusCode)
            {
                web.LoadHtml(await responce.Content.ReadAsStringAsync());



                EmbededInfoLinkResponseDTO UrlEmbededInfo = new EmbededInfoLinkResponseDTO
                {
                    title = web.DocumentNode.SelectSingleNode("//title").InnerText,
                    description = web.DocumentNode.SelectSingleNode("//meta[@name='description']").InnerText,
                    Images = getIconsFromHtml(web),
                    url = responce.RequestMessage!.RequestUri!.Host
                };

                result.HTTPCode = "200";
                result.Result = UrlEmbededInfo;
                result.error = "";
            }
            else 
            {
                result.HTTPCode = "400";
                result.Result = null;
                result.error = await responce.Content.ReadAsStringAsync();

            }



            return result;

        }

        public List<string> getIconsFromHtml(HtmlDocument html) 
        {
            List<string> icons = new List<string>();

            var listOfLinks = html.DocumentNode.SelectNodes("//link[contains(@rel, 'icon')]");

            foreach (var item in listOfLinks) 
            {
                if (item.Attributes.FirstOrDefault(a => a.Name.Contains("href")) != null) 
                {
                    icons.Add(item.Attributes.FirstOrDefault(a => a.Name.Contains("href"))!.Value);
                }
            }

            return icons;
        }

        public string GetImageFromRedactor(IFormFile image)
        {
            throw new NotImplementedException();
        }

        public async Task< BaseLinkResponceDTO> GetYoutubeURl(string url)
        {
            BaseLinkResponceDTO result = new BaseLinkResponceDTO();
            if (GetYoutubeVideoId(url) != null && GetYoutubeVideoId(url) != "") 
            {
                string BaseUrl = "https://youtube.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&id=" + GetYoutubeVideoId(url) + "&key=" + YoutubeApiKey;
                try 
                {
                    var json = JObject.Parse(await _httpClient.GetStringAsync(BaseUrl));

                    if (json["items"] != null && json["items"].HasValues) 
                    {
                        result.url = $"https://www.youtube.com/embed/{GetYoutubeVideoId(url)}";
                        result.error = "";
                        result.HTTPCode = "200";
                        return result;
                    }
                    return result = new BaseLinkResponceDTO { url = "", HTTPCode = "404", error = "Video unexist" };
                }
                catch (Exception e)
                {
                    result.url = "";
                    result.error = e.Message;
                    result.HTTPCode = "400";
                    return result;
                }
            }
            else
            {
                return result = new BaseLinkResponceDTO { url = "", HTTPCode = "404", error = "Url haven`t id" };
            }
        }

        public string? GetYoutubeVideoId(string url)
        {
            try {
                Uri strUrl = new Uri(url);
                var querry = HttpUtility.ParseQueryString(strUrl.Query);

                return querry.Get("v");
            } catch (Exception e) 
            {
                return "";
            }
            
        }
    }
}
