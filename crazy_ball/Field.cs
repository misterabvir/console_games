using System.Text;
namespace crazy_ball;

public class Field
{
    const int H_SIZE = 21;
    const int V_SIZE = 41;
    private Cell[,] _cells = new Cell[V_SIZE, H_SIZE];
    private Random _rand = new Random();
    private Ball _ball = new Ball(0,0,0,0);
    public Field()
    {
        CreateField();
        AddBall();
    }

    private void CreateField()
    {
        for (int y = 0; y < H_SIZE; y++)
        {
            for (int x = 0; x < V_SIZE; x++)
            {
                _cells[x, y] = new Cell();
                if(x == 0 || y == 0 || x == V_SIZE - 1 || y == H_SIZE - 1)
                    _cells[x, y].Value = CellValue.Border;
            }
        }
    }

    private void AddBall()
    {        
        _ball = new Ball(1, V_SIZE-2, 1, H_SIZE-2);
        _cells[_ball.X, _ball.Y].Value = CellValue.Ball;
    }

    public void Update()
    {
        _cells[_ball.X, _ball.Y].Value = CellValue.Empty;
        _ball.Move();
        _cells[_ball.X, _ball.Y].Value = CellValue.Ball;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int y = 0; y < H_SIZE; y++)
        {
            for (int x = 0; x < V_SIZE; x++)
            {
                builder.AppendFormat(_cells[x, y].ToString());
            }
            builder.Append('\n');
        }                
        return builder.ToString();
    }
}