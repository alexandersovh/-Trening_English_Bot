using System;
using System.Collections.Generic;
using System.Text;

namespace Trening_English_Bot.Commands
{
    public abstract class ChatTextCommandOption : AbstractCommand
    {

        //проверка
        public override bool CheckMessage(string message)
        {
            return message.StartsWith(CommandText);
        }
        // вызов строки
        public string ClearMessageFromCommand(string message)
        {
            return message.Substring(CommandText.Length + 1);
        }

    }
}
