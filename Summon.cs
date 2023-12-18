static void Summon(List<Card> hand, List<Card> myBoard, List<Card> hisBoard, int mana)
    {
        Console.Error.WriteLine("summon");
        for(int i=0; i<hand.Count;i++)
        {
            if(hand[i].cost<mana)
            {
                Player.SummonCard(hand[i]);
                mana=0;
            }
        }
    }
