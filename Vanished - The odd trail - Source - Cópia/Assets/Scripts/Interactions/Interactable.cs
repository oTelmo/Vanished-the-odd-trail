public interface IInteractable
{
    float MaxRange { get; }

    void OnStartInteraction();
    void OnInteraction();
    void OnEndInteraction();
}
