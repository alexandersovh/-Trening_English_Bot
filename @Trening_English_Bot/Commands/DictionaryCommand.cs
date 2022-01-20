using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Trening_English_Bot.EnglishTrainer.Model;
using Telegram.Bot.Types;


namespace Trening_English_Bot.Commands
{
    class DictionaryCommand : AbstractCommand
    {
        private ITelegramBotClient botClient;
        public DictionaryCommand(ITelegramBotClient botClient)
        {
            CommandText = "/dictionary";

            this.botClient = botClient;
        }

        public async Task StartDisplayDictionary(Conversation chat)
        {
            string dWord = "";
            foreach(var item in chat.dictionary)
            {
                Word w = item.Value;
                dWord += w.Theme + ": " + w.Russian + " - " + w.English + "\n";
            }
            await botClient.SendTextMessageAsync(chatId: chat.GetId(), text: dWord);
        }
    }
}
