static void Summon(List<Card> hand, List<Card> myBoard, List<Card> hisBoard, int mana)
    {
        int manaTemp = mana;
        Console.Error.WriteLine("summon");
        for(int i=0; i<hand.Count;i++)
        {
            if(hand[i].cost<manaTemp)
            {
                switch (hand[i].cardType) {
                    case 0:
                        Player.SummonCard(hand[i]);
                        manaTemp -= hand[i].cost;
                        break;
                    case 1:
                        if (myBoard.Count > 0) {
                            Player.UseItem(hand[i], myBoard[0]);
                            manaTemp -= hand[i].cost;
                        }
                        break;
                    case 2:
                        if (hisBoard.Count > 0) {
                            Player.UseItem(hand[i], hisBoard[0]);
                            manaTemp -= hand[i].cost;
                        }
                        break;
                    case 3:
                        Player.UseItem(hand[i], null);
                        manaTemp -= hand[i].cost;
                        break;
                }
            }
        }
    }
