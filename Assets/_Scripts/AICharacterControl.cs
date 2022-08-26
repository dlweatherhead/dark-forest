using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson {
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour {
        
        public Transform target; // target to aim for
        public float followDistance = 10.0f;
        public AudioSource audioSource;
        public AudioClip zombieGrowlClip;

        private UnityEngine.AI.NavMeshAgent
            agent { get; set; } // the navmesh agent required for the path finding

        private ThirdPersonCharacter character { get; set; } // the character we are controlling
        private bool hasGrowled;

        void Awake() {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Start() {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void Update() {
            if (target == null)
                return;

            float distanceToTarget = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if (Mathf.Abs(distanceToTarget) < followDistance) {
                agent.Resume();

                if (!hasGrowled) {
                    audioSource.clip = zombieGrowlClip;
                    audioSource.Play();
                    hasGrowled = true;
                }
            }
            else {
                agent.Stop();
                hasGrowled = false;
            }
        }

        void OnTriggerEnter(Collider other) {
            if (other.tag.Equals("Player"))
                agent.Stop();
        }
    }
}