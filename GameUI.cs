using UnityEngine;

namespace Lethalhack
{
    public class GameUI
    {
        private int toolbarInt = 0;
        private string[] toolbarStrings = {"Self Hacks", "ESP Hacks", "Player Menu", "Misc."};
        private Texture2D buttonTexture = null;
        private Texture2D boxTexture = null;

        //UI Variables
        //Toggle States
        public bool godModeState = false;
        public bool batteryState = false;
        public bool staminaState = false;
        public bool enemyStunState = false;
        public bool nightVisionState = false;
        public bool longGrabState = false;

        //Button States
        public bool suicideButtonState = false;
        public bool healButtonState = false;
        public bool teleportPosSaveButtonState = false;
        public bool teleportButtonState = false;
        public bool teleportEntranceButtonState = false;
        public bool teleportShipButtonState = false;
        public bool speedButtonState = false;

        //Slider Values
        public float SpeedSlider = 4.6f;

        public void UiToggle()
        {
            //box color
            GUI.skin.box.alignment = TextAnchor.UpperLeft;
            GUI.skin.box.fontSize = 15;
            if (boxTexture != null)
            {
                GameObject.Destroy(boxTexture);
            }
            boxTexture = MakeTex(2, 2, new Color(135f / 255f, 22f / 255f, 22f / 255f, 0.5f));
            GUI.skin.box.normal.background = boxTexture;
            GUI.Box(new Rect(30, 30, 800, 400), "Lethal Mod Menu");

            //button custom
            GUI.skin.button.normal.textColor = Color.white;
            if (buttonTexture != null )
            {
                GameObject.Destroy(buttonTexture);
            }
            buttonTexture = MakeTex(2, 2, new Color(51f / 255f, 3f / 255f, 5f / 255f));
            GUI.skin.button.normal.background = buttonTexture;

            //toolbar
            toolbarInt = GUI.Toolbar(new Rect(400, 40, 400, 25), toolbarInt, toolbarStrings);
            if (toolbarInt == 0)
            {
                //Labels
                GUI.Label(new Rect(50, 80, 200, 20), "Save Position - Numpad4");
                GUI.Label(new Rect(50, 100, 200, 20), "Position Teleport - Numpad5");
                GUI.Label(new Rect(50, 120, 200, 20), "Entrance Teleport - Numpad7");
                GUI.Label(new Rect(50, 140, 200, 20), "Ship Teleport - Numpad8");


                //Toggles
                godModeState = GUI.Toggle(new Rect(550, 80, 80, 20), godModeState, "GodMode");
                batteryState = GUI.Toggle(new Rect(550, 110, 110, 20), batteryState, "Infinite Battery");
                staminaState = GUI.Toggle(new Rect(550, 140, 110, 20), staminaState, "Infinite Stamina");
                enemyStunState = GUI.Toggle(new Rect(550, 170, 110, 20), enemyStunState, "Stun Forcefield");
                longGrabState = GUI.Toggle(new Rect(550, 200, 110, 20), longGrabState, "Long Grab");
                //nightVisionState = GUI.Toggle(new Rect(550, 200, 110, 20), nightVisionState, "Night Vision");

                //Sliders
                SpeedSlider = GUI.HorizontalSlider(new Rect(400, 80, 80, 20), SpeedSlider, 4.6f, 30f);
                
                //Buttons
                if (GUI.Button(new Rect(700, 80, 100, 25), "Suicide"))
                {
                    suicideButtonState = true;
                }

                if (GUI.Button(new Rect(700, 110, 100, 25), "Heal"))
                {
                    healButtonState = true;
                }

                if (GUI.Button(new Rect(700, 140, 100, 25), "Save Pos"))
                {
                    teleportPosSaveButtonState = true;
                }

                if (GUI.Button(new Rect(700, 170, 100, 25), "Teleport"))
                {
                    teleportButtonState = true;
                }

                if (GUI.Button(new Rect(700, 200, 100, 25), "To Entrance"))
                {
                    teleportEntranceButtonState = true;
                }

                if (GUI.Button(new Rect(700, 230, 100, 25), "To Ship"))
                {
                    teleportShipButtonState = true;
                }

                if (GUI.Button(new Rect(400, 100, 100, 25), "Set Speed"))
                {
                    speedButtonState = true;
                }

            }
            else if (toolbarInt == 1)
            {
                GUI.Button(new Rect(100, 80, 80, 20), "Example2");
            }
            else if (toolbarInt == 2)
            {
                GUI.Button(new Rect(100, 80, 80, 20), "Example3");
            }

            else if (toolbarInt == 3)
            {
                GUI.Button(new Rect(100, 80, 80, 20), "Example4");
            }
        }

        private Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = col;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}
