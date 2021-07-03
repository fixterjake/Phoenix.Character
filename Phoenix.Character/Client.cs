using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Phoenix.Character
{
    public class Client : BaseScript
    {
        private readonly int _cam;
        private bool _hideHud;

        public Client()
        {
            API.RegisterNuiCallbackType("phoenix-character-spawn");
            EventHandlers["playerSpawned"] += new Action(HandleCharacterSpawn);
            EventHandlers["__cfx_nui:phoenix-character-spawn"] +=
                new Action<IDictionary<string, object>, CallbackDelegate>(HandleSpawn);
            _cam = CreateCam();

            API.RegisterCommand("spawn", new Action(HandleCharacterSpawn), false);
            Tick += HideHud;
        }

        public async void HandleCharacterSpawn()
        {
            var player = Game.Player;
            // todo if character exists set the ped

            // Teleport player
            API.StartPlayerTeleport(player.Handle, -213.6f, -1039.51f, 29f, 69.8f, false, false, false);

            // Set default ped
            var model = (uint) API.GetHashKey("a_m_m_bevhills_02");
            API.RequestModel(model);
            while (!API.HasModelLoaded(model))
                await Delay(0);
            API.SetPlayerModel(player.Handle, model);

            API.AttachCamToEntity(_cam, API.GetPlayerPed(-1), 0f, 2.5f, 0.8f, true);
            API.PointCamAtEntity(_cam, API.GetPlayerPed(-1), 0.0f, 0.0f, 0.0f, true);
            API.SetCamFov(_cam, 70f);
            API.RenderScriptCams(true, false, 0, true, false);

            _hideHud = true;
            API.SendNuiMessage("{\"type\":\"show-character\"}");
            API.SetNuiFocus(true, true);
        }

        public int CreateCam()
        {
            return API.CreateCam("DEFAULT_SCRIPTED_CAMERA", true);
        }

        private void HandleSpawn(IDictionary<string, object> data, CallbackDelegate result)
        {
            API.SendNuiMessage("{\"type\":\"hide-character\"}");
            API.SetNuiFocus(false, false);
            API.RenderScriptCams(false, false, 1, true, false);
            API.DestroyCam(_cam, false);
            API.FreezeEntityPosition(API.GetPlayerPed(-1), false);
            API.StartPlayerTeleport(Game.Player.Handle, -213.6f, -1039.51f, 29f, 69.8f, false, true, false);
            _hideHud = false;
            result("Character Loaded");
        }


        public Task HideHud()
        {
            if (!_hideHud) return Task.FromResult(0);
            API.HideHudAndRadarThisFrame();
            API.DisableControlAction(0, 30, true);
            API.DisableControlAction(0, 31, true);
            API.DisableControlAction(0, 32, true);
            API.DisableControlAction(0, 33, true);
            API.DisableControlAction(0, 34, true);
            API.DisableControlAction(0, 35, true);
            API.DisableControlAction(0, 36, true);
            API.DisableControlAction(0, 44, true);
            API.DisableControlAction(0, 142, true);
            API.DisableControlAction(0, 157, true);
            API.DisableControlAction(0, 158, true);
            API.DisableControlAction(0, 159, true);
            API.DisableControlAction(0, 160, true);
            API.DisableControlAction(0, 161, true);
            API.DisableControlAction(0, 162, true);
            API.DisableControlAction(0, 163, true);
            API.DisableControlAction(0, 164, true);
            API.DisableControlAction(0, 165, true);
            API.DisableControlAction(0, 172, true);
            API.DisableControlAction(0, 173, true);
            API.DisableControlAction(0, 210, true);
            API.DisableControlAction(0, 232, true);
            API.DisableControlAction(0, 233, true);
            API.DisableControlAction(0, 234, true);
            API.DisableControlAction(0, 235, true);
            API.DisableControlAction(0, 236, true);
            API.DisableControlAction(0, 257, true);
            API.DisableControlAction(0, 263, true);
            API.DisableControlAction(0, 264, true);
            API.DisableControlAction(0, 270, true);
            API.DisableControlAction(0, 271, true);
            API.DisableControlAction(0, 272, true);
            API.DisableControlAction(0, 273, true);
            return Task.FromResult(0);
        }
    }
}