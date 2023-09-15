using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using threeLayer.Repository.Implement;
using threeLayer.Repository.Interface;
using threeLayer.Service.Implement;
using threeLayer.Service.Interface;

namespace threeLayer
{
    public class Startup
    {
        private IConfiguration Configuration;
        private readonly string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._connectionString = configuration.GetValue<string>("ConnectionString");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();


            services.AddScoped<ICardRepository>(sp =>
            {
                //var connectString = "Data Source = 165.22.242.154; Initial Catalog = eoc; User ID = oec; Password = Eoc$2023";
                return new CardRepository(_connectionString);
            });


            services.AddControllers();

            // 這邊可能還有其他註冊的服務，Swagger 之類的
        }

       
    }
}
