using System.Collections;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle;
using VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Styles.ButtonStyle.SimpleButtonStyle
{
    public abstract class SimpleButtonStyleControllerTests : ZenjectIntegrationTestFixture
    {
        private SimpleButtonStyleController _testTarget;

        /// <summary>
        /// Reference to the container that holds all the controlled objects
        /// </summary>
        private ISimpleButtonStyleObjectReferencesContainer _referencesContainer;

        /// <summary>
        /// Reference to an object that matches a button type with a specific button style
        /// </summary>
        IButtonStyleMatcher<ISimpleButtonStyleElement> _buttonStyleMatcher;
        
        /// <summary>
        /// Button that acts as a source of disable signals
        /// </summary>
        private Button _sourceButton;

        /// <summary>
        /// List of background objects controlled by the style controller
        /// </summary>
        private List<MaskableGraphic> _backgrounds = new List<MaskableGraphic>();

        /// <summary>
        /// List of style objects controlled by the style controller
        /// </summary>
        private List<MaskableGraphic> _symbols = new List<MaskableGraphic>();

        private IButtonStyleEnum _type1 = Substitute.For<IButtonStyleEnum>();
        private IButtonStyleEnum _type2 = Substitute.For<IButtonStyleEnum>();

        private IButtonStyleContainer<ISimpleButtonStyleElement> _style1;
        private IButtonStyleContainer<ISimpleButtonStyleElement> _style2;

        [OneTimeSetUp]
        public void BeforeEveryTestOnce()
        {
            // Generate styles
            _buttonStyleMatcher = Substitute.For<IButtonStyleMatcher<ISimpleButtonStyleElement>>();

            _style1 = Substitute.For<IButtonStyleContainer<ISimpleButtonStyleElement>>();
            _style2 = Substitute.For<IButtonStyleContainer<ISimpleButtonStyleElement>>();
            _buttonStyleMatcher.GetStyleContainer(null).Returns(_style1);
            _buttonStyleMatcher.GetStyleContainer(_type1).Returns(_style1);
            _buttonStyleMatcher.GetStyleContainer(_type2).Returns(_style2);
            // Generate styles
            _style1.NormalSettings.BackgroundColor.Returns(Color.cyan);
            _style1.NormalSettings.SymbolColor.Returns(Color.yellow);
        }

        [SetUp]
        public void BeforeEveryTest()
        {
            // Generate controlled objects
            _referencesContainer = Substitute.For<ISimpleButtonStyleObjectReferencesContainer>();
            _backgrounds.Add(new GameObject().AddComponent<Image>());
            _backgrounds.Add(new GameObject().AddComponent<TextMeshProUGUI>());

            _symbols.Add(new GameObject().AddComponent<Image>());
            _symbols.Add(new GameObject().AddComponent<TextMeshProUGUI>());
            _referencesContainer.Backgrounds.Returns(_backgrounds);
            _referencesContainer.Symbols.Returns(_symbols);
            // Generate controlled objects

            _sourceButton = new GameObject().AddComponent<Button>();

            PreInstall();

            Container.Bind<ISimpleButtonStyleObjectReferencesContainer>().FromInstance(_referencesContainer).AsSingle();
            Container.Bind<IButtonStyleMatcher<ISimpleButtonStyleElement>>().FromInstance(_buttonStyleMatcher)
                .AsSingle();
            Container.Bind<Button>().WithId("ButtonStyleController - Button").FromInstance(_sourceButton).AsSingle();

            Container.Bind<SimpleButtonStyleController>().FromNewComponentOnNewGameObject().AsSingle();

            PostInstall();

            _testTarget = Container.Resolve<SimpleButtonStyleController>();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.DestroyImmediate(_testTarget.gameObject);
            Object.DestroyImmediate(_sourceButton.gameObject);

            // Clean controlled objects
            foreach (var graphic in _backgrounds.AsReadOnly())
            {
                Object.DestroyImmediate(graphic.gameObject);
            }
            _backgrounds.Clear();

            foreach (var graphic in _symbols.AsReadOnly())
            {
                Object.DestroyImmediate(graphic.gameObject);
            }
            _symbols.Clear();
            // Clean controlled objects

            

            
        }

        public class NullStyle : SimpleButtonStyleControllerTests
        {
            [UnityTest]
            public IEnumerator Normal_Settings_Are_Applied_By_Default()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Disabled_Settings_Are_Applied_On_Button_Disable()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.DisabledSettings.BackgroundColor.Returns(Color.red);
                _style1.DisabledSettings.SymbolColor.Returns(Color.blue);

                _sourceButton.interactable = false;
                yield return null;
                Debug.Log("Checking disabled background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.red, graphic.color);
                }

                Debug.Log("Checking disabled symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.blue, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Normal_Settings_Are_Applied_On_Button_Enable()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.DisabledSettings.BackgroundColor.Returns(Color.red);
                _style1.DisabledSettings.SymbolColor.Returns(Color.blue);

                _sourceButton.interactable = false;
                yield return null;
                Debug.Log("Checking disabled background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.red, graphic.color);
                }

                Debug.Log("Checking disabled symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.blue, graphic.color);
                }

                _sourceButton.interactable = true;
                yield return null;
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Higlighted_Settings_Are_Applied_On_Pointer_Enter()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.HighlightedSettings.BackgroundColor.Returns(Color.gray);
                _style1.HighlightedSettings.SymbolColor.Returns(Color.black);
                _testTarget.OnPointerEnter(null);
                Debug.Log("Checking highlighted background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.gray, graphic.color);
                }

                Debug.Log("Checking highlighted symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.black, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Pressed_Settings_Are_Applied_On_Pointer_Sown()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.HighlightedSettings.BackgroundColor.Returns(Color.gray);
                _style1.HighlightedSettings.SymbolColor.Returns(Color.black);
                _testTarget.OnPointerEnter(null);
                Debug.Log("Checking highlighted background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.gray, graphic.color);
                }

                Debug.Log("Checking highlighted symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.black, graphic.color);
                }

                _style1.PressedSettings.BackgroundColor.Returns(Color.red);
                _style1.PressedSettings.SymbolColor.Returns(Color.white);
                _testTarget.OnPointerDown(null);
                Debug.Log("Checking pressed background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.red, graphic.color);
                }

                Debug.Log("Checking pressed symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.white, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Normal_Settings_Are_Applied_On_Pointer_Exit()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.HighlightedSettings.BackgroundColor.Returns(Color.gray);
                _style1.HighlightedSettings.SymbolColor.Returns(Color.black);
                _testTarget.OnPointerEnter(null);
                Debug.Log("Checking highlighted background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.gray, graphic.color);
                }

                Debug.Log("Checking highlighted symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.black, graphic.color);
                }

                _style1.PressedSettings.BackgroundColor.Returns(Color.red);
                _style1.PressedSettings.SymbolColor.Returns(Color.white);
                _testTarget.OnPointerExit(null);
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }
            }

            [UnityTest]
            public IEnumerator Highlighted_Settings_Are_Applied_On_Pointer_Up()
            {
                yield return null;
                Debug.Log("Checking default background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.cyan, graphic.color);
                }

                Debug.Log("Checking default symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.yellow, graphic.color);
                }

                _style1.HighlightedSettings.BackgroundColor.Returns(Color.gray);
                _style1.HighlightedSettings.SymbolColor.Returns(Color.black);
                _testTarget.OnPointerEnter(null);
                Debug.Log("Checking highlighted background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.gray, graphic.color);
                }

                Debug.Log("Checking highlighted symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.black, graphic.color);
                }

                _style1.PressedSettings.BackgroundColor.Returns(Color.red);
                _style1.PressedSettings.SymbolColor.Returns(Color.white);
                _testTarget.OnPointerDown(null);
                Debug.Log("Checking pressed background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.red, graphic.color);
                }

                Debug.Log("Checking pressed symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.white, graphic.color);
                }

                _testTarget.OnPointerUp(null);
                Debug.Log("Checking highlighted background colors:");
                foreach (var graphic in _backgrounds)
                {
                    Assert.AreEqual(Color.gray, graphic.color);
                }

                Debug.Log("Checking highlighted symbol colors:");
                foreach (var graphic in _symbols)
                {
                    Assert.AreEqual(Color.black, graphic.color);
                }
            }
        }

        /*[UnityTest]
        public IEnumerator RunTest1()
        {
            // Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc
    
            PreInstall();
    
            // Call Container.Bind methods
    
            PostInstall();
    
            // Add test assertions for expected state
            // Using Container.Resolve or [Inject] fields
            yield break;
        }*/
    }
}