using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;
using Trening_English_Bot.Commands;
using Trening_English_Bot.EnglishTrainer.Model;

namespace Trening_English_Bot
{
    public class CommandParser
    {
        private List<IChatCommand> Command;

        private AddingController addingController;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            addingController = new AddingController();
        }
        /// <summary>
        /// добоаление слоао команды через класс messeger
        /// </summary>
        /// <param name="chatCommand"></param>
        public void AddCommand(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }
        /// <summary>
        /// приоверка на команду
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsMessageCommand(string message)
        {
           return Command.Exists(x => x.CheckMessage(message));
        }

        /// <summary>
        /// проверка текста команды
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsTextCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        /// <summary>
        /// проверка кнопок
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsButtonCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IKeyBoardCommand;
        }
        /// <summary>
        /// если команды нет
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chat"></param>
        /// <returns></returns>
        public string GetMessageText(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if (command is IChatTextCommandWithAction)
            {
                if (!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };
            }
            return command.ReturnText();
        }


        /// <summary>
        /// к кнопкам походу тренеровка ++
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetInformationalMeggase(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.InformationalMessage();
        }

        public InlineKeyboardMarkup GetKeyBoard(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            return command.ReturnKeyBoard();
        }

        public void AddCallback(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IKeyBoardCommand;

            command.AddCallBack(chat);
        }

        public bool IsAddingCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        public bool IsDictCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is DictionaryCommand;
        }

        public void StartAddingWord(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            addingController.AddFirstState(chat);
            command.StartProcessAsync(chat);

        }
        
        public void DisplayDictionary(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as DictionaryCommand;

            command.StartDisplayDictionary(chat);
        }

        public void NextStage(string message, Conversation chat)
        {
            var command = Command.Find(x => x is AddWordCommand) as AddWordCommand;

            command.DoForStageAsync(addingController.GetStage(chat), chat, message);

            addingController.NextStage(message, chat);

        }


        public void ContinueTraining(string message, Conversation chat)
        {
            var command = Command.Find(x => x is TrainingCommand) as TrainingCommand;

            command.NextStepAsync(chat, message);

        }



    }
}
