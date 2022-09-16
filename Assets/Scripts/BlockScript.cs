using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask Blocke;

    [SerializeField]
    private float breakableStreng;
    [SerializeField]
    private float breakForce;
    [SerializeField]
    private float breakForceCollision;


    private Rigidbody2D rig;

    private ParticleManager particlemann;

    [SerializeField]
    private PointManager pointM;

    bool IsDestroyed = false;

    [SerializeField]
    private int BlockClass;

    // Start is called before the first frame update
    void Start()
    {
        pointM = GameObject.FindGameObjectWithTag("PointCounter").GetComponent<PointManager>();
        particlemann = GameObject.FindGameObjectWithTag("ParticleManager").GetComponent<ParticleManager>();
        rig = GetComponent<Rigidbody2D>();

        Vector3 offset = new Vector2(0, 0.5f);

        //checks the 4 directions for blocks to chain

        RaycastHit2D hit = Physics2D.Raycast(transform.position+(new Vector3 (0,transform.localScale.y,0)), Vector2.up, 0.1f, Blocke);    
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + (new Vector3(0,-transform.localScale.y,0)), Vector2.down, 0.1f, Blocke);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position+(new Vector3(-transform.localScale.x,0,0)), Vector2.left, 0.1f, Blocke);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position + new Vector3(transform.localScale.x,0,0), Vector2.right, 0.1f, Blocke);
        if (hit)
        {   //if hits an block with the ray, creates an connection to the detected block
            HingeJoint2D distanceJoint2d = gameObject.AddComponent<HingeJoint2D>();
            distanceJoint2d.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            distanceJoint2d.enableCollision = true;
            distanceJoint2d.breakForce = breakableStreng;
        }
        if (hit2)
        {

            HingeJoint2D distanceJoint2d2 = gameObject.AddComponent<HingeJoint2D>();
            distanceJoint2d2.connectedBody = hit2.collider.gameObject.GetComponent<Rigidbody2D>();
            distanceJoint2d2.enableCollision = true;
            distanceJoint2d2.breakForce = breakableStreng;
        }
        if (hit3)
        {

            HingeJoint2D distanceJoint2d = gameObject.AddComponent<HingeJoint2D>();
            distanceJoint2d.connectedBody = hit3.collider.gameObject.GetComponent<Rigidbody2D>();
            distanceJoint2d.enableCollision = true;
            distanceJoint2d.breakForce = breakableStreng;
        }
        if (hit4)
        {                                                                                                                                         // hit4.collider.gameObject.transform.position;// + offset;
            HingeJoint2D distanceJoint2d = gameObject.AddComponent<HingeJoint2D>();
            distanceJoint2d.connectedBody = hit4.collider.gameObject.GetComponent<Rigidbody2D>();
            distanceJoint2d.enableCollision = true;
            distanceJoint2d.breakForce = breakableStreng;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rig.velocity.x > breakForce || rig.velocity.x < -breakForce||rig.velocity.y > breakForce || rig.velocity.y < -breakForce )
        {
            DestroyIntoBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DemolitionBall"))
        {
            DestroyIntoBlocks();
        }
        if(collision.gameObject.CompareTag("Block") && rig.velocity.x> breakForceCollision ||
            collision.gameObject.CompareTag("Block") && rig.velocity.y> breakForceCollision ||
            collision.gameObject.CompareTag("Block") && rig.velocity.y<-breakForceCollision ||
            collision.gameObject.CompareTag("Block") && rig.velocity.x<-breakForceCollision)
        {
            collision.gameObject.GetComponent<BlockScript>().DestroyIntoBlocks();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drill"))
        {
            destroyInstantly();
        }
    }
    public void destroyInstantly()
    {
        if (!IsDestroyed)
        {
            IsDestroyed = true;
            pointM.SumPoints(100);
            Destroy(this.gameObject);
        }
    }

        public void DestroyIntoBlocks()
    {
        if (!IsDestroyed)
        {
            for (int i = 0; i < 3; i++)
            {
                var thisSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
                GameObject BrokenBlock = particlemann.GetPooledObject();
                if (BrokenBlock != null)
                {
                    BrokenBlock.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<SpriteRenderer>().color;
                    BrokenBlock.GetComponent<SpriteRenderer>().sprite = particlemann.SelectBlockSprite(BlockClass);
                    BrokenBlock.transform.position = transform.position;
                    BrokenBlock.transform.rotation = BrokenBlock.transform.rotation;
                    BrokenBlock.SetActive(true);
                    var RigAttach =BrokenBlock.GetComponent<Rigidbody2D>();
                    RigAttach.velocity = rig.velocity;
                    RigAttach.angularDrag = rig.angularVelocity;
                }
            }
            pointM.SumPoints(100);
            Destroy(this.gameObject);
            IsDestroyed = true;
        }
    }
}
