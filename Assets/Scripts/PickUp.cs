using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Mesh formeComestible;
    public Rigidbody comestible;
    public GameObject spawnPoint;
    

    private void Start()
    {
        formeComestible = GetComponent<MeshFilter>().mesh;
        /**InstantiateComestible();**/
        /**InvokeRepeating("ApparaitreComestible", 0, 5.0f);**/
    }
    void Update()
    {
        transform.Rotate(new Vector3(50, 30, 45) * Time.deltaTime);
        ApparaitreComestible();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MeshFilter>().mesh = formeComestible;
        }
    }

    void ApparaitreComestible()
    {
        if (comestible != null)
        {
            transform.position = spawnPoint.transform.position;
            Rigidbody instance = Instantiate(comestible);
        }
    }
    /**void InstantiateComestible()
    {
        GameObject comestibleActuel = (GameObject)Instantiate(this.gameObject);
        comestibleActuel.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        StartCoroutine(WaitForInstantiateComestible());
    }
    IEnumerator WaitForInstantiateComestible()
    {
        yield return new WaitForSeconds(10.0f);
        InstantiateComestible();
    }**/
}

