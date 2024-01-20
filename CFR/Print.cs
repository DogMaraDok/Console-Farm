namespace CFR
{
    internal class Print
    {
        static int Row;
        static int Col;

        static public void InitRowCol()
        {
            Row = Console.CursorTop;
            Col = Console.CursorLeft;
        }

        static public void PrintAt(string s, int x, int y)
        {
            Console.SetCursorPosition(Col + x, Row + y);
            Console.Write(s);
        }

    }
}
