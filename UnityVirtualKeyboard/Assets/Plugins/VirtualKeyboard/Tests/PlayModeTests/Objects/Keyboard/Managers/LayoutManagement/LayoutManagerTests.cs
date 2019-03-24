using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using VirtualKeyboard.Blueprints.KeyboardLayout;
using VirtualKeyboard.Blueprints.KeyboardLayoutCollection;
using VirtualKeyboard.Blueprints.KeyboardRow;
using VirtualKeyboard.Data.Button;
using VirtualKeyboard.Objects.Keyboard.Managers.LanguageManagement;
using VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Tests for <see cref="LayoutManager"/>
    /// </summary>
    public class LayoutManagerTests : ZenjectIntegrationTestFixture
    {
        private LayoutManager _target;
        private IKeyboardLayoutCollection _layoutCollection;
        private IRowsManager _rowsManager;
        private ILanguageManager _languageManager;
        private ILayoutPanelParameters _lettersPanelParameters;
        private ILayoutPanelParameters _symbolsPanelParameters;
        private ILayoutPanelParameters _digitsPanelParameters;


        private GameObject _lettersPanel;
        private GameObject _symbolsPanel;
        private GameObject _digitsPanel;

        [SetUp]
        public void BeforeEveryTest()
        {
            _lettersPanel = new GameObject();
            _symbolsPanel = new GameObject();
            _digitsPanel = new GameObject();

            _lettersPanelParameters = new ILayoutPanelParametersBuilder().WithPanelObject(_lettersPanel)
                .WithRowsParentTransform(_lettersPanel.transform).Build();
            _symbolsPanelParameters = new ILayoutPanelParametersBuilder().WithPanelObject(_symbolsPanel)
                .WithRowsParentTransform(_symbolsPanel.transform).Build();
            _digitsPanelParameters = new ILayoutPanelParametersBuilder().WithPanelObject(_digitsPanel)
                .WithRowsParentTransform(_digitsPanel.transform).Build();

            _rowsManager = Substitute.For<IRowsManager>();
            _languageManager = Substitute.For<ILanguageManager>();

            BuildCollection();

            PreInstall();
            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Letters Panel Parameters").FromInstance(_lettersPanelParameters).AsCached();
            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Symbols Panel Parameters").FromInstance(_symbolsPanelParameters).AsCached();
            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Digits Panel Parameters").FromInstance(_digitsPanelParameters).AsCached();
            Container.Bind<IKeyboardLayoutCollection>().FromInstance(_layoutCollection).AsSingle();
            Container.Bind<IRowsManager>().FromInstance(_rowsManager).AsSingle();
            Container.Bind<ILanguageManager>().FromInstance(_languageManager).AsSingle();
            Container.BindInterfacesAndSelfTo<LayoutManager>().FromNew().AsSingle().NonLazy();
            PostInstall();

            _target = Container.Resolve<LayoutManager>();
        }

        private void BuildCollection()
        {
            #region Collection creation

            var digits = new ILayoutBlueprintBuilder()
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("1").WithHorizontalSize(1).Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("2").WithHorizontalSize(1).Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("3").WithHorizontalSize(1).Build()
                        )
                        .Build())
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("4").WithHorizontalSize(1).Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("5").WithHorizontalSize(1).Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("6").WithHorizontalSize(1).Build()
                        )
                        .Build())
                .Build();

            var symbols = new ILayoutBlueprintBuilder()
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("!").WithNewCharacter("?").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("@").WithNewCharacter("#").WithHorizontalSize(1)
                                .Build()
                        )
                        .Build())
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("$").WithNewCharacter("%").WithHorizontalSize(2)
                                .Build()
                        )
                        .Build())
                .Build();

            var englishLayout = new ILayoutBlueprintBuilder()
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("q").WithNewCharacter("Q").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("w").WithNewCharacter("W").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("e").WithNewCharacter("E").WithHorizontalSize(1)
                                .Build()
                        )
                        .Build())
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("z").WithNewCharacter("Z").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter(" ").WithNewCharacter(" ").WithHorizontalSize(2)
                                .Build()
                        )
                        .Build())
                .Build();

            var russianLayout = new ILayoutBlueprintBuilder()
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("é").WithNewCharacter("É").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("ö").WithNewCharacter("Ö").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("ó").WithNewCharacter("Ó").WithHorizontalSize(1)
                                .Build()
                        )
                        .Build())
                .WithNewRow(
                    new IRowBlueprintBuilder()
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter("ô").WithNewCharacter("ô").WithHorizontalSize(1)
                                .Build()
                        )
                        .WithNewButton(
                            new IButtonDataBuilder().WithNewCharacter(" ").WithNewCharacter(" ").WithHorizontalSize(2)
                                .Build()
                        )
                        .Build())
                .Build();

            _layoutCollection = new IKeyboardLayoutCollectionBuilder().WithDigits(digits).WithSymbols(symbols)
                .WithNewLanguage(englishLayout).WithNewLanguage(russianLayout).Build();
            #endregion
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(_lettersPanel);
            Object.Destroy(_symbolsPanel);
            Object.Destroy(_digitsPanel);
        }

        [UnityTest]
        public IEnumerator Set_State_To_Letters()
        {
            List<IRowParameters> received = new List<IRowParameters>();
         
            _rowsManager.AddRow(Arg.Do<IRowParameters>(parameters =>
            {
                Debug.Log("Received");
                received.Add(parameters);
            }));

            _target.SetState(LayoutManagerState.Letters);

            Assert.AreEqual(2, received.Count);
            Assert.AreEqual(_lettersPanel.transform, received[0].RowsParent);
            Assert.AreEqual(_lettersPanel.transform, received[1].RowsParent);

            Assert.AreEqual(0, received[0].Page);
            Assert.AreEqual(0, received[1].Page);

            int x = 0;
            int y = 0;
            foreach (var rowParameters in received)
            {
                foreach (var button in rowParameters.Buttons)
                {
                    switch (x)
                    {
                        case 0:
                            switch (y)
                            {
                                case 0:
                                    Assert.AreEqual("q", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 1:
                                    Assert.AreEqual("w", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 2:
                                    Assert.AreEqual("e", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                            }
                            break;
                        case 1:
                            switch (y)
                            {
                                case 0:
                                    Assert.AreEqual("z", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 1:
                                    Assert.AreEqual(" ", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(2, button.ButtonHorizontalSize);
                                    break;
                            }
                            break;
                    }
                    y++;
                }
                x++;
            }

            yield break;
        }

        [UnityTest]
        public IEnumerator Set_State_To_Letters_And_To_Shift()
        {
            List<IRowParameters> received = new List<IRowParameters>();

            _rowsManager.AddRow(Arg.Do<IRowParameters>(parameters =>
            {
                Debug.Log("Received");
                received.Add(parameters);
            }));

            _target.SetState(LayoutManagerState.Letters);
            _target.SetLayoutPageByIndex(1);

            Assert.AreEqual(4, received.Count);
            Assert.AreEqual(_lettersPanel.transform, received[2].RowsParent);
            Assert.AreEqual(_lettersPanel.transform, received[3].RowsParent);

            Assert.AreEqual(1, received[2].Page);
            Assert.AreEqual(1, received[3].Page);

            int x = 0;
            int y = 0;
            foreach (var rowParameters in received)
            {
                foreach (var button in rowParameters.Buttons)
                {
                    switch (x)
                    {
                        case 2:
                            switch (y)
                            {
                                case 0:
                                    Assert.AreEqual("q", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 1:
                                    Assert.AreEqual("w", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 2:
                                    Assert.AreEqual("e", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                            }
                            break;
                        case 3:
                            switch (y)
                            {
                                case 0:
                                    Assert.AreEqual("z", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(1, button.ButtonHorizontalSize);
                                    break;
                                case 1:
                                    Assert.AreEqual(" ", button.ButtonPageCharacters.ToList()[0]);
                                    Assert.AreEqual(2, button.ButtonHorizontalSize);
                                    break;
                            }
                            break;
                    }
                    y++;
                }
                x++;
            }

            yield break;
        }
    }
}