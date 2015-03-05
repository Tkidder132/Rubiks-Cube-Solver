using UnityEngine;
using System.Collections;

public class ActionQueueController : MonoBehaviour
{
	ActionQueueModel queueModel;

	public void AddToQueue(int method)
	{
		queueModel.AddToQueue (method);
	}
	
	public int GetNextMethod()
	{
		return queueModel.GetNextMethod ();
	}
	
	public ArrayList getHistoryQueue()
	{
		return queueModel.getHistoryQueue ();
	}
}
