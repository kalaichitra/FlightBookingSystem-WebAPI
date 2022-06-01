using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARSAPI.SearchAPI
{
    public class RabbitMqConsts
    {
        public const string RabbitMqRootUri = "rabbitmq://localhost";
        public const string RabbitMqUri = "rabbitmq://localhost/searchQueue";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string NotificationServiceQueue = "notification.service";
    }
}
