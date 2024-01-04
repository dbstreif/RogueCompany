using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace Lethalhack
{

    public partial class GameHackMethods
    {
        //Init Classes
        private ItemCharger itemCharger;
        private EnemyAI enemyAI;
        private EntranceTeleport entranceTeleport;
        private FlashlightItem flashlightItem;

        //Private Vars
        private bool nightvisioncheck = false;

        //Public Vars

        //Self hacks here
        public void Suicide()
        {
            if (ControlPlayer.Localplayer != null)
            {
                ControlPlayer.Localplayer.DamagePlayer(100);
            }
        }

        public void Heal()
        {
            if (ControlPlayer.Localplayer != null)
            {
                HUDManager.Instance.UpdateHealthUI(100);

                if (ControlPlayer.Localplayer.IsServer)
                {
                    ControlPlayer.Localplayer.DamagePlayerClientRpc(0, 100);
                }
                else
                {
                    ControlPlayer.Localplayer.DamagePlayerServerRpc(0, 100);
                }
            }
        }

        public void InfiniteBattery()
        {
            if (itemCharger == null)
            {
                itemCharger = GameObject.FindObjectOfType<ItemCharger>();
            }
            if (itemCharger != null)
            {
                GrabbableObject currentlyHeldObjectServer = GameNetworkManager.Instance.localPlayerController.currentlyHeldObjectServer;
                if (currentlyHeldObjectServer == null)
                {
                    return;
                }
                if (!currentlyHeldObjectServer.itemProperties.requiresBattery)
                {
                    return;
                }
                if (currentlyHeldObjectServer.insertedBattery.charge != 1f)
                {
                    currentlyHeldObjectServer.insertedBattery = new Battery(false, 1f);
                    currentlyHeldObjectServer.SyncBatteryServerRpc(100);
                }
            }
        }

        public void StaminaHack()
        {
            if (ControlPlayer.Localplayer != null && ControlPlayer.Localplayer.sprintMeter != 1f)
            {
                ControlPlayer.Localplayer.sprintMeter = 1f;
                ControlPlayer.Localplayer.isExhausted = false;
            }
        }

        public void ForceField()
        {
            if (enemyAI == null)
            {
                enemyAI = GameObject.FindObjectOfType<EnemyAI>();
            }
            if (enemyAI != null)
            {
                enemyAI.SetEnemyStunned(true);
            }
        }

        public void EntranceTeleport()
        {
            if (entranceTeleport == null)
            {
                entranceTeleport = GameObject.FindObjectOfType<EntranceTeleport>();
            }
            if (entranceTeleport != null)
            {
                entranceTeleport.TeleportPlayer();
            }
        }

        public void ShipTeleport()
        {
            if (entranceTeleport == null)
            {
                entranceTeleport = GameObject.FindObjectOfType<EntranceTeleport>();
            }

            if (ControlPlayer.Localplayer != null)
            {
                Console.WriteLine(StartOfRound.Instance.playerSpawnPositions[0].position);
                ControlPlayer.Localplayer.TeleportPlayer(StartOfRound.Instance.playerSpawnPositions[0].position);
                entranceTeleport.TeleportPlayerServerRpc((int)ControlPlayer.Localplayer.playerClientId);
            }
        }

        public Vector3 SaveTeleportPos()
        {
            if (ControlPlayer.Localplayer != null)
            {
                Vector3 position = ControlPlayer.Localplayer.oldPlayerPosition;
                return position;
            }
            else
            {
                return Vector3.zero;
            }
        }

        public void LocationTeleport(Vector3 position)
        {
            if (entranceTeleport == null)
            {
                entranceTeleport = GameObject.FindObjectOfType<EntranceTeleport>();
            }

            if (ControlPlayer.Localplayer != null && entranceTeleport != null)
            {
                ControlPlayer.Localplayer.TeleportPlayer(position, false, 0f, false, true);
                entranceTeleport.TeleportPlayerServerRpc((int)ControlPlayer.Localplayer.playerClientId);
            }
        }
        
        public void SpeedHack(float speed)
        {
            if (ControlPlayer.Localplayer != null)
            {
                ControlPlayer.Localplayer.movementSpeed = speed;
            }
        }

        //add grabbing through walls as part of it
        public void GrabDistancehack(bool toggled)
        {
            if (ControlPlayer.Localplayer != null)
            {
                if (toggled && ControlPlayer.Localplayer.grabDistance != 300f)
                {
                    Console.WriteLine("Setting High Grab Distance");
                    ControlPlayer.Localplayer.grabDistance = 300f;
                }
                else if (toggled == false && ControlPlayer.Localplayer.grabDistance != 5f)
                {
                    Console.WriteLine("Turning Off High Grab Distance");
                    ControlPlayer.Localplayer.grabDistance = 5f;
                }
            }
        }

        //need to develop
        public void FlyHack()
        {
            if (ControlPlayer.Localplayer != null)
            {
                
            }
            
        }

        //needs fixing
        public void NightVision(bool nightvision)
        {
            if (flashlightItem == null)
            {
                flashlightItem = GameObject.FindObjectOfType<FlashlightItem>();
            }

            if (flashlightItem != null)
            {
                if (nightvision == true && nightvisioncheck == false)
                {
                    Console.WriteLine("Brightening the Day");
                    flashlightItem.flashlightBulb.enabled = true;
                    flashlightItem.flashlightBulbGlow.enabled = true;
                    flashlightItem.playerHeldBy.helmetLight.enabled = true;
                    nightvisioncheck = true;
                }
                else if (nightvision == false && nightvisioncheck == true)
                {
                    Console.WriteLine("Changing Brightness Back");
                    flashlightItem.flashlightBulb.enabled = false;
                    flashlightItem.flashlightBulbGlow.enabled = false;
                    flashlightItem.playerHeldBy.helmetLight.enabled = false;
                    nightvisioncheck = false;
                }
            }
        }


    }
}
