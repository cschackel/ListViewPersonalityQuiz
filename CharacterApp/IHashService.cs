using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterApp
{
    public interface IHashService
    {
        string CreateMd5Hash(string input);
    }
}
