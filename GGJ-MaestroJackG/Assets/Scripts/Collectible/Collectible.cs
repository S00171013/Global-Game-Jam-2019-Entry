using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    Vector2 Startpos;

	void Start () {
        #region Attempt at animating collectibles independently of each other, using the same animation controller.
        // https://answers.unity.com/questions/400648/how-to-set-animators-controller-in-script.html https://forum.unity.com/threads/swapping-runtimeanimatorcontroller-during-runtime.368048/
        //collectiblePrefab = this.gameObject;

        //collectiblePrefab.AddComponent<Animator>(); // Add the Animator component.
        //collectibleAnimator = GetComponent<Animator>(); // Get our reference to this Animator component.

        // Get the prefab's Animator component and set its controller.
        //collectibleAnimator.runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("gameplay_collectible"));
        #endregion

        Startpos = transform.position;
    }

    void Update ()
    {
        transform.position = Startpos + new Vector2(0, Mathf.Sin(1 * Time.time) * 0.1f); // Bob up and down.
	}
}