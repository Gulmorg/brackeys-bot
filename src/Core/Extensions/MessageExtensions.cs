﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using Discord;
using Discord.WebSocket;

namespace BrackeysBot
{
    public static class MessageExtensions
    {
        public static async Task SendToChannel(this Embed e, IMessageChannel channel)
            => await channel.SendMessageAsync(string.Empty, false, e);
        public static EmbedBuilder AddFieldConditional(this EmbedBuilder eb, bool condition, string name, object value, bool inline = false)
        {
            if (condition)
                eb.AddField(name, value, inline);
            return eb;
        }

        public static async Task<bool> TrySendMessageAsync(this IUser user, string text = null, bool isTTS = false, Embed embed = null)
        {
            try
            {
                await user.SendMessageAsync(text, isTTS, embed);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}