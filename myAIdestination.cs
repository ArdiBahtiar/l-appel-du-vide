using UnityEngine;
using System.Collections;

namespace Pathfinding {
	
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	
	
	[UniqueComponent(tag = "ai.destination")]
	//[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class myAIdestination : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		Transform target;
		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () 
		{
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			ai.destination = target.position;
		}
	}
}
