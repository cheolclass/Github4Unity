using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalHandler : MonoBehaviour
{
    public Text successTxt;

    void Start()
    {
        if (successTxt != null)
        {
            successTxt.gameObject.SetActive(false);
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// if (collision != null && collision.collider.CompareTag("Star Item"))  // ref.
        if (collision.CompareTag("Player"))
            successTxt?.gameObject.SetActive(true);
    }

}