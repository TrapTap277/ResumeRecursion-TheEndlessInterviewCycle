using _Scripts.Bug;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Slider slider;

        [SerializeField] private TextMeshProUGUI bugText;
        
        public override void InstallBindings()
        {
            Container.Bind<TextMeshProUGUI>().FromInstance(bugText);
            Container.Bind<Slider>().FromInstance(slider);
            Container.BindInterfacesAndSelfTo<BugCounterUI>().AsSingle();
            Container.Bind<FixBugUI>().AsSingle();
        }
    }
}