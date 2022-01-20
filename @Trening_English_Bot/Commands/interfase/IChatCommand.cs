using System;
using System.Collections.Generic;
using System.Text;
using Trening_English_Bot.EnglishTrainer.Model;

namespace Trening_English_Bot
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
