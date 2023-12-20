    class Player
{   
    static string actions = "";
    static List<Card> hand = new List<Card>();
    static List<Card> myBoard = new List<Card>();
    static List<Card> hisBoard = new List<Card>();
    static List<Card> attackers = new List<Card>();
    static int[] curve = new int[8];

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

    static void UseItem(Card item, Card target) {
        Console.Error.WriteLine("item");
        if (target == null) { // A null target represents an item with no target
            Player.actions += $"USE {item.instanceId} -1;";
        } else {
            Player.actions += $"USE {item.instanceId} {target.instanceId};";
            if (item.cardType == 1) {
                foreach (char ability in item.abilities)
                {
                    if (!target.abilities.Contains(ability))
                    {
                        Console.Error.WriteLine(target.abilities);
                        target.abilities += ability;
                        Console.Error.WriteLine(target.abilities);
                    }
                }
                target.attack += item.attack;
                target.defense += item.defense;
            } else
            {
                foreach (char ability in item.abilities)
                {
                    Console.Error.WriteLine(target.abilities);
                    target.abilities = target.abilities.Replace(ability, '-');
                    Console.Error.WriteLine(target.abilities);
                }
                if (item.defense < 0) // This means the item inflicts damage
                {
                    // If the targeted creature has Ward, it takes no damage but loses Ward
                    if (target.abilities.Contains('W'))
                    {
                        target.abilities.Replace('W', '-');
                    } else {
                        target.defense += item.defense;
                    }
                    target.attack += item.attack;
                }
            }
        }
    }