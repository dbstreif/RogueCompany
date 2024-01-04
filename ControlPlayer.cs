using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Lethalhack
{
    public static class ControlPlayer
    {
        
        public static PlayerControllerB Localplayer => GameNetworkManager.Instance?.localPlayerController ?? null;
        public static PlayerControllerB[] Players => StartOfRound.Instance?.allPlayerScripts ?? null;
        public static void HealPlayer(this PlayerControllerB player) => player.DamagePlayer(-100);

        public static void KillPlayer(this PlayerControllerB player) => player.DamagePlayer(100);
    }
}
