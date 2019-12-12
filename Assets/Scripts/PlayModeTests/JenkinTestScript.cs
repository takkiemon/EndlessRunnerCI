using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class JenkinTestScript
    {
        private LevelBehavior level;
        private GameObject levelObject;

        [SetUp]
        public void Setup()
        {
            levelObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Level"));
            level = levelObject.GetComponent<LevelBehavior>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(levelObject.gameObject);
        }

        [UnityTest]
        public IEnumerator SimpleTestTest()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(1, 0);
        }
        
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator NothingIsNullOrEmpty()
        {
            Assert.IsNotNull(level);
            Assert.IsNotNull(level.belt);
            Assert.IsNotNull(level.belt.itemLanes);
            Assert.GreaterOrEqual(level.belt.itemLanes.Length, 1);
            Assert.GreaterOrEqual(level.belt.itemsOnTheBelt.Count + level.belt.inactiveItems.Count, 1);

            // Use the Assert class to test conditions
            yield return true;
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DoesTheSpawnedObjectMoveOnTheBelt()
        {
            // 3
            level.belt.SpawnSomething();
            GameObject beltObject = level.belt.SpawnSomething();
            // 4
            float initialZPos = beltObject.transform.position.z;
            // 5
            yield return new WaitForSeconds(1.0f);
            // 6
            Assert.Less(beltObject.transform.position.z, initialZPos);
            // 7
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [UnityTest]
        public IEnumerator DoesItSpawn()
        {
            int prevObjectsOnBelt = level.belt.itemsOnTheBelt.Count;
            level.belt.SpawnSomething();
            Assert.Greater(level.belt.itemsOnTheBelt.Count, prevObjectsOnBelt);
            yield return null;
        }
    }
}
