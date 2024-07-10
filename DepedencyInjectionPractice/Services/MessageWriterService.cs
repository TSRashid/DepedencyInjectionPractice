using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepedencyInjectionPractice.Services
{
    
    internal class MessageWriterService
    {
        private string _messageId;
        public MessageWriterService(string mid)
        {
            _messageId = mid;   
            
        }
 
        public void WriteMessage(string message)
        {

            Console.WriteLine(message); 
        }
        public string GetMessageId()
        {
            return _messageId;  
        }

    }
}
