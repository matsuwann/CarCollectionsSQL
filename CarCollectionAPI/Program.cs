using Amazon.S3;
using CarCollectionBusiness; 

namespace CarCollectionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddAWSService<IAmazonS3>(); 

            
            builder.Services.AddSingleton<S3Services>(); 

            
            builder.Services.AddControllers();

            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); 
            app.UseAuthorization(); 

            app.MapControllers(); 

            app.Run(); 
        }
    }
}
