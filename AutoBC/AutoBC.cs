using System;
using Terraria;
using TerrariaApi.Server;
using TShockAPI.Hooks;
using TShockAPI;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Linq;

namespace AutoBC
{
    [ApiVersion(2, 1)]
    public class AutoBC : TerrariaPlugin
    {
        /// <summary>
        /// The name of the plugin.
        /// </summary>
        public override string Name => "自动广播";

        /// <summary>
        /// The version of the plugin in its current state.
        /// </summary>
        public override Version Version => new Version(1, 0, 0);

        /// <summary>
        /// The author(s) of the plugin.
        /// </summary>
        public override string Author => "Average，肝帝熙恩汉化更新1449";

        /// <summary>
        /// A short, one-line, description of the plugin's purpose.
        /// </summary>
        public override string Description => "一个快速，简单，容易的自动广播插件.";

        public AutoBC(Main game) : base(game)
        {

        }

        public static Config config;
        public bool shouldBeBroadcasting = true;

        /// <summary>
        /// Performs plugin initialization logic.
        /// Add your hooks, config file read/writes, etc here
        /// </summary>
        public override void Initialize()
        {
            GeneralHooks.ReloadEvent += Reload;
            ServerApi.Hooks.GameInitialize.Register(this, ServerLoaded);
            ServerApi.Hooks.NetGreetPlayer.Register(this, PlayerJoined);
            ServerApi.Hooks.ServerLeave.Register(this, PlayerLeft);

        }

        private void PlayerLeft(LeaveEventArgs args)
        {
            if (TShock.Players.Count() == 0)
            {
                shouldBeBroadcasting = false;
            }
        }

        private void PlayerJoined(GreetPlayerEventArgs args)
        {
            if(TShock.Players.Count() > 0 && shouldBeBroadcasting == false)
            {
                shouldBeBroadcasting = true; 
                ContinueBC();
            }
        }

        private void ServerLoaded(EventArgs args)
        {
            config = Config.Read();
            //config

        }

        public async void ContinueBC()
        {
            if (shouldBeBroadcasting == true)
            {
                await Task.Delay(config.bcInterval * 60 * 1000);
                //get random message from config
                var r = new Random();
                var index = r.Next(0, config.messages.Count);
                var color = new Microsoft.Xna.Framework.Color(config.messages[index].Color.R, config.messages[index].Color.G, config.messages[index].Color.B);
                TSPlayer.All.SendMessage(config.messages[index].Message, color);
                foreach(string cmd in config.messages[index].Commands)
                {
                    Commands.HandleCommand(TSPlayer.Server, cmd);
                }
                ContinueBC();
            }
        }

        public void Reload(ReloadEventArgs args)
        {
            config = Config.Read();
        }
        
        /// <summary>
        /// Performs plugin cleanup logic
        /// Remove your hooks and perform general cleanup here
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GeneralHooks.ReloadEvent -= Reload;

            }
            base.Dispose(disposing);
        }
    }
}
