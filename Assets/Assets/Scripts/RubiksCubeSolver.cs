using UnityEngine;
using System.Collections;

public class RubiksCubeSolver : MonoBehaviour
{
	private ArrayList ActionsList = new ArrayList();
	private RubiksCubeModel fullCube;

	public ArrayList SolveRubiksCube(RubiksCubeModel fullCubeModel)
	{
		this.fullCube = fullCubeModel;
		SolveTopCrossMiddle ();
		SolveTopCross ();
		SolveTopCorners ();
		SpinMiddle ();
		SolveMiddleSides ();
		SolveBottomCross ();
		SolveBottomCrossSides ();
		SolveBottomCorners ();
		FinishBottomCorners ();
		SpinToWin ();

		return ActionsList;
	}

	void SolveTopCrossMiddle()
	{
		//find the middle white piece and move it to center top
		//it can only be in one of six spots

		//if its top do nothing
		CubeModel temp;
		temp = fullCube [1, 1, 0];
		if (temp.GetTopColor ().Equals (Color.white))
		{
			return;
		}

		//if its bottom face
		//rotate upwards twice
		temp = fullCube [1, 1, 2];
		if (temp.GetBottomColor ().Equals (Color.white))
		{
			ActionsList.Add(9);
			ActionsList.Add(9);
			return;
		}

		//if its the front face
		//rotate middle upwards
		temp = fullCube [1, 0, 1];
		if (temp.GetFrontColor ().Equals (Color.white))
		{
			ActionsList.Add(9);
			return;
		}

		//if its the back face
		//rotate middle downwards
		temp = fullCube [1, 2, 1];
		if (temp.GetBackColor ().Equals (Color.white))
		{
			ActionsList.Add(8);
			return;
		}

		//if its the left face
		//rotate middle clockwise
		temp = fullCube [0, 1, 1];
		if (temp.GetLeftColor ().Equals (Color.white))
		{
			ActionsList.Add(14);
			return;
		}

		//if its the right face
		//rotate middle counter clockwise
		temp = fullCube [2, 1, 1];
		if (temp.GetRightColor ().Equals (Color.white))
		{
			ActionsList.Add(15);
			return;
		}
	}

	void SolveTopCross()
	{
		//first rotate white middle to top
		//second rotate the rest of the cross sides
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	void SolveTopCorners()
	{
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	void SpinMiddle()
	{
		//TODO: SPIN MIDDLE COLORS TO MATCHING FACE
	}
	
	void SolveMiddleSides()
	{
		//TODO: SOLVE MIDDLE SIDES
	}
	
	void SolveBottomCross()
	{
		//TODO: SOLVE YELLOW/BOTTOM CROSS
	}
	
	void SolveBottomCrossSides()
	{
		//TODO: SOLVE BOTTOM CROSS SIDES
	}
	
	void SolveBottomCorners()
	{
		//TODO: PLACE CORNERS IN RIGHT SPOT
	}
	
	void FinishBottomCorners()
	{
		//TODO: SPIN CORNERS TO RIGHT DIRECTION
	}
	
	void SpinToWin()
	{
		//TODO: SPIN COLORS TO MATCH AND FINISH
	}
}
