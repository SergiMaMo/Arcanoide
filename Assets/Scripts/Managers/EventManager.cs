using UnityEngine.Events;

public class EventManager
{
    public UnityEvent<int> OnPuntosCambiados = new UnityEvent<int>();
    public UnityEvent<int> OnVidaCambiada = new UnityEvent<int>();
}
