using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
    {
        public CellManager cellManager;
        public bool alive;

        SpriteRenderer spRend;
        private void Awake()
        {
            spRend = GetComponent<SpriteRenderer>();
        }

        private void OnMouseDown()
        {
            alive = true;
            for (int i = 0; i < 2; i++)
            {
                if (cellManager.cells.TryGetValue(MatePosition(i), out GameObject _cell))
                {
                    _cell.GetComponent<Cell>().alive = true;
                }
            }
        }
        private void Update()
        {
            if (!alive)
            {
                spRend.color = Color.white;
            }
            else
            {
                spRend.color = Color.black;
            }
            if (alive && GetAliveMates() < 2)
            {
                alive = false;
            }
            else if (alive && GetAliveMates() <= 3)
            {
                alive = true;
            }
            else if (alive && GetAliveMates() > 3)
            {
                alive = false;
            }


            if (!alive && GetAliveMates() == 3)
            {
                alive = true;
            }


        }

        GameObject cell;
        public int GetAliveMates()
        {
            int count = 0;
            for (int i = 0; 1 < 8; i++)
            {
                if (cellManager.cells.TryGetValue(MatePosition(i), out cell))
                {
                    if (cell.GetComponent<Cell>().alive)
                    {
                        count += 1;
                    }

                }
            }
        }

        Vector3 MatePosition(int i)
        {
            if (i == 0)
            {

                return transform.position = new Vector3(1, 0, 0);
            }
            else if (i == 1)
            {
                return transform.position = new Vector3(1, -1, 0);
            }
            else if (i == 2)
            {
                return transform.position = new Vector3(0, -1, 0);
            }
            else if (i == 3)
            {
                return transform.position = new Vector3(-1, -1, 0);
            }
            else if (i == 4)
            {
                return transform.position = new Vector3(-1, 0, 0);
            }
            else if (i == 5)
            {
                return transform.position = new Vector3(-1, 1, 0);
            }
            else if (i == 6)
            {
                return transform.position = new Vector3(0, 1, 0);
            }
            else if (i == 7)
            {
                return transform.position = new Vector3(1, 1, 0);
            }
            else
            {
                return Vector3.zero;
            }
        }
    }
