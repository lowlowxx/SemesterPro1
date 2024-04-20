using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Testing
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestingSimplePasses()
    {
        // Use the Assert class to test conditions


    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestingWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator pickUpItems()
    {
        
        yield return null;
    }


    [UnityTest]
    public IEnumerator nextLevelTest()
    {
        
        yield return null;
    }


    [UnityTest]
    public IEnumerator doorBehaviourTest()
    {
        
        yield return null;
    }


    [UnityTest]
    public IEnumerator keyBehaviourTest()
    {
        
        yield return null;
    }


    [UnityTest]
    public IEnumerator playerMoveTest()
    {
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator scoreManagerTest()
    {
        
        yield return null;
    }





}
