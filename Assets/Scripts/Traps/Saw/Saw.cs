using Actors.Player.Health;
using UnityEngine;

namespace Traps.Saw
{
    public class Saw : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float sawSpeed;
        [SerializeField] private float changeDirectionTime;
        [SerializeField] private Directions startDirection;

        [Header("References")]
        [SerializeField] private Animator sawAnimator;

        [Header("Status")]
        [SerializeField] private Directions currentDirection;
        [SerializeField] private bool isOn;
        [SerializeField] private float counter;

        public enum Directions { Right, Left}
        public bool IsOn { get => isOn; set => isOn = value; }

        private void Start()
        {
            currentDirection = startDirection;
        }

        private void Update()
        {
            sawAnimator.SetBool("isOn", IsOn);
            counter += Time.deltaTime;

            if (counter >= changeDirectionTime)
            {
                if (currentDirection == Directions.Left) currentDirection = Directions.Right;
                else currentDirection = Directions.Left;
                counter = 0;
            }

            switch (currentDirection)
            {
                case Directions.Right:
                    transform.position += sawSpeed * Time.deltaTime * Vector3.right;
                    break;
                case Directions.Left:
                    transform.position += sawSpeed * Time.deltaTime * Vector3.left;
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().TakeDamage(1);
            }
        }
    }
}