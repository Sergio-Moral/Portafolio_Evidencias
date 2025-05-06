using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMakr : MonoBehaviour
{
    public GameObject block; 

    public GameObject ink;

    public GameObject trace;
    
    GameObject draw;

    GameObject player;

    int[,] logicGrid;

    int sublevelId = 1;

    int subSectionId = 1;

    GameObject[] traces;

    bool completed = false;

    int posX = 9;

    int posY = 9;


    // Start is called before the first frame update

    public void restart(){

        foreach(GameObject draw in traces){
            Destroy(draw);
        }
        
        for (int i = 0; i < 20; i++){
            for (int j = 0; j < 20; j++){
                logicGrid[i,j] = -1;
            }
        }

        player.transform.position = new Vector3(0,0,0);
    }

    public  void evaluate(){
if(sublevelId == 1){ //Formás básicas
            if(subSectionId == 1){ //Cuadrao

                int side = 5;

                for (int j = 0; j < 20; j++){
                    for (int i = 0; i < 20; i++){

                        Debug.Log(i + " " + j);
                        Debug.Log(logicGrid[i,j]);
                        if (logicGrid[i,j] == 1){
                            if (logicGrid[i + 1, j] == 1 && logicGrid[i +2,j] == 1 && logicGrid[i + 3,j] == 1 && logicGrid[i +4, j] == 1 &&
                            logicGrid[i, j+1] == 1 && logicGrid[i, j +2] == 1 && logicGrid[i, j + 3] == 1 && logicGrid[i, j + 4] == 1 &&
                            logicGrid[i + 4, j+1] == 1 && logicGrid[i +4, j+2] == 1 && logicGrid[i+4, j+3] == 1 && logicGrid[i+4,j+4] == 1 &&
                            logicGrid[i+1,j+4] == 1 && logicGrid[i+2,j+4] == 1 && logicGrid[i+3,j+4] == 1 && logicGrid[i+4,j+4] == 1 &&
                            logicGrid[i+5,j] != 1 && logicGrid[i,j+5] != 1){
                                completed = true;
                            }
                        }
                    }
                }

                if( completed == true){
                    subSectionId = subSectionId + 1;
                    restart();
                }
            }

            if(subSectionId == 2){ //Triágulo equilátero
                completed = false;

                int side = 6;

                 for (int j = 0; j < 20; j++){
                    for (int i = 0; i < 20; i++){
                        if(logicGrid[i,j] == 1){
                            if(logicGrid[i,j+1] == 1 && logicGrid[i,j+2] == 1 && logicGrid[i,j+3] == 1 && logicGrid[i,j+4] == 1 && logicGrid[i,j+5] == 1 &&
                            logicGrid[i,j+6] != 1 &&
                            logicGrid[i+1,j+5] == 1 && logicGrid[i+2,j+5] == 1 && logicGrid[i+3,j+5] == 1 && logicGrid[i+4,j+5] == 1 && logicGrid[i+5,j+5] == 1 &&
                            logicGrid[i+6,j+5] != 1 &&
                            logicGrid[i+1,j+1] == 1 && logicGrid[i+2,j+2] == 1 && logicGrid[i+3,j+3] == 1 && logicGrid[i+4,j+4] == 1 && logicGrid[i+5,j+5] == 1 &&
                            logicGrid[i+6,j+6] != 1){
                                completed = true;
                            }
                        }
                    }
                }

                if( completed == true){
                    subSectionId = subSectionId + 1;
                    restart();
                }
            }

            if(subSectionId == 3){ //Rectángulo
                completed = false;

                int side1 = 7;
                int side2 = 4;

                 for (int j = 0; j < 20; j++){
                    for (int i = 0; i < 20; i++){
                        if(logicGrid[i,j] == 1){
                            if(logicGrid[i+1,j] == 1 && logicGrid[i+2,j] == 1 && logicGrid[i+3,j] == 1 && logicGrid[i+4,j] == 1 && logicGrid[i+5,j] == 1 && logicGrid[i+6,j] == 1 &&
                            logicGrid[i+7,j] != 1 &&
                            logicGrid[i,j+1] == 1 && logicGrid[i,j+2] == 1 && logicGrid[i,j+3] == 1 &&
                            logicGrid[i,j+4] != 1 &&
                            logicGrid[i+1,j+3] == 1 && logicGrid[i+2,j+3] == 1 && logicGrid[i+3,j+3] == 1 && logicGrid[i+4,j+3] == 1 && logicGrid[i+5,j+3] == 1 && logicGrid[i+6,j+3] == 1 &&
                            logicGrid[i+7,j+3] != 1 &&
                            logicGrid[i+6,j+1] == 1 && logicGrid[i+6,j+2] == 1 && logicGrid[i+6,j+3] == 1 &&
                            logicGrid[i+6,j+4] != 1 ||
                            logicGrid[i+1,j] == 1 && logicGrid[i+2,j] == 1 && logicGrid[i+1,j] == 1 &&
                            logicGrid[i+4,j] != 1 &&
                            logicGrid[i,j+1] == 1 && logicGrid[i,j+2] == 1 && logicGrid[i,j+3] == 1 && logicGrid[i,j+4] == 1 && logicGrid[i,j+5] == 1 && logicGrid[i,j+6] == 1 &&
                            logicGrid[i,j+7] != 1 &&
                            logicGrid[i+1,j+6] == 1 && logicGrid[i+2,j+6] == 1 && logicGrid[i+3,j+6] == 1 &&
                            logicGrid[i+4,j+6] != 1 &&
                            logicGrid[i+3,j+1] == 1 && logicGrid[i+3,j+2] == 1 && logicGrid[i+3,j+3] == 1 && logicGrid[i+3,j+4] == 1 && logicGrid[i+3,j+5] == 1 && logicGrid[i+3,j+6] == 1 &&
                            logicGrid[i+3,j+7] != 1){
                                completed = true;
                            }
                        }
                    }
                }

                if( completed == true){
                    sublevelId = sublevelId + 1;
                }
            }
        }

        if(sublevelId == 2){ //Polígonos
            subSectionId = 1;
            completed = false;

            if(subSectionId == 1){ //Pentágono

                int side = 3;
                int apotem = 8;

                if( completed == true){
                    subSectionId = subSectionId + 1;
                }
            }

            if(subSectionId == 2){ //Hexágono
                completed = false;

                int side = 2;
                int apotem = 7;

                if( completed == true){
                    sublevelId = sublevelId + 1;
                }
            }
        }

        if(sublevelId == 3){ //Formas Avanzadas
            subSectionId = 1;
            completed = false;


            if(subSectionId == 1){ //Rombo

            int dMayor = 7;
            int dMenor = 5;

                if( completed == true){
                    subSectionId = subSectionId + 1;
                }
            }

            if(subSectionId == 2){ //Romboide
                completed = false;

                int side = 6;

                int h = 4;

                if( completed == true){
                    subSectionId = subSectionId + 1;
                }

            }

            if(subSectionId == 3){ //Trapecio
                completed = false;

                int sideA = 5;
                int sideB = 10;
                int h = 4;

                if( completed == true){
                    subSectionId = subSectionId + 1;
                }
            }

            if(subSectionId == 4){ //Círculo
                completed = false;

                int r = 0;

                if( completed == true){
                    sublevelId = sublevelId + 1;
                }
            }
        }

        if(sublevelId == 4){ //Victory
            
        }
    }

    void Start()
    {
        createGrid();
        player = Instantiate(ink);
        player.transform.position = new Vector3(0,0,0);
        CreateLevel();
    }

    public void CreateLevel(){
        Level l = new Level{};
        l.levelId = 3;
        l.score = 0;
        l.numTries = 1;
    }

    public void createGrid(){

        int xSize = 20;
        int ySize = 20;

        for(int x = 0; x <= xSize; x++){
            GameObject borderBottom = Instantiate(block); 
            borderBottom.transform.position = new Vector3(x-xSize/2, -ySize/2, 0);

            GameObject borderTop = Instantiate(block); 
            borderTop.transform.position = new Vector3(x-(xSize/2), ySize-(ySize/2), 0);
        }

        for(int y = 0; y <= ySize; y++){
            GameObject borderLeft = Instantiate(block);
            borderLeft.transform.position = new Vector3(-xSize/2, y-(ySize/2), 0); 

          GameObject borderRight = Instantiate(block) ;
            borderRight.transform.position = new Vector3(xSize-(xSize/2), y-(ySize/2), 0); 
        }

        logicGrid = Logic.GenerateGridConfig();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            draw = Instantiate(trace);
            draw.transform.position = player.transform.position;
            draw.tag = "pinga";
            traces = GameObject.FindGameObjectsWithTag("pinga");
            logicGrid[posX,posY] = 1;
        }
        
        if (player.transform.position.x <= 8){
            if(Input.GetKeyDown(KeyCode.D)){
                player.transform.position = player.transform.position + new Vector3 (+1,0,0);
                posX = posX + 1;
            }
        }

        if(player.transform.position.x >= -8){
            if(Input.GetKeyDown(KeyCode.A)){
                player.transform.position = player.transform.position + new Vector3 (-1,0,0);
                posX = posX - 1;
            }
        }

        if(player.transform.position.y <= 8){
            if(Input.GetKeyDown(KeyCode.W)){
                player.transform.position = player.transform.position + new Vector3 (0,+1,0);
                posY = posY - 1;
            }
        }

        if(player.transform.position.y >= -8){
            if(Input.GetKeyDown(KeyCode.S)){
                player.transform.position = player.transform.position + new Vector3 (0,-1,0);
                posY = posY + 1;
            }
        }

    }//aquí acaba update
}
