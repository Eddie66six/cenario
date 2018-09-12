using System;
using UnityEngine;

public class camera : MonoBehaviour {
    public Transform MaxPosition;
    public Transform MinPosition;
    public Transform Player;
    private Vector3 Offset;

    private float CurrentPositionPlayerX;
    // Use this for initialization
    void Start () {
        Offset = transform.position - Player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate() {
        if (Player.position.x < MaxPosition.position.x && Player.position.x > MinPosition.position.x) return;
        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
    }
}
