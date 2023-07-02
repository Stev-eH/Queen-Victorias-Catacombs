using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilePuzzle : MonoBehaviour
{
    public Tilemap puzzle;
    public Tile unpressed;
    public Tile pressed;
    public Tile reset;
    private TileFlags notNew;

    private int solvedTiles;
    private int currentlySolved;

    public bool invalid;
    public bool newUpdate;

    private AudioSource click;


    private TileBase current;

    public Vector3Int oldData;

    // Start is called before the first frame update
    void Start()
    {
        puzzle= GetComponent<Tilemap>();
        invalid = false;
        newUpdate= false;
        currentlySolved=0;
        solvedTiles = 73;
        click= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentlySolved >= solvedTiles)
        {
            GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().solveRoom(3);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!invalid)
        {
            if (puzzle.GetTile(puzzle.WorldToCell(collision.transform.position)) == unpressed)
            {
                if(current != null)
                {
                    puzzle.SetTileFlags(oldData, notNew);

                }
                current = puzzle.GetTile(puzzle.WorldToCell(collision.transform.position));
                oldData = puzzle.WorldToCell(collision.transform.position);
                puzzle.SetTile(puzzle.WorldToCell(collision.transform.position), pressed);
                currentlySolved++;
                click.Play();
            }
        }

        if (puzzle.GetTile(puzzle.WorldToCell(collision.transform.position)) == pressed && puzzle.GetTileFlags (puzzle.WorldToCell(collision.transform.position)) == notNew)
        {
            invalid = true;
        }

        if (puzzle.GetTile(puzzle.WorldToCell(collision.transform.position)) == reset)
        {
            puzzle.SwapTile(pressed, unpressed);
            foreach(Vector3Int position in puzzle.cellBounds.allPositionsWithin)
            {
                puzzle.RemoveTileFlags(position, notNew);
            }
            invalid = false;
            currentlySolved= 0;
        }


    }
}
