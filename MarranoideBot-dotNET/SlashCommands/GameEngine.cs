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
    public class GameEngine : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService Commands { get; set; }
        private CommandHandler _handler;

        public GameEngine(CommandHandler handler)
        {
            _handler = handler;
        }
        // public InteractionCommands(InteractionService commands, CommandHandler handler)
        // {
        //     Commands = commands;
        //     _handler = handler;
        // }

        [SlashCommand("game", "Selecciona un juego para jugar")]
        public async Task StartGame()
        {
            Context.Client.SelectMenuExecuted += SelectedMenuJuego;

            var menu = new SelectMenuBuilder()
            .WithPlaceholder("Selecciona un juego")
            .WithCustomId("menujuego")
            .WithMinValues(1)
            .WithMaxValues(1)
            .AddOption("Juego 1", "game-1", "Vive la historia de un aventurero");

            var builder = new ComponentBuilder()
            .WithSelectMenu(menu);

            await ReplyAsync("Selecciona de la coleccion", components: builder.Build());
        }

        public async Task SelectedMenuJuego(SocketMessageComponent component)
        {
            var text = string.Join(", ", component.Data.Values);
            await component.RespondAsync($"{component.User.Mention} se esta cargando el casset del juego: {text}!");
        }
    }
}