using DepedencyInjectionPractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepedencyInjectionPractice
{
    internal class HelloUser
    {
        private readonly MessageWriterService _messageWriterService;
        public HelloUser(MessageWriterService service)
        {
            _messageWriterService = service;    
            
        }
        public void DisplayName()
        {
            _messageWriterService.WriteMessage("Hello Rashid");

        }
        public void ShowMessageId()
        { 
            
          
            _messageWriterService.WriteMessage(_messageWriterService.GetMessageId());

        }
    }
}
