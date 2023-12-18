static void Fight(List<Card> hand, List<Card> myBoard, List<Card> hisBoard)
    {
        Console.Error.WriteLine("fight");
        Card guard = null;
        for(int i=0;i<myBoard.Count;i++){
            for(int j=0;j<hisBoard.Count;j++){
                Console.Error.WriteLine(j);
                if(hisBoard[j].abilities.Contains("G"))
                {
                    guard = hisBoard[j];
                }
            }
            Player.AttackCard(myBoard[i], guard);
        }
    }
