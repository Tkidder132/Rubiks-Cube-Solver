using UnityEngine;
using System.Collections;

public class CubeModel : MonoBehaviour
{
	//front, back, left, right, top, bottom
	public Color[] _faces = new Color[6];

	private RubiksCubeController fullCubeController;

	public void SetRubiksCubeController(RubiksCubeController cubeController)
	{
		this.fullCubeController = cubeController;
	}

	public void RotateCube(Vector3 cubeAxis, Vector3 cubeDirection, float cubeTime)
	{
		StartCoroutine(rotateCubeCoroutine(cubeAxis, cubeDirection, cubeTime));
	}

	private IEnumerator rotateCubeCoroutine(Vector3 cubeAxis, Vector3 cubeDirection, float cubeTime)
	{
		fullCubeController.SetRotating (true);
		for (var i = 0; i < 30; i++)
		{
			this.transform.RotateAround (cubeAxis, cubeDirection, 3);
			yield return new WaitForSeconds(.0005f);
		}
		fullCubeController.SetRotating (false);
		yield return 0;
	}

	public void SetColors(Color[] faces)
	{
		for (var i = 0; i < this._faces.Length; i++)
		{
			this._faces[i] = faces[i];
		}
	}

	public Color[] GetColorsArray()
	{
		return this._faces;
	}
	
	public void RotateColorsForward()
	{
		Color temp = this._faces [0];
		this._faces [0] = this._faces [4];
		this._faces [4] = this._faces [1];
		this._faces [1] = this._faces [5];
		this._faces [5] = temp;
	}

	public void RotateColorsBackward()
	{
		Color temp = this._faces [0];
		this._faces [0] = this._faces [5];
		this._faces [5] = this._faces [1];
		this._faces [1] = this._faces [4];
		this._faces [4] = temp;
	}
	
	public void RotateColorsClockwise()
	{
		Color temp = this._faces [4];
		this._faces [4] = this._faces [2];
		this._faces [2] = this._faces [5];
		this._faces [5] = this._faces [3];
		this._faces [3] = temp;
	}

	public void RotateColorsCounterClockwise()
	{
		Color temp = this._faces [4];
		this._faces [4] = this._faces [3];
		this._faces [3] = this._faces [5];
		this._faces [5] = this._faces [2];
		this._faces [2] = temp;
	}

	//front, back, left, right, top, bottom
	public void RotateColorsLeft()
	{
		Color temp = this._faces [0];
		this._faces [0] = this._faces [2];
		this._faces [2] = this._faces [1];
		this._faces [1] = this._faces [3];
		this._faces [3] = temp;
	}

	public void RotateColorsRight()
	{
		Color temp = this._faces [0];
		this._faces [0] = this._faces [3];
		this._faces [3] = this._faces [1];
		this._faces [1] = this._faces [2];
		this._faces [2] = temp;
	}

	public bool CheckColors(Color[] faces)
	{
		for (var i = 0; i < this._faces.Length; i++)
		{
			if( this._faces[i] != faces[i] )
			{
				return false;
			}
		}
		return true;
	}

	public Color GetFrontColor()
	{
		return this._faces [0];
	}

	public Color GetBackColor()
	{
		return this._faces [1];
	}

	public Color GetLeftColor()
	{
		return this._faces [2];
	}

	public Color GetRightColor()
	{
		return this._faces [3];
	}

	public Color GetTopColor()
	{
		return this._faces [4];
	}

	public Color GetBottomColor()
	{
		return this._faces [5];
	}
}