using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.DependencyInjection;
using MyVet.Domain.Services;
using MyVet.Domain.Services.Interface;

namespace MyVet.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            //Domain - - La interfaz de primero y luego la clase {IUserServices, UserServices}
            services.AddTransient<IUserServices, UserServices>();
            //services.AddTransient<IRolServices, RolServices>();

            //Inyeccion de servicio REST
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<IAuthorService, AuthorService>();
        }
    }
}