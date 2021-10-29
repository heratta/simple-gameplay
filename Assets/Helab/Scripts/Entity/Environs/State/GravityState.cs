namespace Helab.Entity.Environs.State
{
    public class GravityState : AbstractState
    {
        public bool isGrounded;

        public override void ResetState()
        {
            isGrounded = false;
        }
    }
}
