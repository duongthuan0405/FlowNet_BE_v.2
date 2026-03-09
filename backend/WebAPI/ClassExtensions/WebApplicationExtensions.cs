namespace WebAPI.ClassExtensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseMiddlewares(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
