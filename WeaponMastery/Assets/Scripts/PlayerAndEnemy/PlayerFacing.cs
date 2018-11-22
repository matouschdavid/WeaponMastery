using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour {

    public Sprite[] PlayerSprites;
    public Transform WeaponPos;
    private float ratio;
    private SpriteRenderer spriteRenderer;

    void Start(){

        ratio = 360 / PlayerSprites.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Tab)) {

            Debug.Log(WeaponPos.rotation.z);
            Debug.Log(WeaponPos.rotation.eulerAngles.z);
        }
    }

	void FixedUpdate () {

        for (int i = PlayerSprites.Length - 1; i >= 0; i--) {
            if (WeaponPos.rotation.eulerAngles.z - ratio / 2 <= ratio * (i + 1)) {

                spriteRenderer.sprite = PlayerSprites[i];
            }
        }
		
	}
}
