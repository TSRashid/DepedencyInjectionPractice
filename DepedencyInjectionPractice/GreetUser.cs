using DepedencyInjectionPractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepedencyInjectionPractice
{
    internal class GreetUser
    {
        MessageWriterService service;
        public GreetUser(MessageWriterService service)
        {
            this.service = service;    
        }
        public void GreetUserFun()
        {
            service.WriteMessage("Greeting Rashid..");
        }
        public void ShowMessageId()
        {
           
            try
            {
                service.WriteMessage(service.GetMessageId());
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
