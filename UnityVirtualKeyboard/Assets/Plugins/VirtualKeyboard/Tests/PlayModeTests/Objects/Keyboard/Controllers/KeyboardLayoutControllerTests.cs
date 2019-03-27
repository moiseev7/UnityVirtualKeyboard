using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using UnityEngine.TestTools;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Controllers.LayoutController;
using VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Tests for <see cref="KeyboardLayoutController"/>
    /// </summary>
    public class KeyboardLayoutControllerTests : ZenjectIntegrationTestFixture
    {
        private KeyboardLayoutController _target;
        private IInputFieldSelectionManager _fieldSelectionManager;
        private ILayoutManager _layoutManager;
        private Subject<bool> _selectedSubject;

        [SetUp]
        public void BeforeEveryTest()
        {
            _fieldSelectionManager = Substitute.For<IInputFieldSelectionManager>();
            _selectedSubject = new Subject<bool>();
            _fieldSelectionManager.IsFieldSelectedAsObservable.Returns(_selectedSubject);

            _layoutManager = Substitute.For<ILayoutManager>();
            

            PreInstall();
            Container.Bind<IInputFieldSelectionManager>().FromInstance(_fieldSelectionManager).AsSingle();
            Container.Bind<ILayoutManager>().FromInstance(_layoutManager).AsSingle();
            Container.BindInterfacesAndSelfTo<KeyboardLayoutController>().FromNew().AsSingle();
            PostInstall();
            _target = Container.Resolve<KeyboardLayoutController>();
        }

        [UnityTest]
        public IEnumerator Sends_SetState_On_Field_Selection()
        {
            _selectedSubject.OnNext(true);
            yield return null;
            _layoutManager.Received(1).SetState(Arg.Any<LayoutManagerState>());
        }

        [UnityTest]
        public IEnumerator Sends_2_SetState_On_2_Field_Selection()
        {
            _selectedSubject.OnNext(true);
            _selectedSubject.OnNext(true);
            yield return null;
            _layoutManager.Received(2).SetState(Arg.Any<LayoutManagerState>());
        }

        [UnityTest]
        public IEnumerator Dispose_Works_Correctly()
        {
            _selectedSubject.OnNext(true);
            _target.Dispose();
            _selectedSubject.OnNext(true);
            yield return null;
            _layoutManager.Received(1).SetState(Arg.Any<LayoutManagerState>());
        }
    }
}