namespace Helab.Time
{
    public static class AppTime
    {
        public static float DeltaTime => IsPause ? 0f : UnityEngine.Time.deltaTime;
        
        public static bool IsPause { get; set; }
    }
}
