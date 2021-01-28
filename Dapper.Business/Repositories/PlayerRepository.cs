using Dapper.Business.Helper;
using Dapper.Business.Models;
using Dapper.Business.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Business.Repositories
{
    public interface IPlayerRepository
    {
        void Add(PlayerAddRequest model);
        Task<IEnumerable<Player>> GetAll();
        Task<Player> GetById(int id);
        void Update(Player players);
        void Delete(int id);
    }

    public class PlayerRepository : IPlayerRepository
    {
        // GetSettings.EdFootballConnectionString
        public async void Add(PlayerAddRequest model)
        {
            await using (var con = new SqlConnection(GetSettings.EdFootballConnectionString))
            {
                var par = new DynamicParameters();
                par.Add("@Firstname", model.Firstname);
                par.Add("@Lastname", model.Lastname); 

                await con.ExecuteAsync(QueryString.AddPlayer, par, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            await using (var con = new SqlConnection(GetSettings.EdFootballConnectionString))
            {
                return await con.QueryAsync<Player>(QueryString.GetAllPlayer, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<Player> GetById(int id)
        {
            await using (var con = new SqlConnection(GetSettings.EdFootballConnectionString))
            {
                var par = new DynamicParameters();
                par.Add("@id", id);

                var result = await con.QueryAsync<Player>(QueryString.GetAllPlayerById, par, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async void Update(Player players)
        {
            await using (var con = new SqlConnection(GetSettings.EdFootballConnectionString))
            {
                var par = new DynamicParameters();
                par.Add("@id", players.id);
                par.Add("@Firstname", players.Firstname);
                par.Add("@Lastname", players.Lastname);

                await con.ExecuteAsync(QueryString.UpdatePlayer, par, commandType: CommandType.StoredProcedure);
            }
        }

        public async void Delete(int id)
        {
            await using (var con = new SqlConnection(GetSettings.EdFootballConnectionString))
            {
                await con.ExecuteAsync(QueryString.DeletePlayer, new { id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
