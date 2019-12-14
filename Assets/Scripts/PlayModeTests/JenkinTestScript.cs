using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class JenkinTestScript // test 001
    {
        private GameObject levelObject;
        private LevelBehavior level;
        private PlayerController player;

        [SetUp]
        public void Setup()
        {
            levelObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Level"));
            level = levelObject.GetComponent<LevelBehavior>();
            player = level.player;
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(levelObject.gameObject);
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

        [UnityTest]
        public IEnumerator DoesThePlayerStartInTheMiddle()
        {
            Assert.AreEqual(2, player.currentLane);
            yield return null;
        }

        [UnityTest]
        public IEnumerator CanThePlayerMoveLeft()
        {
            player.FastSetThePlayerToLane(2);
            yield return new WaitForSecondsRealtime(player.timeToMove);
            player.PressLeft();
            Assert.AreEqual(1, player.currentLane);
            yield return null;
        }

        [UnityTest]
        public IEnumerator CanThePlayerMoveRight()
        {
            player.FastSetThePlayerToLane(2);
            yield return new WaitForSecondsRealtime(player.timeToMove);
            player.PressRight();
            Assert.AreEqual(3, player.currentLane);
            yield return null;
        }
    }
}
