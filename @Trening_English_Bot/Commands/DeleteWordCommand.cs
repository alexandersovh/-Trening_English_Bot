using System;
using System.Collections.Generic;
using System.Text;

namespace Trening_English_Bot.Commands
{
    public class DeleteWordCommand : ChatTextCommandOption, IChatTextCommandWithAction
    {
        public DeleteWordCommand()
        {
            CommandText = "/deleteword";
        }

        /// <summary>
        /// поиск и удаление слова
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        public bool DoAction(Conversation chat)
        {
            var message = chat.GetLastMessage();

            var text = ClearMessageFromCommand(message);

            if (chat.dictionary.ContainsKey(text))
            {
                chat.dictionary.Remove(text);

                return true;
            }

            return false; 
        }

        public string ReturnText()
        { 
            return "Слово успешно удалено!";
        }


    }
}
