using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using MarranoideBot_dotNET.Services;

namespace MarranoideBot_dotNET.SlashCommands
{
    public class InteractionCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService Commands { get; set; }
        private CommandHandler _handler;

        public InteractionCommands(CommandHandler handler)
        {
            _handler = handler;
        }
        // public InteractionCommands(InteractionService commands, CommandHandler handler)
        // {
        //     Commands = commands;
        //     _handler = handler;
        // }

        [SlashCommand("ping", "Pong!")]
        public async Task HandlePing()
        {
            var embed = new EmbedBuilder()
                .WithTitle("🏓 Pong")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();

            await RespondAsync(embed: embed.Build());
        }

        [SlashCommand("8ball", "Conoce tu suerte!")]
        public async Task HandleEightBall(string question)
        {
            // create a list of possible replies
            var replies = new List<string>();

            // add our possible replies
            replies.Add("Si");
            replies.Add("No");
            replies.Add("Tal vez");
            replies.Add("Intentalo mas tarde....");
            replies.Add("Honestamente no me importa jaja lol");
            replies.Add("Ve y preguntale a tus amiguitas");
            replies.Add("Si ya, ya... no estes chi***ndo");

            // get the answer
            var answer = replies[new Random().Next(replies.Count - 1)];

            var embed = new EmbedBuilder()
                .WithTitle($"🎱 {question}")
                .WithDescription($"**{answer}**")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();

            await RespondAsync(embed: embed.Build());
        }

        [SlashCommand("time", "Hora del servidor")]
        public async Task HandleServerTime()
        {
            var s = $"{DateTime.Now.ToLongDateString()} @ {DateTime.Now.ToString("HH:MM:ss")}";
            var embed = new EmbedBuilder()
                .WithTitle("🕓 La hora del bot es")
                .WithDescription($"{s}")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();

            await RespondAsync(embed: embed.Build());
        }

        [SlashCommand("latency", "Mide el tiempo de respuesta del servidor")]
        public async Task HandleServerLatency()
        {
            Ping mPing = new Ping();
            string pDNS = "";
            string pDiscord = "";


            PingReply reply = mPing.Send("1.1.1.1", 1000);
            if (reply != null)
            {
                if (reply.RoundtripTime < 100)
                    pDNS = $"El tiempo de respuesta del servidor al DNS es: {reply.RoundtripTime}ms 🟢";

                else if (reply.RoundtripTime < 130)
                    pDNS = $"El tiempo de respuesta del servidor al DNS es: {reply.RoundtripTime}ms 🟡";

                else if (reply.RoundtripTime >= 130)
                    pDNS = $"El tiempo de respuesta del servidor al DNS es: {reply.RoundtripTime}ms 🔴";

            }

            reply = mPing.Send("discord.com", 1000);
            if (reply != null)
            {
                if (reply.RoundtripTime < 100)
                    pDiscord = $"El tiempo de respuesta del servidor a Discord es: {reply.RoundtripTime}ms 🟢";

                else if (reply.RoundtripTime < 130)
                    pDiscord = $"El tiempo de respuesta del servidor a Discord es: {reply.RoundtripTime}ms 🟡";

                else if (reply.RoundtripTime >= 130)
                    pDiscord = $"El tiempo de respuesta del servidor a Discord es: {reply.RoundtripTime}ms 🔴";

            }

            var embed = new EmbedBuilder()
                .WithTitle("🌐 Latencia del bot")
                .WithDescription($"{pDNS} \n{pDiscord}")
                .WithColor(Color.Blue)
                .WithCurrentTimestamp();

            await RespondAsync(embed: embed.Build());
        }
    }
}