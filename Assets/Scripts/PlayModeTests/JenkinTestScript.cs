using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        private LevelBehavior levelObject;
        public GameObject levelPrefab;
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            //GameObject leveObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level"));
            //level = leveObject.GetComponent<LevelBehavior>();
            levelObject = MonoBehaviour.Instantiate(levelPrefab).GetComponent<LevelBehavior>();
            // 3
            levelObject.belt.SpawnSomething();
            GameObject beltObject = levelObject.belt.SpawnSomething();
            
            if (beltObject == null)
            {
                yield return true;
            }
            // 4
            float initialZPos = beltObject.transform.position.z;
            // 5
            yield return new WaitForSeconds(1.0f);
            // 6
            Assert.Less(beltObject.transform.position.z, initialZPos);
            // 7
            Object.Destroy(levelObject.gameObject);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
        }

        public IEnumerator DoesItSpawn()
        {
            int prevObjectsOnBelt = levelObject.belt.itemsOnTheBelt.Count;
            levelObject.belt.SpawnSomething();
            Assert.Less(prevObjectsOnBelt, levelObject.belt.itemsOnTheBelt.Count);
            yield return null;
        }
    }
}
