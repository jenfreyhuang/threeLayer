using Dapper;
using System.Data.SqlClient;
using threeLayer.Models;
using threeLayer.Parameter;

namespace threeLayer.Repository
{
    public class CardRepositorys
    {
        private readonly string _connectString;

        public CardRepositorys(string connectString)
        {
            this._connectString = connectString;
        }

        //private readonly string _connectString = "Data Source=165.22.242.154;Initial Catalog = eoc;User ID=oec;Password=Eoc$2023";

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GetList()
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Query<Card>("SELECT * FROM Card");
                return result;
            }
        }
        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <returns></returns>
        public Card Get(int id)
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<Card>(
                    "SELECT TOP 1 * FROM Card Where Id = @id",
                    new
                    {
                        Id = id,
                    });
                return result;
            }
        }
        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public int Create(CardParameter parameter)
        {
            var sql =
            @"
        INSERT INTO Card 
        (
            [Name]
           ,[Description]
           ,[Attack]
           ,[Health]
           ,[Cost]
        ) 
        VALUES 
        (
            @Name
           ,@Description
           ,@Attack
           ,@Health
           ,@Cost
        );
        
        SELECT @@IDENTITY;
    ";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<int>(sql, parameter);
                return result;
            }
        }

        /// <summary>
        /// 修改卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public bool Update(int id, CardParameter parameter)
        {
            var sql =
            @"
        UPDATE Card
        SET 
             [Name] = @Name
            ,[Description] = @Description
            ,[Attack] = @Attack
            ,[Health] = @Health
            ,[Cost] = @Cost
        WHERE 
            Id = @id
    ";

            var parameters = new DynamicParameters(parameter);
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }
        public void Delete(int id)
        {
            var sql =
            @"
        DELETE FROM Card
        WHERE Id = @Id
    ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
            }
        }

    }
}
