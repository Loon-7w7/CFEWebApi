using Newtonsoft.Json;

namespace APiCFE.Middleware
{
    /// <summary>
    /// Middleware para el manejo de errores en la autenticación y autorización.
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Crea una nueva instancia del middleware de manejo de errores.
        /// </summary>
        /// <param name="next">El siguiente middleware en la cadena de procesamiento.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoca el middleware de manejo de errores.
        /// </summary>
        /// <param name="context">El contexto de la solicitud y la respuesta.</param>
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                await HandleUnauthorizedAsync(context);
            }
            else if (context.Response.StatusCode == 403)
            {
                await HandleForbiddenAsync(context);
            }
        }

        /// <summary>
        /// Maneja una respuesta de autenticación no autorizada.
        /// </summary>
        /// <param name="context">El contexto de la solicitud y la respuesta.</param>
        private static Task HandleUnauthorizedAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;

            var message = "No autorizado";
            var result = JsonConvert.SerializeObject(new { error = message });

            return context.Response.WriteAsync(result);
        }

        /// <summary>
        /// Maneja una respuesta de acceso denegado.
        /// </summary>
        /// <param name="context">El contexto de la solicitud y la respuesta.</param>
        private static Task HandleForbiddenAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 403;

            var message = "Acceso denegado";
            var result = JsonConvert.SerializeObject(new { error = message });

            return context.Response.WriteAsync(result);
        }
    }


}
