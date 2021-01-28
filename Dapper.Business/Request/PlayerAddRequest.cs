using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Business.Request
{
    public class PlayerAddRequest
    {
        // Kullanıcıya id göstermek istemiyorsak ya da belli başli şeyleri göstermek istiyorsak bu şekilde bir model oluştur.
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
