static void Fight()
    {
        Console.Error.WriteLine("fight");
        List<Card> provocs = hisBoard.Where(card => card.abilities.Contains('G')).ToList();
        foreach (Card guard in provocs)
        {
            List<Card> killers = attackers.Where(card => card.attack >= guard.defense
                || card.abilities.Contains('L')).ToList();
            Card attacker;
            if (killers.Count > 0)
            {
                attacker = killers.Aggregate(killers[0], (acc, cur) => cur.attack < acc.attack ? cur : acc);
            } else {
                attacker = myBoard[0];
            }
            foreach (Card myCard in attackers)
            {
                if (myCard.attack > guard.defense && myCard.attack < attacker.attack) 
                {
                    attacker = myCard;
                }
            }
        }

        foreach (Card myCard in myBoard)
        {
            Card guard = hisBoard.FirstOrDefault(card => card.abilities.Contains("G") && card.defense > 0);
            if (myCard.attack > 0)
            {
                Player.AttackCard(myCard, guard);
                if (guard != null)
                {
                    if (guard.abilities.Contains("W"))
                    {
                        // If the target has Ward, it takes no damage but loses Ward
                        guard.abilities.Replace('W', '-');

                    } else {
                        guard.defense = myCard.abilities.Contains('L')
                            ? 0
                            : guard.defense - myCard.attack;
                    }
                }

            }  
        }
    }
