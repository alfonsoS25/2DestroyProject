using UnityEngine;

//this script generates an explosion of the indicated particle effect by giving an int 
public class ButtonSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject[] particles;

    [SerializeField]
    private Transform Root;

    public void GenerateParticle(int particleNum)
    {
        Vector3 ExplosionPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var Clone = Instantiate(particles[particleNum], ExplosionPos, Quaternion.identity, Root);
        Clone.transform.position = ExplosionPos;
        Destroy(Clone, 3);
    }
}