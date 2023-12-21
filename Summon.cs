static void Summon(int mana)
    {
        Console.Error.WriteLine("summon");
        int manaRemaining = mana;
        while (canBePlayed.Count > 0)
        {
            Card card = canBePlayed[0];
            switch (card.cardType) {
                case 0:
                    // Case 0 represents creatures
                    Player.SummonCard(card);
                    myBoard.Add(card);
                    if (card.abilities.Contains('C'))
                    {
                        attackers.Add(card);  
                    }
                    Console.Error.WriteLine($"Abilities: {card.abilities}");
                    manaRemaining -= card.cost;
                    break;
                case 1:
                    // Case 1 represents green items
                    if (myBoard.Count > 0) {
                        Player.UseItem(card, myBoard[0]);
                        manaRemaining -= card.cost;   
                    }
                    break;
                case 2:
                    // Case 2 represents red items
                    if (hisBoard.Count > 0) {
                        Player.UseItem(card, hisBoard[0]);
                        manaRemaining -= card.cost;
                    }
                    break;
                case 3:
                    // Case 3 represents blue items
                    Player.UseItem(card, null);
                    manaRemaining -= card.cost;
                    break;
            }
            canBePlayed.Remove(card);
            canBePlayed.RemoveAll(card => card.cost > manaRemaining);
        }
    }
