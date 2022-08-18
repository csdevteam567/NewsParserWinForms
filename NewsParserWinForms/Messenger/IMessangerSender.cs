using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParserWinForms.Messenger
{
    public interface IMessangerSender
    {
        void SendMessage(Message message);
    }
}
