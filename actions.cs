static string actions = "";
    static void PickCard(int pick) {
        Console.Error.WriteLine("pick");
        Player.actions += $"PICK {pick}";
    }

    static void SummonCard(Card card) {
        Console.Error.WriteLine("summonCard");
        Player.actions += $"SUMMON {card.instanceId};";
    }

    static void AttackCard(Card attacker, Card target) {
        Console.Error.WriteLine("attack");
        if (target == null) { // A null target represents the opponent
            Player.actions += $"ATTACK {attacker.instanceId} -1;";
        } else {
            Player.actions += $"ATTACK {attacker.instanceId} {target.instanceId};";
        }
    }