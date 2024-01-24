namespace CFR
{
    internal class Commands
    {
        static string Command = "";
        static string seterr = "";

        static List<comm> CommandsList = new List<comm>();

        public static void AddToList(string command, string id)
        {
            CommandsList.Add(new comm(command, id));
        }

        internal class comm
        {
            public string Command; 
            public  string Id;

            public comm(string command , string id) 
            {
                Command = command;
                Id = id;
            }
        }

        static public string ReadCommand(string comm)
        {
            comm = comm.Trim();
            string[] strings = comm.Split(' ');
            if (strings.Length > 1) 
            {
                seterr = "";
                for (int x = 1; x < strings.Length; x++)
                {
                    seterr += strings[x];
                }
            }
            if (strings[0] == "")
            {
                return "";
            }
            for (int x = 0; x < CommandsList.Count; x++)
            {
                if (CommandsList[x].Command == strings[0])
                {
                    return CommandsList[x].Id;
                }
            }
            return "wrong";
        }
        static public string GetSeterr() 
        {
            return seterr;
        }
    }
}
