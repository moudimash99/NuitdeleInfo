using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using UnityEngine.Rendering;

namespace Platformer.Gameplay
{
    public class PlayerCondomCollision : Simulation.Event<PlayerCondomCollision>
    {
        public PlayerController player;
        public TokenInstance token;
        
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            player.ActivateCondom();
            //AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
            token.gameObject.SetActive(false);
        }
    }
    
}