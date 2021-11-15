using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject Dia;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player")
        {
            Dia.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dia.SetActive(false);
        }
    }
}
