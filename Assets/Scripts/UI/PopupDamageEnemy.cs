using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDamageEnemy : MonoBehaviour {
    public Text damageText;

    void OnEnable () {
        damageText = gameObject.GetComponent<Text> ();
        StartCoroutine (timeToDestroy ());
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3 (transform.position.x, transform.position.y + (2 * Time.deltaTime), transform.position.z);
        var dcolor = damageText.color;
        dcolor.a -= 0.02f;
        damageText.color = dcolor;
    }

    public void SetDamage (float damage) {
        damageText.text = damage.ToString ();
    }

    IEnumerator timeToDestroy () {
        yield return new WaitForSeconds (1);
        Destroy (gameObject);
    }
}