using UnityEngine;
using System.Collections;

public class ActionQueueModel : MonoBehaviour
{
	private ArrayList _ActionQueue;
	private ArrayList _HistoryQueue;

	public void AddToQueue(int method)
	{
		this._ActionQueue.Add(method);
		this._HistoryQueue.Add(method);
	}

	public int GetNextMethod()
	{
		return (int)this._ActionQueue.IndexOf (0);
		this._ActionQueue.Remove (0);
	}

	public ArrayList getHistoryQueue()
	{
		return this._HistoryQueue;
	}
}
