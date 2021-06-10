using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

	public GameObject[] dest;
	public GameObject[] temp;

	private slot sloot;

	public Vector2 gridSize = new Vector2 (5, 6);

	Vector2 gridOffset;
	Vector3 lastGridSize;
	Vector3 lastPosition;

	public List<Vector4> occupiedPositions;

	public int gs = 4;
	public int lang = 1;
	public int cont = 0;
	private int blk = 0;

	public GameObject win;
	public GameObject halfwin;
	public GameObject menuSureBtn;
	public GameObject btn1;
	public GameObject btn2;
	public GameObject btn3;

	public GameObject txet;
	public GameObject txet2;
	public GameObject txetcont;
	private TextMeshProUGUI txt;
	private TextMeshProUGUI txt2;
	private TextMeshProUGUI txtcon;


	void Awake ()
	{
		sloot = GameObject.FindObjectOfType<slot>();
		UpdateScale ();
	}	

	void Start ()
    {
		txt = txet.GetComponent<TextMeshProUGUI>();
		txt2 = txet2.GetComponent<TextMeshProUGUI>();
		txtcon = txetcont.GetComponent<TextMeshProUGUI>();
		temp = new GameObject[2];
	}

	void Update ()
	{
		dest = GameObject.FindGameObjectsWithTag("Destroyable");

		if (transform.hasChanged)
		{
			transform.hasChanged = false;
			occupiedPositions.Clear ();
			GetComponent<Renderer> ().material.mainTextureScale = gridSize * gs;
			FixPositions ();		
		}

		if ((gridSize.x != lastGridSize.x) || (gridSize.y != lastGridSize.y))
		{
			lastGridSize = gridSize;
			UpdateScale ();
		}

		if (GameObject.FindGameObjectsWithTag("col").Length == 0)
		{
			foreach (var i in dest)
				Destroy(i);

			if (lang == 1)
			{
				if (sloot.p1 > sloot.p2) { txt.SetText("Player 1 WIN"); } else if (sloot.p1 < sloot.p2) { txt.SetText("Player 2 WIN"); } else if (sloot.p1 == sloot.p2) { txt.SetText("TIE WIN"); }
			} else if (lang == 2)
				{
					if (sloot.p1 > sloot.p2) { txt.SetText("1. Oyuncu KAZANDI"); } else if (sloot.p1 < sloot.p2) { txt.SetText("2. Oyuncu KAZANDI"); } else if (sloot.p1 == sloot.p2) { txt.SetText("DOSTLUK KAZANDI"); }
				}

			win	.SetActive(true);
			btn1.SetActive(false);
			btn2.SetActive(false);
			btn3.SetActive(false);
			gameObject.SetActive(false);
		}
	}

	public void halfend()
	{
		if (sloot.ts == 1)
		{
			if (sloot.p1 > 8)
			{
				if (lang == 1) { txt2.SetText("Player 1 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("1. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
			else if (sloot.p2 > 8)
			{
				if (lang == 1) { txt2.SetText("Player 2 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("2. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
		}
		if (sloot.ts == 2)
		{
			if (sloot.p1 > 32)
			{
				if (lang == 1) { txt2.SetText("Player 1 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("1. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
			else if (sloot.p2 > 32)
			{
				if (lang == 1) { txt2.SetText("Player 2 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("2. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
		}
		if (sloot.ts == 3)
		{
			if (sloot.p1 > 60)
			{
				if (lang == 1) { txt2.SetText("Player 1 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("1. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
			else if (sloot.p2 > 60)
			{
				if (lang == 1) { txt2.SetText("Player 2 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("2. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
		}
		if (sloot.ts == 4)
		{
			if (sloot.p1 > 240)
			{
				if (lang == 1) { txt2.SetText("Player 1 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("1. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
			else if (sloot.p2 > 240)
			{
				if (lang == 1) { txt2.SetText("Player 2 WIN - Do you want to continue?"); txtcon.SetText("Continue"); } else if (lang == 2) { txt2.SetText("2. Oyuncu KAZANDI - Devam etmek istiyor musun?"); txtcon.SetText("Devam Et"); }
				halfwin.SetActive(true);
				btn1.SetActive(false);
				btn2.SetActive(false);
				btn3.SetActive(false);
				gameObject.SetActive(false);

				foreach (GameObject i in dest)
					i.SetActive(false);
			}
		}
	}

	public void con()
	{
		Animator anim = menuSureBtn.GetComponent<Animator>();
		anim.Play("MenuAnimRev", 0, 0);
		this.gameObject.SetActive(true);
		btn3.SetActive(true);
		foreach (GameObject i in dest)
			i.SetActive(true);

		foreach (GameObject i in temp)
		{
			if (i)
			{
				i.SetActive(true);
				btn2.SetActive(true);
				blk = 1;
			}
			else if (blk == 0)
			{
				btn1.SetActive(true);
			}
		}
		StartCoroutine("activeFalse");
		cont = 1;
	}

	IEnumerator activeFalse()
	{
		yield return new WaitForSeconds(0.3f);
		menuSureBtn.SetActive(false);
		halfwin.SetActive(false);
		blk = 0;
	}
	void UpdateScale () {
		transform.localScale = new Vector3(gridSize.x, gridSize.y, 1);
		GetComponent<Renderer>().material.mainTextureScale = gridSize * gs;
	}

	void FixPositions () {
		var objs = FindObjectsOfType<DragAndDrop> ();
		var diff = transform.localPosition - lastPosition;
		foreach (DragAndDrop i in objs) {
				i.FixPosition (diff);
				i.UpdateAll ();
		}
		lastPosition = transform.localPosition;
	}

	public Vector2 GetGridOffset () {
		gridOffset.x = transform.localPosition.x;
		gridOffset.y = transform.localPosition.y;
		return gridOffset;
	}

	public void menuSure()
	{
		menuSureBtn.SetActive(false);
		btn1.SetActive(false);
		btn2.SetActive(false);
		btn3.SetActive(false);
		gameObject.SetActive(false);

		foreach (GameObject i in dest)
			i.SetActive(false);

		for (int x = 1; x < 7; x++)
        {
            for (int y = 1; y < 7; y++)
            {
				GameObject tempObj = GameObject.FindGameObjectWithTag("p" + x + y);
				if (tempObj)
                {
					if (x != y)
					{
						temp[0] = GameObject.FindGameObjectWithTag("p" + x + y);
						temp[0].SetActive(false);
						temp[1] = GameObject.FindGameObjectWithTag("p" + y + x);
						temp[1].SetActive(false);
						return;
					} else
                    {
						temp[0] = GameObject.FindGameObjectWithTag("p" + x + y);
						temp[0].SetActive(false);
						temp[1] = null;
						return;
					}
				}
			}
        }
	}
}
