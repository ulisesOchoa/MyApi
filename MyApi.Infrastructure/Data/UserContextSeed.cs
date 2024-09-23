using Microsoft.Extensions.Logging;
using MyApi.Domain.Entities;

namespace MyApi.Infrastructure.Data
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(Context context, ILoggerFactory logger, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                await context.Database.EnsureCreatedAsync();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetUsers());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = logger.CreateLogger<UserContextSeed>();
                    log.LogError($"Exception occured while connecting: {ex.Message}");
                    await SeedAsync(context, logger, retryForAvailability);
                }
            }
        }

        private static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User { Name = "Juan", LastName = "Pérez", Email = "juan.perez@example.com", PhoneNumber = "123456789", Age = 30 },
                new User { Name = "María", LastName = "Gómez", Email = "maria.gomez@example.com", PhoneNumber = "987654321", Age = 25 },
                new User { Name = "Luis", LastName = "Rodríguez", Email = "luis.rodriguez@example.com", PhoneNumber = "456789123", Age = 40 },
                new User { Name = "Ana", LastName = "López", Email = "ana.lopez@example.com", PhoneNumber = "321654987", Age = 35 },
                new User { Name = "Carlos", LastName = "Martínez", Email = "carlos.martinez@example.com", PhoneNumber = "159753864", Age = 28 }
            };
        }
    }
}
