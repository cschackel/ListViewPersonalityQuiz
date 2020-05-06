using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApp
{
    public interface IRestService
    {
        Task<MarvelCharacter> GetCharacterByID(int characterID);
    }
}
