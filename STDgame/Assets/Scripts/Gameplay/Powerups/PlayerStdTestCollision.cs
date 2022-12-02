using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using UnityEngine.Rendering;

namespace Platformer.Gameplay
{
    public class PlayerStdTestCollision : Simulation.Event<PlayerStdTestCollision>
    {
        public PlayerController player;
        public TokenInstance token;
        
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            player.ActivateStdTest();
            //AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
            GameObject.Destroy(token.gameObject);
        }
    }
    
}