using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject pickUp;
    private GameObject currentPickUp;
    bool isRespawning;

    public bool isActivated;
    // Start is called before the first frame update
    void Start()
    {
        ApparaitreComestible();
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentPickUp.activeSelf && !isRespawning)
        {
            StartCoroutine(RespawnPickUp());
        }

    }
    void ApparaitreComestible()
    {
        currentPickUp = Instantiate(pickUp, transform.position, pickUp.transform.rotation);
        currentPickUp.transform.parent = this.transform;
        currentPickUp.GetComponent<PickUp>().ChangeState(isActivated);
    }

    IEnumerator RespawnPickUp()
    {
        isRespawning = true;
        yield return new WaitForSeconds(3.0f);
        currentPickUp.SetActive(true);
        isRespawning = false;
    }


    public void ToggleState()
    {
        isActivated = !isActivated;
        if (currentPickUp.activeSelf)
            currentPickUp.GetComponent<PickUp>().ChangeState(isActivated);
    }

}
