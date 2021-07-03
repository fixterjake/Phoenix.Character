using System;
using CitizenFX.Core;

namespace Phoenix.Character.Server
{
    public class Server : BaseScript
    {
        public Server()
        {
            EventHandlers["playerConnecting"] += new Action<Player, string, dynamic, dynamic>(HandleCharacterSelection);
        }

        public void HandleCharacterSelection([FromSource] Player source, string playerName, dynamic denyWithReason,
            dynamic deferrals)
        {
        }
    }
}