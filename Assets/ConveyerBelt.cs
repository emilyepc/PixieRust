using UnityEngine;

namespace nickmaltbie.ScrollingShader
{
    
    public class ConveyerBelt : MonoBehaviour
    {
        public waterwheel wheel;
        
        private int changedetect;

        public GameObject conveyormodel; //for animating conveyor

        private Material conveyormov;//this is to animate the conveyor
        

        public void Start()
        {
            changedetect = wheel.direction;
        }
        public enum BeltForceMode
        {
            Push,
            Pull
        }

        public enum RelativeDirection
        {
            Up,
            Down,
            Left,
            Right,
            Forward,
            Backward
        }

        
        [SerializeField]
        [Tooltip("Velocity of the conveyer belt.")]
        private float velocity;

        
        [SerializeField]
        [Tooltip("Local direction does this push objects.")]
        private RelativeDirection direction = RelativeDirection.Down;

        
        private BeltForceMode beltMode = BeltForceMode.Push;

        
        private Rigidbody body;

        
        private Vector3 pos;

        
        public void Awake()
        {
            this.body = GetComponent<Rigidbody>();
            pos = transform.position;
        }

        
        public void FixedUpdate()
        {
            if (changedetect != wheel.direction) { transform.Rotate(0, 180, 0); }
            changedetect = wheel.direction;
            if (wheel.on)
            {
                if (body != null && beltMode == BeltForceMode.Pull)
                {
                    Vector3 movement = velocity * GetDirection() * Time.fixedDeltaTime;
                    transform.position = pos - movement;
                    body.MovePosition(pos);
                }
                //conveyormov=conveyormodel.GetComponent<Material>(); cant find material???
                //conveyormov.mainTextureOffset = new Vector2(velocity / 10, 0);

            }
        }

        
        public void OnCollisionStay(Collision other)
        {
            if (wheel.on)
            {
                if (other.rigidbody != null && !other.rigidbody.isKinematic && beltMode == BeltForceMode.Push)
                {
                    Vector3 movement = velocity * GetDirection() * Time.deltaTime;
                    other.rigidbody.MovePosition(other.transform.position + movement);
                }
            }
        }

        
        public Vector3 GetDirection()
        {
            switch (this.direction)
            {
                case RelativeDirection.Up:
                    return transform.up;
                case RelativeDirection.Down:
                    return -transform.up;
                case RelativeDirection.Left:
                    return -transform.right;
                case RelativeDirection.Right:
                    return transform.right;
                case RelativeDirection.Forward:
                    return transform.forward;
                case RelativeDirection.Backward:
                    return -transform.forward;
            }
            return transform.forward;
        }
    }
}
