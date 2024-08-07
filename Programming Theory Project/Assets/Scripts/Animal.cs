using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{

    public string[] sounds { get; protected set; }
    public float jumpForce { get; protected set; }

    private Rigidbody myRb;
    [SerializeField] protected bool isOnAir;
    protected bool showBubble;
    protected Canvas speechBubbleCanvas;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
        speechBubbleCanvas = transform.Find("Speech Bubble Canvas").GetComponent<Canvas>();
    }

    public virtual void Talk()
    {
        ShowBubble(true);
        string sound = GetRandomSound();
        speechBubbleCanvas.transform.Find("Sound Text").GetComponent<TextMeshProUGUI>().text = sound;
        StartCoroutine(CloseBubble());
    }

    protected IEnumerator CloseBubble()
    {
        yield return new WaitForSeconds(2);
        ShowBubble(false);
    }

    private string GetRandomSound()
    {
        return sounds[Random.Range(0, sounds.Length)];
    }

    public void Jump()
    {
        if (!isOnAir)
        {
            myRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnAir = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Floor":
            default:
                isOnAir = false;
                break;

        }
    }

    protected void ShowBubble(bool show)
    {
        speechBubbleCanvas.gameObject.SetActive(show);
    }
}
