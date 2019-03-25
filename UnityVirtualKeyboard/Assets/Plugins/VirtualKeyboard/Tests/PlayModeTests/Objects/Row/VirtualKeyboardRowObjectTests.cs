using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VirtualKeyboard.Data.Button;
using VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using VirtualKeyboard.Objects.Row;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Row
{
    /// <summary>
    /// Tests for <see cref="VirtualKeyboardRowObject"/>
    /// </summary>
    public class VirtualKeyboardRowObjectTests : ZenjectIntegrationTestFixture
    {
        private VirtualKeyboardRowObject _target;
        private IButtonsManager _buttonsManager;
        private Transform _parent;
        private VirtualKeyboardRowObject.Pool _pool;

        [SetUp]
        public void BeforeEveryTest()
        {
            _parent = new GameObject().transform;
            _buttonsManager = Substitute.For<IButtonsManager>();
            

            PreInstall();
            Container.Bind<IButtonsManager>().FromInstance(_buttonsManager).AsSingle();
            Container.BindMemoryPool<VirtualKeyboardRowObject, VirtualKeyboardRowObject.Pool>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<Transform>().WithId("RowsManager - Pool Parent Transform").FromInstance(_parent).AsSingle();
            PostInstall();

            _pool = Container.Resolve<VirtualKeyboardRowObject.Pool>();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(_parent.gameObject);
            Object.Destroy(_target.gameObject);
        }


        [UnityTest]
        public IEnumerator Sends_Reset_On_Despawn()
        {
            _target = _pool.Spawn(new IRowParametersBuilder().WithPage(0).WithNewButton(new ButtonData(new List<string>{"a"},1 )).WithParentTransform(_parent).Build());
            _pool.Despawn(_target);

            _buttonsManager.Received(1).Reset();

            yield break;
        }

        [UnityTest]
        public IEnumerator Sends_Button_Information_To_The_buttons_Manager ()
        {
            List<IButtonsParameters> received = new List<IButtonsParameters>();
            _buttonsManager.AddButton(Arg.Do<IButtonsParameters>(parameters => received.Add(parameters)));

            _target = _pool.Spawn(new IRowParametersBuilder().WithPage(0).WithNewButton(new ButtonData(new List<string> { "a" }, 1)).WithNewButton(new ButtonData(new List<string> { "b" }, 2)).WithParentTransform(_parent).Build());
            
            Assert.AreEqual(2, received.Count);

            Assert.AreEqual(0, received[0].Page);
            Assert.AreEqual(_target.transform, received[0].ButtonParent);
            Assert.AreEqual(1, received[0].ButtonData.ButtonHorizontalSize);
            Assert.AreEqual("a", received[0].ButtonData.ButtonPageCharacters.ToList()[0]);

            Assert.AreEqual(0, received[1].Page);
            Assert.AreEqual(_target.transform, received[1].ButtonParent);
            Assert.AreEqual(2, received[1].ButtonData.ButtonHorizontalSize);
            Assert.AreEqual("b", received[1].ButtonData.ButtonPageCharacters.ToList()[0]);

            _target = _pool.Spawn(new IRowParametersBuilder().WithPage(1).WithNewButton(new ButtonData(new List<string> { "a", "A" }, 1)).WithNewButton(new ButtonData(new List<string> { "b", "B" }, 2)).WithParentTransform(_parent).Build());
            Assert.AreEqual(1, received[2].Page);
            Assert.AreEqual(_target.transform, received[2].ButtonParent);
            Assert.AreEqual(1, received[2].ButtonData.ButtonHorizontalSize);
            Assert.AreEqual("a", received[2].ButtonData.ButtonPageCharacters.ToList()[0]);
            Assert.AreEqual("A", received[2].ButtonData.ButtonPageCharacters.ToList()[1]);

            Assert.AreEqual(1, received[3].Page);
            Assert.AreEqual(_target.transform, received[3].ButtonParent);
            Assert.AreEqual(2, received[3].ButtonData.ButtonHorizontalSize);
            Assert.AreEqual("b", received[3].ButtonData.ButtonPageCharacters.ToList()[0]);
            Assert.AreEqual("B", received[3].ButtonData.ButtonPageCharacters.ToList()[1]);

            yield break;
        }
    }
}