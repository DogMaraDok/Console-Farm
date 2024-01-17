namespace CFR
{
    internal class Messeg
    {
        static public int Row;
        static public int Col;

        static public void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(Col + x, Row + y);
            Console.Write(s);
        }
    }
}
