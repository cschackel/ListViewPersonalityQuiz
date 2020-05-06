using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApp
{
    public class MarvelDataManager
    {
        IRestService restService;
        public MarvelDataManager(IRestService service)
        {
            restService = service;
        }

        public Task<MarvelCharacter> GetCharacterByID(int id)
        {
            return restService.GetCharacterByID(id);
        }
    }
}
