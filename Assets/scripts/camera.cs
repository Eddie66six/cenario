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
        if (CurrentPositionPlayerX > Player.position.x) return;
        if (Math.Abs(MaxPosition.position.x - Player.position.x) <= 0.1 || Math.Abs(MinPosition.position.x - Player.position.x) >= 1)
        {
            CurrentPositionPlayerX = Player.position.x;
            transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
        }
    }
}
