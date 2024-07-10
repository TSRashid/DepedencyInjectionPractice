using DepedencyInjectionPractice;
using DepedencyInjectionPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Implementing using singleton
            var services = CreateServices();
            MessageWriterService service = services.GetService<MessageWriterService>();

            HelloUser user = new HelloUser(service);
            user.DisplayName();
            user.ShowMessageId();

            HelloUser user2 = new HelloUser(service);
            user2.ShowMessageId();

            GreetUser user3 = new GreetUser(service);
            user3.ShowMessageId();

            GreetUser user4 = new GreetUser(service);
            user4.ShowMessageId();

            // Implementation using Transient
            var servicesTransient = CreateServicesWithTransient();

          
            MessageWriterService service2 = servicesTransient.GetService<MessageWriterService>();
            GreetUser user5 = new GreetUser(service2);
            user5.ShowMessageId();
            user5.ShowMessageId();

            GreetUser user6 = new GreetUser(servicesTransient.GetService<MessageWriterService>());
            user6.ShowMessageId();

            // implementation of Scoped DI
            var ScopedServiceProvider = CreateServiceWithScoped();
            
            var scopedService = ScopedServiceProvider.GetService<MessageWriterService>();
            GreetUser User = new GreetUser(scopedService);
            User.ShowMessageId();
            GreetUser User2 = new GreetUser(scopedService);
            User2.ShowMessageId();
            






        }

        private static ServiceProvider CreateServices()
        {
            // Registering MessageWriterService as singleton
            MessageWriterService WritingService = new MessageWriterService(GenerateUniqueId());

            var serviceProvider = new ServiceCollection()
                .AddSingleton<MessageWriterService>(WritingService)
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static ServiceProvider CreateServicesWithTransient()
        {
            // Registering MessageWriterService as transient
            var serviceProvider = new ServiceCollection()
                .AddTransient<MessageWriterService>(provider =>
                {
                    return new MessageWriterService(GenerateUniqueId());
                })
                .BuildServiceProvider();

            return serviceProvider;
        }
        private static ServiceProvider CreateServiceWithScoped()
        {
            var serviceProvider = new ServiceCollection().AddScoped<MessageWriterService>(provider =>
            {
                return new MessageWriterService(GenerateUniqueId());
            }).BuildServiceProvider(); 
            
            return serviceProvider;



        }
        static string GenerateUniqueId()
        {
            // Generate unique ID (for demonstration)
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

      
    }
    


}
