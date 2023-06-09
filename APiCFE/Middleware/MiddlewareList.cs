namespace APiCFE.Middleware
{
    /// <summary>
    /// Lista de middlewares
    /// </summary>
    public class MiddlewareList
    {
        public static List<Object> midd() 
        {
            return new List<Object>() 
            {
                new ErrorHandlingMiddleware(),
            };
        } 
    }
}
