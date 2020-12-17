using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotTelegramGame
{
    class Program
    {
        static ITelegramBotClient bot;
        private static Dictionary<long, string> dict = new Dictionary<long, string>();
        private static Dictionary<long, string> messageDictionary = new Dictionary<long, string>();
        static void Main(string[] args)
        {   
            string token = "1446474527:AAF_5LreDT7sSi7Ah8ENtk31VG6YWBdSMoU";
            //"1446474527:AAF_5LreDT7sSi7Ah8ENtk31VG6YWBdSMoU"; 

            bot = new TelegramBotClient(token);
            Console.WriteLine($"@{bot.GetMeAsync().Result.Username} start...");

            Random rand = new Random();
            Dictionary<long, int> db = new Dictionary<long, int>();

            bot.OnMessage += (s, arg) =>
            {
                #region var 

                string msgText = arg.Message.Text;
                string replyMsg = String.Empty;
                int msgId = arg.Message.MessageId;
                long chatID = arg.Message.Chat.Id;
                var firstName = arg.Message.From.FirstName;
                var lastName = arg.Message.From.LastName;

                string path = $"id_{chatID.ToString().Substring(0, 5)}";

                Console.WriteLine($"{firstName}: {msgText}");

                #endregion

                var message = arg.Message;
                if (message == null || message.Type != MessageType.Text) return;
                if (message.Text == @"/start")
                {
                    var keyboard = new ReplyKeyboardMarkup(new[]
                    {
                    new []
                    {
                        new KeyboardButton("Расписание"),
                        new KeyboardButton("Контакты"),
                    },
                    new []
                    {
                        new KeyboardButton("О нас"),
                        new KeyboardButton("Главное меню"),
                    }
                });

                    bot.SendTextMessageAsync(chatID, "Добро пожаловать!",default,default,default,default,keyboard,default);
                }
                if (message.Text == "Расписание")
                    bot.SendTextMessageAsync(message.Chat.Id, "Ближайшее расписание:\n" + System.IO.File.ReadAllText(@"E:/РС/rasp.txt"));
                else if (message.Text == "Контакты")
                    bot.SendTextMessageAsync(message.Chat.Id, "Наши контакты: \nРазработчик: Калугин Михаил, ИСиТ-1801");
                else if (message.Text == "О нас")
                    bot.SendTextMessageAsync(message.Chat.Id, "Мы супер:3");
                else if (message.Text == "Главное меню")
                    bot.SendTextMessageAsync(message.Chat.Id, "Вы в меню!\nВыберите любой пункт на клавиатуре.");
            };

            bot.StartReceiving();
            Console.ReadLine();




        }
    }
}
