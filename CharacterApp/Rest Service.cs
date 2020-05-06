using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApp
{
    public class Rest_Service : IRestService
    {
        HttpClient _client;

        const string _API_PRIVATE_KEY = "24c6402f50d5b3ec21ec0ed0d2d687fa5514728d";

        const string _API_PUBLIC_KEY = "21a4113da43a74f0fecc90ea7d116799";

        readonly IHashService _hashService;



        public MarvelCharacter MarCharacter { get; private set; }

        public Rest_Service(IHashService hashService)
        {
            _client = new HttpClient();
            _hashService = hashService;
        }

        public async Task<MarvelCharacter> GetCharacterByID(int marvelID)
        {

            var ts = Guid.NewGuid().ToString();
            var hash = _hashService.CreateMd5Hash(ts + _API_PRIVATE_KEY + _API_PUBLIC_KEY);
            MarCharacter = new MarvelCharacter();

                var uri =
                $@"http://gateway.marvel.com/v1/public/characters/{marvelID}&apikey={_API_PUBLIC_KEY}&hash={hash}&ts={ts}";
            /*
            try
            {
                
                    var response = await _client.GetAsync(uri);
                    Debug.WriteLine("XXXX: " + response.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        MarvelCharacter mc = JsonConvert.DeserializeObject<MarvelCharacter>(content);
                        Debug.WriteLine(mc);
                        MarCharacter = mc;
                    }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            */

            //var client = new HttpClient();
            var response = await _client.GetStringAsync(uri);

            var responseObject = JObject.Parse(response);

            List<MarvelCharacter> temp =  (List<MarvelCharacter>)await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<MarvelCharacter>>(responseObject["data"]["results"].ToString()));

            

            return temp[0];
        }

    }
}
