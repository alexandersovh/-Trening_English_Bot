using System;
using System.Collections.Generic;
using System.Text;

namespace Trening_English_Bot.Commands
{
    interface IChatTextCommandWithAction: IChatTextCommand
    {
        bool DoAction(Conversation chat);
    }
}
