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
        public int ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
