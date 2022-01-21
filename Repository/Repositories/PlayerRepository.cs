using System.Collections.Generic;
using Domain.Entities;
using Dommel;
using MySqlConnector;

namespace Repository.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>
    {
        public override IEnumerable<Player> GetAll()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.GetAll<Player, Team, Player>((player, team) =>
                {
                    player.Team = team;
                    return player;
                });
            }
        }

    }
}