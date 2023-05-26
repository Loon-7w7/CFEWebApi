using CFE_Services.Excepciones;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APiCFE.Middleware
{
    /// <summary>
    /// Middleware para manejar excepciones de Entity Framework.
    /// </summary>
    public class EntityFrameworkExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<EntityFrameworkExceptionMiddleware> _logger;

        /// <summary>
        /// Constructor del middleware EntityFrameworkExceptionMiddleware.
        /// </summary>
        /// <param name="next">Delegate de solicitud siguiente.</param>
        /// <param name="logger">Instancia del logger.</param>
        public EntityFrameworkExceptionMiddleware(RequestDelegate next, ILogger<EntityFrameworkExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        /// <summary>
        /// Constructor del middleware EntityFrameworkExceptionMiddleware.
        /// </summary>
        public EntityFrameworkExceptionMiddleware()
        {
        }
        /// <summary>
        /// Método de invocación del middleware.
        /// </summary>
        /// <param name="context">Contexto de la solicitud.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityCreateException ex)
            {
                _logger.LogError(ex, "Se produjo un error al actualizar la base de datos");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (EntityDeleteException ex)
            {
                _logger.LogError(ex, "Se produjo un error al actualizar la base de datos");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (EntityUpdateException ex)
            {
                _logger.LogError(ex, "Se produjo un error al actualizar la base de datos");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError(ex, "Entidad no encontrada");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (EmptyListException ex)
            {
                _logger.LogError(ex, "Lista vacía");
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo una excepción no controlada");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Se produjo un error al procesar su solicitud.");
            }
        }
    }

}
