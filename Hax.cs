using HarmonyLib;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Lethalhack
{
    public class Hax : MonoBehaviour
    {
        //Init Classes
        private GameUI gameUI = new GameUI();
        private GameHackMethods gameHacks = new GameHackMethods();


        //Init Game Hack Vars
        private bool gui_on = false;
        private Vector3 TeleportPos = Vector3.zero;


        public void Start()
        {
            //Do stuff here once for initialization
            AllocConsoleHandler.Open();
            Console.WriteLine("Console Initialized");
        }
        public void Update()
        {
            //Do stuff here on every tick
            //GUI Toggle
            if (Keyboard.current[Key.Insert].wasPressedThisFrame)
            {
                if (!gui_on)
                {
                    gui_on = true;
                }
                else
                {
                    gui_on = false;
                }
            }

            //Toggle Hacks
            if (gameUI.godModeState == true)
            {
                gameHacks.Heal();
            }

            if (gameUI.batteryState == true)
            {
                gameHacks.InfiniteBattery();
            }

            if (gameUI.staminaState == true)
            {
                gameHacks.StaminaHack();
            }

            if (gameUI.enemyStunState == true)
            {
                gameHacks.ForceField();
            }

            if (gameUI.nightVisionState == true)
            {
                gameHacks.NightVision(gameUI.nightVisionState);
            }

            /*if (gameUI.nightVisionState == false)
            {
                gameHacks.NightVision(gameUI.nightVisionState);
            }*/

            if (gameUI.longGrabState == true)
            {
                gameHacks.GrabDistancehack(true);
            }
            else
            {
                gameHacks.GrabDistancehack(false);
            }

            //Button Hacks
            if (gameUI.suicideButtonState == true)
            {
                gameHacks.Suicide();
                gameUI.suicideButtonState = false;
            }

            if (gameUI.healButtonState == true)
            {
                gameHacks.Heal();
                gameUI.healButtonState = false;
            }

            if (gameUI.teleportPosSaveButtonState == true)
            {
                TeleportPos = gameHacks.SaveTeleportPos();
                gameUI.teleportPosSaveButtonState = false;
            }

            if (gameUI.teleportButtonState == true)
            {
                gameHacks.LocationTeleport(TeleportPos);
                gameUI.teleportButtonState = false;
            }

            if (gameUI.teleportEntranceButtonState == true)
            {
                gameHacks.EntranceTeleport();
                gameUI.teleportEntranceButtonState = false;
            }

            if (gameUI.teleportShipButtonState == true)
            {
                gameHacks.ShipTeleport();
                gameUI.teleportShipButtonState = false;
            }

            if (gameUI.speedButtonState == true)
            {
                gameHacks.SpeedHack(gameUI.SpeedSlider);
                gameUI.speedButtonState = false;
            }
            

            //Keybinds
            if (Keyboard.current[Key.Numpad7].wasPressedThisFrame)
            {
                gameHacks.EntranceTeleport();
            }

            if (Keyboard.current[Key.Numpad8].wasPressedThisFrame)
            {
                gameHacks.ShipTeleport();
            }

            if (Keyboard.current[Key.Numpad4].wasPressedThisFrame)
            {
                gameHacks.SaveTeleportPos();
            }

            if (Keyboard.current[Key.Numpad5].wasPressedThisFrame)
            {
                gameHacks.LocationTeleport(TeleportPos);
            }


            /*if (Keyboard.current[Key.Numpad9].wasPressedThisFrame)
            {
                if (ControlPlayer.Localplayer != null)
                {
                    if (ControlPlayer.Localplayer.movementSpeed == 4.6f)
                    {
                        ControlPlayer.Localplayer.movementSpeed = 15f;
                    }
                    else
                    {
                        ControlPlayer.Localplayer.movementSpeed = 4.6f;
                    }
                }

            }

            if (Keyboard.current[Key.Numpad8].wasPressedThisFrame)
            {
                if (shipLights == null)
                {
                    shipLights = FindObjectOfType<ShipLights>();
                }
                if (shipLights != null)
                {
                    shipLights.ToggleShipLights();
                }
            }



            if (Keyboard.current[Key.Numpad4].wasPressedThisFrame)
            {
                if (terminal == null)
                {
                    terminal = FindObjectOfType<Terminal>();
                }
                if (terminal != null)
                {
                    terminal.groupCredits += 1000;
                }
            }

            if (Keyboard.current[Key.Numpad5].wasPressedThisFrame)
            {
                if (terminal == null)
                {
                    terminal = FindObjectOfType<Terminal>();
                }
                if (terminal != null)
                {
                    terminal.BeginUsingTerminal();
                }

            }*/


            if (Keyboard.current[Key.Delete].wasPressedThisFrame)
            {
                Loader.Unload();
                AllocConsoleHandler.Close();
            }
        }

        public void OnGUI()
        {
           if (gui_on)
            {
                gameUI.UiToggle();
            }
        }
    }
}
