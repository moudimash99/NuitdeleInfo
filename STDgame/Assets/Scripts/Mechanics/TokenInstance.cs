using System;
using System.Security.Cryptography;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Random = UnityEngine.Random;


namespace Platformer.Mechanics
{
    /// <summary>
    /// This class contains the data required for implementing token collection mechanics.
    /// It does not perform animation of the token, this is handled in a batch by the 
    /// TokenController in the scene.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class TokenInstance : MonoBehaviour
    {
        public enum PowerUpType
        {
            CONDOM,
            STD_TEST
        }
        public AudioClip tokenCollectAudio;
        [Tooltip("If true, animation will start at a random position in the sequence.")]
        public bool randomAnimationStartTime = false;
        [Tooltip("List of frames that make up the animation.")]
        public Sprite[] idleAnimation, collectedAnimation;

        internal Sprite[] sprites = new Sprite[0];

        internal SpriteRenderer _renderer;

        //unique index which is assigned by the TokenController in a scene.
        internal int tokenIndex = -1;
        internal TokenController controller;
        //active frame in animation, updated by the controller.
        internal int frame = 0;
        internal bool collected = false;

        public PowerUpType powerUpType = PowerUpType.CONDOM;

        public Sprite CondomSprite;
        public Sprite StdSprite;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (randomAnimationStartTime)
                frame = Random.Range(0, sprites.Length);
            sprites = idleAnimation;
        }

        void Start()
        {
            if (this.powerUpType == PowerUpType.CONDOM)
            {
                this._renderer.sprite = CondomSprite;
            }else if (this.powerUpType == PowerUpType.STD_TEST)
            {
                this._renderer.sprite = StdSprite;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null) OnPlayerEnter(player);
        }

        void OnPlayerEnter(PlayerController player)
        {
            if (collected) return;
            //disable the gameObject and remove it from the controller update list.
            frame = 0;
            sprites = collectedAnimation;
            if (controller != null)
                collected = true;
            //send an event into the gameplay system to perform some behaviour.
            if (powerUpType == PowerUpType.CONDOM)
            {
                var ev = Schedule<PlayerCondomCollision>();
                ev.token = this;
                ev.player = player;
            } else if (powerUpType == PowerUpType.STD_TEST)
            {
                var ev = Schedule<PlayerStdTestCollision>();
                ev.token = this;
                ev.player = player;
            }
        }
    }
}