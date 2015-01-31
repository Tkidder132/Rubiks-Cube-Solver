using UnityEngine;
using System.Collections;

public class RubiksCubeSolver : MonoBehaviour
{
	private ArrayList ActionsList = new ArrayList();
	private CubeModel[,,] fullCube;

	public ArrayList SolveRubiksCube(CubeModel[,,] fullCubeModel)
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

	private void SolveTopCrossMiddle()
	{
		//find the middle white piece and move it to center top
		//it can only be in one of six spots

		CubeModel temp;
		temp = fullCube [1, 1, 0];
		if (temp.GetTopColor ().Equals (Color.white))
		{
			return;
		}

		temp = fullCube [1, 1, 2];
		if (temp.GetBottomColor ().Equals (Color.white))
		{
			ActionsList.Add(9);
			ActionsList.Add(9);
			return;
		}

		temp = fullCube [1, 0, 1];
		if (temp.GetFrontColor ().Equals (Color.white))
		{
			ActionsList.Add(9);
			return;
		}

		temp = fullCube [1, 2, 1];
		if (temp.GetBackColor ().Equals (Color.white))
		{
			ActionsList.Add(8);
			return;
		}

		temp = fullCube [0, 1, 1];
		if (temp.GetLeftColor ().Equals (Color.white))
		{
			ActionsList.Add(14);
			return;
		}

		temp = fullCube [2, 1, 1];
		if (temp.GetRightColor ().Equals (Color.white))
		{
			ActionsList.Add(15);
			return;
		}
	}

	private void SolveTopCross()
	{
		//second rotate the rest of the cross sides
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	private void SolveTopCorners()
	{
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	private void SpinMiddle()
	{
		//TODO: SPIN MIDDLE COLORS TO MATCHING FACE
	}
	
	private void SolveMiddleSides()
	{
		//TODO: SOLVE MIDDLE SIDES
	}
	
	private void SolveBottomCross()
	{
		//TODO: SOLVE YELLOW/BOTTOM CROSS
	}
	
	private void SolveBottomCrossSides()
	{
		//TODO: SOLVE BOTTOM CROSS SIDES
	}
	
	private void SolveBottomCorners()
	{
		//TODO: PLACE CORNERS IN RIGHT SPOT
	}
	
	private void FinishBottomCorners()
	{
		//TODO: SPIN CORNERS TO RIGHT DIRECTION
	}
	
	private void SpinToWin()
	{
		//TODO: SPIN COLORS TO MATCH AND FINISH
	}
}
