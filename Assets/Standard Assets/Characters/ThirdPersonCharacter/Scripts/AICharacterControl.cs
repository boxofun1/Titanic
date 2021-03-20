using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public int targetRank;                                      // Used to know what target to follow

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

            targetRank = 1;
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if (gameObject.name == "npc_path")
			{
                target = GameObject.Find("target" + targetRank).transform;
                if(Vector3.Distance(transform.position, target.transform.position) < 1.0)
				{
                    targetRank++;
                    if (targetRank > 4) targetRank = 1;
                    target = GameObject.Find("target" + targetRank).transform;
                }
                print("Current Target is target" + targetRank);
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
