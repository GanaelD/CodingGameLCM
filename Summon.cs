static void Summon(int mana)
    {
        int manaTemp = mana;
        Console.Error.WriteLine(manaTemp);
        Console.Error.WriteLine("summon");
        foreach (Card card in hand)
        {
            if (card.cost <= manaTemp)
            {
                switch (card.cardType) {
                    case 0:
                        // Case 0 represents creatures
                        Player.SummonCard(card);
                        myBoard.Add(card);
                        manaTemp -= card.cost;
                        break;
                    case 1:
                        // Case 1 represents green items
                        if (myBoard.Count > 0) {
                            Player.UseItem(card, myBoard[0]);
                            manaTemp -= card.cost;
                        }
                        break;
                    case 2:
                        // Case 2 represents red items
                        if (hisBoard.Count > 0) {
                            Player.UseItem(card, hisBoard[0]);
                            manaTemp -= card.cost;
                        }
                        break;
                    case 3:
                        // Case 3 represents blue items
                        Player.UseItem(card, null);
                        manaTemp -= card.cost;
                        break;
                }
            }
        }
    }
