using UnityEngine;
public class CameraController : MonoBehaviour
{
    /* 
     * script napisany przez Zachariasza
     * kontrola kamery jest napisana w ten sposób, aby można było ją dostosować z poziomu menu unity.
     * Do zmiennych camera(x albo y)(min albo max) wpisujemy odpowiednie wartości które odpowiadają położeniu kamery.
     * np. zmienna cameraYMax oznacza max położenie względem prostej Y naszej kamery w unity.
     * panSpeed jest to zmienna która manipuluje prędkością poruszania kamery.
     * panBorderFickness jest to wartość jednostek od odpowiedniej krawędzi, na której gdy znajdzie się kursor myszki kamera poruszy się w stronę krawędzi.
    */
    public float panSpeed = 20f;
    public float panBorderFickness = 10f;
    public float cameraYMax;
    public float cameraYMin;
    public float cameraXMax;
    public float cameraXMin;


    // Update is called once per frame
    void Update()
    {
        // Manipulowanie kamerą jest w funkcji Update, ponieważ można zmieniać położenie kamery co klatkę.
        // Kamera może być kontrolowana za pomocą myszki bądź klawiatury.
        Vector3 pos = transform.position;

        // Przy naciśnięciu W albo położeniu myszki o ilość jednostek wpisanych do zmiennej panBorderFickness mniej niż górna krawędź myszki kamera ruszy w górę,
        // kamera analogicznie będzię się zachowywać co każdą instrukcję warunkową napisaną poniżej.
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderFickness)
            pos.y += panSpeed * Time.deltaTime;
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderFickness)
            pos.y -= panSpeed * Time.deltaTime;
        
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.height - panBorderFickness)
            pos.x += panSpeed * Time.deltaTime;
        
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderFickness)
            pos.x -= panSpeed * Time.deltaTime;
       
        // w kodzie poniżej nakładam "blokady" do sterowania kamerą, tzn  ograniczam poruszanie się kamery do konkretnych wartości.
        // Dzięki temu kamera nie będzie poruszać się po obszarze, na którym nie ma mapy.
        pos.x = Mathf.Clamp(pos.x, cameraXMin, cameraXMax);
        pos.y = Mathf.Clamp(pos.y, cameraYMin, cameraYMax);
        transform.position = pos;

    }
}