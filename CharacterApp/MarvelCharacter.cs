using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterApp
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MarvelCharacter
    {
        [JsonProperty(PropertyName = "id")]
        int ID;
        [JsonProperty(PropertyName = "name")]
        string Name;
        [JsonProperty(PropertyName = "description")]
        string Description;
    }
}
