using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

		public float followDistance = 10.0f;

		public AudioSource audioSource;
		public AudioClip zombieGrowlClip;
		public AudioClip zombieStopClip;

		private bool hasGrowled = false;

		void Awake() {
			audioSource = gameObject.GetComponent<AudioSource>();
		}

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
			if(target == null)
				return;
			
			float distanceToTarget = Vector3.Distance(gameObject.transform.position, target.transform.position);

			// Determine Target
			if (target != null)
				agent.SetDestination(target.position);

			if (agent.remainingDistance > agent.stoppingDistance)
				character.Move(agent.desiredVelocity, false, false);
			else
				character.Move(Vector3.zero, false, false);	

			// Determine Distance
			if (Mathf.Abs(distanceToTarget) < followDistance) {
				agent.Resume();

				if(!hasGrowled) {

					audioSource.clip = zombieGrowlClip;
					audioSource.Play();

					//AudioSource.PlayClipAtPoint(zombieGrowlClip, target.transform.position);
					hasGrowled = true;
				}
					

			}
			else {
				agent.Stop();
				hasGrowled = false;
			}				
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

		void OnTriggerEnter(Collider other) {
			if(other.tag.Equals("Player")) {				
				agent.Stop();
			}
		}
			
    }
}
