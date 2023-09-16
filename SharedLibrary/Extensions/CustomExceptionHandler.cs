using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Text.Json;

namespace SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500; // 500 dönüyoruz çünkü bu hata Client'ın sebep olduğu bir hata değil, Server'ın sebep olduğu bizden kaynaklı bir hata.
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>(); // IExceptionHandlerFeature interface'i üzerinden hatayı yakalıyoruz.

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorDto errorDto = null;

                        if (ex is CustomException)
                        {
                            errorDto = new ErrorDto(ex.Message, true); // CustomException ise true dönüyoruz.
                        }
                        else
                        {
                            errorDto = new ErrorDto(ex.Message, false); // CustomException değilse false dönüyoruz. Bu sayede Client'ın bu hatayı görmesini engelliyoruz.
                        }

                        var response = Response<NoDataDto>.Fail(errorDto, 500);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}