namespace CFR
{
    internal class Commands
    {
        public enum CommandsLists
        {

        }
        public string[] ReadCommand(string comm)
        {
            comm = comm.ToLower();
            string[] Command = comm.Split(' ');
            return Command;
        }

        public void CommandComplit(string[] comm, CommandsLists CLists)
        {
            MainMenu mainMenu = new MainMenu();
            switch (CLists)
            {
                //    case :

                //        break;
            }
        }
    }
}
