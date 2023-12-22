static void Fight()
{
    Console.Error.WriteLine("fight");
    List<Card> provocs = hisBoard.Where(card => card.abilities.Contains('G')).ToList();

    Card toxicityCard = myBoard.FirstOrDefault(card => card.abilities.Contains("L"));

    if (toxicityCard != null)
    {
        // Toxicity attack highest HP (at least 4 HP)
        Card maxHpEnemie = hisBoard.Where(card => card.defense >= 4)
            .OrderByDescending(card => card.defense)
            .FirstOrDefault();

        if (maxHpEnemie != null)
        {
            Player.AttackCard(toxicityCard, maxHpEnemie);
        }
        else
        {
            Player.AttackCard(toxicityCard, provocs.FirstOrDefault());
        }
    }
    else
    {
        foreach (Card guard in provocs)
        {
            List<Card> killers = attackers.Where(card => card.attack >= guard.defense
                || card.abilities.Contains('L')).ToList();
            Card attacker;
            if (killers.Count > 0)
            {
                
                attacker = killers.Aggregate(killers[0], (acc, cur) => cur.attack < acc.attack ? cur : acc);
            }
            else
            {
                attacker = myBoard[0];
            }
            Player.AttackCard(attacker, guard);
        }

        foreach (Card myCard in attackers.ToList())
        {
            if (myCard.attack > 0)
            {
                if (provocs.Count > 0)
                {
                    Card guard = hisBoard.FirstOrDefault(card => card.abilities.Contains("G") && card.defense > 0);
                    if (guard != null)
                    {
                        Player.AttackCard(myCard, guard);
                    }
                }
                else
                {
                    Card maxHpEnemie = hisBoard.Where(card => card.defense >= 4)
                        .OrderByDescending(card => card.defense)
                        .FirstOrDefault();
                    if (maxHpEnemie != null)
                    {
                        Player.AttackCard(myCard, maxHpEnemie);
                    }
                }
            }
        }
    }
}
