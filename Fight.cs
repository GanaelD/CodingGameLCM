static void ScoreAttack(Card attacker, Card Attacked)
    {
        return 10;
    }

static void Fight()
    {
        Console.Error.WriteLine("fight");
        List<Card> provocs = hisBoard.Where(card => card.abilities.Contains('G')).ToList();
        int maxScore = 0;
        Card bestAttacker = new Card();
        Card defender = new Card();
        while(provocs.Count > 0 && attackers.Count > 0)
        {
            foreach (Card guard in provocs)
            {
                foreach (Card attacker in attackers){
                    if (ScoreAttack(attacker,guard)>maxScore)
                    {
                        maxScore=ScoreAttack(attacker,guard);
                        bestAttacker = attacker;
                        defender = guard;
                    }
                }
            }
            AttackCard(bestAttacker,defender);
            provocs = hisBoard.Where(card => card.abilities.Contains('G')&&card.defense>0).ToList();
        }

        if(attackers.Sum(attacker => attacker.attack) >= pdv du mec)     //changer pour mettre les points de vie de l'adversaire
        {
            foreach(Card attacker in attackers)
            {
                AttackCard(attacker, null);
            }
        }

        bestAttacker = new Card();
        defender = new Card();
        maxScore = 0;
        while (attackers.Count > 0 && hisBoard.Count > 0)
        {
            foreach (Card attacker in attackers)
            {
                foreach (Card defend in hisBoard){
                    if (ScoreAttack(attacker,defend)>maxScore)
                    {
                        maxScore=ScoreAttack(attacker,defend);
                        bestAttacker = attacker;
                        defender = defend;
                    }
                }
            }
            AttackCard(bestAttacker,defender);
        }
        if(attacker.Count > 0)
        {
            foreach(Card attacker in attackers)
            {
                AttackCard(attacker, null);
            }
        }
    }
