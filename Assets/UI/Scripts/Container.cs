using UnityEngine;
using UnityEngine.Rendering;

public class Container : MonoBehaviour
{
    [SerializeField] private Health[] heartBar;
    [SerializeField] private LifeControllerPlayer lifePlayer;
    private void Start()
    {
        lifePlayer = FindFirstObjectByType<LifeControllerPlayer>();

        lifePlayer.damagePlayer += ActivateHearts;
        lifePlayer.healPlayer += ActivateHearts;

        ActivateHearts(lifePlayer.GetCurrentHealth());

    }
    private void OnDisable()
    {
        lifePlayer.damagePlayer -= ActivateHearts;
        lifePlayer.healPlayer -= ActivateHearts;
    }
    private void ActivateHearts(int currencurrentHealth)
    {
        for (int i = 0; i < heartBar.Length; i++)
        {
            if (i < currencurrentHealth)
            {
                heartBar[i].ActiveHealth();

            }
            else
            {
                heartBar[i].DeactiveHealth();
            }
        }

    }
}
