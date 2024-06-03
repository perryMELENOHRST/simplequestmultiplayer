using Microsoft.Extensions.Logging; // Used for ILogger type
using Server.Logger;

namespace Server {

    public class Server 
    {
        private LoggerCreater loggerCreater = new();
        private ILogger s_logger; // s_ prefix is for server ONLY variables
        
        public Server()
        {
            s_logger = loggerCreater.CreateLogger("Server");
            s_logger.LogInformation("Server started");
            s_logger.LogInformation("listening on port 8080");
        }
    }

}