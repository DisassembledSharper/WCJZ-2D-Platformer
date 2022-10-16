using Actors.Player.Jump;
using Actors.Player.Movement;
using System.Collections;
using UnityEngine;

namespace Actors.Player.Effects
{
    public class PlayerEffects : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float appearingDuration;
        [SerializeField] private float desappearingDuration;

        [Header("References")]
        [SerializeField] private PlayerJump playerJump;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private GameObject appearingObject;
        [SerializeField] private GameObject desappearingObject;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Start()
        {
            StartCoroutine(Appear());
        }
        public IEnumerator Appear()
        {
            yield return new WaitForSeconds(0.5f);
            spriteRenderer.enabled = false;
            appearingObject.SetActive(true);
            playerMovement.FreezeInput = true;
            playerJump.FreezeInput = true;
            yield return new WaitForSeconds(appearingDuration);
            playerMovement.FreezeInput = false;
            playerJump.FreezeInput = false;
            spriteRenderer.enabled = true;
            appearingObject.SetActive(false);
        }

        public IEnumerator Desappear()
        {
            spriteRenderer.enabled = false;
            desappearingObject.SetActive(true);
            yield return new WaitForSeconds(desappearingDuration);
            gameObject.SetActive(false);
            desappearingObject.SetActive(false);
        }
    }
}