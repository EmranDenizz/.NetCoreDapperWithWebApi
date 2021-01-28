using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Business.Helper
{
    public static class QueryString
    {
        //Burada storade procedure'lerimiz tanımlıdır. Static ve readonly tanımlı ki projenin her yerinden erişilebilir ama değiştirilemez durumda olsun.
        public static readonly string GetAllPlayerById = "sp_GetAllPlayerById";
        public static readonly string GetAllPlayer = "sp_GetAllDeneme";
        public static readonly string AddPlayer = "sp_AddPlayer";
        public static readonly string DeletePlayer = "sp_DeletePlayer";
        public static readonly string UpdatePlayer = "sp_UpdatePlayer";
    }
}
