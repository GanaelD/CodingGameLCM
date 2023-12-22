static int ScoreAttack(Card attacker, Card attacked)  //rajouter score si la créature adverse a bcp d'attaque
    {
        int score = 0;
        if(attacker.attack > attacked.defense && !attacked.abilities.Contains('W'))
        {
            score += 10 + Math.Abs(attacked.attack - attacker.defense);
            if(attacker.abilities.Contains('B'))
            {
                score += attacker.attack-attacked.defense;
            }else {
                score += 5-(attacker.attack-attacked.defense);
            }

        }else if(attacker.abilities.Contains('L') && !attacked.abilities.Contains('W'))
        {
            score += 10 + Math.Abs(attacked.attack - attacker.defense)*2;
        }else if(attacker.attack < attacked.defense || attacked.abilities.Contains('W'))
        {
            score += attacker.defense - attacked.attack;
        }
        return score;
    }

static void Fight()
    {
        Console.Error.WriteLine("fight");
        List<Card> provocs = hisBoard.Where(card => card.abilities.Contains('G')).ToList();
        int maxScore = 0;
        Card bestAttacker = attackers[0];
        Card defender;
        while(provocs.Count > 0 && attackers.Count > 0)
        {
            defender = provocs[0];
            maxScore =0;
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
            Console.Error.WriteLine(attackers.Any(attack => attack.instanceId==bestAttacker.instanceId));
            Console.Error.WriteLine(attackers.Count);
            foreach (Card attacker in attackers){
                Console.Error.WriteLine(attacker.instanceId);
            }
            
            provocs = hisBoard.Where(card => card.abilities.Contains('G')&&card.defense>0).ToList();
        }

        if(attackers.Sum(attacker => attacker.attack) >= 30)     //changer pour mettre les points de vie de l'adversaire
        {
            foreach(Card attacker in attackers)
            {
                AttackCard(attacker, null);
            }
        }

        bestAttacker = null;
        defender = null;
        maxScore = 0;
        while (attackers.Count > 0 && hisBoard.Count > 0)
        {
            bestAttacker = attackers[0];
            defender = hisBoard[0];
            maxScore = 0;
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
            if(maxScore>15)     //score palier à determiner
            {
                AttackCard(bestAttacker,defender);
            }else
            {
                AttackCard(bestAttacker,null); 
            }
            
        }
        if(attackers.Count > 0)
        {
            foreach(Card attacker in attackers.ToList())
            {
                AttackCard(attacker, null);
            }
        }
    }