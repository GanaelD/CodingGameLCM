static void Fight(List<Card> hand, List<Card> myBoard, List<Card> hisBoard)
    {
        Console.Error.WriteLine("fight");
        foreach (Card myCard in myBoard)
        {
            Card guard = hisBoard.FirstOrDefault(card => card.abilities.Contains("G") && card.defense > 0);
            if (myCard.attack > 0)
            {
                Player.AttackCard(myCard, guard);
                if (guard != null)
                {
                    guard.defense -= myCard.attack;
                }
            }  
        }
    }
