using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour {

    Player Player;


    private void Awake()
    {
        Player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update () {
        if (Player != null)
        {
            UpdateCameraPosition();
        }        
    }

    void UpdateCameraPosition()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3(Player.transform.position.x , Player.transform.position.y + 10f, Player.transform.position.z - 30f),
            Time.deltaTime * 10f);
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
             float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
