using UnityEngine;
using System.Collections;

//Controls all the visuals
//I.E. moving the actual 3d models
public class RubiksCubeView : MonoBehaviour
{

	private RubiksCubeController fullCubeController;

	enum Layer{TOP, MIDDLE, BOTTOM};
	enum Face{FRONT, MIDDLE, BACK};
	enum Slice{LEFT, MIDDLE, RIGHT};

	public void SetRubiksCubeController(RubiksCubeController cubeController)
	{
		this.fullCubeController = cubeController;
	}

	public void RotateCubeClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFrontClockwise (fullCubeModel);
		RotateMiddleFaceClockwise (fullCubeModel);
		RotateBackCounterClockwise (fullCubeModel);
	}

	public void RotateCubeCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFrontCounterClockwise (fullCubeModel);
		RotateMiddleFaceCounterClockwise (fullCubeModel);
		RotateBackClockwise (fullCubeModel);
	}

	public void RotateCubeForward(RubiksCubeModel fullCubeModel)
	{
		RotateLeftClockwise (fullCubeModel);
		RotateMiddleVerticalForward (fullCubeModel);
		RotateRightCounterClockwise (fullCubeModel);
	}
	
	public void RotateCubeBackwards(RubiksCubeModel fullCubeModel)
	{
		RotateLeftCounterClockwise (fullCubeModel);
		RotateMiddleVerticalBackwards (fullCubeModel);
		RotateRightClockwise (fullCubeModel);
	}

	public void RotateCubeLeft(RubiksCubeModel fullCubeModel)
	{
		RotateTopClockwise (fullCubeModel);
		RotateMiddleHorizontalLeft (fullCubeModel);
		RotateBottomCounterClockwise (fullCubeModel);
	}

	public void RotateCubeRight(RubiksCubeModel fullCubeModel)
	{
		RotateTopCounterClockwise (fullCubeModel);
		RotateMiddleHorizontalRight (fullCubeModel);
		RotateBottomClockwise (fullCubeModel);
	}

	public void ReverseCube(RubiksCubeModel fullCubeModel)
	{
		RotateCubeLeft (fullCubeModel);
		RotateCubeLeft (fullCubeModel);
	}
	
	/************************************************************************************************/

	private void RotateLayerClockwise(int layer, RubiksCubeModel fullCubeModel)
	{
		for( var x = 0; x < 3; x++ )
		{
			for( var y = 0; y < 3; y++ )
			{
				fullCubeModel.GetRubiksCubeBlock(x,y,layer).RotateCube(Vector3.zero, Vector3.up, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	private void RotateLayerCounterClockwise(int layer, RubiksCubeModel fullCubeModel)
	{
		for( var x = 0; x < 3; x++ )
		{
			for( var y = 0; y < 3; y++ )
			{
				fullCubeModel.GetRubiksCubeBlock(x,y,layer).RotateCube(Vector3.zero, Vector3.down, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	public void RotateTopClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateLayerClockwise ((int)Layer.TOP, fullCubeModel);
	}

	public void RotateTopCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateLayerCounterClockwise ((int)Layer.TOP, fullCubeModel);
	}

	public void RotateMiddleHorizontalLeft(RubiksCubeModel fullCubeModel)
	{
		RotateLayerClockwise ((int)Layer.MIDDLE, fullCubeModel);
	}

	public void RotateMiddleHorizontalRight(RubiksCubeModel fullCubeModel)
	{
		RotateLayerCounterClockwise ((int)Layer.MIDDLE, fullCubeModel);
	}

	public void RotateBottomClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateLayerCounterClockwise ((int)Layer.BOTTOM, fullCubeModel);
	}

	public void RotateBottomCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateLayerClockwise ((int)Layer.BOTTOM, fullCubeModel);
	}
	
	/************************************************************************************************/

	private void RotateSliceForward(int slice, RubiksCubeModel fullCubeModel)
	{
		for( var z = 0; z < 3; z++ )
		{
			for( var y = 2; y >= 0; y-- )
			{
				fullCubeModel.GetRubiksCubeBlock(slice,y,z).RotateCube(Vector3.zero, Vector3.left, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	private void RotateSliceBackward(int slice, RubiksCubeModel fullCubeModel)
	{
		for( var z = 0; z < 3; z++ )
		{
			for( var y = 2; y >= 0; y-- )
			{
				fullCubeModel.GetRubiksCubeBlock(slice,y,z).RotateCube(Vector3.zero, Vector3.right, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	public void RotateLeftClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateSliceForward ((int)Slice.LEFT, fullCubeModel);
	}
	
	public void RotateLeftCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateSliceBackward ((int)Slice.LEFT, fullCubeModel);
	}
	
	public void RotateMiddleVerticalForward(RubiksCubeModel fullCubeModel)
	{
		RotateSliceForward ((int)Slice.MIDDLE, fullCubeModel);
	}
	
	public void RotateMiddleVerticalBackwards(RubiksCubeModel fullCubeModel)
	{
		RotateSliceBackward ((int)Slice.MIDDLE, fullCubeModel);
	}
	
	public void RotateRightClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateSliceBackward ((int)Slice.RIGHT, fullCubeModel);
	}
	
	public void RotateRightCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateSliceForward ((int)Slice.RIGHT, fullCubeModel);
	}
	
	/************************************************************************************************/

	private void RotateFaceClockwise(int face, RubiksCubeModel fullCubeModel)
	{
		for (var z = 0; z < 3; z++)
		{
			for( var x = 0; x < 3; x++ )
			{
				fullCubeModel.GetRubiksCubeBlock(x,face,z).RotateCube(Vector3.zero, Vector3.back, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	private void RotateFaceCounterClockwise(int face, RubiksCubeModel fullCubeModel)
	{
		for (var z = 0; z < 3; z++)
		{
			for( var x = 0; x < 3; x++ )
			{
				fullCubeModel.GetRubiksCubeBlock(x,face,z).RotateCube(Vector3.zero, Vector3.forward, fullCubeController.GetRotationDegree() * Time.deltaTime);
			}
		}
	}

	public void RotateFrontClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceClockwise ((int)Face.FRONT, fullCubeModel);
	}
	
	public void RotateFrontCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceCounterClockwise ((int)Face.FRONT, fullCubeModel);
	}
	
	public void RotateMiddleFaceClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceClockwise ((int)Face.MIDDLE, fullCubeModel);
	}
	
	public void RotateMiddleFaceCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceCounterClockwise ((int)Face.MIDDLE, fullCubeModel);
	}
	
	public void RotateBackClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceCounterClockwise ((int)Face.BACK, fullCubeModel);
	}
	
	public void RotateBackCounterClockwise(RubiksCubeModel fullCubeModel)
	{
		RotateFaceClockwise ((int)Face.BACK, fullCubeModel);
	}
}
