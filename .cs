using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("MonoTest", "NoSharp", "0.1.0", ResourceId = 0)]
    class MonoTest : RustPlugin
    {

        [ChatCommand("chickenC4")]
        private void cmdChatTeleport(BasePlayer player, string command, string[] args)
        {

            var chicken = GameManager.server.CreateEntity("assets/rust.ai/agents/chicken/chicken.prefab", player.transform.position);
            chicken.Spawn();
            var controller = chicken.gameObject.AddComponent<Chickenc4>();
            
            controller.TeleportChicken(player);

        }

        private class Chickenc4 : MonoBehaviour
        {
            private Chicken chicken;
            private TimedExplosive c4;

            public BasePlayer target;

            private void Awake()
            {
                
                chicken = GetComponent<Chicken>();
                
                

                
            }

            public void TeleportChicken(BasePlayer target) {
                var c4Prefab = GameManager.server.CreateEntity("assets/prefabs/tools/c4/explosive.timed.deployed.prefab", chicken.transform.position);
                
                c4Prefab.Spawn();
                c4Prefab.SetParent(chicken);
                
                c4Prefab.transform.localPosition = new Vector3(0.1f, 0.1f, 0.1f);
                c4Prefab.transform.localRotation = Quaternion.Euler(0.3f, 0.3f, 0.1f);
            }
        }
    }
}
