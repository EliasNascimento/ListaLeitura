using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ListaLeitura.App
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();  
        }
        public void Configure(IApplicationBuilder app)
        {
            //utilizado para ver detalhes de erros das páginas;
            app.UseDeveloperExceptionPage();

           app.UseMvcWithDefaultRoute();    
        }
    }
}