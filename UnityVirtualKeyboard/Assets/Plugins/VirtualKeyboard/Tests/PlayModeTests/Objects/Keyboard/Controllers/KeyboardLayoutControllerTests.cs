using Zenject;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class KeyboardLayoutControllerTests : ZenjectIntegrationTestFixture
{
    [UnityTest]
    public IEnumerator RunTest1()
    {
        // Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc

        PreInstall();

        // Call Container.Bind methods

        PostInstall();
        Assert.AreEqual(true, false);
        // Add test assertions for expected state
        // Using Container.Resolve or [Inject] fields
        yield break;
    }
}