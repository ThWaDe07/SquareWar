using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{
	private slot sloot;
	private Grid griid;

	public bool interactable = true;

	[Header("Restrictions")]
	public bool considerScale = true;
	public bool considerOtherObjects = true;

	[Space(5)]

	public Vector2 dragScale = new Vector2(0.5f, 0.5f);
	public Vector4 currentPosition = new Vector4(1, 1, -3, 1);

	Vector2 gridOffset = Vector2.zero;
	Vector2 gridSize = Vector2.one;
	Vector3 screenPoint;

	Vector4 lastPos;
	Vector3 lastParentPos;
	Vector3 lastObjPos;

	Vector4 targetPos;

	void Awake()
	{		
		sloot = GameObject.FindObjectOfType<slot>();
		griid = GameObject.FindObjectOfType<Grid>();

		if (sloot.ts == 1){dragScale = new Vector2(1f, 1f);} else
			if (sloot.ts == 2 || sloot.ts == 3) { dragScale = new Vector2(0.5f, 0.5f); } else
				if (sloot.ts == 4) { dragScale = new Vector2(0.25f, 0.25f); }

		var newPos = transform.localPosition;
		newPos.x = (transform.localScale.x / 2f) - 0.5f;
		newPos.y = -((transform.localScale.y / 2f) - 0.5f);

		transform.localPosition = newPos;

		UpdateGridData();
		UpdatePosition();

		lastParentPos = transform.parent.position;
		lastObjPos = transform.position;
		lastPos = currentPosition;

		AddPosition(lastPos);
	}

	void UpdateGridData()
	{
		gridSize = FindObjectOfType<Grid>().gridSize;
		gridOffset = FindObjectOfType<Grid>().GetGridOffset();
	}

	void OnMouseDown()
	{
		sloot.coll = 0;
		if (sloot.doneTurn == 0)
		{
			if (interactable == true)
			{
				RemovePosition(lastPos);

				UpdateGridData();

				if (sloot.ts == 1) { transform.localScale *= 4; } else if (sloot.ts == 2 || sloot.ts == 3) { transform.localScale *= 2; }

				var newPos = transform.localPosition;
				newPos.x = (transform.localScale.x / 2f) - 0.5f;
				newPos.y = -((transform.localScale.y / 2f) - 0.5f);
				newPos.z = 1;

				transform.localPosition = newPos;

				UpdatePosition();
			}
		}

	}

	void OnMouseDrag()
	{
		if (sloot.doneTurn == 0)
		{
			if (interactable == true)
			{
				screenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1))	;
				screenPoint.z = 1;
				if (gridSize.x % 2 == 0)
				{
					screenPoint.x -= 0f;				}
				if (gridSize.y % 2 == 0)
				{
					screenPoint.y += 1.5f;
				}
				transform.parent.position = SnapToGrid(screenPoint);
			}
		}
	}

	public void UpdateAll()
	{
		UpdatePosition();
		AddPosition(lastPos);
	}

	void OnMouseUp()  /* X-Z solüst ------ W-Y sağalt üzerinde olduğu kutunun kordinatı*/
	{
		UpdateGridData();
		if (sloot.ts == 1)
		{
			targetPos.x = (transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f);
			targetPos.y = ((transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f) + transform.localScale.x - 1f);

			targetPos.z = -(transform.parent.position.y - (gridSize.y * 0.5f) - 1.5f);
			targetPos.w = -((transform.parent.position.y - (gridSize.y * 0.5f) - 1f) - transform.localScale.y + 0.5f);
		}
		if (sloot.ts == 2)
		{
			targetPos.x = (transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 2f);
			targetPos.y = ((transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 1f) + transform.localScale.x * 2f);

			targetPos.z = -(transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 4f);
			targetPos.w = -((transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 3f) - transform.localScale.y * 2f);
		}
		if (sloot.ts == 3)
		{
			targetPos.x = (transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 2.5f);
			targetPos.y = ((transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 1.5f) + transform.localScale.x * 2f);

			targetPos.z = -(transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 5f);
			targetPos.w = -((transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 4f) - transform.localScale.y * 2f);
		}
		if (sloot.ts == 4)
		{
			targetPos.x = (transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f);
			targetPos.y = ((transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f) + transform.localScale.x - 0.25f);

			targetPos.z = -(transform.parent.position.y - (gridSize.y * 0.5f) - 2f);
			targetPos.w = -((transform.parent.position.y - (gridSize.y * 0.5f) - 2f) - transform.localScale.y + 0.25f);
		}

		if (interactable == true)
		{ 
			if (considerOtherObjects)
			{
				if (!IsOccupied())
				{
					if (transform.parent.tag == "p12") { Destroy(GameObject.FindGameObjectsWithTag("p21")[0]); } else if (transform.parent.tag == "p21") { Destroy(GameObject.FindGameObjectsWithTag("p12")[0]); }
					if (transform.parent.tag == "p13") { Destroy(GameObject.FindGameObjectsWithTag("p31")[0]); } else if (transform.parent.tag == "p31") { Destroy(GameObject.FindGameObjectsWithTag("p13")[0]); }
					if (transform.parent.tag == "p14") { Destroy(GameObject.FindGameObjectsWithTag("p41")[0]); } else if (transform.parent.tag == "p41") { Destroy(GameObject.FindGameObjectsWithTag("p14")[0]); }
					if (transform.parent.tag == "p15") { Destroy(GameObject.FindGameObjectsWithTag("p51")[0]); } else if (transform.parent.tag == "p51") { Destroy(GameObject.FindGameObjectsWithTag("p15")[0]); }
					if (transform.parent.tag == "p16") { Destroy(GameObject.FindGameObjectsWithTag("p61")[0]); } else if (transform.parent.tag == "p61") { Destroy(GameObject.FindGameObjectsWithTag("p16")[0]); }

					if (transform.parent.tag == "p23") { Destroy(GameObject.FindGameObjectsWithTag("p32")[0]); } else if (transform.parent.tag == "p32") { Destroy(GameObject.FindGameObjectsWithTag("p23")[0]); }
					if (transform.parent.tag == "p24") { Destroy(GameObject.FindGameObjectsWithTag("p42")[0]); } else if (transform.parent.tag == "p42") { Destroy(GameObject.FindGameObjectsWithTag("p24")[0]); }
					if (transform.parent.tag == "p25") { Destroy(GameObject.FindGameObjectsWithTag("p52")[0]); } else if (transform.parent.tag == "p52") { Destroy(GameObject.FindGameObjectsWithTag("p25")[0]); }
					if (transform.parent.tag == "p26") { Destroy(GameObject.FindGameObjectsWithTag("p62")[0]); } else if (transform.parent.tag == "p62") { Destroy(GameObject.FindGameObjectsWithTag("p26")[0]); }

					if (transform.parent.tag == "p34") { Destroy(GameObject.FindGameObjectsWithTag("p43")[0]); } else if (transform.parent.tag == "p43") { Destroy(GameObject.FindGameObjectsWithTag("p34")[0]); }
					if (transform.parent.tag == "p35") { Destroy(GameObject.FindGameObjectsWithTag("p53")[0]); } else if (transform.parent.tag == "p53") { Destroy(GameObject.FindGameObjectsWithTag("p35")[0]); }
					if (transform.parent.tag == "p36") { Destroy(GameObject.FindGameObjectsWithTag("p63")[0]); } else if (transform.parent.tag == "p63") { Destroy(GameObject.FindGameObjectsWithTag("p36")[0]); }

					if (transform.parent.tag == "p45") { Destroy(GameObject.FindGameObjectsWithTag("p54")[0]); } else if (transform.parent.tag == "p54") { Destroy(GameObject.FindGameObjectsWithTag("p45")[0]); }
					if (transform.parent.tag == "p46") { Destroy(GameObject.FindGameObjectsWithTag("p64")[0]); } else if (transform.parent.tag == "p64") { Destroy(GameObject.FindGameObjectsWithTag("p46")[0]); }

					if (transform.parent.tag == "p56") { Destroy(GameObject.FindGameObjectsWithTag("p65")[0]); } else if (transform.parent.tag == "p65") { Destroy(GameObject.FindGameObjectsWithTag("p56")[0]); }

					transform.position = transform.position + new Vector3(0, 0, 96);

					transform.parent.tag = "Destroyable";
					transform.tag = "ColTag";
					interactable = false;
					sloot.doneTurn = 1;
					sloot.Point();
					sloot.coll = 1;
					sloot.t1 = null;
					sloot.t2 = null;
					griid.temp[0] = null; griid.temp[1] = null;

					RemovePosition(lastPos);

					UpdatePosition();
					AddPosition(targetPos);

					if ( sloot.turn == 1 ) { sloot.turn = 2; } else if ( sloot.turn == 2 ) { sloot.turn = 1; }

					sloot.rollBtn.SetActive(true);

					if (griid.cont == 0) { griid.dest = GameObject.FindGameObjectsWithTag("Destroyable"); griid.halfend(); }
				}
				else
				{
					if (sloot.ts == 1) { transform.localScale /= 4; } else if (sloot.ts == 2 || sloot.ts == 3) { transform.localScale /= 2; }
					AddPosition(lastPos);
					transform.position = lastObjPos;
					soundmanager.PlaySound("wrongmove");
				}
			}
			else
			{
				if (sloot.ts == 1) { transform.localScale /= 4; } else if (sloot.ts == 2 || sloot.ts == 3) { transform.localScale /= 2; }
				UpdatePosition();
				AddPosition(targetPos);
				soundmanager.PlaySound("wrongmove");
			}
		}
	}

	void AddPosition(Vector4 pos)
	{
		var grid = FindObjectOfType<Grid>();
		if (!grid.occupiedPositions.Contains(pos))
		{
			grid.occupiedPositions.Add(pos);
		}
	}

	void RemovePosition(Vector4 pos)
	{
		var grid = FindObjectOfType<Grid>();
		if (grid.occupiedPositions.Contains(pos))
		{
			grid.occupiedPositions.Remove(pos);
		}
	}

	bool IsOccupied()
	{
		var occupied = FindObjectOfType<Grid>().occupiedPositions;
		foreach (Vector4 pos in occupied)
		{
			if (((targetPos.x >= pos.x && targetPos.x <= pos.y) || (targetPos.y >= pos.x && targetPos.y <= pos.y) || (pos.y >= targetPos.x && pos.y <= targetPos.y))
				&& ((targetPos.z >= pos.z && targetPos.z <= pos.w) || (targetPos.w >= pos.z && targetPos.w <= pos.w) || (pos.w >= targetPos.z && pos.w <= targetPos.w)))
			{

				transform.parent.position = lastParentPos;
				currentPosition = lastPos;
				return true;
			}
		}
		return false;
	}

	void UpdatePosition()
	{
		if (sloot.ts == 1)
		{
			currentPosition.x = (transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f);
			currentPosition.y = ((transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f) + transform.localScale.x - 1f);

			currentPosition.z = -(transform.parent.position.y - (gridSize.y * 0.5f) - 1.5f);
			currentPosition.w = -((transform.parent.position.y - (gridSize.y * 0.5f) - 1f) - transform.localScale.y + 0.5f);
		}
		if (sloot.ts == 2)
		{
			currentPosition.x = (transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 2f);
			currentPosition.y = ((transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 1f) + transform.localScale.x * 2f);

			currentPosition.z = -(transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 4f);
			currentPosition.w = -((transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 3f) - transform.localScale.y * 2f);
		}
		if (sloot.ts == 3)
		{
			currentPosition.x = (transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 2.5f);
			currentPosition.y = ((transform.parent.position.x * 2 + (gridSize.x * 0.5f) + 1.5f) + transform.localScale.x * 2f);

			currentPosition.z = -(transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 5f);
			currentPosition.w = -((transform.parent.position.y * 2 - (gridSize.y * 0.5f) - 4f) - transform.localScale.y * 2f);
		}
		if (sloot.ts == 4)
		{
			currentPosition.x = (transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f);
			currentPosition.y = ((transform.parent.position.x + (gridSize.x * 0.5f) + 0.5f) + transform.localScale.x - 0.25f);

			currentPosition.z = -(transform.parent.position.y - (gridSize.y * 0.5f) - 2f);
			currentPosition.w = -((transform.parent.position.y - (gridSize.y * 0.5f) - 2f) - transform.localScale.y + 0.25f);
		}

		lastParentPos = transform.parent.position;
		lastPos = currentPosition;
	}

	public void FixPosition(Vector3 newPos) {
		newPos.z = 0;
		transform.parent.position = transform.parent.position + newPos ;

		UpdateGridData();
		UpdatePosition();
	}

	Vector3 SnapToGrid(Vector3 dragPos)
	{
		if(sloot.ts == 1 || sloot.ts == 2 || sloot.ts == 3)
		{
			if (gridSize.x % 2 == 0) {
				dragPos.x = (Mathf.Round(dragPos.x / dragScale.x) * dragScale.x) + 0.5f;
			} else {
				dragPos.x = (Mathf.Round(dragPos.x / dragScale.x) * dragScale.x);
			}

			if (gridSize.y % 2 == 0) {
				dragPos.y = (Mathf.Round(dragPos.y / dragScale.y) * dragScale.y) + 0.5f;
			} else {
				dragPos.y = (Mathf.Round(dragPos.y / dragScale.y) * dragScale.y);
			}
		}

		if (sloot.ts == 4)
		{
			if (gridSize.x % 2 == 0) {
				dragPos.x = (Mathf.Round(dragPos.x / dragScale.x) * dragScale.x) + 0.5f;
			} else {
				dragPos.x = (Mathf.Round(dragPos.x / dragScale.x) * dragScale.x);
			} 
			
			if (gridSize.y % 2 == 0) {
				dragPos.y = (Mathf.Round(dragPos.y / dragScale.y) * dragScale.y);
			} else {
				dragPos.y = (Mathf.Round(dragPos.y / dragScale.y) * dragScale.y) + 0.5f;
			}
		}

		#region Restrictions

		// Restrict exit from grid
		var maxXPos = ((gridSize.x - 1) * 0.5f) + gridOffset.x;
		var maxYPos = ((gridSize.y - 1) * 0.5f) + gridOffset.y;

		// Considering GameObject Scale
		if (considerScale) {
			if (dragPos.x > maxXPos - transform.localScale.x + 1) {
				dragPos.x = maxXPos - transform.localScale.x + 1;
			}
			if (dragPos.x < -maxXPos + gridOffset.x + gridOffset.x)	{
				dragPos.x = -maxXPos + gridOffset.x + gridOffset.x;
			}
			if (dragPos.y > maxYPos) {
				dragPos.y = maxYPos;
			}
			if (dragPos.y < (-maxYPos + gridOffset.y + gridOffset.y) + transform.localScale.y - 1) {
				dragPos.y = -maxYPos + gridOffset.y + gridOffset.y + transform.localScale.y - 1;
			}
		} else
			{
				if (dragPos.x > maxXPos) {
					dragPos.x = maxXPos;
				}
				if (dragPos.x < -maxXPos + gridOffset.x + gridOffset.x) {
					dragPos.x = -maxXPos + gridOffset.x + gridOffset.x;
				}
				if (dragPos.y > maxYPos) {
					dragPos.y = maxYPos;
				}
				if (dragPos.y < -maxYPos + gridOffset.y + gridOffset.y)	{
					dragPos.y = -maxYPos + gridOffset.y + gridOffset.y;
				}
			}
		#endregion

		return dragPos;
	}
}