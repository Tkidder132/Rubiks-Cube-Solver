using System;
using NUnit.Framework;

public class SampleTestNew
{
	[Test]
	public void SimpleAddition()
	{
		//Assert.That (2 + 2 == 4);

		//Arrange
		var two = 2;
		var expected = 4;
		int result;
		//act
		result = Add (two, two);
		//Assert
		Assert.AreEqual (expected, result);
	}

	int Add(int first, int second)
	{
		return first + second;
	}
}
